
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TamTechBackendSDK.Common.Services.IdentityService.Settings;
using TamTechBackendSDK.IdentityService.Data;
using TamTechBackendSDK.IdentityService.Models;
using TamTechBackendSDK.IdentityService.Settings;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.IdentityService
{
    public class DataMigrationManager
    {

        public void SeedIdentityServerUsersAndRoles(SeedUsersAndRolesSettings dataSource, IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var usersContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                usersContext.Database.Migrate();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // create roles
                if (dataSource.Roles?.Count > 0)
                {
                    foreach (var role in dataSource.Roles)
                    {
                        if (!roleManager.Roles.Any(r => r.Name == role))
                            roleManager.CreateAsync(new IdentityRole(role)).Wait();
                    }
                }

                // create users
                if (dataSource.Users?.Count > 0)
                {
                    foreach (var u in dataSource.Users)
                    {
                        if (!userManager.Users.Any(user => user.UserName == u.Username))
                        {
                            var user = new ApplicationUser { Id = u.Id, UserName = u.Username, PhoneNumber = u.PhoneNumber, PhoneNumberConfirmed = false, Email = u.Email };
                            userManager.CreateAsync(user, u.Password).Wait();
                            userManager.AddToRolesAsync(user, u.Roles).Wait();
                        }
                    }
                }

                usersContext.SaveChanges();
            }
        }

        public void SeedIdentityServerSettings(SeedIdentityServerSettings dataSource, IApplicationBuilder app, string identityServerUrl)
        {



            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                context.Database.Migrate();

                foreach (var resource in dataSource.GetApiResources())
                {
                    if (!context.ApiResources.Any(r => r.Name == resource.Name))
                        context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();

                foreach (var resource in dataSource.GetIdentityResources())
                {
                    if (!context.IdentityResources.Any(r => r.Name == resource.Name))
                        context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();

                foreach (var client in dataSource.GetClients(identityServerUrl))
                {
                    if (!context.Clients.Any(c => c.ClientId == client.ClientId))
                        context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }
        }



    }
}

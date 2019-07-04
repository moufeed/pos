using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Galleries.Models;

namespace TamTechSDK.Common.Services.ContentService.Galleries
{
    public class GalleriesService : IGalleriesService
    {


        #region prop
        RequestProviderResult<List<GalleryDto>> Galleries = new RequestProviderResult<List<GalleryDto>>
        {
            Success = true,
            Data = new List<GalleryDto>
            {
                new GalleryDto
                {
                    Id = new Guid("7eae60e9-d423-4c71-925d-d50177d08fe0"),
                    Title = "Mobile Apps",
                    Slug ="mobile_apps",
                    MainImage ="http://via.placeholder.com/150x150",
                    Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                    CreatedDate = DateTime.Now,
                    DisplayOrder = 2
                },
                new GalleryDto
                {
                    Id = new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                    Title = "Mobile Apps",
                    Slug ="mobile_apps",
                    MainImage ="http://via.placeholder.com/150x150",
                    Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                    CreatedDate = DateTime.Now,
                    DisplayOrder = 2,
                    Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                             
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                          
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("dce1d3d3-585c-4aa2-8b97-6b2ac3648b04"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/1024/768/arch",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 30
                        },
                        new GalleryItemDto
                        {
                          
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                },
                new GalleryDto
                {
                     Id = new Guid("4d657f36-9ca3-4520-879c-64eea6947ad7"),
                     Title = "printing and typesetting industry. Lorem ",
                     Slug ="Lorem_Ipsum_is_simply_dummy",
                     MainImage ="https://placeimg.com/150/150/nature/sepia",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 3,
                     Published = true,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                             
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        }

                    }
                },
                new GalleryDto
                {
                     Id = new Guid("2688b521-760d-4e95-a879-89db1c009cc8"),
                     Title = "people",
                     Slug ="people",
                     MainImage ="https://placeimg.com/150/150/people",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 0,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                          
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                },
                new GalleryDto
                {
                     Id = new Guid("3fd2b6e4-8585-4fe2-b81d-b41e1da25d29"),
                     Title = "printing and typesetting industry.",
                     Slug ="printing_and_typesetting_industry",
                     MainImage ="https://placeimg.com/150/150/nature",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 0,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                          
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        }

                    }
                },
                new GalleryDto
                {
                     Id = new Guid("060d4aa6-525d-434c-83a8-8ca69e616ed8"),
                     Title = "SEO Optimization",
                     Slug ="seo_optimzation",
                     MainImage ="https://placeimg.com/150/150/arch",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 0,
                     Published = true,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("dce1d3d3-585c-4aa2-8b97-6b2ac3648b04"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/1024/768/arch",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 30
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                },
                new GalleryDto
                {
                     Id = new Guid("0e86a231-e27d-4943-839a-f77a9e2ce910"),
                     Title = "has been the industry",
                     Slug ="has_been_the_industry",
                     MainImage ="https://placeimg.com/150/150/tech",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 1,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("dce1d3d3-585c-4aa2-8b97-6b2ac3648b04"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/1024/768/arch",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 30
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                },
                new GalleryDto
                {
                    Id = new Guid("def12295-b782-48c4-b161-67bff03477d0"),
                     Title = "simply dummy text of the printing",
                     Slug ="simply_dummy_text_of_the_printing",
                     MainImage ="https://placeimg.com/150/150/any",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 1,
                     Published = true,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("dce1d3d3-585c-4aa2-8b97-6b2ac3648b04"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/1024/768/arch",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 30
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                },
                new GalleryDto
                {
                    Id = new Guid("b0303b83-055c-48f1-a496-e80ee9043c61"),
                     Title = "Lorem Ipsum is simply ",
                     Slug ="seo_optimzation",
                     MainImage ="https://placeimg.com/150/150/animals",
                     Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley ",
                     CreatedDate = DateTime.Now,
                     DisplayOrder = 1,
                       Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("dce1d3d3-585c-4aa2-8b97-6b2ac3648b04"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/1024/768/arch",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 30
                        },
                        new GalleryItemDto
                        {
                            
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                },
            }
        };
        #endregion


        #region puplic



        public Task<List<GalleryLiteDto>> GetPublicListAsync(int takeItems)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<GalleryDto>> GetPublicBySlugAsync(string slug, string lang)
        {
            return new RequestProviderResult<GalleryDto> {
                Success = true,
                Data = new GalleryDto()
                {
                    Id = new Guid("23541438-1eec-45b0-96b4-97d447f86d2e"),
                    Title = "Mobile Apps",
                    Slug = "mobile_apps",
                    MainImage = "http://via.placeholder.com/150x150",
                    Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                    CreatedDate = DateTime.Now,
                    DisplayOrder = 2,
                    Items = new List<GalleryItemDto>
                    {
                        new GalleryItemDto
                        {
                          
                            Id= new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                            Published = true,
                            Title = "Ultrices mi ",
                            Slug ="mobile_apps",
                            MainImage ="https://colorlib.com/polygon/gentelella/images/media.jpg",
                            Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                            CreatedDate = DateTime.Now,
                            DisplayOrder = 1,

                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("ee808694-5b27-442b-bcb6-71148204047e"),
                            Published = true,
                             Title = " varius vel pharetra",
                             Slug ="mobile_apps",
                             MainImage ="https://placeimg.com/2000/1000/nature",
                             Summary = "Blandit aliquam etiam erat velit scelerisque in dictum non. ",
                             CreatedDate = DateTime.Now,
                             DisplayOrder = 22
                        },
                        new GalleryItemDto
                        {
                          
                            Id= new Guid("a7bf2f5e-1fdf-42e2-9f1a-9ef65046734c"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/600/480/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 11
                        },
                        new GalleryItemDto
                        {
                         
                            Id= new Guid("dce1d3d3-585c-4aa2-8b97-6b2ac3648b04"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/1024/768/arch",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 30
                        },
                        new GalleryItemDto
                        {
                           
                            Id= new Guid("085b07b0-7f09-4757-9c66-a6d905d7bab4"),
                            Published = true,
                             Title = "Mobile Apps",
                                Slug ="mobile_apps",
                                MainImage ="https://placeimg.com/800/600/tech",
                                Summary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the",
                                CreatedDate = DateTime.Now,
                                DisplayOrder = 6
                        }
                    }
                }
            };
        }

        #endregion


        #region Gallery
        public async Task<IRequestProviderResult<Guid>> CreateAsync(CreateGalleryDto Gallery)
        {

            return new RequestProviderResult<Guid>
            {
                Success = true,
                Data = new Guid("7eae60e9-d423-4c71-925d-d50177d08fe0")
            };
        }

        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateGalleryDto Gallery)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<IRequestProviderResult<GalleryDto>> GetByIdAsync(Guid id, string lang)
        {
            var v = Galleries.Data.FirstOrDefault(a => a.Id == id);

            if (v == null)
                return new RequestProviderResult<GalleryDto>
                {
                    Success = false,
                    Data = v
                };
            return new RequestProviderResult<GalleryDto>
            {
                Success = true,
                Data = v
            };

        }

        public async Task<IRequestProviderResult<bool>> PublishAsync(PublishDTO data)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<IRequestProviderResult<bool>> DeleteAsync(Guid id)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        #endregion


        #region Gallery item
        public async Task<IRequestProviderResult<Guid>> CreateGalleryItemAsync(CreateGalleryItemDto Gallery)
        {
            return new RequestProviderResult<Guid>
            {
                Success = true,
                Data = new Guid()
            };
        }
        
        public async Task<IRequestProviderResult<bool>> EditGalleryItemAsync(UpdateGalleryItemDto Gallery)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<IRequestProviderResult<GalleryItemDto>> GetGalleryItemByIdAsync(GalleryItemKeysDto model , string lang)
        {
            return new RequestProviderResult<GalleryItemDto>
            {
                Success = true,
                Data = new GalleryItemDto
                {
                   
                    Id = new Guid("88fe4385-1105-46ac-8e3a-e3c8bfdf1b9d"),
                    Published = true,
                    Title = "Ultrices mi ",
                    Slug = "mobile_apps",
                    MainImage = "https://colorlib.com/polygon/gentelella/images/media.jpg",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nascetur ridiculus mus mauris vitae. Ut lectus arcu bibendum at varius vel. Neque convallis a cras semper auctor. Nulla posuere sollicitudin aliquam ultrices sagittis. Tortor vitae purus faucibus ornare suspendisse sed nisi lacus. ",
                    CreatedDate = DateTime.Now,
                    DisplayOrder = 1,
                }
            };
        }

        public async Task<IRequestProviderResult<bool>> PublishGalleryItemByIdAsync(GalleryItemKeysDto dto)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<IRequestProviderResult<bool>> DeleteGalleryItemByIdAsync(GalleryItemKeysDto dto)
        {
            return new RequestProviderResult<bool>
            {
                Success = true,
                Data = true
            };
        }

        public Task<IRequestProviderResult<List<GalleryLiteDto>>> GetPublicListAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<bool>> PublishGalleryItemsAsync(PublishDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<Dictionary<Guid, string>>> CreateListGalleryItemsAsync(CreateListGalleryItemsDto data)
        {
            throw new NotImplementedException();
        }

        public Task<IRequestProviderResult<List<GalleryLiteDto>>> GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        Task<IRequestProviderResult<GalleryList>> IGalleriesService.GetAllAsync(PaginationModel pagination, Dictionary<string, object> searchParams, SortingModel sorting, string lang)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultModel<List<GalleryLiteDto>>> GetPublicListAsync(PaginationModel pagination, SortingModel sorting = null)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultModel<List<GalleryLiteDto>>> GetPublicListAsync(PaginationModel pagination, bool sortingByOrder = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<GalleryLiteDto>> GetPublicListAsync(int takeItems, string section = null, bool sortManually = false)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultModel<List<GalleryLiteDto>>> GetPublicListAsync(PaginationModel pagination, string section = null, SortingModel sorting = null)
        {
            throw new NotImplementedException();
        }





        #endregion






    }
}

using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.IdentityService.Models;

namespace TamTech.Monshaat.POS.IdentityService.Utilities
{
   public static class Mapper
    {
        public static TokenModel MapToModel(this TokenResponse t)
        {
            return new TokenModel
            {
                AccessToken = t.AccessToken,
                RefreshToken = t.RefreshToken,
                ExpiresIn = t.ExpiresIn,
                TokenType = t.TokenType,
            };
        }
    }
}

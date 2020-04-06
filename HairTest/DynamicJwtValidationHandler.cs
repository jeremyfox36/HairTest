using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HairTest
{
    internal class DynamicJwtValidationHandler : ISecurityTokenValidator
    {
        public bool CanValidateToken => throw new System.NotImplementedException();

        public int MaximumTokenSizeInBytes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool CanReadToken(string securityToken)
        {
            throw new System.NotImplementedException();
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
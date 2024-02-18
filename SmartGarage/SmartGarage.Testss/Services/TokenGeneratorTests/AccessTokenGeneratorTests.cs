using System;
using SmartGarage.Services.TokenGenerator;

using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Tests.Services.TokenGeneratorTests
{
    [TestClass]
    public class AccessTokenGeneratorTests
    {
        private AuthenticationConfiguration _configuration;
        private AccessTokenGenerator _tokenGenerator;

        [TestInitialize]
        public void Initialize()
        {
            _configuration = new AuthenticationConfiguration
            {
                AccessTokenSecret = "the secret key wich must be very long", // TODO
                AccessTokenExpirationMinutes = 60,
                Issuer = "TestIssuer",
                Audience = "TestAudience"
            };

            _tokenGenerator = new AccessTokenGenerator(_configuration);
        }

        [TestMethod]
        public void GenerateToken_ShouldReturnValidToken()
        {
            // Arrange
            var user = new User { UserID = 1, Email = "test@example.com", Username = "testuser" };

            // Act
            var tokenString = _tokenGenerator.GenerateToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);

            // Assert
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Claims.Any(c => c.Type == "id" && c.Value == user.UserID.ToString()));
            Assert.IsTrue(token.Claims.Any(c => c.Type == ClaimTypes.Email && c.Value == user.Email));
            Assert.IsTrue(token.Claims.Any(c => c.Type == ClaimTypes.Name && c.Value == user.Username));
        }

        [TestMethod]
        public void GenerateToken_TokenShouldExpireCorrectly()
        {
            // Arrange
            var user = new User { UserID = 1, Email = "test@example.com", Username = "testuser" };

            // Act
            var tokenString = _tokenGenerator.GenerateToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);

            // Assert
            var validFrom = token.ValidFrom;
            var validTo = token.ValidTo;

            Assert.AreEqual(_configuration.AccessTokenExpirationMinutes, (validTo - validFrom).TotalMinutes, 1); // 1-minute tolerance
        }
    }

}

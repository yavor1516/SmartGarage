using Moq;
using SmartGarage.Services.Contracts;
using SmartGarage.Services.TokenGenerator;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGarage.Helpers.Contracts;
using ForumSystem.Exceptions;
using SmartGarage.Models.DTO;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class AccountServiceTests
    {
        private Mock<IUserDataService> _userDataServiceMock;
        private Mock<IPasswordHasher> _passwordHasherMock;
        private Mock<AccessTokenGenerator> _tokenGeneratorMock;
        private AccountService _accountService;

        [TestInitialize]
        public void Setup()
        {
            _userDataServiceMock = new Mock<IUserDataService>();
            _passwordHasherMock = new Mock<IPasswordHasher>();
            _tokenGeneratorMock = new Mock<AccessTokenGenerator>();

            _accountService = new AccountService(
                _userDataServiceMock.Object,
                _passwordHasherMock.Object,
                _tokenGeneratorMock.Object
            );
        }

    }
}

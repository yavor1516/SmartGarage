using Moq;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;
using SmartGarage.Services;
using SmartGarage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class VehicleDataServiceTests
    {
        private Mock<IVehicleRepository> _repositoryMock;
        private Mock<GarageContext> _contextMock;
        private IVehicleDataService _vehicleDataService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IVehicleRepository>();
            _contextMock = new Mock<GarageContext>();
            _vehicleDataService = new VehicleDataService(_repositoryMock.Object, _contextMock.Object);
        }

       
    }
}

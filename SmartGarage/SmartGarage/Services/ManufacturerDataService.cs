﻿using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class ManufacturerDataService : IManufacturerDataService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerDataService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public ManufacturerDTO CreateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                throw new ArgumentNullException(nameof(manufacturerDTO));
            }

            var manufacturer = new Manufacturer
            {
                ManufacturerID = manufacturerDTO.ManufacturerID,
                BrandName = manufacturerDTO.BrandName
            };

            var createdManufacturer = _manufacturerRepository.CreateManufacturer(manufacturer);

            return MapManufacturerToDTO(createdManufacturer);
        }

        public ManufacturerDTO GetManufacturerById(int id)
        {
            var manufacturer = _manufacturerRepository.GetManufacturerById(id);
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            return MapManufacturerToDTO(manufacturer);
        }

        public ManufacturerDTO GetManufacturerByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            }

            var manufacturer = _manufacturerRepository.GetManufacturerByName(name);
            return manufacturer == null ? null : MapManufacturerToDTO(manufacturer);
        }

        public ICollection<ManufacturerDTO> GetAllManufacturers()
        {
            var manufacturers = _manufacturerRepository.GetAllManufacturers();
            return manufacturers.Select(MapManufacturerToDTO).ToList();
        }

        public void UpdateManufacturer(ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                throw new ArgumentNullException(nameof(manufacturerDTO));
            }

            var manufacturer = MapManufacturerDTOToEntity(manufacturerDTO);
            var existingManufacturer = _manufacturerRepository.GetManufacturerById(manufacturer.ManufacturerID);

            if (existingManufacturer == null)
            {
                throw new InvalidOperationException("Manufacturer does not exist.");
            }

            existingManufacturer.BrandName = manufacturerDTO.BrandName;

            _manufacturerRepository.UpdateManufacturer(existingManufacturer);
        }

        private ManufacturerDTO MapManufacturerToDTO(Manufacturer manufacturer)
        {
            return new ManufacturerDTO
            {
                ManufacturerID = manufacturer.ManufacturerID,
                BrandName = manufacturer.BrandName,
                CarModels = manufacturer.CarModels.Select(cm => new CarModelDTO
                {
                    CarModelID = cm.CarModelID,
                    Model = cm.Model,
                    ManufacturerID = cm.ManufacturerID
                }).ToList()

            };
        }
        private Manufacturer MapManufacturerDTOToEntity(ManufacturerDTO manufacturerDTO)
        {
            if(manufacturerDTO == null)
            {
                return null;
            }

            return new Manufacturer
            {
                ManufacturerID = manufacturerDTO.ManufacturerID,
                BrandName = manufacturerDTO.BrandName
            };
        }
    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using realEstateAPI.Data;
using realEstateAPI.Models.Domain;
using realEstateAPI.Models.DTO;
using realEstateAPI.Repositories;

namespace realEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly RealEstateDbContext dbContext;
        private readonly IPropertyRepository propertyRepository;
        private readonly IMapper mapper;

        public PropertiesController(RealEstateDbContext dbContext,
            IPropertyRepository propertyRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var propertiesDomain = await propertyRepository.GetAllAsync();

            // Return DTOs
            return Ok(mapper.Map<List<PropertyDto>>(propertiesDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        { 
            var propertyDomain = await propertyRepository.GetByIdAsync(id);

            if (propertyDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PropertyDto>(propertyDomain));
        }

        [HttpPost]
        //[ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddPropertyRequestDto addPropertyRequestDto)
        {
            var propertyDomainModel = mapper.Map<Property>(addPropertyRequestDto);

            propertyDomainModel = await propertyRepository.CreateAsync(propertyDomainModel);

            var propertyDto = mapper.Map<PropertyDto>(propertyDomainModel);

            return CreatedAtAction(nameof(GetByID), new { id = propertyDto.Id }, propertyDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        //[ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePropertyRequestDto updatePropertyRequestDto)
        {
            var propertyDomainModel = mapper.Map<Property>(updatePropertyRequestDto);

            propertyDomainModel = await propertyRepository.UpdateAsync(id, propertyDomainModel);

            if (propertyDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PropertyDto>(propertyDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var propertyDomainModel = await propertyRepository.DeleteAsync(id);

            if (propertyDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PropertyDto>(propertyDomainModel));
        }
    }
}

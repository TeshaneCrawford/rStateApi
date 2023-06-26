using Microsoft.EntityFrameworkCore;
using realEstateAPI.Data;
using realEstateAPI.Models.Domain;

namespace realEstateAPI.Repositories
{
    public class SQLPropertyRepository : IPropertyRepository
    {
        private readonly RealEstateDbContext dbContext;

        public SQLPropertyRepository(RealEstateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task<Property> IPropertyRepository.CreateAsync(Property property)
        {
            await dbContext.Properties.AddAsync(property);
            await dbContext.SaveChangesAsync();
            return property;
        }

        async Task<Property?> IPropertyRepository.DeleteAsync(Guid id)
        {
            var existingProperty = await dbContext.Properties.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProperty == null)
            {
                return null;
            }

            dbContext.Properties.Remove(existingProperty);
            await dbContext.SaveChangesAsync();
            return existingProperty;

        }

        async Task<List<Property>> IPropertyRepository.GetAllAsync()
        {
            return await dbContext.Properties.ToListAsync();
        }

        async Task<Property?> IPropertyRepository.GetByIdAsync(Guid id)
        {
            return await dbContext.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }

       async Task<Property?> IPropertyRepository.UpdateAsync(Guid id, Property property)
        {
            var existingProperty = await dbContext.Properties.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProperty == null)
            {
                return null;
            }

            existingProperty.Description = property.Description;
            existingProperty.Price = property.Price;
            existingProperty.IsAvailable = property.IsAvailable;
            existingProperty.IsForSale = property.IsForSale;
            existingProperty.IsForRent = property.IsForRent;
            existingProperty.ProprtyImageUrl = property.ProprtyImageUrl;
            existingProperty.AgentId = property.AgentId;
            existingProperty.PropertyDetailsId = property.PropertyDetailsId;
            existingProperty.PropertyTypeId = property.PropertyTypeId;
            existingProperty.PropertyType = property.PropertyType;

            await dbContext.SaveChangesAsync();
            return existingProperty;
        }
    }
}

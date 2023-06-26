using realEstateAPI.Models.Domain;

namespace realEstateAPI.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(Guid id);
        Task<Property> CreateAsync(Property property);
        Task<Property?> UpdateAsync(Guid id, Property property);
        Task<Property?> DeleteAsync(Guid id);
    }
}

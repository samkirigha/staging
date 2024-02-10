using ticketsservice.Dtos;

namespace ticketsservice.Services;

public interface ICategoryService
{
    public Task<List<CategoryResponseDto>> GetAllCategories();
}
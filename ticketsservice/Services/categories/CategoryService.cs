

using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ticketsservice.Dtos;
using ticketsservice.EF;

namespace ticketsservice.Services;

public class CategoryService : ICategoryService
{
    private TicketsDBContext _dbContext;
    private IMapper _mapper;

    public CategoryService(TicketsDBContext ticketsDBContext, IMapper mapper)
    {
        _dbContext = ticketsDBContext;
        _mapper = mapper;
    }
    public async Task<List<CategoryResponseDto>> GetAllCategories()
    {
       try
       {
        var response = await _dbContext.Categories.ToListAsync();
        var categories = _mapper.Map<List<CategoryResponseDto>>(response);
        return categories;
       }
        catch (Exception ex)
        {
            throw;
        }
    }
}
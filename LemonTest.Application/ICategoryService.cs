using LemonTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LemonTest.Application
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> Get(int id);
        Task<CategoryDto> Create(CategoryDto dto);
        Task<CategoryDto> Update(CategoryDto dto);
        Task<bool> Delete(int id);
    }
}

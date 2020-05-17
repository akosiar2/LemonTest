using LemonTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LemonTest.Application
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Create(ProductDto dto);
        Task<ProductDto> Update(ProductDto dto);
        Task<bool> Delete(int id);
    }
}

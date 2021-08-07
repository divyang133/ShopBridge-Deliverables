using ShopBridge.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Repository
{
    public interface IProductRepository
    {
        Task<tblProductDetails> AddProductAsync(tblProductDetails tblProductDetails);
        Task<tblProductDetails> GetProductByIdAsync(long id);
        Task<tblProductDetails> GetProductByNameAndBrandAsync(string productName, string Brand);
        Task<tblProductDetails> GetProductByNameAsync(string productName);
        Task<List<tblProductDetails>> ListProductAsync(int skip, int take, string search);
        Task<tblProductDetails> UpdateProductAsync(tblProductDetails tblProductDetails);
    }
}
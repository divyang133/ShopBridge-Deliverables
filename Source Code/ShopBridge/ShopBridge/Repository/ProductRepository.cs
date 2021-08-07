using Microsoft.EntityFrameworkCore;
using ShopBridge.Context;
using ShopBridge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ShopBridgeDB shopBridgeDB;

        public ProductRepository(ShopBridgeDB shopBridgeDB)
        {
            this.shopBridgeDB = shopBridgeDB;
        }

        public async Task<tblProductDetails> AddProductAsync(tblProductDetails tblProductDetails)
        {
            shopBridgeDB.Add(tblProductDetails);
            await shopBridgeDB.SaveChangesAsync();
            return tblProductDetails;
        }

        public async Task<tblProductDetails> GetProductByIdAsync(long id)
        {
            return await shopBridgeDB.tblProductDetails.FirstOrDefaultAsync(a => a.PDID == id && a.Status == "Active");
        }


        public async Task<tblProductDetails> GetProductByNameAsync(string productName)
        {
            return await shopBridgeDB.tblProductDetails.FirstOrDefaultAsync(a => a.ProductName == productName && a.Status == "Active");
        }

        public async Task<tblProductDetails> GetProductByNameAndBrandAsync(string productName, string Brand)
        {
            return await shopBridgeDB.tblProductDetails.FirstOrDefaultAsync(a => a.ProductName == productName && a.Brand == Brand && a.Status == "Active");
        }

        public async Task<tblProductDetails> UpdateProductAsync(tblProductDetails tblProductDetails)
        {
            shopBridgeDB.Update(tblProductDetails);
            await shopBridgeDB.SaveChangesAsync();
            return tblProductDetails;
        }

        public async Task<List<tblProductDetails>> ListProductAsync(int skip, int take, string search)
        {
            return await shopBridgeDB.tblProductDetails.Where(a => a.Status == "Active" && string.IsNullOrEmpty(search) ? true :
            (a.ProductName.Contains(search) || a.Description.Contains(search) || a.Price.ToString().Contains(search) || a.Brand.Contains(search) || a.Manufacturer.Contains(search))
            ).Skip(skip).Take(take).ToListAsync();
        }
    }
}

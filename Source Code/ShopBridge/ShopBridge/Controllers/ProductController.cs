using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Context;
using ShopBridge.DTOs;
using ShopBridge.Entities;
using ShopBridge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost("AddProduct")]

        //The action mathod will add a new product to the database
        public async Task<ActionResult> AddProductAsync([FromBody] tblProductDetails tblProductDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var existingProdutc = await productRepository.GetProductByNameAndBrandAsync(tblProductDetails.ProductName, tblProductDetails.Brand);
            if (existingProdutc != null)
                return Ok(new ServerResponse<tblProductDetails>(tblProductDetails, false, "The product alreay exists!"));
            await productRepository.AddProductAsync(tblProductDetails);
            return Ok(new ServerResponse<tblProductDetails>(tblProductDetails, true, "The product has been added successfully."));
        }

        [HttpGet("EditProduct/{id}")]

        //The action mathod will fetch the product details for edit from the database
        public async Task<ActionResult> EditProductAsync(long id)
        {
            var tblProductDetails = await productRepository.GetProductByIdAsync(id);
            if (tblProductDetails == null)
                return NotFound(string.Format("The product not found for the product id {0}", id));
            return Ok(new ServerResponse<tblProductDetails>(tblProductDetails, true, "The product has been fetched successfully."));
        }

        [HttpPut("UpdateProduct/{id}")]
        //The action mathod will update the product details to the database for given product
        public async Task<ActionResult> UpdateProductAsync([FromBody] tblProductDetails tblProductDetails, long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var existingProdutc = await productRepository.GetProductByNameAndBrandAsync(tblProductDetails.ProductName, tblProductDetails.Brand);
            if (existingProdutc != null)
                return Ok(new ServerResponse<tblProductDetails>(tblProductDetails, false, "The product alreay exists!"));
            await productRepository.UpdateProductAsync(tblProductDetails);
            return Ok(new ServerResponse<tblProductDetails>(tblProductDetails, true, "The product has been updated successfully."));
        }


        [HttpDelete("DeleteProduct/{id}")]
        //The action mathod will inactivate the product so it will seem like deleted.
        public async Task<ActionResult> DeleteProductAsync(long id)
        {
            var tblProductDetails = await productRepository.GetProductByIdAsync(id);
            if (tblProductDetails == null)
                return NotFound(string.Format("The product not found for the product id {0}", id));
            tblProductDetails.Status = "InActive";
            await productRepository.UpdateProductAsync(tblProductDetails);
            return Ok(new ServerResponse<tblProductDetails>(tblProductDetails, true, "The product has been deleted successfully."));
        }


        [HttpGet("GetProducts/{skip}/{take}/search")]
        //The method will return list of the products by pagination and search
        public async Task<ActionResult> GetProductsAsync(int skip, int take, string search)
        {
            return Ok(new ServerResponse<List<tblProductDetails>>(await productRepository.ListProductAsync(skip, take, search), true, "The product list has been fetched successfully."));
        }
    }
}

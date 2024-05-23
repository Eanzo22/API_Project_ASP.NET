using ECommerce.BL.DTOS.Products;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Products
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddProduct(AddProductDto productDto)
        {
            var product = new Product
            {
              Name = productDto.Name,
              Description= productDto.Description,
              Price= productDto.Price,
              Category= productDto.Category,
              ImageURL= productDto.ImageURL,
            };
            unitOfWork.ProductRepo.Add(product);
            unitOfWork.SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var product = unitOfWork.ProductRepo.GetById(id);
            if (product is null)
                return false;
            unitOfWork.ProductRepo.Delete(product);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool Edit(EditProductDto editProductDto)
        {
            var product = unitOfWork.ProductRepo.GetById(editProductDto.Id);
            if (product is null) return false;
            product.Name= editProductDto.Name;
            product.Price= editProductDto.Price;
            product.Category= editProductDto.Category;
            product.Description= editProductDto.Description;
            product.ImageURL= editProductDto.ImageURL;
            unitOfWork.SaveChanges();
            return true;
        }

        public IEnumerable<ReadProductDto> GetAll(ProductFilterDto productFilterDto)
        {

                var query= unitOfWork.ProductRepo.GetAll();
            if (!string.IsNullOrEmpty(productFilterDto.Name))
                query = query.Where(p => p.Name.Contains(productFilterDto.Name.Trim(), StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(productFilterDto.Category))
                query = query.Where(p => p.Category.Contains(productFilterDto.Category.Trim(), StringComparison.OrdinalIgnoreCase));
            var products = query.ToList();
            return products.Select(p => new ReadProductDto
            {
                Id = p.Id,
                Name= p.Name,
                Description = p.Description,
                Price= p.Price,
                Category= p.Category,
                ImageURL= p.ImageURL,
            });
        }

        public ReadProductDto? GetById(int id)
        {
            var product = unitOfWork.ProductRepo.GetById(id);
            if(product is null) return null;
            return new ReadProductDto { 
                Id= product.Id,
                Name= product.Name,
                Description= product.Description,
                Price= product.Price,
                Category= product.Category,
                ImageURL= product.ImageURL,
            }; 
                
                }
    }
}

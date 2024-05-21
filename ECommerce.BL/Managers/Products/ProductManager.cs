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

        public void DeleteById(int id)
        {
            var product = unitOfWork.ProductRepo.GetById(id);
            if (product is null)
                return;
            unitOfWork.ProductRepo.Delete(product);
            unitOfWork.SaveChanges();
        }

        public void Edit(EditProductDto editProductDto)
        {
            var product = unitOfWork.ProductRepo.GetById(editProductDto.Id);
            if (product is null) return;
            product.Name= editProductDto.Name;
            product.Price= editProductDto.Price;
            product.Category= editProductDto.Category;
            product.Description= editProductDto.Description;
            product.ImageURL= editProductDto.ImageURL;
            unitOfWork.SaveChanges();
        }

        public IEnumerable<ReadProductDto> GetAll()
        {

                var products= unitOfWork.ProductRepo.GetAll();
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

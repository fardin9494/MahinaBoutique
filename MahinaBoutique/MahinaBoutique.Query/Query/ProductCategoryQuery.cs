using _0_SelfBuildFramwork.Application;
using DiscountManagement.Infrastracture.EFCore;
using InventoryManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Product;
using MahinaBoutique.Query.Contract.ProductCategory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventory;
        private readonly DiscountContext _discount;

        public ProductCategoryQuery(ShopContext context, InventoryContext inventory, DiscountContext discount)
        {
            _context = context;
            _inventory = inventory;
            _discount = discount;
        }

        public List<ProductCategoryQueryModel> GetCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel{
                Id = x.Id,
                Slug = x.Slug,
                Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Name = x.Name,
                }).ToList();


        }

        public List<ProductCategoryQueryModel> GetCategoryWithProducts()
        {
            var discount = _discount.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).
                Select(x => new {x.ProductId,x.DiscountRate}).ToList();
            var inventory = _inventory.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();
            var categories = _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel{ 
                Id = x.Id,
                Slug = x.Slug,
                Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Name = x.Name,
                Products = MapProduct(x.Products)
                
                }).ToList();


            foreach (var category in categories)
            {
                foreach(var product in category.Products)
                {
                   var Price = inventory.FirstOrDefault(x => x.ProductId == product.Id).UnitPrice;
                    product.Price = Price.ToMoney();
                   
                    if(discount.FirstOrDefault(x => x.ProductId == product.Id) != null)
                       {
                         var discountrate = discount.FirstOrDefault(x => x.ProductId == product.Id).DiscountRate;
                    
                        {
                            product.HaveDiscount = discountrate>0;
                            product.DiscountRate = discountrate;
                            var DiscountAmount = Math.Round((((decimal)Price)*discountrate)/100);
                            var PriceafterChange = Price - ((double)DiscountAmount);
                            product.PriceAfterDiscount = PriceafterChange.ToMoney();
                        }
                    }
                }
            }

            return categories;

        }

        private static List<ProductQueryModel> MapProduct(List<Product> products)
        {
             return products.Select(x => new ProductQueryModel{
                    Category = x.Category.Name,
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt= x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                }).ToList();
          
        }

        public ProductCategoryQueryModel GetCategoryWithProductBy(string slug)
        {
            var discount = _discount.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).
                Select(x => new {x.ProductId,x.DiscountRate,x.EndDate}).ToList();
            var inventory = _inventory.Inventory.Select(x => new {x.ProductId, x.UnitPrice}).ToList();
            var category = _context.ProductCategories.Include(x => x.Products).
                ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
            {
                Slug = x.Slug,
                Id = x.Id,
                Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle,
                Name = x.Name,
                Products = MapProduct(x.Products),
                Description = x.Description,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
            }).FirstOrDefault(x => x.Slug == slug);


            foreach(var product in category.Products)
            {
                var Inventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                var Discount= discount.FirstOrDefault(x => x.ProductId == product.Id);
                if(Inventory != null)
                {
                    var price = Inventory.UnitPrice;
                    product.Price = price.ToMoney();
                    if(Discount != null)
                    {
                        var discountrate = Discount.DiscountRate;
                        product.DiscountRate = discountrate;
                        product.HaveDiscount = discountrate>0;
                        var DiscountAmount = Math.Round((price*discountrate)/100);
                        product.PriceAfterDiscount = (price - DiscountAmount).ToMoney();
                        product.ExpireDiscountTime = Discount.EndDate.ToDiscountFormat();
                    }

                }
            }
            return category;
        }
    }
}

using _0_SelfBuildFramwork.Application;
using CommentManagement.Infrastracture.EfCore;
using DiscountManagement.Infrastracture.EFCore;
using InventoryManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Comment;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventory;
        private readonly DiscountContext _discount;
        private readonly CommentContext _comment;

        public ProductQuery(ShopContext context, InventoryContext inventory, DiscountContext discount, CommentContext comment)
        {
            _context = context;
            _inventory = inventory;
            _discount = discount;
            _comment = comment;
        }

        public List<ProductQueryModel> GetArrivals()
        {
            var Discount = _discount.CustomerDiscounts.Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now).Select(x => new {x.ProductId,x.DiscountRate}).ToList();
            var inventory = _inventory.Inventory.Select(x => new {x.ProductId,x.UnitPrice}).ToList();
            var products = _context.Products.Include(x => x.Category).Select(x => new ProductQueryModel{
                Category = x.Category.Name,
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CategorySlug = x.Category.Slug,
                }).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();

            foreach(var product in products)
            {
                var unitPrice = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                var discountRate = Discount.FirstOrDefault(x => x.ProductId == product.Id);
                if(unitPrice != null)
                {
                    var price = unitPrice.UnitPrice;
                    product.Price = price.ToMoney();
                    if(discountRate != null)
                    {
                        var discount = discountRate.DiscountRate;
                        product.HaveDiscount = discount>0;
                        product.DiscountRate = discount;
                        var DiscountAmount = Math.Round((price*discount)/100);
                        product.PriceAfterDiscount = (price - DiscountAmount).ToMoney();
                    }

                }
                    
            }

            return products;

        }

        public ProductQueryModel GetDeatail(string slug)
        {
            var discount = _discount.CustomerDiscounts.Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now).Select(x => new {x.ProductId,x.DiscountRate,x.EndDate}).ToList();
            var inventory = _inventory.Inventory.Select(x => new {x.ProductId,x.UnitPrice,x.InStock}).ToList();
            var Product = _context.Products.Include(x => x.Category).Include(x => x.Pictures).Select(x => new ProductQueryModel{
                Category = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Code =x.Code,
                Description = x.Description,
                Keywords = x.Keywords,
                ProductPictures = MapPictures(x.Pictures),
                MetaDescription = x.MetaDescription,
                }).FirstOrDefault(x => x.Slug == slug);

             var Inventory = inventory.FirstOrDefault(x => x.ProductId == Product.Id);
             var Discount= discount.FirstOrDefault(x => x.ProductId == Product.Id);
                if(Inventory != null)
                {
                    var price = Inventory.UnitPrice;
                    Product.Price = price.ToMoney();
                    Product.IsInStock = Inventory.InStock;
                    if(Discount != null)
                    {
                        var discountrate = Discount.DiscountRate;
                        Product.DiscountRate = discountrate;
                        Product.HaveDiscount = discountrate>0;
                        
                        var DiscountAmount = Math.Round((price*discountrate)/100);
                        Product.PriceAfterDiscount = (price - DiscountAmount).ToMoney();
                        Product.ExpireDiscountTime = Discount.EndDate.ToDiscountFormat();
                    }

                }

                var comments = _comment.Comments.Where(x => x.IsConfirmed && !x.IsCanceled)
                .Where(x => x.Type == CommentTypesMapping.Product)
                .Where(x => x.OwnerRecordId == Product.Id).Select(x => new CommentQueryModel{
                    Id = x.Id,
                    Massege = x.Message,
                    Name = x.Name
                    }).ToList();

                Product.Comments = comments;
           
            return Product;
        }

        private static List<ProductPictureQueryModel> MapPictures(List<ProductPicture> pictures)
        {
           return pictures.Where(x => !x.IsRemoved).Select(x => new ProductPictureQueryModel{
               Picture = x.Picture,
               PictureAlt = x.PictureAlt,
               PictureTitle = x.PictureTitle,
               }).ToList();
        }

        public List<ProductQueryModel> Search(string value)
        {
            var Discount = _discount.CustomerDiscounts.Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now).Select(x => new {x.ProductId,x.DiscountRate,x.EndDate}).ToList();
            var inventory = _inventory.Inventory.Select(x => new {x.ProductId,x.UnitPrice}).ToList();
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductQueryModel{
                Category = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Id = x.Id,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
            {
              query =  query.Where(x => x.Name.Contains(value)||x.ShortDescription.Contains(value));
            }

            var products = query.OrderByDescending(x => x.Id).ToList();

            foreach(var product in products)
            {
                var unitPrice = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                var discountRate = Discount.FirstOrDefault(x => x.ProductId == product.Id);
                if(unitPrice != null)
                {
                    var price = unitPrice.UnitPrice;
                    product.Price = price.ToMoney();
                    if(discountRate != null)
                    {
                        var discount = discountRate.DiscountRate;
                        product.HaveDiscount = discount>0;
                        product.DiscountRate = discount;
                        product.ExpireDiscountTime = discountRate.EndDate.ToDiscountFormat();
                        var DiscountAmount = Math.Round((price*discount)/100);
                        product.PriceAfterDiscount = (price - DiscountAmount).ToMoney();
                    }

                }
                 
                    
            }

           

            return products;
        }
    }
}

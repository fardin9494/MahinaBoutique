using _0_SelfBuildFramwork.Application;
using DiscountManagement.Infrastracture.EFCore;
using InventoryManagement.Infrastracture.EfCore;
using MahinaBoutique.Query.Contract.Product;
using Microsoft.EntityFrameworkCore;
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

        public ProductQuery(ShopContext context, InventoryContext inventory, DiscountContext discount)
        {
            _context = context;
            _inventory = inventory;
            _discount = discount;
        }

        public List<ProductQueryModel> GetArrivals()
        {
            var Discount = _discount.CustomerDiscounts.Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now).Select(x => new {x.ProductId,x.DiscountRate}).ToList();
            var inventory = _inventory.Inventory.Select(x => new {x.ProductId,x.UnitPrice}).ToList();
            var products = _context.Products.Include(x => x.Category).Select(x => new ProductQueryModel{
                Category = x.Category.Name,
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                }).OrderByDescending(x => x.Id).Take(6).ToList();

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
    }
}

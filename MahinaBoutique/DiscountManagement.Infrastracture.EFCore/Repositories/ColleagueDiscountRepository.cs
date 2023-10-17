using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.InfraStracture.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastracture.EFCore.Repositories
{
    public class ColleagueDiscountRepository : BaseRepository<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount{
                DiscountRate = x.DiscountRate,
                Id = x.Id,
                ProductId = x.ProductId,
                }).FirstOrDefault(x => x.Id==id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new {x.Id,x.Name}).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel{
                DiscountRate =x.DiscountRate,
                Id = x.Id,
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi()
                });

            if(searchModel.ProductId != 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            var ColleaguesDiscount = query.OrderByDescending(x => x.Id).ToList();

            foreach(var Discount in ColleaguesDiscount)
            {
                Discount.Product = products.FirstOrDefault(x => x.Id == Discount.ProductId).Name;
            }

            return ColleaguesDiscount;

            //ColleaguesDiscount.ForEach(collegue => collegue.Product = products.FirstOrDefault(x => x.Id == collegue.ProductId)?.Name)

        }
    }
}

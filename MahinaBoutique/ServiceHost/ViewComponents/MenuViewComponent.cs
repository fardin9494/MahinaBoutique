using MahinaBoutique.Query.Contract;
using MahinaBoutique.Query.Contract.ArticleCategory;
using MahinaBoutique.Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IArticleCategoryQuery _articleCategory;
        private readonly IProductCategoryQuery _productCategory;

        public MenuViewComponent(IArticleCategoryQuery articleCategory, IProductCategoryQuery productCategory)
        {
            _articleCategory = articleCategory;
            _productCategory = productCategory;
        }

        public IViewComponentResult Invoke()
        {
            var menu = new MenuQueryModel
            {
                ArticleCategories = _articleCategory.GetArticleCategories(),
                ProductCategories = _productCategory.GetCategories()
            };
            return View("_Menu",menu);
        }
    }
}

using MahinaBoutique.Query.Contract.ArticleCategory;
using MahinaBoutique.Query.Contract.ProductCategory;
using System.Collections.Generic;

namespace MahinaBoutique.Query.Contract
{
    public class MenuQueryModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
       
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}

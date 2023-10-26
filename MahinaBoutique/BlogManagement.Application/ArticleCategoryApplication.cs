using _0_Framework.Application;
using _0_SelfBuildFramwork.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if(_articleCategoryRepository.IsExist(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var slug = command.Slug.Slugify();
            var ImagePath = _fileUploader.Upload(command.Image,slug,false);
            
            var ArticleCategory = new ArticleCategory(command.Name,command.ShowOrder,command.Description,ImagePath,
            command.ImageTitle,command.ImageAlt,command.Keywords,command.MetaDescription,command.CanonicalAddress,slug);
            _articleCategoryRepository.Create(ArticleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var selectedArticleCAtegory = _articleCategoryRepository.GetBy(command.Id);
            if(selectedArticleCAtegory == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            if(_articleCategoryRepository.IsExist(x => x.Name == selectedArticleCAtegory.Name && x.Id != selectedArticleCAtegory.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var slug = command.Slug.Slugify();
            var ImagePath = _fileUploader.Upload(command.Image,slug,false);
            selectedArticleCAtegory.Edit(command.Name,command.ShowOrder,command.Description,ImagePath,
            command.ImageTitle,command.ImageAlt,command.Keywords,command.MetaDescription,command.CanonicalAddress,slug);
            _articleCategoryRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditArticleCategory GetDetail(long id)
        {
            return _articleCategoryRepository.GetDetail(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            return _articleCategoryRepository.Search(search);
        }
    }
}

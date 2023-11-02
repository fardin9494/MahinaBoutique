using _0_SelfBuildFramwork.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _repository;
        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IArticleRepository repository, IFileUploader fileUploader)
        {
            _repository = repository;
            _fileUploader = fileUploader;

        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if(_repository.IsExist(x => x.Title == command.Title))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var slug = command.Slug.Slugify();
            var categoryslug = _repository.GetSlug(command.CategoryId);
            var imagePath = _fileUploader.Upload(command.Picture,$"{categoryslug}/{slug}",BaseFolderForUpload.Article);

            var Article = new Article(command.Title,command.ShortDescription,command.Description,imagePath,command.PictureAlt,
                command.PictureTitle,command.MetaDescription,command.Keywords,slug,command.PublishDate.ToGeorgianDateTime(),command.CanonicalAddress,
                command.CategoryId);

            _repository.Create(Article);
            _repository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var Article = _repository.GetBy(command.Id);
            if(Article == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            if(_repository.IsExist(x => x.Title == Article.Title && x.Id != Article.Id))
            {
                return operation.Failed(ApplicationMessages.DupplicatedMessage);
            }
            var slug = command.Slug.Slugify();
            var categoryslug = _repository.GetSlug(command.CategoryId);
            var imagePath = _fileUploader.Upload(command.Picture,$"{categoryslug}/{slug}",BaseFolderForUpload.Article);

            Article.Edit(command.Title,command.ShortDescription,command.Description,imagePath,command.PictureAlt,
                command.PictureTitle,command.MetaDescription,command.Keywords,slug,command.PublishDate.ToGeorgianDateTime(),command.CanonicalAddress,
                command.CategoryId);

            _repository.SaveChanges();
            return operation.Succedded();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _repository.GetArticleCategories();
        }

        public EditArticle GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel search)
        {
            return _repository.Search(search);
        }
    }
}

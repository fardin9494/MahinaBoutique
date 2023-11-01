using _0_SelfBuildFramwork.Application;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;

namespace CommentManagement.Application
{
    public class CommentAppplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentAppplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.GetBy(id);
            if(comment == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            comment.Cancel();
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.GetBy(id);
            if(comment == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            comment.Confirm();
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Create(CreateComment command)
        {
            var operation = new OperationResult();
            var comment = new Comment(command.Name,command.Email,command.WebSite,command.Message,command.OwnerRecordId,command.Type,command.ParentId);
            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<CommentViewModel> Search(CommentSearchModel search)
        {
            return _commentRepository.Search(search);
        }
    }
}

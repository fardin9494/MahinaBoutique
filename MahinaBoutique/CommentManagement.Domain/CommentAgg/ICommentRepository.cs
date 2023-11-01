using _0_SelfBuildFramwork.Domain;
using CommentManagement.Application.Contract.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,Comment>
    {
        List<CommentViewModel> Search (CommentSearchModel search);
    }
}

using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Application.Contract.Comment
{
    public interface ICommentApplication
    {
        OperationResult Create(CreateComment command);

        OperationResult Cancel(long id);

        OperationResult Confirm(long id);

        List<CommentViewModel> Search (CommentSearchModel search);
    }
}

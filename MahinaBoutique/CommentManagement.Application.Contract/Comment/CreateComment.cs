using _0_SelfBuildFramwork.Application;
using System.ComponentModel.DataAnnotations;

namespace CommentManagement.Application.Contract.Comment
{
    public class CreateComment
    {
        [Required (ErrorMessage = ValidationMessages.Required)]
         public string Name { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Email { get; set; }

        public string WebSite { get; set; }

        [Required (ErrorMessage = ValidationMessages.Required)]
        public string Message { get; set; }
        
        public long OwnerRecordId { get; set; }

        public int Type { get; set; }

        public long ParentId { get; set; }
    }
}

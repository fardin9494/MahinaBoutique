using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahinaBoutique.Query.Contract.Comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Massege { get; set; }

        public string CommentDate { get; set; }

        public long ParentId { get; set; }
    }
}

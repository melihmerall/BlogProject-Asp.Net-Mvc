using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entity.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [StringLength(100)]
        public string BlogTitle { get; set; }
        [StringLength(100)]
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }

        public bool BlogStatus { get; set; }
        public int BlogRate { get; set; }

        //  Category Relathion
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Author Relathion
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        // Comment Relathion
        public ICollection<Comment> Comments { get; set; }


    }
}

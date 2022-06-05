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
  
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        [ AllowHtml]
        public string BlogContent { get; set; }

        public int BlogClickCount { get; set; }
        public bool BlogStatus { get; set; }
        public int BlogRating { get; set; }

        //  Category Relation
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Author Relation
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        // Comment Relation
        public ICollection<Comment> Comments { get; set; }


        // Many  to Many relation
        public Blog()
        {
            this.Tags = new HashSet<Tag>();
        }
        public virtual ICollection<Tag> Tags { get; set; }

    }
}

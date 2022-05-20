using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Author : IEntity
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; }
        [StringLength(100)]
        public string AuthorImage { get; set; }
        [StringLength(250)]
        public string AuthorDetail { get; set; }
        [Url]
        public string AuthorTwitter { get; set; }
        [Url]
        public string AuthorInstagram { get; set; }
        [Url]
        public string AuthorLinkedin { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}

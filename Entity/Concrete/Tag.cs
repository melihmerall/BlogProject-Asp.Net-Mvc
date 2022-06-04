using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Tag
    {
        public Tag()
        {
            this.Blogs = new HashSet<Blog>();
        }

        [Key]
        public int TagId { get; set; }
        [StringLength(30)]
        public string TagName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }


    }
}

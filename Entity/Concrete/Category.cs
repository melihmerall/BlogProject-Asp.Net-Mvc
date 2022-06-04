using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category : IEntity
    {



        [Key]
        public int CategoryId { get; set; }
        [StringLength(30)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }


        public ICollection<Blog> Blogs { get; set; }
        

    }
}

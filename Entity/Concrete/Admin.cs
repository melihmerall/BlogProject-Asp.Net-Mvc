using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(16)]
        public string Password { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }

        public bool AdminStatus { get; set; }
    }
}

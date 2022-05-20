using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entity.Concrete
{
    public class Subscribe : IEntity
    {
        [Key]
        public int MailId { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }
    }
}

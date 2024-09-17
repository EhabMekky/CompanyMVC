using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.DAL.Models
{
    public class Department : BaseEntity
    {
        [Required(ErrorMessage = "Code is required")]
        public int? Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
    }
}

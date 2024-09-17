using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.DAL.Models
{
    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(25,60,ErrorMessage = "Age must be between 25 and 60")]
        public int? Age { get; set; }
        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{4,10}",
            ErrorMessage = "Address must be in the format: 123-Street-Cairo-Egypt")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name = "Is Active?")]
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}

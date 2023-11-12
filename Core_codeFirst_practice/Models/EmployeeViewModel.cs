using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_codeFirst_practice.Models
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of birth")]
        public DateTime DateofBirth { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public Double Salary { get; set; }
        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesStudent.Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 1)]  
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Display(Name = "Certified Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime CertifiedDate { get; set; }
        
        
        public string Location { get; set; }
        public string Program { get; set; }

        [Display(Name = "Tuition & Fees")]
        [Range(1, 50000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TandF { get; set; }
    }
}
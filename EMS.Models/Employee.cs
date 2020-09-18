using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        //to be past
        public DateTime DateOfJoining { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [Range(1000000000, 9999999999)]
        public long Phone { get; set; }
        [Required]
        public Gender Gender { get; set; }

        // nav properties
        public virtual Department Department { get; set; }
        public virtual Project Project { get; set; }
    }
}

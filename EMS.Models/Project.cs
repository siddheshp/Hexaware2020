﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Client { get; set; }
        [Required]
        public int ProjectManager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Department Department { get; set; }
    }
}
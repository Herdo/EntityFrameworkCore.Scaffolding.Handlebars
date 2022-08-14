using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding.Handlebars.Tests.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        public EmployeeId EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Country { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Territory.Employees))]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
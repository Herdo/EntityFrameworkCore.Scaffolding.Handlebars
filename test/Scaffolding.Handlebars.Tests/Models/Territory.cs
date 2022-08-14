using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding.Handlebars.Tests.Models
{
    [Table("Territory")]
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [StringLength(20)]
        public TerritoryId TerritoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(Employee.Territories))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
namespace Scaffolding.Handlebars.Tests
{
    public partial class HbsCSharpScaffoldingGeneratorTests
    {
        private static class ExpectedEntities
        {
            public const string CategoryClass =
@"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    /// <summary>
    /// A category of products
    /// </summary>
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
";

            public const string ProductClass =
@"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
";

            public const string EmployeeClass =
                @"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    public partial class Employee
    {
        public Employee()
        {
            Territories = new HashSet<Territory>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
";

            public const string TerritoryClass =
                @"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
";
        }

        private static class ExpectedEntitiesWithTransformMappings
        {
            public const string CategoryClass =
@"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    /// <summary>
    /// A category of products
    /// </summary>
    public partial class CategoryRenamed
    {
        public CategoryRenamed()
        {
            Products = new HashSet<ProductRenamed>();
        }

        public int CategoryIdRenamed { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        public string CategoryNameRenamed { get; set; }

        public virtual ICollection<ProductRenamed> Products { get; set; }
    }
}
";

            public const string ProductClass =
@"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    public partial class ProductRenamed
    {
        public int ProductIdRenamed { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPriceRenamed { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        public int? CategoryIdRenamed { get; set; }

        public virtual CategoryRenamed Category { get; set; }
    }
}
";
        }

        private static class ExpectedEntitiesNoEncoding
        {
            public const string CategoryClass =
                @"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    /// <summary>
    /// 产品
    /// </summary>
    public partial class Category : Entity<int>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
";

            public const string ProductClass =
                @"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    /// <summary>
    /// 产品
    /// </summary>
    public partial class Product : Entity<int>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
";
        }

        private static class ExpectedEntitiesWithAnnotations
        {
            public const string CategoryClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    /// <summary>
    /// A category of products
    /// </summary>
    [Table(""Category"")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
";

            public const string ProductClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    [Table(""Product"")]
    [Index(nameof(CategoryId), Name = ""IX_Product_CategoryId"")]
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(TypeName = ""money"")]
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(""Products"")]
        public virtual Category Category { get; set; }
    }
}
";

            public const string EmployeeClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    [Table(""Employee"")]
    public partial class Employee
    {
        public Employee()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Column(TypeName = ""datetime"")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = ""datetime"")]
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
";
            
            public const string TerritoryClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    [Table(""Territory"")]
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [StringLength(20)]
        public string TerritoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(Employee.Territories))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
";
        }

        private static class ExpectedEntitiesWithAnnotationsAndTransformMappings
        {
            public const string CategoryClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    /// <summary>
    /// A category of products
    /// </summary>
    [Table(""Category"")]
    public partial class CategoryRenamed
    {
        public CategoryRenamed()
        {
            Products = new HashSet<ProductRenamed>();
        }

        [Key]
        [Column(""CategoryId"")]
        public int CategoryIdRenamed { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        [Required]
        [Column(""CategoryName"")]
        [StringLength(15)]
        public string CategoryNameRenamed { get; set; }

        [InverseProperty(nameof(ProductRenamed.Category))]
        public virtual ICollection<ProductRenamed> Products { get; set; }
    }
}
";

            public const string ProductClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    [Table(""Product"")]
    [Index(nameof(CategoryId), Name = ""IX_Product_CategoryId"")]
    public partial class ProductRenamed
    {
        [Key]
        [Column(""ProductId"")]
        public int ProductIdRenamed { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(""UnitPrice"", TypeName = ""money"")]
        public decimal? UnitPriceRenamed { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        [Column(""CategoryId"")]
        public int? CategoryIdRenamed { get; set; }

        [ForeignKey(nameof(CategoryIdRenamed))]
        [InverseProperty(""Products"")]
        public virtual CategoryRenamed Category { get; set; }
    }
}
";
        }

        private static class ExpectedEntitiesWithAnnotationsNoEncoding
        {
            public const string CategoryClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    /// <summary>
    /// 产品
    /// </summary>
    [Table(""Category"")]
    public partial class Category : Entity<int>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
";

            public const string ProductClass =
                @"using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeNamespace
{
    /// <summary>
    /// 产品
    /// </summary>
    [Table(""Product"")]
    [Index(nameof(CategoryId), Name = ""IX_Product_CategoryId"")]
    public partial class Product : Entity<int>
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(TypeName = ""money"")]
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public byte[] RowVersion { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(""Products"")]
        public virtual Category Category { get; set; }
    }
}
";
        }

        private static class ExpectedEntitiesWithNullableNavigation
        {
            public const string CategoryClass =
@"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    /// <summary>
    /// A category of products
    /// </summary>
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        /// <summary>
        /// The name of a category
        /// </summary>
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
";

            public const string ProductClass =
@"using System;
using System.Collections.Generic;

namespace FakeNamespace
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public byte[]? RowVersion { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
";
        }
    }
}
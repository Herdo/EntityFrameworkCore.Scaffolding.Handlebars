﻿using Constants = Scaffolding.Handlebars.Tests.Helpers.Constants;
namespace Scaffolding.Handlebars.Tests
{
    public partial class HbsCSharpScaffoldingGeneratorTests
    {
        private static class ExpectedContexts
        {
            public static string ContextClass =
@"using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNamespace
{
    public partial class FakeDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(""" + Constants.Connections.SqlServerConnection.Replace(@"\",@"\\") + @""");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable(""Category"");

                entity.HasComment(""A category of products"");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasComment(""The name of a category"");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerKey);

                entity.ToTable(""Customer"");

                entity.Property(e => e.CustomerKey)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable(""Employee"");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType(""datetime"");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType(""datetime"");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        ""EmployeeTerritory"",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey(""TerritoryId""),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(""EmployeeId""),
                        j =>
                        {
                            j.HasKey(""EmployeeId"", ""TerritoryId"");

                            j.ToTable(""EmployeeTerritory"");

                            j.HasIndex(new[] { ""TerritoryId"" }, ""IX_EmployeeTerritory_TerritoryId"");

                            j.IndexerProperty<string>(""TerritoryId"").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable(""Product"");

                entity.HasIndex(e => e.CategoryId, ""IX_Product_CategoryId"");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UnitPrice).HasColumnType(""money"");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.ToTable(""Territory"");

                entity.Property(e => e.TerritoryId).HasMaxLength(20);

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
";
        }
        private static class ExpectedContextsWithTransformMappings
        {
            public static string ContextClass =
@"using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNamespace
{
    public partial class FakeDbContext : DbContext
    {
        public virtual DbSet<CategoryRenamed> Category { get; set; }
        public virtual DbSet<CustomerRenamed> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ProductRenamed> Product { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }

        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(""" + Constants.Connections.SqlServerConnection.Replace(@"\",@"\\") + @""");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryRenamed>(entity =>
            {
                entity.HasKey(e => e.CategoryIdRenamed);

                entity.ToTable(""Category"");

                entity.HasComment(""A category of products"");

                entity.Property(e => e.CategoryIdRenamed).HasColumnName(""CategoryId"");

                entity.Property(e => e.CategoryNameRenamed)
                    .HasColumnName(""CategoryName"")
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasComment(""The name of a category"");
            });

            modelBuilder.Entity<CustomerRenamed>(entity =>
            {
                entity.HasKey(e => e.CustomerKey);

                entity.ToTable(""Customer"");

                entity.Property(e => e.CustomerKey)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType(""datetime"");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType(""datetime"");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasMany(d => d.Territory)
                    .WithMany(p => p.Employee)
                    .UsingEntity<Dictionary<string, object>>(
                        ""EmployeeTerritory"",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey(""TerritoryId""),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(""EmployeeId""),
                        j =>
                        {
                            j.HasKey(""EmployeeId"", ""TerritoryId"");

                            j.ToTable(""EmployeeTerritory"");

                            j.HasIndex(new[] { ""TerritoryId"" }, ""IX_EmployeeTerritory_TerritoryId"");

                            j.IndexerProperty<string>(""TerritoryId"").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<ProductRenamed>(entity =>
            {
                entity.HasKey(e => e.ProductIdRenamed);

                entity.ToTable(""Product"");

                entity.HasIndex(e => e.CategoryIdRenamed, ""IX_Product_CategoryId"");

                entity.Property(e => e.ProductIdRenamed).HasColumnName(""ProductId"");

                entity.Property(e => e.CategoryIdRenamed).HasColumnName(""CategoryId"");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UnitPriceRenamed)
                    .HasColumnName(""UnitPrice"")
                    .HasColumnType(""money"");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryIdRenamed);
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.Property(e => e.TerritoryId).HasMaxLength(20);

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
";
        }
        private static class ExpectedContextsSupressOnConfiguring
        {
            public static string ContextClass =
@"using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNamespace
{
    public partial class FakeDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable(""Category"");

                entity.HasComment(""A category of products"");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasComment(""The name of a category"");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerKey);

                entity.ToTable(""Customer"");

                entity.Property(e => e.CustomerKey)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable(""Employee"");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType(""datetime"");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType(""datetime"");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        ""EmployeeTerritory"",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey(""TerritoryId""),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(""EmployeeId""),
                        j =>
                        {
                            j.HasKey(""EmployeeId"", ""TerritoryId"");

                            j.ToTable(""EmployeeTerritory"");

                            j.HasIndex(new[] { ""TerritoryId"" }, ""IX_EmployeeTerritory_TerritoryId"");

                            j.IndexerProperty<string>(""TerritoryId"").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable(""Product"");

                entity.HasIndex(e => e.CategoryId, ""IX_Product_CategoryId"");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UnitPrice).HasColumnType(""money"");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.ToTable(""Territory"");

                entity.Property(e => e.TerritoryId).HasMaxLength(20);

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
";
        }
        private static class ExpectedContextsSupressOnConfiguringWithTransformMappings
        {
            public static string ContextClass =
@"using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNamespace
{
    public partial class FakeDbContext : DbContext
    {
        public virtual DbSet<CategoryRenamed> Category { get; set; }
        public virtual DbSet<CustomerRenamed> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ProductRenamed> Product { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }

        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryRenamed>(entity =>
            {
                entity.HasKey(e => e.CategoryIdRenamed);

                entity.ToTable(""Category"");

                entity.HasComment(""A category of products"");

                entity.Property(e => e.CategoryIdRenamed).HasColumnName(""CategoryId"");

                entity.Property(e => e.CategoryNameRenamed)
                    .HasColumnName(""CategoryName"")
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasComment(""The name of a category"");
            });

            modelBuilder.Entity<CustomerRenamed>(entity =>
            {
                entity.HasKey(e => e.CustomerKey);

                entity.ToTable(""Customer"");

                entity.Property(e => e.CustomerKey)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType(""datetime"");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType(""datetime"");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasMany(d => d.Territory)
                    .WithMany(p => p.Employee)
                    .UsingEntity<Dictionary<string, object>>(
                        ""EmployeeTerritory"",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey(""TerritoryId""),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(""EmployeeId""),
                        j =>
                        {
                            j.HasKey(""EmployeeId"", ""TerritoryId"");

                            j.ToTable(""EmployeeTerritory"");

                            j.HasIndex(new[] { ""TerritoryId"" }, ""IX_EmployeeTerritory_TerritoryId"");

                            j.IndexerProperty<string>(""TerritoryId"").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<ProductRenamed>(entity =>
            {
                entity.HasKey(e => e.ProductIdRenamed);

                entity.ToTable(""Product"");

                entity.HasIndex(e => e.CategoryIdRenamed, ""IX_Product_CategoryId"");

                entity.Property(e => e.ProductIdRenamed).HasColumnName(""ProductId"");

                entity.Property(e => e.CategoryIdRenamed).HasColumnName(""CategoryId"");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UnitPriceRenamed)
                    .HasColumnName(""UnitPrice"")
                    .HasColumnType(""money"");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryIdRenamed);
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.Property(e => e.TerritoryId).HasMaxLength(20);

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
";
        }
        public static class ExpectedContextsWithAnnotations
        {
            public static string ContextClass =
@"using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNamespace
{
    public partial class FakeDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(""" + Constants.Connections.SqlServerConnection.Replace(@"\",@"\\") + @""");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasComment(""A category of products"");

                entity.Property(e => e.CategoryName).HasComment(""The name of a category"");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerKey).IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        ""EmployeeTerritory"",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey(""TerritoryId""),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(""EmployeeId""),
                        j =>
                        {
                            j.HasKey(""EmployeeId"", ""TerritoryId"");

                            j.ToTable(""EmployeeTerritory"");

                            j.HasIndex(new[] { ""TerritoryId"" }, ""IX_EmployeeTerritory_TerritoryId"");

                            j.IndexerProperty<string>(""TerritoryId"").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
";
        }
        public static class ExpectedContextsWithAnnotationsAndTransformMappings
        {
            public static string ContextClass =
@"using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FakeNamespace
{
    public partial class FakeDbContext : DbContext
    {
        public virtual DbSet<CategoryRenamed> Category { get; set; }
        public virtual DbSet<CustomerRenamed> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ProductRenamed> Product { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }

        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(""" + Constants.Connections.SqlServerConnection.Replace(@"\",@"\\") + @""");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryRenamed>(entity =>
            {
                entity.HasComment(""A category of products"");

                entity.Property(e => e.CategoryNameRenamed).HasComment(""The name of a category"");
            });

            modelBuilder.Entity<CustomerRenamed>(entity =>
            {
                entity.Property(e => e.CustomerKey).IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasMany(d => d.Territory)
                    .WithMany(p => p.Employee)
                    .UsingEntity<Dictionary<string, object>>(
                        ""EmployeeTerritory"",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey(""TerritoryId""),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(""EmployeeId""),
                        j =>
                        {
                            j.HasKey(""EmployeeId"", ""TerritoryId"");

                            j.ToTable(""EmployeeTerritory"");

                            j.HasIndex(new[] { ""TerritoryId"" }, ""IX_EmployeeTerritory_TerritoryId"");

                            j.IndexerProperty<string>(""TerritoryId"").HasMaxLength(20);
                        });
            });

            modelBuilder.Entity<ProductRenamed>(entity =>
            {
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
";
        }

    }
}

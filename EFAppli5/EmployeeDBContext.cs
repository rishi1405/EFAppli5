using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EFAppli5
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // This line will tell entity framework to use stored procedures
            // when inserting, updating and deleting Employees
            //modelBuilder.Entity<Employee>().MapToStoredProcedures();
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
            .MapToStoredProcedures(p => p.Insert(x => x.HasName("InsertEmployee")));
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Update(x => x.HasName("UpdateEmployee")));
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Delete(x => x.HasName("DeleteEmployee")));

            base.OnModelCreating(modelBuilder);
        }
    }
}
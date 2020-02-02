using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Div
{
    //I am using EF Core.I want my base class to keep reference of CreateByUser, and LastModifiedByUser.Unfortunately I can only get it to work with one foreign key.When I try to add a second foreign key I get this error:


    //Introducing FOREIGN KEY constraint 'FK_Assignments_Users_LastModifiedByUserId' on table 'Assignments' may cause cycles or multiple cascade paths.Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints. Could not create constraint or index. See previous errors.Note that I can use "Add-Migration" with out any errors, but once I run "Update-Database" it errors.


    //Below is the relevant code to the problem and error.

    public class ApplicationContext : DbContext
    {
        public DbSet<DivUser> DivUsers { get; set; }
        public DbSet<DivAssignment> DivAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DivAssignment>()
                .HasRequired(c => c.CreatedByUser)
                .WithMany(u => u.CreatedDivAssignments)
                .HasForeignKey(c => c.CreatedByUserId)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<DivAssignment>()
                .HasRequired(c => c.LastModifiedByUser)
                .WithMany(u => u.ModifiedDivAssignments)
                .HasForeignKey(c => c.LastModifiedByUserId)
                .WillCascadeOnDelete(false);
        }
    }
}

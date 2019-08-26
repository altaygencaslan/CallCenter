using CallCenter.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Business
{
    public class CallCenterDbContext : DbContext
    {
        public CallCenterDbContext() : base("CallCenterDbContext")
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Employee>()
                        .HasOptional(h => h.TicketList);


            modelBuilder.Entity<Ticket>()
                        .HasOptional(h => h.ResponsedUser)
                        .WithMany(w => w.TicketList);


            //base.OnModelCreating(modelBuilder);
        }
    }
}

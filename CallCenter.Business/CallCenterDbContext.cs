using CallCenter.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //TODO: ALTAY tabloları çoğul yapmayı engelle

            base.OnModelCreating(modelBuilder);
        }
    }
}

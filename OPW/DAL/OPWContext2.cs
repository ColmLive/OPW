using OPW.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OPW.DAL
{
    public class OPWContext2:DbContext
    {
        public OPWContext2() : base("OPWContext2")
        {
        }

        public DbSet<Work> Opwwork2 { get; set; }
        public DbSet<Property> Opwproperty2 { get; set; }
        public DbSet<Authorisation> Opwauthorisation2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
                     

    }
}
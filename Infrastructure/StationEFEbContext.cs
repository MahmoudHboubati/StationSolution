using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class EFBaseContext : DbContext, IDisposable
    {
        public EFBaseContext() : base("name=StationDB") { }
    }

    public class StationEFEbContext : EFBaseContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationStatus>().ToTable("tblStationStatus");
        }

        public IDbSet<StationStatus> StationsStatuses { get; set; }
    }
}

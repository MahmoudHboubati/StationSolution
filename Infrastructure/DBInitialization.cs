using Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StationDBInitializer : CreateDatabaseIfNotExists<StationEFEbContext>
    {
        protected override void Seed(StationEFEbContext context)
        {
            base.Seed(context);

            IList<StationStatus> defaultData = new List<StationStatus>();

            defaultData.Add(new StationStatus() { StationID = 100, isOnline = true, EventDateTime = DateTime.Now });

            foreach (StationStatus std in defaultData)
                context.StationsStatuses.Add(std);

            context.SaveChanges();

        }
    }
}

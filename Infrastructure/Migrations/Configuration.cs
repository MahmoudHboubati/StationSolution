namespace Infrastructure.Migrations
{
    using Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.StationEFEbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StationEFEbContext context)
        {
            base.Seed(context);

            IList<StationStatus> defaultData = new List<StationStatus>();

            defaultData.Add(new StationStatus() { StationID = 100, isOnline = true, EventDateTime = DateTime.Now });
            defaultData.Add(new StationStatus() { StationID = 102, isOnline = true, EventDateTime = DateTime.Now });
            defaultData.Add(new StationStatus() { StationID = 100, isOnline = true, EventDateTime = DateTime.Now });
            defaultData.Add(new StationStatus() { StationID = 105, isOnline = true, EventDateTime = DateTime.Now });
            defaultData.Add(new StationStatus() { StationID = 108, isOnline = true, EventDateTime = DateTime.Now.AddMinutes(-1) });
            defaultData.Add(new StationStatus() { StationID = 100, isOnline = true, EventDateTime = DateTime.Now.AddMinutes(-21) });
            defaultData.Add(new StationStatus() { StationID = 108, isOnline = true, EventDateTime = DateTime.Now.AddHours(-1) });
            defaultData.Add(new StationStatus() { StationID = 102, isOnline = true, EventDateTime = DateTime.Now.AddHours(-2) });

            defaultData.Add(new StationStatus() { StationID = 105, isOnline = true, EventDateTime = DateTime.Now.AddDays(-1) });
            defaultData.Add(new StationStatus() { StationID = 107, isOnline = true, EventDateTime = DateTime.Now.AddDays(-1) });
            defaultData.Add(new StationStatus() { StationID = 100, isOnline = true, EventDateTime = DateTime.Now.AddDays(-2) });
            defaultData.Add(new StationStatus() { StationID = 102, isOnline = true, EventDateTime = DateTime.Now.AddDays(-3) });

            foreach (StationStatus std in defaultData)
                context.StationsStatuses.AddOrUpdate(std);

        }
    }
}

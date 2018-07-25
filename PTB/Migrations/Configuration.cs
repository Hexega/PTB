namespace PTB.Migrations
{
    using PTB.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PTB.Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PTB.Context.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Accounts.AddOrUpdate(x => x.AccountId,
                new Account() { AccountName = "Hexega", Password = "091klok", Server = "http://tx128.atergatis.ir", Speed = 128, Tribe = TribeType.Teutons });
        }
    }
}

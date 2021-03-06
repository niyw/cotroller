﻿using MongoDB.Driver;
using niyw.cotroller.AgentPools;
using niyw.cotroller.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace niyw.cotroller.MongoDB
{
    [ConnectionStringName("Default")]
    public class cotrollerMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();
        public IMongoCollection<Pool> AgentPools => Collection<Pool>();
        public IMongoCollection<Project> Projects => Collection<Project>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<AppUser>(b =>
            {
                /* Sharing the same "AbpUsers" collection
                 * with the Identity module's IdentityUser class. */
                b.CollectionName = "AbpUsers";
            });
        }
    }
}

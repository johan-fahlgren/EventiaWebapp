﻿using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend
{
    public class Admin
    {

        private readonly DbContextOptions _options;

        public Admin(DbContextOptions options)
        {
            this._options = options;
        }

        public static void PredTestDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(
                @"server=(localdb)\MSSQLLocalDB;database=EF_Test_EventiaDb");

            //var database = new Database(optionsBuilder.Options);
        }

    }
}
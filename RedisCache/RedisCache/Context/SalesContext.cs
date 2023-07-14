﻿using Microsoft.EntityFrameworkCore;
using RedisCache.Models;
using System.IO;

namespace RedisCache.Context
{
    public class SalesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public string DbPath { get; set; }

        public SalesContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Sales.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

    }  
}

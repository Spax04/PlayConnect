﻿using Game.Models.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace Game.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
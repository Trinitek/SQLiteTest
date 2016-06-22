using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.SQLite;
using SQLite_Test_2.Tables;

namespace SQLite_Test_2
{
    class Context : DbContext
    {
        public Context(SQLiteConnection connection) : base(connection, false) { }

        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasRequired(e => e.Address);
        }
    }
}

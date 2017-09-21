using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Mvc_db.Models
{
    public class GirlDbContext : DbContext
    {
        public DbSet<Girl> girls { get; set; }
    }
}
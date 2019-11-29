﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class DataDetailContext:DbContext
    {
        public DataDetailContext(DbContextOptions<DataDetailContext> options):base(options)
        {


        }
        public DbSet<DataDetails> DataDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChartJSAsync.Models;

namespace ChartJSAsync.Data
{
    public class ChartJSAsyncContext : DbContext
    {
        public ChartJSAsyncContext (DbContextOptions<ChartJSAsyncContext> options)
            : base(options)
        {
        }

        public DbSet<ChartJSAsync.Models.InvoiceModel> InvoiceModel { get; set; }
    }
}

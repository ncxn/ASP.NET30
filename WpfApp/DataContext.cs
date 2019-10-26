using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp
{
    public class DataContext:DbContext
    {
        // DbSet properties declarations...

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

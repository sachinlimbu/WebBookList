using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookList.Core;

namespace WebBookList.Data
{
    public class WebBookListDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public WebBookListDbContext(DbContextOptions<WebBookListDbContext> options) : base(options)
        {

        }
    }
}

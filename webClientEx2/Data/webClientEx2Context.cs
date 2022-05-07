#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webClientEx2.Models;

namespace webClientEx2.Data
{
    public class webClientEx2Context : DbContext
    {
        public webClientEx2Context (DbContextOptions<webClientEx2Context> options)
            : base(options)
        {
        }

        public DbSet<webClientEx2.Models.Rate> Rate { get; set; }
    }
}

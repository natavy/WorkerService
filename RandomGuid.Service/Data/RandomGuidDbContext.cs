using Microsoft.EntityFrameworkCore;
using SampleWorkerService.Models;
using System;
using System.Linq;

namespace SampleWorkerService.Data
{
    public class RandomGuidDbContext : DbContext
    {
        public DbSet<RandomGuid> Guids { get; set; }
        public DbSet<GuidStatus> GuidStatus { get; set; }
       
        public RandomGuidDbContext(DbContextOptions<RandomGuidDbContext> options) : base(options)
        {

        }
    }
}

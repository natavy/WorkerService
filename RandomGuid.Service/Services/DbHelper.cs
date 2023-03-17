using Microsoft.EntityFrameworkCore;
using SampleWorkerService.Data;
using SampleWorkerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleWorkerService.Services
{
    public class DbHelper
    {
        private RandomGuidDbContext dbContext;

        private DbContextOptions<RandomGuidDbContext> GetAllOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<RandomGuidDbContext>();
            optionBuilder.UseSqlServer(AppSettings.ConnectionString);
            return optionBuilder.Options;
        }

        //GetTheLastItem
        public RandomGuid GetData()
        {
            using (dbContext = new RandomGuidDbContext(GetAllOptions()))
            {
                try
                {
                    var data = dbContext.Guids
                       .OrderByDescending(g => g.Id)
                       .FirstOrDefault();
                  
                    return data;
                   
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        //Seed data
        public void SeedData()
        {
            using (dbContext = new RandomGuidDbContext(GetAllOptions()))
            {
                
                RandomGuid data = new RandomGuid()
                {
                    Id = Guid.NewGuid(),
                    StatusId = RandomGuid.Status.Active,
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };


                dbContext.Guids.Add(data);

                dbContext.SaveChanges();
                
            }     
            

        }

       
    }
}


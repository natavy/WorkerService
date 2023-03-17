using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWorkerService.Models
{
    public class RandomGuid
    {
 
        public Guid Id { get; set; }    
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status StatusId { get; set; }

        public enum Status
        {
            Active = 1,
            Ready = 2,
            Saved = 3,
            Rejected = 4
        }

    }
   
}

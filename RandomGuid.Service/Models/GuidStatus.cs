

using System.ComponentModel.DataAnnotations;
using static SampleWorkerService.Models.RandomGuid;

namespace SampleWorkerService.Models
{
    public class GuidStatus
    {
        [Key, MaxLength(5)]
        public Status StatusId { get; set; }
        public string StatusName { get; set; }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;

namespace RandomGuid.Web.Models
{
    public partial class GuidViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status StatusId { get; set; }
        //public ICollection<GuidStatusViewModel> Statuses { get; set; }
    }
    public enum Status
    {

        Active = 1,
        Ready = 2,
        Saved = 3,
        Rejected = 4
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace RandomGuid.Web.Models
{
    public class TextFileViewModel
    {
        [Key]
        public int FileId { get; set; }

       public string FileName { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid GuidId { get; set; }
    }
}

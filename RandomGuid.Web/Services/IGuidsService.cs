using RandomGuid.Web.Models;
using System;
using System.Collections.Generic;

namespace RandomGuid.Web.Services
{
    public interface IGuidsService
    {
        public List<GuidViewModel> GetAll();
        public GuidViewModel GetGuidById(Guid id);
        public void Update(GuidViewModel guid);
        public void Details(GuidViewModel model);

        public TextFileViewModel GetFileName(string fileName); 
        public TextFileViewModel GetFileById(int fileId); 

    }
}

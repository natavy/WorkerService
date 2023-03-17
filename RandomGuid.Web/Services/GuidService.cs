using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RandomGuid.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomGuid.Web.Services
{
    public class GuidService : IGuidsService
    {
        private readonly GuidDbContext _db;
        public GuidService(GuidDbContext db)
        {
            _db = db;
        }
        
        public void Details(GuidViewModel model)
        {
            var guidToEdit = _db.Guids.SingleOrDefault(g => g.Id == model.Id);
            {
                guidToEdit.Id = model.Id;
                guidToEdit.CreationDate = model.CreationDate;
                guidToEdit.CreationDate = model.ModifiedDate;
                guidToEdit.StatusId = model.StatusId;
            }

        }

        public List<GuidViewModel> GetAll()
        {
           return  _db.Guids.ToList();
        }

        public GuidViewModel GetGuidById(Guid id)
        {
            return _db.Guids.Find(id);
        }

        public void Update(GuidViewModel guid)
        {
           
            _db.Entry(guid).State = EntityState.Modified;
            _db.SaveChanges();
        }


        public TextFileViewModel GetFileName(string fileName)
        {
            return _db.TextFiles.Find(fileName);
        }

        public TextFileViewModel GetFileById(int id)
        {
            //var id = db..OrderByDescending(p => p.StatusId == Status.Ready).FirstOrDefault().Id;

            return _db.TextFiles.OrderByDescending(t=>t.FileId==id).FirstOrDefault();
        }



    }
}

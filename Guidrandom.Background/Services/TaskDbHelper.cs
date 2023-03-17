using RandomGuid.Web.Models;
using System;
using System.IO;
using System.Linq;


namespace Guidrandom.Background
{
    public class TaskDbHelper
    {
        private readonly GuidDbContext _dbContext;
        GuidViewModel getData = new GuidViewModel();
        string filePath = @"C:\Users\tipot\source\repos\SampleWorkerService\Guidrandom.Background\";
        int counter = 1;

        public TaskDbHelper()
        {
            _dbContext = new GuidDbContext();
        }

        //Write data into file
        public void ReadDataAndWriteIntoFile()
        {
            try
            {
                    getData = _dbContext.Guids.OrderByDescending(i => i.ModifiedDate).Where(s => s.StatusId == Status.Ready).FirstOrDefault();
                    string myUniqueFileName = string.Format(@"{0}.txt", DateTime.Now.Ticks);
                    FileStream mystream = new FileStream(myUniqueFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter tw = new StreamWriter(mystream);
                    string wr = getData.Id + " " + getData.StatusId;
                    tw.WriteLine(wr);
                    tw.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update status from Ready to Saved
        public void UpdateData()
        {

            if (getData != null)
            {
                getData.StatusId = Status.Saved;
                _dbContext.SaveChanges();
            }

        }

        //Write document in Db
        public void AddDocument()
        {

            try
            {

                var files = new DirectoryInfo(filePath).GetFiles("*.txt*").OrderByDescending(f => f.LastWriteTime).FirstOrDefault();

                TextFileViewModel model = new TextFileViewModel();

                if (model != null && files != null)
                {
                    model.FileName = files.Name;
                    model.CreationDate = DateTime.Now;
                    model.GuidId = getData.Id;
                    _dbContext.Add(model);
                    _dbContext.SaveChanges();
                }
               
            }
            catch (Exception)
            {

                throw;
            }

         
        }

        //Update status to Rejected
        public void UpdateStatusToRejected()
        {
            getData.StatusId = Status.Rejected;
            
            _dbContext.SaveChanges();
        }

    }

}


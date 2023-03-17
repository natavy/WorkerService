using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using RandomGuid.Web.Models;
using RandomGuid.Web.Services;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;


namespace RandomGuid.Web.Controllers
{
    public class GuidController : Controller
    {
        private readonly GuidDbContext _db;
        private readonly IGuidsService _service;
        HttpClient client = new HttpClient();
        public GuidController(GuidDbContext db, IGuidsService service)
        {
            _db = db;
            _service = service;
        }

        public IActionResult Index()
        {


            var data = _service.GetAll();
            return View(data);
        }


        [HttpGet]
        public IActionResult Edit(Guid id, int fileId)
        {
            GuidDetailViewModel model = new GuidDetailViewModel();

            model.GuiDetail = _service.GetGuidById(id);
            model.TextFile = _service.GetFileById(fileId);


            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(GuidDetailViewModel model)
        {

            ////UPDATE DATA VIA API

            //if (ModelState.IsValid)
            //{
            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri(url);
            //        //var response = client.GetAsync("model" + model.Id.ToString());
            //        var result = client.PutAsJsonAsync(url, model);


            //        if (result.IsCompletedSuccessfully)
            //        {

            //            return RedirectToAction("Index");
            //        }
            //    }

            //}

            //return RedirectToAction(nameof(Index));



            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(model.GuiDetail);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }
            }
            else
            {

                return View();
            }
        }


    }
}

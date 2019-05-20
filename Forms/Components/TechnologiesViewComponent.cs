using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Forms.DAL;
using Forms.Models;
using Forms.ViewModel;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace Forms.Componeds
{
    public class TechnologiesViewComponent : ViewComponent
    {
        //private readonly IHostingEnvironment _hostingEnviroment;

        private IConferenceDate _conferenceDate;

        public ConferenceControlerViewModel _conferecneVievModel { get; set; }
        public TechnologiesViewComponent()
        {
            //_hostingEnviroment = environment;
            _conferenceDate = new JsonConferenceDate();
            _conferecneVievModel = new ConferenceControlerViewModel();
        }

        public IViewComponentResult Invoke()
        {
           

            var selectList = new List<SelectListItem>
            {
                new SelectListItem{Value=ConferenceType.Lecture.ToString(), Text="Wyklady" },
                new SelectListItem{Value=ConferenceType.WorkShop.ToString(), Text="Warsztaty" },
                new SelectListItem{Value=ConferenceType.Discussion.ToString(), Text="Dyskusja" }

            };

            ViewBag.ConferenceType = selectList;

            _conferecneVievModel.ConferenceUsers = _conferenceDate.GetSavedUsers().ToList();


            return View(_conferecneVievModel);
        }

    }



}

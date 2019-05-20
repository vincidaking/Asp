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

namespace Forms.Controllers
{
    public class ConferenceController : Controller
    {

        //1 polskie nazwy typow konferecnia na liscie zarejestrowanych
        //2 dodanie opcji wyslania avatara wraz z wyswietlaniem 
        //3 mackaroo.com wygenerowac plik i potraktowac go jako baze danych z ktoraj czytamy i do ktorej zapisujemy
        //4 formularz i lista na jednej stronie
        //pagination 

        private readonly IHostingEnvironment _hostingEnviroment;

        private IConferenceDate _conferenceDate;
        


        public ConferenceControlerViewModel _conferecneVievModel { get; set; }
        public ConferenceController(IHostingEnvironment environment)
        {
            _hostingEnviroment = environment;
            _conferenceDate = new JsonConferenceDate();           
            _conferecneVievModel = new ConferenceControlerViewModel();
        }


        public Dictionary<ConferenceType, string> ConferenceTypeTranslation = new Dictionary<ConferenceType, string>
        {
            { ConferenceType.Lecture,"Wykłady" },
            { ConferenceType.WorkShop,"Warsztaty" },
            { ConferenceType.Discussion,"Dyskusja"}
        };

        // GET: Conference
        public ActionResult Index()
        {

            var selectList = new List<SelectListItem>
            {
                new SelectListItem{Value=ConferenceType.Lecture.ToString(), Text="Wyklady" },
                new SelectListItem{Value=ConferenceType.WorkShop.ToString(), Text="Warsztaty" },
                new SelectListItem{Value=ConferenceType.Discussion.ToString(), Text="Dyskusja" }

            };

            ViewBag.ConferenceType = selectList;


            _conferecneVievModel.ConferenceUsers = _conferenceDate.GetSavedUsers().ToList();

            //var temp = new EntityConferenceDate();
            //foreach (var item in _conferenceDate.GetSavedUsers().ToList())
            //{
            //    temp.SaveUser(item);
            //}


            // _conferenceDate.Upgrade();



            return View(_conferecneVievModel);
        }

        // GET: Conference/Details/5


        // GET: Conference/Create
        public ActionResult Create()
        {


            var selectList = new List<SelectListItem>
            {
                new SelectListItem{Value=ConferenceType.Lecture.ToString(), Text="Wyklady" },
                new SelectListItem{Value=ConferenceType.WorkShop.ToString(), Text="Warsztaty" },
                new SelectListItem{Value=ConferenceType.Discussion.ToString(), Text="Dyskusja" }

            };

            ViewBag.ConferenceType = selectList;
            
            return View();
        }

        // POST: Conference/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(ConferenceUsers conferenceUser, IFormFile avatar)
        //{
        //    try
        //    {
        //        if (avatar != null)
        //        {
        //            var fileName = Path.Combine($"{_hostingEnviroment.WebRootPath}\\images\\avatarImages", Path.GetFileName(avatar.FileName));
        //            avatar.CopyTo(new FileStream(fileName, FileMode.Create));

        //            conferenceUser.Avatar = "/images/avatarImages/" + Path.GetFileName(avatar.FileName);

                    
        //        }
                
        //        _conferenceDate.SaveUser(conferenceUser);


        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ConferenceUsers conferenceUser, IFormFile avatar)
        {
            if (!ModelState.IsValid)
            {
                return View(_conferenceDate);
            }
            else
            {
                if (avatar != null)
                {
                    var fileName = Path.Combine($"{_hostingEnviroment.WebRootPath}\\images\\avatarImages", Path.GetFileName(avatar.FileName));
                    avatar.CopyTo(new FileStream(fileName, FileMode.Create));

                    conferenceUser.Avatar = "/images/avatarImages/" + Path.GetFileName(avatar.FileName);
                }
                _conferenceDate.SaveUser(conferenceUser);
                

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Conference/Edit/5



    }
}
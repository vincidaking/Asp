using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blood.DAL;
using Blood.Models;
using Blood.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Blood.Models.BloodType;

namespace Blood.Controllers
{
    public class BloodController : Controller
    {

        private IHostingEnvironment _environment;
        private IBloodDate _bloodDate;
        private IBloodDownloadDate _download;

        public static List<EventBlood> _EventBlood { get; set; }

        public BloodController(IHostingEnvironment environment)
        {
            _environment = environment;
            _bloodDate = new EntityBloodDate();
            _EventBlood = new List<EventBlood>();
            _download = new CsvBloodDownload();
        }


        // GET: Blood
        public ActionResult Index()
        {
            //_EventBlood = _bloodDate.GetSavedUsers().ToList();
            //var displayPostViewModel = _bloodDate.GetSavedUsers();//_EventBlood.Select(n => new DisplayViewModel

            //var displayPostViewModel = new DisplayViewModel();

            var displayPostViewModel = _bloodDate.GetSavedUsers().ToList().Select(n => new DisplayViewModel
            {
                FirstName = n.FirstName,
                LastName = n.LastName,
                Pesel = n.Pesel,
                BloodGroup = n.BloodGroup,
                BloodType = n.BloodType,
                //Date = _EventBlood.Select(x=>x.Date).Where(n.Person.Pesel=).ToList(),
                //DonatedBlood = _EventBlood.Select(x => x.DonatedBlood).ToList()
                EventBloods = n.EventBloods.Select(d => new EventBlood
                {
                    DonatedBlood = d.DonatedBlood,
                    Date = d.Date
                }
                ).ToList(),
                Sum = n.EventBloods.Sum(x => x.DonatedBlood)

            })
            ;




            return View(displayPostViewModel);
        }

        public ActionResult Person()
        {

            _EventBlood = _bloodDate.GetUsers().ToList();



            var displayPostViewModel = _EventBlood.Select(n => new DisplayViewModel

            {
                FirstName = n.Person.FirstName,
                LastName = n.Person.LastName,
                Pesel = n.Person.Pesel,
                BloodGroup = n.Person.BloodGroup,
                BloodType = n.Person.BloodType,

            });

            return View(displayPostViewModel);
        }




        // GET: Blood/Create
        public ActionResult Create()
        {

            var selectList1 = new List<SelectListItem>
            {
                new SelectListItem{Value=BloodType.Rh_Minus.ToString(), Text="Rh-" },
                new SelectListItem{Value=BloodType.Rh_Plus.ToString(), Text="Rh+" }
            };
            var selectList2 = new List<SelectListItem>
            {
                new SelectListItem{Value=BloodGroup.O.ToString(), Text="0" },
                new SelectListItem{Value=BloodGroup.A.ToString(), Text="A" },
                new SelectListItem{Value=BloodGroup.B.ToString(), Text="B" },
                new SelectListItem{Value=BloodGroup.AB.ToString(), Text="AB" }

            };

            ViewBag.BloodType = selectList1;
            ViewBag.BloodGroup = selectList2;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel postViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (postViewModel.Pesel == _EventBlood.Select(x => x.Person.Pesel).FirstOrDefault())
                    //{

                    //    var eevent = new EventBlood
                    //    {
                    //        //Id = Guid.NewGuid(),
                    //        Person = _EventBlood.Select(x => x.Person).FirstOrDefault(),
                    //        DonatedBlood = postViewModel.DonatedBlood,
                    //        Date = postViewModel.Date,
                    //    };
                    //    _bloodDate.SaveUser(eevent);

                    //}
                    //else
                    //{
                        var eevent = new EventBlood
                        {
                            Id = Guid.NewGuid(),
                            Person = new Person()
                            {
                                BloodGroup = postViewModel.BloodGroup,
                                BloodType = postViewModel.BloodType,
                                Pesel = postViewModel.Pesel,
                                FirstName = postViewModel.FirstName,
                                LastName = postViewModel.LastName
                            },
                            DonatedBlood = postViewModel.DonatedBlood,
                            Date = postViewModel.Date,
                        };
                        _bloodDate.SaveUser(eevent);

                    
                    return RedirectToAction(nameof(Index));

                };

                return View(postViewModel);
            }
            catch (Exception e)
            {
                return View(e);
            }

        }





       // [ActionName("xd")]
        public ActionResult CSV()
        {

            return View();
        }

        // POST: Post/Create
        //[ActionName("xd")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CSV(CSVUpdate _CSVUpdate)
        {
            try
            {
                var relativePath = Path.Combine(_CSVUpdate.CSVUrl.FileName);
                var path = Path.Combine(_environment.WebRootPath, "Upload", relativePath);

                using (var photoFile = new FileStream(path, FileMode.Create))
                {
                    _CSVUpdate.CSVUrl.CopyTo(photoFile);

                }
                foreach (var item in _download.GetDownload(path).ToList())
                {
                    _bloodDate.SaveUser(item);
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodDonor = _bloodDate.FindFirstOrDefault(id);
            if (bloodDonor == null)
            {
                return NotFound();
            }

            return View(bloodDonor);
        }

        // POST: Blood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var bloodDonor = _bloodDate.FindDonor(id);
            _bloodDate.Delete(bloodDonor, id);
            return RedirectToAction(nameof(Index));

        }

    }





}


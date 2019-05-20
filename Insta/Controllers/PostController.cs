using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Insta.DAL;
using Insta.Models;
using Insta.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Controllers
{
    public class PostController : Controller
    {
        private IHostingEnvironment _environment;
        private IInstaDate _instaDate;

        public PostController(IHostingEnvironment environment)
        {
            _environment = environment;
            _instaDate = new EntityPostDate();
        }
        public static List<Post> PublishedPosts { get; set; } = new List<Post>();

        // GET: Post
        public ActionResult Index()
        {
            var displayPostViewModel = PublishedPosts.Select(n => new DisplayPostViewModel
            {
                Title = n.Title,
                PhotoPath = n.PhotoPath,
                Tags = n.Tags.Select(t => t.Name).ToList()

            });
            return View(displayPostViewModel);

            //var displayPostViewModel = _instaDate.GetSavedUsers().Select(n => new DisplayPostViewModel
            //{
            //    Title = n.Title,
            //    PhotoPath = n.PhotoPath,
            //    Tags = n.Tags.Select(t => t.Name).ToList()

            //});

            //return View(_instaDate);
        }



        // GET: Post/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel postViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < postViewModel.PostedPhoto.Count; i++)
                    {

                        var relativePath = Path.Combine(postViewModel.PostedPhoto[i].FileName);
                        var path = Path.Combine(_environment.WebRootPath, "Upload", relativePath);

                            using (var photoFile = new FileStream(path, FileMode.Create))
                            {
                                postViewModel.PostedPhoto[i].CopyTo(photoFile);

                             
                            }


                    }


                    var post = new Post
                    {
                        Id = Guid.NewGuid(),
                        PhotoPath = postViewModel.PostedPhoto
                            .Select(n => "/Upload/"+n.FileName )
                            .ToList(),
                        Title = postViewModel.Title,
                        Tags = postViewModel.CommaSeperatedTags
                            .Split(' ')
                            .Select(n => new Tag { Name = n })
                            .ToList()
                    };
                    //TODO zapisz postu do bazy 
                    //TODO wybierania wiele zdjec 

                    //_instaDate.SaveUser(post);
                    PublishedPosts.Add(post);
                    return RedirectToAction(nameof(Index));
                }
                return View(postViewModel);
            }
            catch
            {
                return View();
            }
        }



    }
}
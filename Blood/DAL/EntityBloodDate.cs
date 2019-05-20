using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blood.Models;
using Blood.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Blood.DAL
{
    public class EntityBloodDate : IBloodDate, IDisposable
    {

        private Context _context = new Context();



        public IEnumerable<Person> GetSavedUsers()
        {

            _context.Database.EnsureCreated();





            return _context.Person.Select(n => new Person
            {
                //Person = n,
                //DonatedBlood = n.EventBloods.Select(x => x.DonatedBlood).FirstOrDefault(),
                //Date = n.EventBloods.Select(x => x.Date).FirstOrDefault(),
                FirstName = n.FirstName,
                LastName = n.LastName,
                Pesel = n.Pesel,
                BloodGroup = n.BloodGroup,
                BloodType = n.BloodType,
                EventBloods = n.EventBloods.Select(d => new EventBlood
                {
                    DonatedBlood = d.DonatedBlood,
                    Date = d.Date
                }
                ).ToList()

            });



        }

        public IEnumerable<EventBlood> GetUsers()
        {

            _context.Database.EnsureCreated();

            return _context.Person.Select(n => new EventBlood
            {
                Person = n,
            });



        }

        //public DisplayViewModel Details(string id)
        //{
        //    return _context.Person
        //        .Select(n => new DisplayViewModel
        //        {
        //            Pesel = n.Pesel,
        //            FirstName = n.FirstName,
        //            LastName = n.LastName,
        //            BloodType = n.BloodType,
        //            BloodGroup = n.BloodGroup,
        //             = n.BloodDonations
        //                .Select(bd => new BloodDonation
        //                {
        //                    Volume = bd.Volume,
        //                    DonationDate = bd.DonationDate
        //                }).ToList()
        //        })
        //         .FirstOrDefault(m => m.PESEL == id);
        //}

        public void SaveUser(EventBlood eventBlood)
        {


            var temp = _context.Person.Include(x => x.EventBloods).FirstOrDefault(x => x.Pesel == eventBlood.Person.Pesel);
            if(temp!=null)
            {
                temp.EventBloods.Add(new EventBlood
                {
                    Date = eventBlood.Date,
                    DonatedBlood = eventBlood.DonatedBlood

                });
                
            }
            else
            {
                _context.Add(eventBlood);

            }
            _context.SaveChanges();
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Person FindFirstOrDefault(string id)
        {
            return _context.Person
                .FirstOrDefault(m => m.Pesel == id);
        }

        public DisplayViewModel FindDonor(string id)
        {
            return _context.Person
                .Select(n => new DisplayViewModel
                {
                    Pesel = n.Pesel,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    BloodType = n.BloodType,
                    BloodGroup = n.BloodGroup,
                })
                 .FirstOrDefault(m => m.Pesel == id);
        }

        void Delete(PostViewModel postViewModel, string id)
        {
            var a = _context.Person
                .Select(n => new Person
                {
                    Pesel = n.Pesel,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    BloodType = n.BloodType,
                    BloodGroup = n.BloodGroup,

                })
                 .FirstOrDefault(m => m.Pesel == id);
            _context.Person.Remove(a);
            _context.SaveChanges();

        }

        public Person Details(string id)
        {
            throw new NotImplementedException();
        }

        void IBloodDate.Delete(DisplayViewModel displayViewModel, string id)
        {
            //var a = _context.Person
            //    .Select(n => new Person
            //    {
            //        Pesel = n.Pesel,
            //        FirstName = n.FirstName,
            //        LastName = n.LastName,
            //        BloodType = n.BloodType,
            //        BloodGroup = n.BloodGroup

            //    })
            //     .FirstOrDefault(m => m.Pesel == id);
            var tempo = _context.Person.FirstOrDefault(n => n.Pesel == id);


            _context.Person.Remove(tempo);
            _context.SaveChanges();
        }
    }
}

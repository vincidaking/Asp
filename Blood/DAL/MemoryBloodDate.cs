using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blood.Models;
using Blood.ViewModel;

namespace Blood.DAL
{
    public class MemoryBloodDate : IBloodDate
    {
        public static List<EventBlood> _EventBlood { get; private set; } = new List<EventBlood>();

        public void Delete(DisplayViewModel displayViewModel, string id)
        {
            throw new NotImplementedException();
        }

        public Person Details(string id)
        {
            throw new NotImplementedException();
        }

        public DisplayViewModel FindDonor(string id)
        {
            throw new NotImplementedException();
        }

        public Person FindFirstOrDefault(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventBlood> GetSavedUsers()
        {
            
            return _EventBlood;
        }

        public IEnumerable<EventBlood> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void SaveUser(EventBlood eventBlood)
        {
            //var eevent = new EventBlood
            //{
            //    Id = Guid.NewGuid(),
            //    Person = new Person()
            //    {
            //        BloodGroup = postViewModel.BloodGroup,
            //        BloodType = postViewModel.BloodType,
            //        Pesel = postViewModel.Pesel,
            //        FirstName = postViewModel.FirstName,
            //        LastName = postViewModel.LastName
            //    },
            //    DonatedBlood = postViewModel.DonatedBlood,
            //    Date = postViewModel.Date

            //};

            _EventBlood.Add(eventBlood);
        }

        IEnumerable<Person> IBloodDate.GetSavedUsers()
        {
            throw new NotImplementedException();
        }
    }
}

using Blood.Models;
using Blood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.DAL
{
    public interface IBloodDate
    {
        IEnumerable<Person> GetSavedUsers();
        void SaveUser(EventBlood eventBlood);
        IEnumerable<EventBlood> GetUsers();

        Person Details(string id);
        Person FindFirstOrDefault(string id);

        DisplayViewModel FindDonor(string id);

        void Delete(DisplayViewModel displayViewModel, string id);

    }
}

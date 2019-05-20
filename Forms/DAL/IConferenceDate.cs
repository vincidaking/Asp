using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.DAL
{
    public interface IConferenceDate
    {
        IEnumerable<ConferenceUsers> GetSavedUsers();
        void SaveUser(ConferenceUsers conferenceUsers);
        void Upgrade();

    }
}

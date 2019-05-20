using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Models;

namespace Forms.DAL
{
    public class MemoryConferenceDate : IConferenceDate
    {
        public static List<ConferenceUsers> ConferenceUsers { get; private set; } = new List<Models.ConferenceUsers>();

        public IEnumerable<ConferenceUsers> GetSavedUsers()
        {
            return ConferenceUsers;
        }

        public void SaveUser(ConferenceUsers conferenceUsers)
        {
            ConferenceUsers.Add(conferenceUsers);
        }

        public void Upgrade()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Models;

namespace Forms.DAL
{
    public class EntityConferenceDate : IConferenceDate, IDisposable
    {
        //public static List<ConferenceUsers> ConferenceUsers { get; private set; } = new List<Models.ConferenceUsers>();
        
        private  ConferenceContext _context = new ConferenceContext();
            
        public IEnumerable<ConferenceUsers> GetSavedUsers()
        {
            
            _context.Database.EnsureCreated();
            return _context.ConferenceUsers;
        }

        public void SaveUser(ConferenceUsers conferenceUsers)
        {
            _context.Add(conferenceUsers);
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

        public void Upgrade()
        {
            var temp = new List<ConferenceUsers>();
            temp = _context.ConferenceUsers.ToList();

            for (int i = 0; i < _context.ConferenceUsers.ToList().Count(); i++)
            {
                temp[i].Id = i;
                

            }

            _context.SaveChanges();



        }
    }
}

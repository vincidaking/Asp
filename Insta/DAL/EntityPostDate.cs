using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insta.Models;

namespace Insta.DAL
{
    public class EntityPostDate : IInstaDate, IDisposable
    {
        private Context _context = new Context();

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

        public IEnumerable<Post> GetSavedUsers()
        {

            _context.Database.EnsureCreated();
            return _context.Post;
        }

        public void SaveUser(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }
    }
}

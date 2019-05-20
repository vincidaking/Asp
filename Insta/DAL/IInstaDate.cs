using Insta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insta.DAL
{
    public interface IInstaDate
    {
        IEnumerable<Post> GetSavedUsers();
        void SaveUser(Post post);
    }
}

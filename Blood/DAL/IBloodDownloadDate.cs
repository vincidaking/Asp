using Blood.Models;
using Blood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blood.DAL
{
    public interface IBloodDownloadDate
    {
        IEnumerable<EventBlood> GetDownload(string temp);


    }
}

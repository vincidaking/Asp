using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Forms.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonFlatFileDataStore;

namespace Forms.DAL
{
    public class JsonConferenceDate : IConferenceDate
    {
        public static List<ConferenceUsers> ConferenceUsers { get; private set; } = new List<Models.ConferenceUsers>();

        public IEnumerable<ConferenceUsers> GetSavedUsers()
        {

            if(!ConferenceUsers.Any())
            using (StreamReader file = new StreamReader("File/MOCK_DATA.json"))
            {

                var serializer = new Newtonsoft.Json.JsonSerializer();
                    var json = (List<ConferenceUsers>)serializer.Deserialize(file, typeof(List<ConferenceUsers>));

                    
                    foreach (var item in json)
                    {
                        
                       
                        ConferenceUsers.Add(item);
                        
                    }
            }




            return ConferenceUsers;

        }

        public void SaveUser(ConferenceUsers conferenceUsers)
        {
            ConferenceUsers.Add(conferenceUsers);
           

            string zapis = JsonConvert.SerializeObject(ConferenceUsers.ToArray(), Formatting.Indented);

            System.IO.File.WriteAllText("File/MOCK_DATA.json", zapis);

        }
        public void Upgrade()
        {
            var temp = new List<ConferenceUsers>();
            temp = ConferenceUsers;
            for (int i = 0; i < ConferenceUsers.Count(); i++)
            {
                
                temp[i].Id = i;
            }
            string zapis = JsonConvert.SerializeObject(temp.ToArray(), Formatting.Indented);

            System.IO.File.WriteAllText("File/MOCK_DATA.json", zapis);

        }




    }
}

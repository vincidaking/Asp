using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blood.Models;
using Blood.ViewModel;
using CsvHelper;
using CsvHelper.Configuration;

namespace Blood.DAL
{
    public class CsvBloodDownload : IBloodDownloadDate
    {
        public static List<EventBlood> _EventBlood { get; private set; } = new List<EventBlood>();


        public IEnumerable<EventBlood> GetDownload(string temp)
        {
            using (var streamReader = File.OpenText(temp))
            {
                var reader = new CsvReader(streamReader);
                reader.Configuration.Delimiter = ",";
                //reader.Configuration.RegisterClassMap<PessoaCSVMap>();
                reader.Configuration.HasHeaderRecord = true;
                reader.Configuration.HeaderValidated = null;
                reader.Configuration.MissingFieldFound = null;


                var postViewModel = reader.GetRecords<PostViewModel>().ToList();


                for (int i = 0; i < postViewModel.Count(); i++)
                {
                    var eevent = new EventBlood
                    {
                        Id = Guid.NewGuid(),
                        Person = new Person()
                        {
                            FirstName = postViewModel[i].FirstName,
                            LastName = postViewModel[i].LastName,
                            Pesel = postViewModel[i].Pesel,
                            BloodGroup = postViewModel[i].BloodGroup,
                            BloodType = postViewModel[i].BloodType
                        },
                        DonatedBlood = postViewModel[i].DonatedBlood,
                        Date = postViewModel[i].Date

                    };
                    _EventBlood.Add(eevent);
                }

            }

            return _EventBlood;
        }

        //sealed class PessoaCSVMap : CsvClassMap<PessoaCSVMap>
        //{
        //    public PessoaCSVMap()
        //    {
        //        Map(m => m.Name).Index(0);
        //        Map(m => m.Surname).Index(1);
        //        Map(m => m.Age).Index(2);
        //    }
        //}
    }






}

using System;
using System.Linq;
using System.Collections.Generic;
using EmercomDisp.Model.Models;

namespace EmercomDisp.Service.Contracts.Contracts
{
    public class FakeCallService : ICallService
    {
        private static List<string> _categories = new List<string>()
        {
            "Low",
            "Medium",
            "High"
        };

        private List<Call> _callList = new List<Call>()
        {
            new Call
            {
                Id = 1,
                Adress = "Pushkina st., Kolotushkina House",
                Reason = "Fire",
                CallTime = new DateTime(2017,11,19,18,40,32),
                TransferTime = new DateTime(2017,11,19,18,45,00),
                ArriveTime = new DateTime(2017,11,19,18,50,00),
                FinishTime = new DateTime(2017,11,19,18,51,00),
                ReturnTime = new DateTime(2017,11,19,18,55,00),
                Victims = new List<Victim>()
                {
                    new Victim
                    {
                        Id = 1,
                        Name = "John"
                    },

                    new Victim
                    {
                        Id = 2,
                        Name = "Mary"
                    }
                },
                Brigade = new Brigade
                {
                    Id = 1,
                    Members = new List<string>()
                    {
                        "Superman"
                    }
                },
                Incident = new Incident
                {
                    Id = 1,
                    Info = "Just fire",
                    Cause = "Smoking",
                    Equipment = "Superpower"
                },
                Category = _categories[0]
            },
            new Call
            {
                Id = 2,
                Adress = "Old van under the bridge",
                Reason = "Fire",
                CallTime = new DateTime(2017,11,19,18,40,32),
                TransferTime = new DateTime(2017,11,19,18,45,00),
                ArriveTime = new DateTime(2017,11,19,18,50,00),
                FinishTime = new DateTime(2017,11,19,18,51,00),
                ReturnTime = new DateTime(2017,11,19,18,55,00),
                Victims = new List<Victim>()
                {
                    new Victim
                    {
                        Id = 3,
                        Name = "Boozer 1"
                    },

                    new Victim
                    {
                        Id = 4,
                        Name = "Boozer 2"
                    }
                },
                Brigade = new Brigade
                {
                    Id = 1,
                    Members = new List<string>()
                    {
                        "Superman"
                    }
                },
                Incident = new Incident
                {
                    Id = 2,
                    Info = "Just fire",
                    Cause = "Smoking",
                    Equipment = "Superpower"
                },
                Category = _categories[1]
            }
        };

        public IEnumerable<Call> GetCalls()
        {
            return _callList;
        }
        public Call GetCallById(int id)
        {
            Call call = _callList.Where(c => c.Id == id).FirstOrDefault();
            return call;
        }

        public IEnumerable<Call> GetCallsByUrgency(string urgency)
        {
            List<Call> callList = _callList
                .Where(c => c.Category.ToLower() == urgency.ToLower())
                .ToList();

            return callList;
        }

        public IEnumerable<string> GetCategories()
        {
            return _categories;
        }
    }
}

using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public class FakeCallRepositoty : IRepository
    {
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
                    Members = new List<BrigadeMember>()
                    {
                        new BrigadeMember
                        {
                            Id = 1,
                            Name = "Superman"
                        }
                    }
                },
                Incident = new Incident
                {
                    Id = 1,
                    Info = "Just fire",
                    Cause = "Smoking",
                    Equipment = new List<Equipment>()
                    {
                        new Equipment
                        {
                            Id = 1,
                            Name = "Superpower"
                        }
                    }
                },
                Category = UrgencyEnum.Low
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
                    Members = new List<BrigadeMember>()
                    {
                        new BrigadeMember
                        {
                            Id = 1,
                            Name = "Superman"
                        }
                    }
                },
                Incident = new Incident
                {
                    Id = 2,
                    Info = "Just fire",
                    Cause = "Smoking",
                    Equipment = new List<Equipment>()
                    {
                        new Equipment
                        {
                            Id = 1,
                            Name = "Superpower"
                        }
                    }
                },
                Category = UrgencyEnum.High
            }
        };

        public IEnumerable<Call> GetCalls()
        {
            return _callList;
        }
    }
}

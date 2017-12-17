using EmercomDisp.Data.VictimsService;
using EmercomDisp.Model.Models;
using log4net;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Data.Repositories
{
    public class VictimsRepository : IVictimsRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public Victim GetVictimById(int id)
        {
            var victim = new Victim();
            using (var client = new VictimsServiceClient())
            {
                try
                {
                    client.Open();

                    var victimDto = client.GetVictimById(id);

                    if (victimDto != null)
                    {
                        victim.Name = victimDto.Name;
                        victim.Residence = victimDto.Residence;
                        victim.Age = victimDto.Age;
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return victim;
        }

        public IEnumerable<Victim> GetVictimsByIncidentId(int id)
        {
            var victimsList = new List<Victim>();
            using (var client = new VictimsServiceClient())
            {
                try
                {
                    client.Open();
                    var victimsListDto = client.GetVictimsByIncidentId(id);
                    if (victimsListDto != null)
                    {
                        foreach (var victimDto in victimsListDto)
                        {
                            var victim = new Victim()
                            {
                                Id = victimDto.Id,
                                Name = victimDto.Name,
                                Residence = victimDto.Residence,
                                Age = victimDto.Age
                            };
                            victimsList.Add(victim);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return victimsList;
        }

        public void AddVictim(Victim victim, int callId)
        {
            using (var client = new VictimsServiceClient())
            {
                try
                {
                    client.Open();

                    var newVictim = new VictimDto()
                    {
                        Name = victim.Name,
                        Residence = victim.Residence,
                        Age = victim.Age
                    };

                    client.AddVictim(newVictim, callId);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void UpdateVictim(Victim victim)
        {
            using (var client = new VictimsServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedVictim = new VictimDto()
                    {
                        Id = victim.Id,
                        Name = victim.Name,
                        Residence = victim.Residence,
                        Age = victim.Age
                    };

                    client.UpdateVictim(updatedVictim);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteVictim(int id)
        {
            using (var client = new VictimsServiceClient())
            {
                try
                {
                    client.Open();

                    client.DeleteVictim(id);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }
    }
}

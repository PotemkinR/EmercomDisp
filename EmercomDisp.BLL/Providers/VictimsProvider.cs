using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public class VictimsProvider : IVictimsProvider
    {
        public readonly IVictimsRepository _victimsRepository;

        public VictimsProvider(IVictimsRepository victimsRepository)
        {
            _victimsRepository = victimsRepository ?? throw new ArgumentNullException("Victims Repository");
        }

        public Victim GetVictimById(int id)
        {
            return _victimsRepository.GetVictimById(id);
        }

        public IEnumerable<Victim> GetVictimsByIncidentId(int id)
        {
            return _victimsRepository.GetVictimsByIncidentId(id);
        }

        public void AddVictim(Victim victim, int callId)
        {
            _victimsRepository.AddVictim(victim, callId);
        }

        public void UpdateVictim(Victim victim)
        {
            _victimsRepository.UpdateVictim(victim);
        }

        public void DeleteVictim(int id)
        {
            _victimsRepository.DeleteVictim(id);
        }
    }
}

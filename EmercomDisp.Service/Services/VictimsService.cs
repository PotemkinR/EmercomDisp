using EmercomDisp.Service.Contracts.Contracts;
using EmercomDisp.Service.Dto.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.Service.Services
{
    public class VictimsService : IVictimsService
    {
        public IEnumerable<VictimDto> GetVictimsForIncident(int incidentId)
        {
            throw new NotImplementedException();
        }
    }
}
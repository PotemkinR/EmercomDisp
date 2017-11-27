using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Clients
{
    public class CallClient : ICallClient
    {
        public Call GetCallById(int id)
        {    
            var call = new Call();
            using (var client = new ServiceReference1.CallServiceClient())
            {
                client.Open();

                var callDto = client.GetCallById(id);

                if (callDto != null)
                {
                    call.Id = callDto.Id;
                    call.Address = callDto.Address;
                    call.ArriveTime = callDto.ArriveTime;
                    call.BrigadeId = callDto.BrigadeId;
                    call.CallTime = callDto.CallTime;
                    call.Category = callDto.Category;
                    call.FinishTime = callDto.FinishTime;
                    call.IncidentId = callDto.IncidentId;
                    call.Reason = callDto.Reason;
                    call.ReturnTime = callDto.ReturnTime;
                    call.TransferTime = callDto.ReturnTime;
                }
                client.Close();
            }
            return call;
        }

        public IEnumerable<Call> GetCalls()
        {
            var calls = new List<Call>();
            using (var client = new ServiceReference1.CallServiceClient())
            {
                client.Open();
                var callsDto = client.GetCalls();
                if(callsDto != null)
                {
                    foreach(var callDto in callsDto)
                    {
                        var call = new Call
                        {
                            Id = callDto.Id,
                            Address = callDto.Address,
                            ArriveTime = callDto.ArriveTime,
                            BrigadeId = callDto.BrigadeId,
                            CallTime = callDto.CallTime,
                            Category = callDto.Category,
                            FinishTime = callDto.FinishTime,
                            IncidentId = callDto.IncidentId,
                            Reason = callDto.Reason,
                            ReturnTime = callDto.ReturnTime,
                            TransferTime = callDto.ReturnTime
                        };
                        calls.Add(call);
                    }
                }
                client.Close();
            }
            return calls;
        }

        public IEnumerable<Call> GetCallsByCategory(string category)
        {
            var calls = new List<Call>();
            using (var client = new ServiceReference1.CallServiceClient())
            {
                client.Open();

                var callsDto = client.GetCallsByCategory(category);

                if (callsDto != null)
                {
                    foreach (var callDto in callsDto)
                    {
                        var call = new Call
                        {
                            Id = callDto.Id,
                            Address = callDto.Address,
                            ArriveTime = callDto.ArriveTime,
                            BrigadeId = callDto.BrigadeId,
                            CallTime = callDto.CallTime,
                            Category = callDto.Category,
                            FinishTime = callDto.FinishTime,
                            IncidentId = callDto.IncidentId,
                            Reason = callDto.Reason,
                            ReturnTime = callDto.ReturnTime,
                            TransferTime = callDto.ReturnTime
                        };
                        calls.Add(call);
                    }
                }
                client.Close();
            }
            return calls;
        }

        public IEnumerable<string> GetCategories()
        {
            var categories = new List<string>();
            using (var client = new ServiceReference1.CallServiceClient())
            {
                client.Open();
                var categoriesDto = client.GetCategories();
                if (categoriesDto != null)
                {
                    foreach (var category in categoriesDto)
                    {
                        categories.Add(category);
                    }
                }
                client.Close();
            }
            return categories;
        }
    }
}

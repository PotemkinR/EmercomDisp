using EmercomDisp.Data.ServiceReference1;
using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Clients
{
    public class CallClient : ICallClient
    {
        public Call GetCallById(int id)
        {    
            var call = new Call();
            using (var client = new CallServiceClient())
            {
                client.Open();

                var callDto = client.GetCallById(id);

                if (callDto != null)
                {
                    call = MapCall(callDto);
                }
                client.Close();
            }
            return call;
        }

        public IEnumerable<Call> GetCalls()
        {
            var calls = new List<Call>();
            using (var client = new CallServiceClient())
            {
                client.Open();
                var callsDto = client.GetCalls();
                if(callsDto != null)
                {
                    foreach(var callDto in callsDto)
                    {
                        var call = MapCall(callDto);
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
            using (var client = new CallServiceClient())
            {
                client.Open();

                var callsDto = client.GetCallsByCategory(category);

                if (callsDto != null)
                {
                    foreach (var callDto in callsDto)
                    {
                        var call = MapCall(callDto);
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
            using (var client = new CallServiceClient())
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

        private Call MapCall(CallDto callDto)
        {
            var call = new Call
            {
                Id = callDto.Id,
                Address = callDto.Address,
                CallTime = callDto.CallTime,
                Category = callDto.Category,
                Reason = callDto.Reason
            };

            return call;
        }
    }
}

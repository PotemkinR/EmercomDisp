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
                    call = callDto;
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
                    foreach(var call in callsDto)
                    {
                        calls.Add(call);
                    }
                }
                client.Close();
            }
            return calls;
        }

        public IEnumerable<Call> GetCallsByUrgency(string urgency)
        {
            var calls = new List<Call>();
            using (var client = new ServiceReference1.CallServiceClient())
            {
                client.Open();

                var callsDto = client.GetCallsByUrgency(urgency);

                if (callsDto != null)
                {
                    foreach (var call in callsDto)
                    {
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

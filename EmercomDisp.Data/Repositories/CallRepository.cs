﻿using EmercomDisp.Data.CallService;
using EmercomDisp.Model.Models;
using log4net;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Data.Repositories
{
    public class CallRepository : ICallRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public Call GetCallById(int id)
        {    
            var call = new Call();
            using (var client = new CallServiceClient())
            {
                try
                {
                    client.Open();

                    var callDto = client.GetCallById(id);

                    if (callDto != null)
                    {
                        call = MapCall(callDto);
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return call;
        }

        public IEnumerable<Call> GetCalls()
        {
            var calls = new List<Call>();
            using (var client = new CallServiceClient())
            {
                try
                {
                    client.Open();
                    var callsDto = client.GetCalls();
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
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return calls;
        }

        public IEnumerable<Call> GetCallsByCategory(string category)
        {
            var calls = new List<Call>();
            using (var client = new CallServiceClient())
            {
                try
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
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        
            return calls;
        }

        public IEnumerable<string> GetCategories()
        {
            var categories = new List<string>();
            using (var client = new CallServiceClient())
            {
                try
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
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return categories;
        }

        public void UpdateCall(Call call)
        {
            using (var client = new CallServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedCall = new CallDto()
                    {
                        Id = call.Id,
                        Address = call.Address,
                        Reason = call.Reason,
                        CallTime = call.CallTime,
                        Category = call.Category,
                        IncidentDescription = call.IncidentDescription,
                        IncidentCause = call.IncidentCause
                    };

                    client.UpdateCall(updatedCall);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteCall(int id)
        {
            using (var client = new CallServiceClient())
            {
                try
                {
                    client.Open();

                    client.DeleteCall(id);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        private Call MapCall(CallDto callDto)
        {
            var call = new Call
            {
                Id = callDto.Id,
                Address = callDto.Address,
                CallTime = callDto.CallTime,
                Category = callDto.Category,
                Reason = callDto.Reason,
                IncidentDescription = callDto.IncidentDescription,
                IncidentCause = callDto.IncidentCause
            };

            return call;
        }
    }
}

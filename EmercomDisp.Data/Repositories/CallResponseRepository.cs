using EmercomDisp.Data.CallResponseService;
using EmercomDisp.Model.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Data.Repositories
{
    public class CallResponseRepository : ICallResponseRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public CallResponse GetCallResponseById(int id)
        {
            var callResponse = new CallResponse();
            using (var client = new CallResponseServiceClient())
            {
                try
                {
                    client.Open();

                    var callResponseDto = client.GetCallResponseById(id);

                    if (callResponseDto != null)
                    {
                        callResponse.Id = callResponseDto.Id;
                        callResponse.TransferTime = callResponseDto.TransferTime;
                        callResponse.ArriveTime = callResponseDto.ArriveTime;
                        callResponse.FinishTime = callResponseDto.FinishTime;
                        callResponse.ReturnTime = callResponseDto.ReturnTime;
                        callResponse.BrigadeName = callResponseDto.BrigadeName;
                        callResponse.IncidentId = callResponseDto.IncidentId;
                    }
                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
            return callResponse;
        }

        public IEnumerable<CallResponse> GetCallResponsesForCall(int callId)
        {
            var callResponses = new List<CallResponse>();
            using (var client = new CallResponseServiceClient())
            {
                try
                {
                    client.Open();

                    var callResponsesDto = client.GetCallResponsesForCall(callId);

                    if (callResponsesDto != null)
                    {
                        foreach (var callResponseDto in callResponsesDto)
                        {
                            var callResponse = new CallResponse()
                            {
                                Id = callResponseDto.Id,
                                TransferTime = callResponseDto.TransferTime,
                                ArriveTime = callResponseDto.ArriveTime,
                                FinishTime = callResponseDto.FinishTime,
                                ReturnTime = callResponseDto.ReturnTime,
                                BrigadeName = callResponseDto.BrigadeName
                            };
                            callResponses.Add(callResponse);
                        }
                    }
                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }

            return callResponses;
        }

        public void CreateCallResponse(CallResponse callResponse)
        {
            using (var client = new CallResponseServiceClient())
            {
                try
                {
                    client.Open();

                    var newCallResponse = new CallResponseDto
                    {
                        IncidentId = callResponse.IncidentId,
                        TransferTime = callResponse.TransferTime,
                        BrigadeName = callResponse.BrigadeName
                    };

                    client.CreateCallResponse(newCallResponse);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void UpdateCallResponse(CallResponse callResponse)
        {
            using (var client = new CallResponseServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedCallResponse = new CallResponseDto()
                    {
                        Id = callResponse.Id,
                        TransferTime = callResponse.TransferTime,
                        ArriveTime = callResponse.ArriveTime,
                        FinishTime = callResponse.FinishTime,
                        ReturnTime = callResponse.ReturnTime
                    };

                    client.UpdateCallResponse(updatedCallResponse);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteCallResponse(int id)
        {
            using (var client = new CallResponseServiceClient())
            {
                try
                {
                    client.Open();

                    client.DeleteCallResponse(id);

                    client.Close();
                }
                catch (Exception e)
                {
                    _log.Error(e.Message);
                }
            }
        }
    }
}

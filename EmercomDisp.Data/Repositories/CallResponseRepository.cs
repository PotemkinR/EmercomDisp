using EmercomDisp.Data.CallResponseService;
using EmercomDisp.Model.Models;
using log4net;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Data.Repositories
{
    public class CallResponseRepository : ICallResponseRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

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
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }

            return callResponses;
        }
    }
}

using EmercomDisp.Data.BrigadeService;
using EmercomDisp.Model.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace EmercomDisp.Data.Repositories
{
    public class BrigadeRepository : IBrigadeRepository
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public Brigade GetBrigadeById(int id)
        {
            var brigade = new Brigade();
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    var brigadeDto = client.GetBrigadeById(id);

                    if (brigadeDto != null)
                    {
                        brigade.Id = brigadeDto.Id;
                        brigade.Name = brigadeDto.Name;
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return brigade;
        }

        public Brigade GetBrigadeForCallResponse(int callResponseId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brigade> GetBrigades()
        {
            var brigades = new List<Brigade>();
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();
                    var brigadesDto = client.GetBrigades();
                    if (brigadesDto != null)
                    {
                        foreach (var brigadeDto in brigadesDto)
                        {
                            var brigade = new Brigade()
                            {
                                Id = brigadeDto.Id,
                                Name = brigadeDto.Name,
                                MemberCount = brigadeDto.MemberCount
                            };
                            brigades.Add(brigade);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return brigades.AsQueryable();
        }

        public void UpdateBrigade(Brigade brigade)
        {
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedBrigade = new BrigadeDto()
                    {
                        Id = brigade.Id,
                        Name = brigade.Name
                    };

                    client.UpdateBrigade(updatedBrigade);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void CreateBrigade(Brigade brigade)
        {
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    var newBrigade = new BrigadeDto()
                    {
                        Name = brigade.Name
                    };

                    client.CreateBrigade(newBrigade);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteBrigade(int id)
        {
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    client.DeleteBrigade(id);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public BrigadeMember GetBrigadeMemberById(int id)
        {
            var brigadeMember = new BrigadeMember();
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    var brigadeMemberDto = client.GetBrigadeMemberById(id);

                    if (brigadeMemberDto != null)
                    {
                        brigadeMember.Id = brigadeMemberDto.Id;
                        brigadeMember.Name = brigadeMemberDto.Name;
                        brigadeMember.BrigadeName = brigadeMemberDto.BrigadeName;
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return brigadeMember;
        }

        public IEnumerable<BrigadeMember> GetBrigadeMembers()
        {
            var brigadeMembers = new List<BrigadeMember>();
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();
                    var brigadeMembersDto = client.GetBrigadeMembers();
                    if (brigadeMembersDto != null)
                    {
                        foreach (var brigadeMemberDto in brigadeMembersDto)
                        {
                            var brigadeMember = new BrigadeMember()
                            {
                                Name = brigadeMemberDto.Name,
                                Id = brigadeMemberDto.Id,
                                BrigadeName = brigadeMemberDto.BrigadeName
                            };
                            brigadeMembers.Add(brigadeMember);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return brigadeMembers;
        }

        public void UpdateBrigadeMember(BrigadeMember brigadeMember)
        {
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedBrigadeMember = new BrigadeMemberDto()
                    {
                        Id = brigadeMember.Id,
                        Name = brigadeMember.Name,
                        BrigadeName = brigadeMember.BrigadeName
                    };

                    client.UpdateBrigadeMember(updatedBrigadeMember);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void CreateBrigadeMember(BrigadeMember brigadeMember)
        {
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    var newBrigadeMember = new BrigadeMemberDto()
                    {
                        Name = brigadeMember.Name,
                        BrigadeName = brigadeMember.BrigadeName
                    };

                    client.CreateBrigadeMember(newBrigadeMember);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteBrigadeMember(int id)
        {
            using (var client = new BrigadeServiceClient())
            {
                try
                {
                    client.Open();

                    client.DeleteBrigadeMember(id);

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

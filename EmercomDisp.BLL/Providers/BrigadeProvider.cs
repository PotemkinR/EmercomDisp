using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmercomDisp.BLL.Providers
{
    public class BrigadeProvider : IBrigadeProvider
    {
        private readonly IBrigadeRepository _brigadeRepository;

        public BrigadeProvider(IBrigadeRepository brigadeRepository)
        {
            _brigadeRepository = brigadeRepository ?? throw new ArgumentNullException("Brigade Repository");
        }

        public Brigade GetBrigadeById(int id)
        {
            return _brigadeRepository.GetBrigadeById(id);
        }

        public IQueryable<Brigade> GetBrigades()
        {
            return _brigadeRepository.GetBrigades();
        }

        public void UpdateBrigade(Brigade brigade)
        {
            _brigadeRepository.UpdateBrigade(brigade);
        }
        
        public void CreateBrigade(Brigade brigade)
        {
            _brigadeRepository.CreateBrigade(brigade);
        }

        public void DeleteBrigade(int id)
        {
            _brigadeRepository.DeleteBrigade(id);
        }

        public IEnumerable<BrigadeMember> GetBrigadeMembers()
        {
            return _brigadeRepository.GetBrigadeMembers();
        }

        public IEnumerable<BrigadeMember> GetBrigadeMembersByBrigadeId(int id)
        {
            return _brigadeRepository.GetBrigadeMembersByBrigadeId(id);
        }

        public BrigadeMember GetBrigadeMemberById(int id)
        {
            return _brigadeRepository.GetBrigadeMemberById(id);
        }

        public void UpdateBrigadeMember(BrigadeMember brigadeMember)
        {
            _brigadeRepository.UpdateBrigadeMember(brigadeMember);
        }

        public void DeleteBrigadeMember(int id)
        {
            _brigadeRepository.DeleteBrigadeMember(id);
        }

        public void CreateBrigadeMember(BrigadeMember brigadeMember)
        {
            _brigadeRepository.CreateBrigadeMember(brigadeMember);
        }
    }
}

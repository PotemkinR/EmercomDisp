﻿using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface ICallProvider
    {
        IEnumerable<Call> GetCalls();
        IEnumerable<Call> GetCallsByCategory(string urgency);
        Call GetCallById(int id);
        IEnumerable<string> GetCategories();
        int CreateCall(Call call);
        void UpdateCall(Call call);
        void DeleteCall(int id);
    }
}

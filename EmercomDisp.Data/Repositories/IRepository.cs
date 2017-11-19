﻿using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface IRepository
    {
        IEnumerable<Call> GetCalls();
    }
}

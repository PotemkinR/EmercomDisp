using System;

namespace EmercomDisp.BLL.ErrorProviders
{
    public class SimplestErrorProvider : IErrorProvider
    {
        public void ThrowError()
        {
            throw new NotImplementedException();
        }
    }
}

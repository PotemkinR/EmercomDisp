using System;

namespace EmercomDisp.BLL.MessageProvider
{
    public class SimpleMessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "TestMessage";
        }
    }
}

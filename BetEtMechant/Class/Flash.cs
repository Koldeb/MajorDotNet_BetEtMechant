using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace BetEtMechant.Class
{
    public class Flash
    {
        public string Message { get; set; }
        public TypeMessage TypeMessage { get; private set; }

        public Flash(string message, TypeMessage typeMessage)
        {
            Message = message;
            TypeMessage = typeMessage;
        }
    }

    public enum TypeMessage
    {
        SUCCESS,
        WARNING,
        DANGER,
        INFO
    }
}

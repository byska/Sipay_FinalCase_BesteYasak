using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Business.Services.Logger
{
    public class LoggerService:ILoggerService
    {
        public void Write(string message)
        {
            Log.Error("[Logger] - " + message);

        }
    }
}

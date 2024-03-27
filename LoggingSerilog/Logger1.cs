using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//---
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace LoggingSerilog
{
    public class Logger1
    {
        public ILogger CreateLogger2()
        {
             
            Log.Logger = new LoggerConfiguration()                         
                        .WriteTo.File("all-28-Test.logs",
                                        rollingInterval: RollingInterval.Minute)

                        // set default minimum level
                        .MinimumLevel.Debug()
                        .CreateLogger();

            ILogger lg = Log.Logger;
            
            return lg;            
        }
    }
}

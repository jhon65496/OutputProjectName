using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//---
using Serilog;
using Serilog.Core;
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
                                        outputTemplate: "{Timestamp:u} | {ProjectName} | [{Level:u3}] {Message:lj}{NewLine}"                                        )

                        // set default minimum level
                        .MinimumLevel.Debug()
                        .Enrich.With<ProjectNameEnricher>()
                        .CreateLogger();

            ILogger lg = Log.Logger;
            
            return lg;            
        }
    }

    class ProjectNameEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory pf)
        {
            // logEvent.AddPropertyIfAbsent(pf.CreateProperty("ProjectName", typeof(Program).Assembly.GetName().Name));
            // logEvent.AddPropertyIfAbsent(pf.CreateProperty("ProjectName", Assembly.GetCallingAssembly().GetName().Name));
            logEvent.AddPropertyIfAbsent(pf.CreateProperty("ProjectName", Assembly.GetEntryAssembly().GetName().Name));
            // 
        }
    }
}

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// --- --- --- --- ---
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog.Events;
using System.Reflection;

namespace LoggingSerilog
{
    public class LogExtensions
    {
        public static ILogger<T> LoggingInstance<T>()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("all-28-12HF-Test.logs",
                                outputTemplate: "{Timestamp:u} | " + typeof(T).Name  +
                                                " | {SourceContext} | [{Level:u3}] " +
                                                "{Message:lj} {NewLine}")
                .MinimumLevel.Debug()
                // --- --- --- --- --- --- ---
                // .Enrich.With<UtcTimestampEnricher>()
                   .Enrich.With<ProjectNameEnricher>()
                // --- --- --- --- --- --- ---
                .CreateLogger();

            ILoggerFactory factory = new LoggerFactory().AddSerilog(Log.Logger);
            return factory.CreateLogger<T>();
        }

    }

    class ProjectNameEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory pf)
        {
            // logEvent.AddPropertyIfAbsent(pf.CreateProperty("ProjectName", typeof(Program).Assembly.GetName().Name));            
            // logEvent.AddPropertyIfAbsent(pf.CreateProperty("ProjectName", Assembly.GetCallingAssembly().GetName().Name));
            logEvent.AddPropertyIfAbsent(pf.CreateProperty("ProjectName", Assembly.GetEntryAssembly().GetName().Name));
        }
    }
}

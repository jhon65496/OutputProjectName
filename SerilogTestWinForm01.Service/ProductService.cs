
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// 
using Serilog;
using Microsoft.Extensions.Logging;
using LoggingSerilog;


namespace SerilogTestWinForm01.Service
{
    public class ProductService
    {
        private readonly ILogger<ProductService> _logger;
        

        public ProductService()
        {
            _logger = LogExtensions.LoggingInstance<ProductService>();
        }


        public void CreateLoggerMessageProductService()
        {
            Thread.Sleep(1000);

            _logger.LogInformation($"MyNameSerilogTestWinForm01.Service | CreateLoggerMessageProductService()");
        }

    }
}

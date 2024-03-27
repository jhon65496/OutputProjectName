using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogTestWinForm01.Service
{
    public class ProductService
    {
        private readonly ILogger _log;

        public ProductService(ILogger log)
        {
            _log = log;       
        }


        public void CreateLoggerMessage()
        {
            _log.Information("MyName--SerilogTestWinForm01.Service | CreateLoggerMessage");
        }

    }
}

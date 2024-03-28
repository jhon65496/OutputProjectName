using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
// using LoggingSerilog3;
using LoggingSerilog;
using SerilogTestWinForm01.Service;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace SerilogTestWinForm01
{
    public partial class Form1 : Form
    {
        // ILogger _lg;
        private readonly ILogger<Form1> _logger;
        ProductService productService;

        public Form1()
        {
            InitializeComponent();

            _logger = LogExtensions.LoggingInstance<Form1>();
            // Logger1 lg = new Logger1();
            // _lg = lg.CreateLogger2();

            productService = new ProductService();

            CreateLoggerMessageForm1();
            CreateLoggerMessageProductService();
        }

        public void CreateLoggerMessageForm1()
        {
            _logger.LogInformation($"MyNameForm1 | `CreateLoggerMessageForm1()`");
        }
     
        public void CreateLoggerMessageProductService()
        {
            productService.CreateLoggerMessageProductService();
        }
    }
}

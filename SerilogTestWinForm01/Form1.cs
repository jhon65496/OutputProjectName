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


namespace SerilogTestWinForm01
{
    public partial class Form1 : Form
    {
        ILogger _lg;
        ProductService productService;

        public Form1()
        {
            InitializeComponent();

            Logger1 lg = new Logger1();
            _lg = lg.CreateLogger2();

            productService = new ProductService(_lg);

            CreateLoggerMessage();
        }

        public void CreateLoggerMessage()
        {
             _lg.Information($"SerilogTestWinForm01 | Message");

            productService.CreateLoggerMessage();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize CefSharp
            Cef.Initialize();
            // Create a new browser window
            _browser =
                new ChromiumWebBrowser("http://www.google.com/");
            // Add the new browser window to the form
            Controls.Add(_browser);
        }
    }
}

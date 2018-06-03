using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace MyForm2
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser _browser;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始程序
        /// </summary>
       public Action InitAction { get; set; }

        public SynchronizationContext UiCtx { get; private set; }

        static public Form1 AppForm { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            UiCtx = SynchronizationContext.Current;

            AppForm = this;


            InitAction?.Invoke();

            // Initialize CefSharp
            Cef.Initialize();
            // Create a new browser window
            _browser =
                new ChromiumWebBrowser("http://localhost:5000");
            this.panel2.
                  Controls.Add(_browser);
            _browser.LoadingStateChanged += _browser_LoadingStateChanged;
            _browser.LoadError += _browser_LoadError;
          
        }

        private void _browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            //reload
            if (e.CanReload)
            {
                this.Invoke(new Action(() => this.panel1.Visible = false));
               
            }  
        }

        private void _browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            Task.Delay(2000).ContinueWith(task => _browser.Load("http://localhost:5000"))
                ;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
        }

        public void HelloWorld()
        {
            MessageBox.Show(this, "Hello World", "Message");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UiCtx.Post(x => this.HelloWorld(), null);
        }
    }
}

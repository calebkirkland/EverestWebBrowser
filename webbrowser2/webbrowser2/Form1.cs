using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbrowser2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://google.com");
            webBrowser.DocumentCompleted += WebBroswer_DocumentCompleted;
        }

        private void WebBroswer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = webBrowser.DocumentTitle;

        }
        // makes the go button go to places
        private void btnGo_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
                web.Navigate(txtUrl.Text);

        }

        WebBrowser webTab = null;

        //for making new tabs
        private void btnNewtab_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "New Tab";
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://google.com:");
            txtUrl.Text = "https://google.com";
            webTab.DocumentCompleted += WebTab_DocumentCompleted;
        }
        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = webTab.DocumentTitle;

        }
        //makes the back button do things :^)
        private void btnBack_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web !=null)
            {
                if (web.CanGoBack)
                    web.GoBack();
            }
        }
        // makes the forward button do things :^)
        private void btnForward_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                    web.GoForward();
            }
        }
        //makes the enter button take you places from the text box
        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                if (web != null)
                {
                    web.Navigate(txtUrl.Text);
                }
            }
        }
        // exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //about button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Everest Web browser was created in C# by Caleb Kirkand, an 18 year old aspiring software engineer, for his final economics project. The idea was to creat a simple, functional, light, and elegant web browser. This browser will continue to be worked on and have frequent updates.");
        }

        // this closes the currently selected tab
        private void btnCloseTab_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Remove(tabControl.SelectedTab);
        }
        // this makes the refresh button refresh!
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }
    }
}

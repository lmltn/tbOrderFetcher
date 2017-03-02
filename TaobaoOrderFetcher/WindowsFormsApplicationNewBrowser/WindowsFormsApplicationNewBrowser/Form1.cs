using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using WebKit;

namespace WindowsFormsApplicationNewBrowser
{
    public partial class Form1 : Form
    {


        private WebKit.WebKitBrowser browser;

        public Form1()
        {
            InitializeComponent();
            browser = new WebKitBrowser();
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);
            browser.Navigate("http://www.taobao.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {

           // String fdfda = browser.DocumentText;

            StreamReader streamReader = new StreamReader("taobao_html.txt",System.Text.Encoding.UTF8);


            Console.WriteLine("no matter what happend today");
            
           string browerContent = streamReader.ReadToEnd();



         //  MatchCollection matchCollection = Regex.Matches(browerContent, "(?m)<script[^>]*>(\\w|\\W)*?</script[^>]*>");

           MatchCollection matchCollection = Regex.Matches(browerContent, "(?m)<script[^>]*>(\\w|\\W)*?</script[^>]*>");
           foreach (Match m in matchCollection) {

               string dst = m.Value;
               int fetchResult = dst.IndexOf("var data =");

               if(fetchResult > 0){

                   Console.WriteLine("============================");
                   Console.WriteLine(dst);
               }
               
           }
        }
    }
}

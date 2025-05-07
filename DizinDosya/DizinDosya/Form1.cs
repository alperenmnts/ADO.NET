using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Configuration;


namespace DizinDosya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string degistir = txtAra.Text;
            string degisen = txtDegis.Text;

            
            //int n = 0;  
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\Alperen\Desktop\Dosya", "*.txt", SearchOption.AllDirectories))
            {
                FileInfo f = new FileInfo(file);
                if (File.Exists(file) && f.Length > 0)
                {

                    StreamReader sr = new StreamReader(file, Encoding.Default);
                    string contents = sr.ReadToEnd();
                    sr.Close();

                    //string contents = File.ReadAllText(file);
                    
                    int text_length = contents.Length;
                    int new_text_length = contents.Replace(degisen, null).Length;
                    int value_count = (text_length - new_text_length) / degisen.Length;
                   // contents.Contains(degisen);

                    if (value_count > 0)
                    {

                        StreamWriter sw = new StreamWriter(file);
                        sw.Write(contents.Replace(degisen, degistir));
                        sw.Close();
                        listBox1.Items.Add(file.ToString());

                    }

                }




            }




        }


    }
}

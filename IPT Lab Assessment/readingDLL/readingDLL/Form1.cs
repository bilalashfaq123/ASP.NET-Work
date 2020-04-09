using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace readingDLL
{
    public partial class form1 : Form
    {
        public Type type;
        public form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                string fileName = Path.GetFileName(file);
                string reg = "([a-zA-Z0-9-_]*\\.dll)";
                bool isDll = Regex.IsMatch(fileName, reg);
                if (!isDll)
                {
                    MessageBox.Show("Not a DLL File, Please Select Dll File");
                    return;
                }
                label2.Text = fileName.ToString();
                
                try
                {
                    type = Assembly.LoadFile(file).GetType();
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MethodInfo[] methods = type.GetMethods();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Methods Info\n");
            foreach (MethodInfo mf in methods)
            {
                stringBuilder.Append(mf.ToString() + "\n");
            }

            richTextBox1.Text = stringBuilder.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConstructorInfo[] constructor = type.GetConstructors();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Constructors Info\n");
            foreach (ConstructorInfo cons in constructor)
            {
                stringBuilder.Append(cons.ToString() + "\n");
            }
            richTextBox1.Text = stringBuilder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraySearching
{
    public partial class Form1 : Form
    {
        public bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String regExp = "^[0-9]*$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(ArrayLength.Text, regExp) ||ArrayLength.Text == "")
            {
                MessageBox.Show("Invalid Arguments");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, regExp) || ArrayLength.Text == "")
            {
                MessageBox.Show("Invalid Arguments in Array Length");
                return;
            }

            int lengthtoAssign = Convert.ToInt32(textBox1.Text); //array length read

            int Searching = Convert.ToInt32(ArrayLength.Text);
            try
            {
                int[] array = new int[lengthtoAssign];

                Random radRandom = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = radRandom.Next(1000);
                }

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                SearchSingleThreaded(Searching, array);
                stopwatch.Stop();
                label2.Text = stopwatch.ElapsedMilliseconds.ToString() + " miliseconds";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SearchSingleThreaded(int search,int[] array)
        {
            bool fl = false;
            label4.Text = "Finding";
            for (int i = 0; i < array.Length; i++)
            {
                if (search == array[i])
                {
                    label4.Text = "Found";
                    fl = true;
                }
            }

            if(!fl)
                label4.Text = "Not Found :(";
        }

        private void ArrayLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            String regExp = "^[0-9]*$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(ArrayLength.Text, regExp) || ArrayLength.Text == "")
            {
                MessageBox.Show("Invalid Number to Search");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, regExp) || ArrayLength.Text == "")
            {
                MessageBox.Show("Invalid Arguments in Array Length");
                return;
            }

            try
            {


                int lengthtoAssign = Convert.ToInt32(textBox1.Text); //array length read


                int Searching = Convert.ToInt32(ArrayLength.Text);
                int[] array = new int[lengthtoAssign];
                Random radRandom = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = radRandom.Next(1000);
                }

                Stopwatch stopwatch = new Stopwatch();
                ParameterizedThreadStart param = new ParameterizedThreadStart(SearchingMultiThreaded);
                Thread[] threads = new Thread[5];
                stopwatch.Start();
                for (int i = 0; i < 5; i++)
                {
                    threads[i] = new Thread(param);
                    threads[i].Start(new DataClass(search: Searching, array: array,
                        startingIndex: (array.Length / 5) * (i), endingIndex: (array.Length / 5) * (i + 1) - 1));
                }

                for (int i = 0; i < 5; i++)
                {
                    threads[i].Join();
                }

                stopwatch.Stop();
                if (flag)
                {
                    label5.Text = "Found";
                }
                else
                {
                    label5.Text = "Not Found :(";
                }

                label3.Text = stopwatch.ElapsedMilliseconds.ToString() + " miliseconds";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private async void SearchingMultiThreaded(object data)
        { 
            DataClass dataClass = (DataClass) data;
            int[] arr = dataClass.array;
            int seachingNumber = dataClass.search;
            int startingIndex = dataClass.StartingIndex;
            int endingIndex = dataClass.EndingIndex;
            for (int i = startingIndex; i < endingIndex; i++)
            {
                if (arr[i] == seachingNumber)
                {
                    flag = true;
                }
            }
        }

        class DataClass
        {
            public int search;
            public int[] array;
            public int StartingIndex;
            public int EndingIndex;

            public DataClass(int search, int[] array, int startingIndex, int endingIndex)
            {
                this.search = search;
                this.array = array;
                StartingIndex = startingIndex;
                EndingIndex = endingIndex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //allow for working with files

namespace MidtermProject
{
    //Paxston Gulledge, Mario Olguin, Priscilla Chaidez
    //Midterm Project
    //July 26, 2017
    public partial class Form1 : Form
    {

        private StreamReader inFile; //Declaring a file stream object

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string inValue;
            bool isNumber = false;
            int num = 0;
            int counter = 0;
            int numSum = 0;
            int numMax = 0;
            int numMin = 99;
            int numEleven = 0;
            float average = 0;
            //Ensure that numbers file exists before we do anything
            if (File.Exists("numbers.txt"))
            {
                try
                {
                    //declare a streamreader to read the numbers file
                    inFile = new StreamReader("numbers.txt");
                    //our string will be set the the current line, and then so on til the end of file as long as
                    //it isn't null
                    while ((inValue = inFile.ReadLine()) != null)
                    {
                        //If the line is a number, it says num variable to that number, and isNumber to true allowing
                        //for the checks to happen
                        isNumber = (Int32.TryParse(inValue, out num));
                        if (isNumber)
                        {
                            //Add to the total
                            numSum = numSum + num;
                            //if the current number is greater than the current max(starts at 0) it becomes the new max
                            if (num > numMax)
                            {
                                numMax = num;

                            }
                            //if the current number is less than the current min(starts at 99) it becomes the new min
                            if (num < numMin)
                            {
                                numMin = num;
                            }
                            //if the current number is eleven it increments a counter specifically for 11
                            if (num == 11)
                            {
                                numEleven++;
                            }
                            //each line we increment the counter by 1
                            counter++;
                        }
                    }

                    //Display our information
                    lblDisplay.Text = "Numbers in the file: " + Convert.ToString(counter);
                    lblDisplay.Text = lblDisplay.Text + "\nSum of all numbers:" + numSum.ToString();
                    average = ((float)numSum / counter);
                    lblDisplay.Text = lblDisplay.Text + "\nAverage of the numbers:" + average.ToString("F");
                    lblDisplay.Text = lblDisplay.Text + "\nHighest number in the file:" + numMax.ToString();
                    lblDisplay.Text = lblDisplay.Text + "\nLowest number in the file:" + numMin.ToString();
                    lblDisplay.Text = lblDisplay.Text + "\nNumber of times 11 appears in the file:" + numEleven.ToString();
                }
                catch (System.IO.IOException exc)
                {
                    lblDisplay.Text = exc.Message;
                }
            }
            else
            {
                lblDisplay.Text = "File unavailable";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                inFile.Close();
            }
            catch
            {

            }
        }
    }
}

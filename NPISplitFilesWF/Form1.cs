using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPISplitFilesWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int recordCounter = 0;
            //int fileNumCounter = 0;
            string headerRow = "";
            //bool lineAdded = false;

            if (!string.IsNullOrEmpty(stateSelect.Text))
            {

                using (var reader = new StreamReader(sourceFile.Text))
                {
                    List<string> fileEntries = new List<string>();
                    headerRow = reader.ReadLine();

                    fileEntries.Add(headerRow);

                    while (!reader.EndOfStream)
                    {

                        string readerLine = reader.ReadLine();
                        List<string> readerArray = readerLine.Split(new string[] { "\",\"" }, StringSplitOptions.None).ToList<string>();
                        string readerArrayState = readerArray[23];

                        if (readerArrayState == stateSelect.Text.ToString())
                        {
                            fileEntries.Add(readerLine);
                            //recordCounter++;
                        }

                        /*
                        if (recordCounter >= 1000)
                        {
                            string toWrite = string.Join(Environment.NewLine, fileEntries.ToList()) + Environment.NewLine;
                            File.AppendAllText(string.Format(@"{0}\NPI_{1}_File.txt", destinationPath.Text, stateSelect.Text.ToString()), toWrite);
                            recordCounter = 0;
                            fileEntries = new List<string>();
                        }
                         */

                        /*
                        if (readerArrayState == "CT")
                        {
                            CTEntries.Add(readerLine);
                            fileEntries.Add(readerLine);
                            lineAdded = true;
                        }
                        else if (readerArrayState == "GA")
                        {
                            GAEntries.Add(readerLine);
                            fileEntries.Add(readerLine);
                            lineAdded = true;
                        }
                        else if (readerArrayState == "TX")
                        {
                            TXEntries.Add(readerLine);
                            fileEntries.Add(readerLine);
                            lineAdded = true;
                        }
                        */

                        /*
                        string toWrite = string.Join(Environment.NewLine, fileEntries.ToList());
                        File.AppendAllText(string.Format(@"{0}\NPI_{1}_File.txt", destinationPath.Text, "CT"), toWrite);
                        */

                        /*
                        if ((recordCounter >= 30000) && (!lineAdded))
                        {
                            fileEntries.Add(readerLine);
                            recordCounter = 0;
                        }

                        lineAdded = false;
                        */

                        //if (readerLine.Contains("\"CT\""))
                        //{
                        //    CTEntries.Add(readerLine);
                        //    //fileEntries.Add(readerLine);
                        //}
                        //if (readerLine.Contains("\"GA\""))
                        //{
                        //    GAEntries.Add(readerLine);
                        //}
                        //if (readerLine.Contains("\"TX\""))
                        //{
                        //    TXEntries.Add(readerLine);
                        //}

                        //fileEntries.Add(reader.ReadLine());
                        //if ((recordCounter >= 44000) || (reader.EndOfStream))
                        //if (reader.EndOfStream)
                        //{
                        //    fileNumCounter++;
                        //    //File.WriteAllLines(string.Format(@"{0}\NPI_CT_TX_GA_File{1}.txt", destinationPath.Text, fileNumCounter), fileEntries.ToList());
                        //    File.WriteAllLines(string.Format(@"{0}\NPI_CT_File.txt", destinationPath.Text), CTEntries.ToList());
                        //    File.WriteAllLines(string.Format(@"{0}\NPI_GA_File.txt", destinationPath.Text), GAEntries.ToList());
                        //    File.WriteAllLines(string.Format(@"{0}\NPI_TX_File.txt", destinationPath.Text), TXEntries.ToList());
                        //    File.WriteAllLines(string.Format(@"{0}\NPI_CT_GA_TX_File.txt", destinationPath.Text), fileEntries.ToList());
                        //    fileEntries = new List<string>();
                        //    recordCounter = 0;
                        //}
                    }

                    File.WriteAllLines(string.Format(@"{0}\NPI_{1}_File.txt", destinationPath.Text, stateSelect.Text.ToString()), fileEntries.ToList());

                    //string toFinalWrite = string.Join(Environment.NewLine, fileEntries.ToList()) + Environment.NewLine;
                    //File.AppendAllText(string.Format(@"{0}\NPI_{1}_File.txt", destinationPath.Text, stateSelect.Text.ToString()), toFinalWrite);
                }
            }
        }
    }
}

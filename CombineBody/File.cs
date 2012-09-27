
namespace CombineBody
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;

    public class File
    {
        /// <summary>
        /// gets or sets debug message
        /// </summary>
        public string debugMsg { get; set; }

        /// <summary>
        /// gets or sets file name
        /// </summary>
        private string filename { get; set; }

        /// <summary>
        /// Save Measured Body Data to txt file
        /// </summary>
        private StreamWriter measuredBodyData;

        /// <summary>
        /// basic constructor
        /// </summary>
        public File(bool save, bool read)
        {
            if (save == true)
            {
                this.filename = this.saveLidarDialog();
                this.measuredBodyData = new StreamWriter(this.filename);
            }

            if (read == true)
            {
                //this.readData = this.ReadLidarDialog();
            }
        }

        /// <summary>
        /// add data for save data to txt file
        /// </summary>
        /// <param name="data"></param>
        public void addDataForSave(List<int> data, int readCount)
        {
            string dataStr = readCount + " ";

            if (data.Count != 0 && data[0] == 205 && data[data.Count - 1] == 10)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == (data.Count - 1))
                    {
                        dataStr += data[i];
                    }
                    else
                    {
                        dataStr += data[i] + " ";
                    }
                }

                this.measuredBodyData.WriteLine(dataStr);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// close the save file
        /// </summary>
        public void closeSave()
        {
            this.measuredBodyData.Close();
        }

        /// <summary>
        /// save file dialog
        /// </summary>
        /// <returns></returns>
        private string saveLidarDialog()
        {
            string fileName = null;

            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Title = "Save Combine Body data to txt file";
            sfDialog.InitialDirectory = @"C:\Users\cho\Documents\Visual Studio 2010\Projects\ProjectData";
            sfDialog.Filter = "txt files (*.txt)|*.txt";
            sfDialog.FilterIndex = 1;
            sfDialog.RestoreDirectory = true;

            if (sfDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = sfDialog.FileName;
                }
                catch (Exception ex)
                {
                    this.debugMsg = ex.Message;
                }
            }

            return fileName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PKX_Extraction.Core.DataManager
{
    class File_Manager
    {
        public delegate void MaxProgressMethodInvoker(int amount);
        public event MaxProgressMethodInvoker MP;

        public File_Manager() 
        {

        }

        public byte[] OpenFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        public void WriteFile(string path, byte[] inputFile)
        {
            File.WriteAllBytes(path, inputFile);
        }

        public void LoadData(string path, Applicaton_Values obj)
        {
            byte[] inputFile;

            inputFile = OpenFile(path);
            obj.FileData = inputFile;

            MP(inputFile.Length);
        }
    }
}

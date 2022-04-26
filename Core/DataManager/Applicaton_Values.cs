using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    class Applicaton_Values
    {
        bool fileAdded;
        string path;
        byte[] fileData;
        int found;
        int selectIndex;
        int dexNum;
        int gen;
        bool endTask;
        int comboSelect;
        int subGen;

        public Applicaton_Values()
        {
            fileAdded = false;
            path = null;
            fileData = new byte[1];
            found = 0;
            selectIndex = 0;
            dexNum = 0;
            gen = 0;
            endTask = false;
            comboSelect = 0;
            subGen = 0;
        }

        public void PartReset()
        {
            fileData = new byte[1];
            found = 0;
            selectIndex = 0;
            dexNum = 0;
            gen = 0;
            subGen = 0;
        }

        public bool GetFileAdded()
        {
            return fileAdded;
        }

        public void SetFileAdded(bool booleon)
        {
            fileAdded = booleon;
        }

        public string GetPath()
        {
            return path;
        }

        public void SetPath(string filePath)
        {
            path = filePath;
        }

        public byte[] GetFileData()
        {
            return fileData;
        }

        public void SetFileData(byte[] data)
        {
            fileData = data;
        }

        public int GetFound()
        {
            return found;
        }

        public void SetFound(int amount)
        {
            found = amount;
        }

        public int GetSelectIndex()
        {
            return selectIndex;
        }

        public void SetSelectIndex(int index)
        {
            selectIndex = index;
        }

        public int GetDexNum()
        {
            return dexNum;
        }

        public void SetDexNum(int num)
        {
            dexNum = num;
        }

        public int GetGen()
        {
            return gen;
        }

        public void SetGen(int g)
        {
            gen = g;
        }

        public bool GetEndTask()
        {
            return endTask;
        }

        public void SetEndTask(bool end)
        {
            endTask = end;
        }

        public int GetComboSelect()
        {
            return comboSelect;
        }

        public void SetComboSelect(int index)
        {
            comboSelect = index;
        }

        public int GetSubGen()
        {
            return subGen;
        }

        public void SetSubGen(int sub)
        {
            subGen = sub;
        }
    }
}

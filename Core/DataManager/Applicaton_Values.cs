using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    public class Applicaton_Values
    {
        public bool FileAdded { get; set; } = false;
        public string Path { get; set; } = null;
        public byte[] FileData { get; set; } = new byte[1];
        public int Found { get; set; } = 0;
        public int SelectIndex { get; set; } = 0;
        public int DexNum { get; set; } = 0;
        public int Gen { get; set; } = 0;
        public bool EndTask { get; set; } = false;
        public int ComboSelect { get; set; } = 0;
        public int SubGen { get; set; } = 0;


        public void PartReset()
        {
            FileData = new byte[1];
            Found = 0;
            SelectIndex = 0;
            DexNum = 0;
            Gen = 0;
            SubGen = 0;
        }
    }
}

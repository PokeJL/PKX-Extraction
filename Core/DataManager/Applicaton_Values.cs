using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    /// <summary>
    /// Values needed for the application to function.
    /// Moved out of PKX_Extraction.cs to make passing of
    /// values easier.
    /// </summary>
    public class Applicaton_Values
    {
        public bool FileAdded { get; set; } = false; //Indicates if a file is added or not
        public string Path { get; set; } = null; //The file path
        public byte[] FileData { get; set; } = new byte[1]; //The byte data from the file
        public int Found { get; set; } = 0; //how many Pokemon found
        public int SelectIndex { get; set; } = 0; //The index of the selected item in the Pokemon found combo box
        public int DexNum { get; set; } = 0; //Stores one Pokemon dex number
        public int Gen { get; set; } = 0; //Stores current saved gen
        public bool EndTask { get; set; } = false; //Stops the working thread
        public int ComboSelect { get; set; } = 0; //Selected index of the game
        public int SubGen { get; set; } = 0; //Helps determine target game if data is stored diffrently between games in a gen

        //Resets some of the application values
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

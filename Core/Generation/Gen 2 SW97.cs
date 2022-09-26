using PKX_Extraction.Core.Resource;
using PKX_Extraction.Core.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.Generation
{
    /// <summary>
    /// Converts Space World 1997 Pokemon Gold Demo Pokemon data
    /// to data that can be read by Japanese release copies
    /// of Gold and Silver.
    /// For that no longer exist in the released version of
    /// the games the Pokemon is either set to an existing
    /// Pokemon in the evolutionary line they were suppose
    /// to belong to or if there is no Pokemon they have
    /// a connection with in the current games the dex
    /// number will not change and they will be whatever
    /// Pokemon the dex number corralates with in the 
    /// release versions of the games.
    /// </summary>
    class Gen_2_SW97
    {
        public Gen_2_SW97() 
        {
            
        }

        /// <summary>
        /// Process is so fast that a seperate worker thread is not used.
        /// Instead it is all done in the UI thread. This function reads form
        /// the file and gets the conversion going.
        /// </summary>
        /// <param name="pokemon">List of list of Pokemon</param>
        /// <param name="path">File path</param>
        /// <param name="val">The application values needed to run</param>
        /// <param name="gv">Values spacific to the targeted game</param>
        public void Start(List<List<byte>> pokemon, string path, Applicaton_Values val, Game_Values gv)
        {
            File_Manager fm = new File_Manager();
            byte[] inputFile;

            inputFile = fm.OpenFile(path);
            Rip(pokemon, inputFile, val, gv);
        }

        /// <summary>
        /// Converts the data in the input array to actual Pokemon
        /// data and stores the completed Pokemon in the Pokemon list.
        /// Note there are no major checks on the data to validate
        /// that this is actually valid data. Only percaution is
        /// to ensure that the Pokemon index does not go beyond 251
        /// or dex number is 0.
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="input"></param>
        /// <param name="val"></param>
        /// <param name="gv"></param>
        private void Rip(List<List<byte>> pokemon, byte[] input, Applicaton_Values val, Game_Values gv)
        {
            int count = 0;
            bool testMode = false;
            byte[] name = new byte[6];
            Data_Conversion con = new Data_Conversion();
            Dex_Conversion dex = new Dex_Conversion();
            Array_Manager arr = new Array_Manager();
            Gen_2_Beta_Data beta = new Gen_2_Beta_Data();
            List<byte> temp = new List<byte>();

            if (input.Length == gv.PartyDataSize && //Input file is a length of 48 bytes
                con.ConOneHex(input[0]) != 0 && //The Species is valid
                con.ConOneHex(input[0]) <= 251) //The Species does not go out of range
            {
                val.DexNum = con.ConOneHex(input[0]);
                val.Found = 1;
                pokemon.Add(temp);
                pokemon[0].Add(0x01); //Restore Pokemon header
                pokemon[0].Add(0x00); //Restore Pokemon header
                pokemon[0].Add(0xFF); //Restore Pokemon header
                arr.AddPart1Dto2D(pokemon, 0, input, 0, input.Length);
                pokemon[0][3] = dex.GetNewG2SW97PokeIndex(val.DexNum); //Updates species index
                pokemon[0][4] = 0x00; //Sets the item to None

                if (con.LittleEndian(input, 9, 2, true) == 0) //Checks to see if ID is 00000
                    testMode = true;

                beta.GetOT(testMode, name); //Gets OT based on ID

                for (int i = 51; i < 57; i++, count++) //Adds the OT
                    pokemon[0].Add(name[count]);

                beta.GetPokeName(val.DexNum, name); //Gets species name based on original species index

                count = 0;

                for (int i = 57; i < 63; i++, count++) //Adds the Pokemon name
                    pokemon[0].Add(name[count]);
            }
        }
    }
}

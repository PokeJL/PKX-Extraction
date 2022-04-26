using PKX_Extraction.Core.Resource;
using PKX_Extraction.Core.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.Generation
{
    class Gen_2_SW97
    {
        //Applicaton_Values val;

        public Gen_2_SW97() 
        {
            //val = new Applicaton_Values();
        }

        public void Start(List<List<byte>> pokemon, string path, Applicaton_Values val, Game_Values gv)
        {
            File_Manager fm = new File_Manager();
            byte[] inputFile;

            //val = obj;
            inputFile = fm.OpenFile(path);
            Rip(pokemon, inputFile, val, gv);
        }

        private void Rip(List<List<byte>> pokemon, byte[] input, Applicaton_Values val, Game_Values gv)
        {
            int count = 0;
            bool testMode = false;
            byte[] name = new byte[6];
            Data_Conversion con = new Data_Conversion();
            Dex_Conversion dex = new Dex_Conversion();
            Array_Manager arr = new Array_Manager();
            Gen_2_Beta_Data beta = new Gen_2_Beta_Data();

            if (input.Length == gv.GetSize() && //Input file is a length of 48 bytes
                con.ConOneHex(input[3]) != 0 && //The Species is valid
                con.ConOneHex(input[3]) <= 251) //The Species does not go out of range
            {
                val.SetDexNum(con.ConOneHex(input[0]));
                val.SetFound(1);
                pokemon[0][0] = 0x01; //Restore Pokemon header
                pokemon[0][1] = 0x00; //Restore Pokemon header
                pokemon[0][2] = 0xFF; //Restore Pokemon header
                arr.AddPart1Dto2D(pokemon, 0, 3, input, 0, gv.GetSize());
                pokemon[0][3] = dex.getNewG2SW97PokeIndex(val.GetDexNum()); //Updates species index
                pokemon[0][4] = 0x00; //Sets the item to None

                if (con.LittleEndian(input, 9, 2, true) == 0) //Checks to see if ID is 00000
                    testMode = true;

                beta.GetOT(testMode, name); //Gets OT based on ID

                for (int i = 51; i < 57; i++, count++) //Adds the OT
                    pokemon[0][i] = name[count];

                beta.GetPokeName(val.GetDexNum(), name); //Gets species name based on original species index

                count = 0;

                for (int i = 57; i < 63; i++, count++) //Adds the Pokemon name
                    pokemon[0][i] = name[count];
            }
        }
    }
}

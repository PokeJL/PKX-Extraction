using PKX_Extraction.Core.Resource;
using PKX_Extraction.Core.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKX_Extraction.Core.Generation
{
    class Data_Ripper
    {
        readonly Data_Conversion hex;
        readonly Array_Manager arr;
        readonly Dex_Conversion dexCon;
        readonly Exceptions exceptions;
        readonly PokeCrypto_Start start;
        readonly Validation check;
        readonly Pokemon_Value_Check checkP;

        public delegate void CurrentProgressMethodInvoker(int amount);
        public delegate bool EndThread();

        public event CurrentProgressMethodInvoker CP;
        public event EndThread End;

        public Data_Ripper() 
        {
            hex = new();
            arr = new();
            dexCon = new();
            exceptions = new();
            start = new();
            check = new();
            checkP = new();
        }

        /// <summary>
        /// Starts the linear search to find Pokemon in the RAM
        /// </summary>
        /// <param name="pokemon">List of Pokemon</param>
        /// <param name="val">Basic valuse needed for the application</param>
        /// <param name="offset_Data">The offsets of the Pokemon values</param>
        /// <param name="gv">Contains the target games parameters</param>
        public void SearchPokemon(List<List<byte>> pokemon, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] buffer = new byte[gv.PartyDataSize];
            int updateTime;
            byte[] inputFile = val.FileData;
            //Ensures that the RAM file is larger then a Pokemon in your party
            if (inputFile.Length >= gv.PartyDataSize)
            {
                updateTime = UpdateBar(inputFile.Length); //Gets update intervals

                //Loops to the end of the RAM file
                for (int i = 0; i < inputFile.Length; i++)
                {
                    //Ends the rip process
                    if (End() == true)
                    {
                        val.Found = 0;
                        break;
                    }
                    //Ensures the that the size for the Pokemon stored in the party plus the current
                    //index of the loop isn't past the input length.
                    //Initial check of data to make sure the current data doesn't have a checksum of 0
                    if (i + gv.PartyDataSize <= inputFile.Length && check.ChecksumStart(inputFile, gv.Option, i, val.Gen, val.SubGen, gv.Invert))
                    {
                        //loads data into buffer
                        for (int n = 0; n < gv.PartyDataSize; n++)
                        {
                            buffer[n] = inputFile[i + n];
                        }
                        //Checks the game values if the data is encrypted or not
                        if (gv.IsEncrypted == true)
                            Encrypted(pokemon, buffer, val, offset_Data, gv);
                        else
                            NonEncrypted(pokemon, buffer, val, offset_Data, gv);
                    }
                    //Updates the progress bar
                    ProgressUpdate(i, updateTime, inputFile);
                }
            }
            //Ensures that the game that the Pokemon is from is valid for gen 5.
            if (val.Found != 0 && val.Gen == 5)
            {
                exceptions.BWB2W2VsSeeker(ref pokemon, val.Found);
            }
        }

        /// <summary>
        /// Breaks the encryption if the data is encrypted
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="buffer"></param>
        /// <param name="val"></param>
        /// <param name="offset_Data"></param>
        /// <param name="gv"></param>
        private void Encrypted(List<List<byte>> pokemon, byte[] buffer, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] convert = new byte[1];
            //Breaks encryption based on gen
            if (val.Gen == 3)
                convert = start.PK3(buffer);
            else if (val.Gen == 4)
                convert = start.PK4(buffer);
            else if (val.Gen == 5)
                convert = start.PK5(buffer);
            else if (val.Gen == 6 || val.Gen == 7)
                convert = start.PK67(buffer);
            else if (val.Gen == 8)
                convert = start.PK8(buffer);
            //Battle tower shiny fix
            if (val.Gen == 3)
                exceptions.FRLGTrainerTower(ref convert);

            NonEncrypted(pokemon, convert, val, offset_Data, gv);
        }

        /// <summary>
        /// For non encrypted data and where it's determined if the data is a Pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="buffer"></param>
        /// <param name="val"></param>
        /// <param name="offset_Data"></param>
        /// <param name="gv"></param>
        private void NonEncrypted(List<List<byte>> pokemon, byte[] buffer, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            int currentDexNum;
            //Gets the Pokemon correct dex number to determine if the data is a Pokemon
            //Gen 1 and 3 have Pokemon with the incorrect numbers
            if (val.Gen == 1)
                currentDexNum = dexCon.GetGen1Num(hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert));
            else if (val.Gen == 3)
                currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert));
            else
                currentDexNum = hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert);          

            //Checks if the data is a Pokemon
            if (checkP.IsPokemon(buffer, currentDexNum, val, offset_Data, gv))
            {
                //Checks if the found Pokemon was already found else where in the RAM
                if (arr.UpdateCheck(pokemon, val.Found, buffer, val.Gen, val.SubGen, gv.Invert))
                {
                    //If the Pokemon is new add to the Pokemon list
                    arr.Array1Dto2D(pokemon, val.Found, gv.StorageDataSize, buffer);
                    val.Found += 1;
                }
            }
        }

        /// <summary>
        /// Updates progress bar
        /// </summary>
        /// <param name="progress">How much the loop has gone</param>
        /// <param name="time">the update time intervals</param>
        /// <param name="data">the data file</param>
        private void ProgressUpdate(int progress, int time, byte[] data)
        {
            if (progress % time == 0) //Update bar if module is 0
                CP(progress);
            else if (progress + 1 == data.Length) //Update bar if the next loop is the last
                CP(progress);
        }

        //163 allows for update intervals that don't slow down the process by delaying the update by a bit
        static private int UpdateBar(int size)
        {
            int timing;
            if (size <= 163)
                timing = size;
            else
                timing = (int)(size / 163);
            return timing;
        }
    }
}

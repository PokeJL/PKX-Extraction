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
        Data_Conversion hex;
        Array_Manager arr;
        Dex_Conversion dexCon;
        Exceptions exceptions;
        PokeCrypto_Start start;
        Validation check;
        Pokemon_Value_Check checkP;

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

        public void SearchPokemon(List<List<byte>> pokemon, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] buffer = new byte[gv.PartyDataSize];
            int updateTime;
            byte[] inputFile = val.FileData;

            if (inputFile.Length >= gv.PartyDataSize)
            {
                updateTime = UpdateBar(inputFile.Length);
                for (int i = 0; i < inputFile.Length; i++)
                {
                    //Ends the rip process
                    if (End() == true)
                    {
                        val.Found = 0;
                        break;
                    }

                    if (i + gv.PartyDataSize <= inputFile.Length && check.ChecksumStart(inputFile, gv.Option, i, val.Gen, val.SubGen, gv.Invert) /*hex.LittleEndian(inputFile, i + offset_Data.GetChecksum(), 2) != 0*/)
                    {
                        for (int n = 0; n < gv.PartyDataSize; n++)
                        {
                            buffer[n] = inputFile[i + n];
                        }

                        if (gv.IsEncrypted == true)
                            Encrypted(pokemon, buffer, i, val, offset_Data, gv);
                        else
                            NonEncrypted(pokemon, buffer, i, val, offset_Data, gv);
                    }

                    ProgressUpdate(i, updateTime, inputFile);
                }
            }
            //Ensures that the game that the Pokemon is from is valid for gen 5.
            if (val.Found != 0 && val.Gen == 5)
            {
                exceptions.BWB2W2VsSeeker(ref pokemon, val.Found);
            }
        }

        private void Encrypted(List<List<byte>> pokemon, byte[] buffer, int i, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] convert = new byte[1];

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

            if (val.Gen == 3)
                exceptions.FRLGTrainerTower(ref convert);

            NonEncrypted(pokemon, convert, i, val, offset_Data, gv);
        }

        private void NonEncrypted(List<List<byte>> pokemon, byte[] buffer, int i, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            bool update = false;
            int currentDexNum;

            if (val.Gen == 1)
                currentDexNum = dexCon.GetGen1Num(hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert));
            else if (val.Gen == 3)
                currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert));
            else
                currentDexNum = hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert);          

            if (checkP.IsPokemon(buffer, currentDexNum, val, offset_Data, gv))
            {
                arr.UpdateCheck(pokemon, val.Found, buffer, ref update, val.Gen, val.SubGen, gv.Invert);
                if (!update)
                {
                    arr.Array1Dto2D(pokemon, val.Found, gv.StorageDataSize, buffer);
                    val.Found += 1;
                }
            }
        }

        private void ProgressUpdate(int progress, int time, byte[] data)
        {
            if (progress % time == 0)
            {
                CP(progress);
            }
            else if (progress + 1 == data.Length)
            {
                CP(progress);
            }
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

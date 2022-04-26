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
        }

        public void SearchPokemon(List<List<byte>> pokemon, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] buffer = new byte[gv.GetSize()];
            int updateTime;
            byte[] inputFile = val.GetFileData();

            if (inputFile.Length >= gv.GetSize())
            {
                updateTime = UpdateBar(inputFile.Length);
                for (int i = 0; i < inputFile.Length; i++)
                {
                    //Ends the rip process
                    if (End() == true)
                    {
                        val.SetFound(0);
                        break;
                    }

                    if (i + gv.GetSize() <= inputFile.Length && check.ChecksumStart(inputFile, gv.GetOption(), i, val.GetGen(), val.GetSubGen(), gv.GetInvert()) /*hex.LittleEndian(inputFile, i + offset_Data.GetChecksum(), 2) != 0*/)
                    {
                        for (int n = 0; n < gv.GetSize(); n++)
                        {
                            buffer[n] = inputFile[i + n];
                        }

                        if (gv.GetIsEncrypted() == true)
                            Encrypted(pokemon, buffer, i, val, offset_Data, gv);
                        else
                            NonEncrypted(pokemon, buffer, i, val, offset_Data, gv);
                    }

                    ProgressUpdate(i, updateTime, inputFile);
                }
            }
            //Ensures that the game that the Pokemon is from is valid for gen 5.
            if (val.GetFound() != 0 && val.GetGen() == 5)
            {
                exceptions.BWB2W2VsSeeker(ref pokemon, val.GetFound());
            }
        }

        private void Encrypted(List<List<byte>> pokemon, byte[] buffer, int i, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] convert = new byte[1];

            if (val.GetGen() == 3)
                convert = start.PK3(buffer);
            else if (val.GetGen() == 4)
                convert = start.PK4(buffer);
            else if (val.GetGen() == 5)
                convert = start.PK5(buffer);
            else if (val.GetGen() == 6 || val.GetGen() == 7)
                convert = start.PK67(buffer);
            else if (val.GetGen() == 8)
                convert = start.PK8(buffer);

            if (val.GetGen() == 3)
                exceptions.FRLGTrainerTower(ref convert);

            NonEncrypted(pokemon, convert, i, val, offset_Data, gv);
        }

        private void NonEncrypted(List<List<byte>> pokemon, byte[] buffer, int i, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            bool update = false;
            int currentDexNum;

            if (val.GetGen() == 1)
                currentDexNum = dexCon.GetGen1Num(hex.LittleEndian(buffer, offset_Data.GetDex(), offset_Data.GetSizeDex(), gv.GetInvert()));
            else if (val.GetGen() == 3)
                currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(buffer, offset_Data.GetDex(), offset_Data.GetSizeDex(), gv.GetInvert()));
            else
                currentDexNum = hex.LittleEndian(buffer, offset_Data.GetDex(), offset_Data.GetSizeDex(), gv.GetInvert());

            //Value_Test testing = new();
            //testing.Test(buffer, currentDexNum, val, offset_Data, gv);

            if (hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != 0 && //Move 1 has an actual move
            hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) <= gv.GetNumOfMovesInGen() && //Move 1 is a valid move
            hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) <= gv.GetNumOfMovesInGen() && //Move 2 is a valid move
            hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) <= gv.GetNumOfMovesInGen() && //Move 3 is a valid move
            hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) <= gv.GetNumOfMovesInGen() && //Move 4 is a valid move
            currentDexNum <= gv.GetNumOfPokeInGen() && //Ensures the species is not outside the valid range
            hex.LittleEndian(buffer, offset_Data.GetDex(), offset_Data.GetSizeDex(), gv.GetInvert()) != 0 && //Not a glitch Pokemon
             hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) && //Move 1 != Move 2
            hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) && //Move 1 != Move 3
            hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) && //Move 1 != Move 4
            ((hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) &&
            hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert())) == true ||
            (hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) == 0 &&
            hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) == 0 &&
            hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) == 0) == true) && //2 != 3 and != 4 OR Moves 2 = 0 and 3 = 0 and 4 = 0
            ((hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert())) == true ||
            (hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) == 0 &&
            hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) == 0) == true) && //3 != 4
            (hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) == 0 &&
            hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) != 0 &&
            hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) != 0) == false && //Make sure move 2 is a move if move 3 and 4 is a move
            (hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) == 0 && hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) != 0) == false && //Make sure move 3 is a move if move 4 is a move
            check.EV(buffer, gv.GetEffortTotal(), gv.GetInvert(), val.GetGen(), val.GetSubGen(), gv.GetOption()) && // EV total does not exceed limit
            check.Pkrus(buffer, gv.GetOption()) && //Makes sure Pokerus is valid
            check.IVs(buffer, gv.GetOption()) && //Check valid IVs
            check.ChecksumEnd(buffer, gv.GetOption(), gv.GetColumn(), gv.GetInvert()) //Makes sure the checksum is correct
            )
            {
                /*bit.Checksum(buffer, offset_Data.GetChecksum(), offset_Data.GetChecksumCalcDataStart(), val.GetColumn())*/
                arr.UpdateCheck(pokemon, val.GetFound(), buffer, ref update, val.GetGen(), val.GetSubGen(), gv.GetInvert());
                if (update == false)
                {
                    arr.Array1Dto2D(pokemon, val.GetFound(), gv.GetColumn(), buffer);
                    val.SetFound(val.GetFound() + 1);
                }
            }
            //check = new();
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

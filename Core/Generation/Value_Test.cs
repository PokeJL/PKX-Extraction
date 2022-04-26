using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.DataManager;

namespace PKX_Extraction.Core.Generation
{
    class Value_Test
    {
        Data_Conversion hex;
        Validation check;
        public Value_Test()
        {
            hex = new();
            check = new();
        }

        //This function is to check to make sure everything is returning true
        public void Test(byte[] buffer, int currentDexNum, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            bool test = true;
            if (hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != 0) //Move 1 has an actual move
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) <= gv.GetNumOfMovesInGen()) //Move 1 is a valid move
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) <= gv.GetNumOfMovesInGen()) //Move 2 is a valid move
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) <= gv.GetNumOfMovesInGen()) //Move 3 is a valid move
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) <= gv.GetNumOfMovesInGen()) //Move 4 is a valid move
                test = true;
            else
                test = false;
            if (currentDexNum <= gv.GetNumOfPokeInGen()) //Ensures the species is not outside the valid range
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetDex(), offset_Data.GetSizeDex(), gv.GetInvert()) != 0) //Not a glitch Pokemon
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert())) //Move 1 != Move 2
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert())) //Move 1 != Move 3
                test = true;
            else
                test = false;
            if (hex.LittleEndian(buffer, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert())) //Move 1 != Move 4
                test = true;
            else
                test = false;
            if (((hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) && hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert())) == true || (hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) == 0 && hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) == 0 && hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) == 0) == true)) //2 != 3 and != 4 OR Moves 2 = 0 and 3 = 0 and 4 = 0
                test = true;
            else
                test = false;
            if (((hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) != hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert())) == true || (hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) == 0 && hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) == 0) == true)) //3 != 4
                test = true;
            else
                test = false;
            if ((hex.LittleEndian(buffer, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), gv.GetInvert()) == 0 && hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) != 0 && hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) != 0) == false) //Make sure move 2 is a move if move 3 and 4 is a move
                test = true;
            else
                test = false;
            if ((hex.LittleEndian(buffer, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), gv.GetInvert()) == 0 && hex.LittleEndian(buffer, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), gv.GetInvert()) != 0) == false) //Make sure move 3 is a move if move 4 is a move
                test = true;
            else
                test = false;
            if (check.EV(buffer, gv.GetEffortTotal(), gv.GetInvert(), val.GetGen(), val.GetSubGen(), gv.GetOption())) // EV total does not exceed limit
                test = true;
            else
                test = false;
            if (check.Pkrus(buffer, gv.GetOption())) //Makes sure Pokerus is valid
                test = true;
            else
                test = false;
            if (check.IVs(buffer, gv.GetOption())) //Check valid IVs
                test = true;
            else
                test = false;
            if (check.ChecksumEnd(buffer, gv.GetOption(), gv.GetColumn(), gv.GetInvert()))
                test = true;
            else
                test = false;
        }
    }
}

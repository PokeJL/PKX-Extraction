using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.DataManager;

namespace PKX_Extraction.Core.DataManager
{
    class Pokemon_Value_Check
    {
        Data_Conversion hex;
        Validation check;
        public Pokemon_Value_Check()
        {
            hex = new();
            check = new();
        }

        /// <summary>
        /// Checks to see if the data in the buffer looks like a valid Pokemon
        /// </summary>
        /// <param name="buffer">The bits that are being checked</param>
        /// <param name="currentDexNum"></param>
        /// <param name="val">Needed to know the gen and sub gen for the checksum might migrate this to
        /// Game_Values in future</param>
        /// <param name="offset_Data">Contains the offset for each value being compared</param>
        /// <param name="gv">Contains basic values of the target game such as party size</param>
        /// <returns></returns>
        public bool IsPokemon(byte[] buffer, int currentDexNum, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            //Move 1 has an actual move
            if (!(hex.LittleEndian(buffer, offset_Data.Move1, offset_Data.SizeMove1, gv.Invert) != 0)) 
                return false;
            //Move 1 is a valid move
            if (!(hex.LittleEndian(buffer, offset_Data.Move1, offset_Data.SizeMove1, gv.Invert) <= gv.NumOfMovesInGen)) 
                return false;
            //Move 2 is a valid move
            if (!(hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) <= gv.NumOfMovesInGen)) 
                return false;
            //Move 3 is a valid move
            if (!(hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) <= gv.NumOfMovesInGen)) 
                return false;
            //Move 4 is a valid move
            if (!(hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) <= gv.NumOfMovesInGen)) 
                return false;
            //Ensures the species is not outside the valid range
            if (!(currentDexNum <= gv.NumOfPokeInGen)) 
                return false;
            //Not a glitch Pokemon
            if (!(hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert) != 0)) 
                return false;
            //Move 1 != Move 2
            if (!(hex.LittleEndian(buffer, offset_Data.Move1, offset_Data.SizeMove1, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert))) 
                return false;
            //Move 1 != Move 3
            if (!(hex.LittleEndian(buffer, offset_Data.Move1, offset_Data.SizeMove1, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert))) 
                return false;
            //Move 1 != Move 4
            if (!(hex.LittleEndian(buffer, offset_Data.Move1, offset_Data.SizeMove1, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert))) 
                return false;
            //2 != 3 OR 2 AND 3 == 0
            if (!((hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert)) ||
                (hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) == 0))) 
                return false;
            //2 != 4 OR 2 AND 4 == 0
            if (!((hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert)) ||
                (hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) == 0))) 
                return false;
            //3 != 4 OR 3 AND 4 == 0
            if (!((hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert)) ||
                (hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) == 0))) 
                return false;
            // EV total does not exceed limit
            if (!check.EV(buffer, gv.EffortTotal, gv.Invert, val.Gen, val.SubGen, gv.Option)) 
                return false;
            //Makes sure Pokerus is valid
            if (!check.Pkrus(buffer, gv.Option)) 
                return false;
            //Check valid IVs
            if (!check.IVs(buffer, gv.Option)) 
                return false;
            //Makes sure the checksum is valid or if the game does not have checksum additional
            //checks are completed
            if (!check.ChecksumEnd(buffer, gv.Option, gv.StorageDataSize, gv.Invert))
                return false;

            return true;
        }

        /// <summary>
        /// Ensures that the found Pokemon isn't already been found since Pokemon
        /// data can repeat multiple times in the RAM
        /// </summary>
        /// <param name="pokemon">The list of list that contains all fond Pokemon</param>
        /// <param name="convert">The Pokemon in the buffer be checked</param>
        /// <param name="inversion">Is the data little edian </param>
        /// <param name="f">Current index of the loop. Is f and not index since this was 
        /// move out of the loop</param>
        /// <param name="offset_Data">Contains the offest data for the Pokemon</param>
        /// <returns>false if Pokemon is already found OR true if Pokemon is new</returns>
        public bool Duplicate(List<List<byte>> pokemon, byte[] convert, bool inversion, int f /*f is the index*/, Offest_data offset_Data)
        {
            //Check if PID of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.PID, offset_Data.SizePID, inversion) ==
                hex.LittleEndian(convert, offset_Data.PID, offset_Data.SizePID, inversion)))
                return false;
            //Check if Dex # of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Dex, offset_Data.SizeDex, inversion) == 
                hex.LittleEndian(convert, offset_Data.Dex, offset_Data.SizeDex, inversion)))
                return false;
            //Check if ID of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.ID, offset_Data.SizeID, inversion) == 
                hex.LittleEndian(convert, offset_Data.ID, offset_Data.SizeID, inversion)))
                return false;
            //Check if SID of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.SID, offset_Data.SizeSID, inversion) == 
                hex.LittleEndian(convert, offset_Data.SID, offset_Data.SizeSID, inversion)))
                return false;
            //Check if Item of found Pokemon matches one already found
            //May cause issue if item is consumed 
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Item, offset_Data.SizeItem, inversion) == 
                hex.LittleEndian(convert, offset_Data.Item, offset_Data.SizeItem, inversion))) 
                return false;
            //Check if Friendship of found Pokemon matches one already found
            //May cause issue if Pokemon fraints
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Friendship, offset_Data.SizeFriendship, inversion) == 
                hex.LittleEndian(convert, offset_Data.Friendship, offset_Data.SizeFriendship, inversion)))  
                return false;
            //Check if Ability of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Ability, offset_Data.SizeAbility, inversion) == 
                hex.LittleEndian(convert, offset_Data.Ability, offset_Data.SizeAbility, inversion))) 
                return false;
            //Check if HP EV of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.HPEV, offset_Data.SizeHPEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.HPEV, offset_Data.SizeHPEV, inversion))) 
                return false;
            //Check if Attack EV of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.AttEV, offset_Data.SizeAttEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.AttEV, offset_Data.SizeAttEV, inversion))) 
                return false;
            //Check if Defence EV of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.DefEV, offset_Data.SizeDefEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.DefEV, offset_Data.SizeDefEV, inversion)))
                return false;
            //Check if Sp.Attack EV of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.SpAttEV, offset_Data.SizeSpAttEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.SpAttEV, offset_Data.SizeSpAttEV, inversion)))
                return false;
            //Check if Sp.Defence EV of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.SpDefEV, offset_Data.SizeSpDefEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.SpDefEV, offset_Data.SizeSpDefEV, inversion)))
                return false;
            //Check if Speen EV of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.SpeedEV, offset_Data.SizeSpeedEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.SpeedEV, offset_Data.SizeSpeedEV, inversion)))
                return false;
            //Check if Cool of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Cool, offset_Data.SizeCool, inversion) == 
                hex.LittleEndian(convert, offset_Data.Cool, offset_Data.SizeCool, inversion)))
                return false;
            //Check if Beauty of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Beauty, offset_Data.SizeBeauty, inversion) == 
                hex.LittleEndian(convert, offset_Data.Beauty, offset_Data.SizeBeauty, inversion)))
                return false;
            //Check if Cute of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Cute, offset_Data.SizeCute, inversion) == 
                hex.LittleEndian(convert, offset_Data.Cute, offset_Data.SizeCute, inversion)))
                return false;
            //Check if Smart of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Smart, offset_Data.SizeSmart, inversion) == 
                hex.LittleEndian(convert, offset_Data.Smart, offset_Data.SizeSmart, inversion)))
                return false;
            //Check if Tough of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Tough, offset_Data.SizeTough, inversion) == 
                hex.LittleEndian(convert, offset_Data.Tough, offset_Data.SizeTough, inversion)))
                return false;
            //Check if Sheen of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Sheen, offset_Data.SizeSheen, inversion) == 
                hex.LittleEndian(convert, offset_Data.Sheen, offset_Data.SizeSheen, inversion))) 
                return false;
            //Check if Move 1 of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Move1, offset_Data.SizeMove1, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move1, offset_Data.SizeMove1, inversion))) 
                return false;
            //Check if Move 2 of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Move2, offset_Data.SizeMove2, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move2, offset_Data.SizeMove2, inversion)))
                return false;
            //Check if Move 3 of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Move3, offset_Data.SizeMove3, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move3, offset_Data.SizeMove3, inversion)))
                return false;
            //Check if Move 4 of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Move4, offset_Data.SizeMove4, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move4, offset_Data.SizeMove4, inversion)))
                return false;
            //Check if Nature of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Nature, offset_Data.SizeNature, inversion) == 
                hex.LittleEndian(convert, offset_Data.Nature, offset_Data.SizeNature, inversion)))
                return false;
            //Check if Encryption of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.Encryption, offset_Data.SizeEncryption, inversion) == 
                hex.LittleEndian(convert, offset_Data.Encryption, offset_Data.SizeEncryption, inversion)))
                return false;
            //Check if EXP of found Pokemon matches one already found
            if (!(hex.LittleEndian2D(pokemon, f, offset_Data.EXP, offset_Data.SizeEXP, inversion) == 
                hex.LittleEndian(convert, offset_Data.EXP, offset_Data.SizeEXP, inversion)))
                return false;

            return true;
        }
    }
}

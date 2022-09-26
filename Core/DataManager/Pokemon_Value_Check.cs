using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.DataManager;

namespace PKX_Extraction.Core.DataManager
{
    /// <summary>
    /// This class breaks down the original hard to read if
    /// statments and breaks them down into easy to read
    /// statments that can be modified easier.
    /// </summary>
    class Pokemon_Value_Check
    {
        Data_Conversion hex;
        Validation_Data_Check vdc;
        public Pokemon_Value_Check()
        {
            hex = new();
            vdc = new();
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
            //2 == 0 AND 3 == 0
            if (hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) != 0)
                return false;
            //2 != 4 OR 2 AND 4 == 0
            if (!((hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert)) ||
                (hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) == 0))) 
                return false;
            //2 == 0 AND 4 == 0
            if (hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) != 0)
                return false;
            //3 != 4 OR 3 AND 4 == 0
            if (!((hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) !=
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert)) ||
                (hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) == 0))) 
                return false;
            //3 == 0 AND 4 == 0
            if (hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert) == 0 &&
                hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert) != 0)
                return false;
            // EV total does not exceed limit
            if (!vdc.EV(buffer, gv.EffortTotal, gv.Invert, val.Gen, val.SubGen, gv.Option)) 
                return false;
            //Makes sure Pokerus is valid
            if (!vdc.Pkrus(buffer, gv.Option)) 
                return false;
            //Check valid IVs
            if (!vdc.IVs(buffer, gv.Option)) 
                return false;
            //Makes sure the checksum is valid or if the game does not have checksum additional
            //checks are completed
            if (!vdc.ChecksumEnd(buffer, gv.Option, gv.StorageDataSize, gv.Invert))
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

        public bool ColoXDChecksum(byte[] inputFile, int i, Offest_data offset_Data)
        {
            if (!vdc.CheckPokemonNameCompare(inputFile, i + offset_Data.Nickname, offset_Data.NicknameSize))
                return false;

            if (!vdc.CheckOTNameCompare(inputFile, i + offset_Data.OTName, offset_Data.OTNameSize))
                return false;

            if(!(inputFile[i + offset_Data.Language] != 0))
                return false;

            if (!(inputFile[i + offset_Data.Language] < 7))
                return false;

            if (!((inputFile[i + offset_Data.Version] == 9 || 
                inputFile[i + offset_Data.Version] == 8 || 
                inputFile[i + offset_Data.Version] == 10 || 
                inputFile[i + offset_Data.Version] == 1 || 
                inputFile[i + offset_Data.Version] == 2 && 
                inputFile[i + 16] < 2) || 
                (inputFile[i + offset_Data.Version] == 11 && 
                inputFile[i + 16] == 0))) //78 = 0x4E & 56 = 0x38
                return false;

            return true;
        }

        public bool RBYChecksum(byte[] inputFile, int i, Offest_data offset_Data)
        {
            //if (!(inputFile[i + 3] > 1 && inputFile[i + 3] <= 100)) //Level between 2 and 100
            //    return false;

            if (!(inputFile[i + 4] == 0 ||
                inputFile[i + 4] == 0x04 ||
                inputFile[i + 4] == 0x08 ||
                inputFile[i + 4] == 0x10 ||
                inputFile[i + 4] == 0x20 ||
                inputFile[i + 4] == 0x40)) //Valid status condition
                return false;

            if (!(inputFile[i + 5] == 0x00 ||
                inputFile[i + 5] == 0x01 ||
                inputFile[i + 5] == 0x02 ||
                inputFile[i + 5] == 0x03 ||
                inputFile[i + 5] == 0x04 ||
                inputFile[i + 5] == 0x05 ||
                inputFile[i + 5] == 0x07 ||
                inputFile[i + 5] == 0x08 ||
                inputFile[i + 5] == 0x14 ||
                inputFile[i + 5] == 0x15 ||
                inputFile[i + 5] == 0x16 ||
                inputFile[i + 5] == 0x17 ||
                inputFile[i + 5] == 0x18 ||
                inputFile[i + 5] == 0x19 ||
                inputFile[i + 5] == 0x1A)) //valid type 1
                return false;

            if (!(inputFile[i + 6] == 0x00 ||
                inputFile[i + 6] == 0x01 ||
                inputFile[i + 6] == 0x02 ||
                inputFile[i + 6] == 0x03 ||
                inputFile[i + 6] == 0x04 ||
                inputFile[i + 6] == 0x05 ||
                inputFile[i + 6] == 0x07 ||
                inputFile[i + 6] == 0x08 ||
                inputFile[i + 6] == 0x14 ||
                inputFile[i + 6] == 0x15 ||
                inputFile[i + 6] == 0x16 ||
                inputFile[i + 6] == 0x17 ||
                inputFile[i + 6] == 0x18 ||
                inputFile[i + 6] == 0x19 ||
                inputFile[i + 6] == 0x1A))
                return false;

            if (!(hex.LittleEndian(inputFile, i + offset_Data.EXP, offset_Data.SizeEXP, false) <= 1250000))
                return false;

            //if (!(hex.LittleEndian(inputFile, i + 1, 2, false) <= hex.LittleEndian(inputFile, i + 0x22, 2, false))) //Make sure current HP is less or equal to max HP
            //    return false;

            //if (!(hex.LittleEndian(inputFile, i + 0x22, 2, false) != 0)) //Make sure max HP does not equal 0
            //    return false;

            if (!(hex.LittleEndian(inputFile, i + 0x22, 2, false) <= 710))
                return false;

            return true;
        }

        public bool GSCChecksum(byte[] inputFile, int i, Offest_data offset_Data)
        {
            if (!(inputFile[i + 0x1F] > 1 && inputFile[i + 0x1F] <= 100)) //Level between 2 and 100
                return false;

            if (!(inputFile[i + 0x20] == 0 ||
                inputFile[i + 0x20] == 0x04 ||
                inputFile[i + 0x20] == 0x08 ||
                inputFile[i + 0x20] == 0x10 ||
                inputFile[i + 0x20] == 0x20 ||
                inputFile[i + 0x20] == 0x40)) //Valid status condition
                return false;

            if (!(hex.LittleEndian(inputFile, i + offset_Data.EXP, offset_Data.SizeEXP, false) <= 1250000))
                return false;

            if (!(hex.LittleEndian(inputFile, i + 0x22, 2, false) <= hex.LittleEndian(inputFile, i + 0x24, 2, false))) //Make sure current HP is less or equal to max HP
                return false;

            //if ((hex.LittleEndian(inputFile, i + 0x24, 2, false) != 0)) //Make sure make HP does not equal 0
            //    return false;

            if (!(hex.LittleEndian(inputFile, i + 0x24, 2, false) <= 713))
                return false;

            return true;
        }
    }
}

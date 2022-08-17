using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Run Options
--------------------------------------------------------------------------
option 0 is for standard run of the program (mainline games gen 3 onward)
option 1 is Colo and XD run of the program
option 2 is for RBY run of the program
option 3 is for GSC run of the program
--------------------------------------------------------------------------

This ugly class handles exceptions to data structure as they appear in diffrent
games.
 */
namespace PKX_Extraction.Core.DataManager
{
    class Validation
    {
        Data_Conversion hex;
        Offest_data offset_Data;
        Array_Manager arr;
        Bit_Check bit;

        public Validation() 
        {
            hex = new();
            offset_Data = new();
            arr = new();
            bit = new();
        }
        //NOTE TO SELF CLEAN UP THESE IF STATEMENTS THEY ARE BAD!!!!!!!!!
        /// <summary>
        /// Does basic check at start of loop to determine
        /// if the data is Pokemon like and worth checking further
        /// </summary>
        /// <param name="inputFile">Potential Pokemon data</param>
        /// <param name="option">Which run of the program are we using</param>
        /// <param name="i">index</param>
        /// <param name="gen">Target gen</param>
        /// <param name="subGen">Helps determine which gen of the gen 
        /// is being targeted</param>
        /// <param name="inversion">Is data in little edian</param>
        /// <returns></returns>
        public bool ChecksumStart(byte[] inputFile, int option, int i, int gen, int subGen, bool inversion)
        {
            offset_Data.SetValues(gen, subGen);

            if (option == 0) //Checksum does not equal 0
            {
                if (hex.LittleEndian(inputFile, i + offset_Data.Checksum, 2, inversion) != 0)
                    return true;
            }
            else if (option == 1) //Fake checksum check for Colo and XD
            {
                if (CheckPokemonNameCompare(inputFile, i + offset_Data.Nickname, offset_Data.NicknameSize) &&
                    CheckOTNameCompare(inputFile, i + offset_Data.OTName, offset_Data.OTNameSize) &&
                    inputFile[i + offset_Data.Language] != 0 &&
                    inputFile[i + offset_Data.Language] < 7 &&
                    ((inputFile[i + offset_Data.Version] == 9 || inputFile[i + offset_Data.Version] == 8 || inputFile[i + offset_Data.Version] == 10 || inputFile[i + offset_Data.Version] == 1 || inputFile[i + offset_Data.Version] == 2 && inputFile[i + 16] < 2) || (inputFile[i + offset_Data.Version] == 11 && inputFile[i + 16] == 0))) //78 = 0x4E & 56 = 0x38
                    return true;
            }
            else if (option == 2)
            {
                if ((inputFile[i + 3] > 1 && inputFile[i + 3] <= 100) && //Level between 2 and 100
                    (inputFile[i + 4] == 0 || inputFile[i + 4] == 0x04 || inputFile[i + 4] == 0x08 || inputFile[i + 4] == 0x10 || inputFile[i + 4] == 0x20 || inputFile[i + 4] == 0x40) && //Valid status condition
                    (inputFile[i + 5] == 0x00 || inputFile[i + 5] == 0x01 || inputFile[i + 5] == 0x02 || inputFile[i + 5] == 0x03 || inputFile[i + 5] == 0x04 || inputFile[i + 5] == 0x05 || inputFile[i + 5] == 0x07 || inputFile[i + 5] == 0x08 || inputFile[i + 5] == 0x14 || inputFile[i + 5] == 0x15 || inputFile[i + 5] == 0x16 || inputFile[i + 5] == 0x17 || inputFile[i + 5] == 0x18 || inputFile[i + 5] == 0x19 || inputFile[i + 5] == 0x1A) && //valid type 1
                    (inputFile[i + 6] == 0x00 || inputFile[i + 6] == 0x01 || inputFile[i + 6] == 0x02 || inputFile[i + 6] == 0x03 || inputFile[i + 6] == 0x04 || inputFile[i + 6] == 0x05 || inputFile[i + 6] == 0x07 || inputFile[i + 6] == 0x08 || inputFile[i + 6] == 0x14 || inputFile[i + 6] == 0x15 || inputFile[i + 6] == 0x16 || inputFile[i + 6] == 0x17 || inputFile[i + 6] == 0x18 || inputFile[i + 6] == 0x19 || inputFile[i + 6] == 0x1A) &&
                    hex.LittleEndian(inputFile, i + offset_Data.EXP, offset_Data.SizeEXP, false) <= 1250000 &&
                    hex.LittleEndian(inputFile, i + 1, 2, false) <= hex.LittleEndian(inputFile, i + 0x22, 2, false) && //Make sure current HP is less or equal to max HP
                    hex.LittleEndian(inputFile, i + 0x22, 2, false) != 0 && //Make sure max HP does not equal 0
                    hex.LittleEndian(inputFile, i + 0x22, 2, false) <= 710)
                {
                    return true;
                }
            }
            else if (option == 3)
            {
                if ((inputFile[i + 0x1F] > 1 && inputFile[i + 0x1F] <= 100) && //Level between 2 and 100
                    (inputFile[i + 0x20] == 0 || inputFile[i + 0x20] == 0x04 || inputFile[i + 0x20] == 0x08 || inputFile[i + 0x20] == 0x10 || inputFile[i + 0x20] == 0x20 || inputFile[i + 0x20] == 0x40) && //Valid status condition
                    hex.LittleEndian(inputFile, i + offset_Data.EXP, offset_Data.SizeEXP, false) <= 1250000 &&
                    hex.LittleEndian(inputFile, i + 0x22, 2, false) <= hex.LittleEndian(inputFile, i + 0x24, 2, false) && //Make sure current HP is less or equal to max HP
                    hex.LittleEndian(inputFile, i + 0x24, 2, false) != 0 && //Make sure make HP does not equal 0
                    hex.LittleEndian(inputFile, i + 0x24, 2, false) <= 713)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Runs actual checksum if there is one else return true
        /// because that game was a big pain (cough cough Colo and XD)
        /// and the developers didn't feel the need for checksums
        /// therefore leaving them up so I had to make stuff up!!!!!
        /// </summary>
        /// <param name="inputFile">The data being checked</param>
        /// <param name="option">Only matters if it is 0</param>
        /// <param name="size">The size of the data</param>
        /// <param name="inversion">little edian?</param>
        /// <returns></returns>
        public bool ChecksumEnd(byte[] inputFile, int option, int size, bool inversion)
        {
            if (option == 0) //Calcs checksum to see if it matches the value stored in data
            {
                if (Checksum(inputFile, offset_Data.Checksum, offset_Data.ChecksumCalcDataStart, size, inversion))
                    return true;
            }
            else
                return true; //Return true if option is not 0 because there is no checksum

            return false;
        }

        /// <summary>
        /// A frankenstine function of stuff from PKHeX
        /// and my own insanity
        /// </summary>
        /// <param name="data"></param>
        /// <param name="chkOffest"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <param name="inversion"></param>
        /// <returns></returns>
        private bool Checksum(byte[] data, int chkOffest, int start, int size, bool inversion)
        {
            Data_Conversion con = new Data_Conversion();
            ushort check = PokeCrypto.GetCHK(data, start, size); //Makes the checksum

            if (con.LittleEndian(data, chkOffest, 2, inversion) == check)
                return true;

            return false;
        }

        /// <summary>
        /// Ensures the IVs are valid
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool IVs(byte[] inputFile, int option)
        {
            if (option == 0) //IVs stored in 3 bytes
            {
                if (bit.IV(inputFile, offset_Data.IV))
                    return true;
            }
            else if (option == 1) //IVs stored in 6 bytes
            {
                if (inputFile[offset_Data.IV] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 2] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 3] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 4] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 5] <= 31)
                {
                    return true;
                }
            }
            else if (option == 2 || option == 3)
            {
                return true; //Checking IVs in gens 1 and 2 is pointless
            }

            return false;
        }

        /// <summary>
        /// Checks if Pkrus is valid
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool Pkrus(byte[] inputFile, int option)
        {           
            if (option == 0 || option == 3) //PkRus single byte
            {
                return bit.Pokerus(inputFile[offset_Data.Pkrus]);
            }
            else if (option == 1) //PkRus Split in 2 bytes
            {
                int skip;
                if (offset_Data.Pkrus == 0xCA)
                    skip = 3; //Colo
                else
                    skip = 2; //XD

                byte[] tempArr = { inputFile[offset_Data.Pkrus] };
                string byte1 = Convert.ToHexString(tempArr);
                tempArr[0] = inputFile[offset_Data.Pkrus + skip];
                string byte2 = Convert.ToHexString(tempArr);
                byte pkrus;

                byte1 += byte2;
                tempArr = Convert.FromHexString(byte1);
                pkrus = tempArr[0];
                return bit.Pokerus(pkrus);
            }
            else if (option == 2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ensures the EV total is valid
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="totalEV"></param>
        /// <param name="invert"></param>
        /// <param name="gen"></param>
        /// <param name="subGen"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool EV(byte[] buffer, int totalEV, bool invert, int gen, int subGen, int option)
        {
            offset_Data.SetValues(gen, subGen);

            if (option != 2 || option != 3)
            {
                if ((hex.LittleEndian(buffer, offset_Data.HPEV, offset_Data.SizeHPEV, invert) +
                    hex.LittleEndian(buffer, offset_Data.AttEV, offset_Data.SizeAttEV, invert) +
                    hex.LittleEndian(buffer, offset_Data.DefEV, offset_Data.SizeDefEV, invert) +
                    hex.LittleEndian(buffer, offset_Data.SpeedEV, offset_Data.SizeSpeedEV, invert) +
                    hex.LittleEndian(buffer, offset_Data.SpAttEV, offset_Data.SizeSpAttEV, invert) +
                    hex.LittleEndian(buffer, offset_Data.SpDefEV, offset_Data.SizeSpDefEV, invert)) <= totalEV)
                {
                    return true;
                }
            }
            else
                return true; //Not worth checking EVs for gen 1 and 2

            return false;
        }

        /// <summary>
        /// Helps determine if Pokemon data from Colo and XD
        /// is valid since checksums are not a thing.
        /// Basically since the Pokemon name is stored 2 times
        /// in Colo and XD Pokemon structue this function
        /// checks if both names match or not blank.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool CheckPokemonNameCompare(byte[] data, int start, int length)
        {
            byte[] temp1 = new byte[length];
            byte[] temp2 = new byte[length];
            byte[] temp1bytes = new byte[2];
            byte[] temp2bytes = new byte[2];
            bool temp1Valid = false;
            bool temp2Valid = false;
            string temp1String = string.Empty;
            string temp2String = string.Empty;

            //Stors each name instance into an array
            arr.ArrayPart(temp1, data, start);
            arr.ArrayPart(temp2, data, start + 22); //+22 = 0x64

            for (int i = 0; i < length; i += 2)
            {
                arr.ArrayPart(temp1bytes, temp1, i);
                arr.ArrayPart(temp2bytes, temp2, i);

                if (Convert.ToInt32(Convert.ToHexString(temp1bytes), 16) < 55296 &&
                    Convert.ToInt32(Convert.ToHexString(temp2bytes), 16) < 55296) //0xD800 = 55296
                {
                    temp1String += char.ConvertFromUtf32(Convert.ToInt32(Convert.ToHexString(temp1bytes), 16));
                    temp2String += char.ConvertFromUtf32(Convert.ToInt32(Convert.ToHexString(temp2bytes), 16));
                }
            }

            temp1String.TrimStart().TrimEnd();
            temp2String.TrimStart().TrimEnd();

            if (temp1String != string.Empty)
                temp1Valid = true;
            if (temp2String != string.Empty)
                temp2Valid = true;

            if (temp1Valid == true && temp2Valid == true)
                return arr.ArrayCompare(temp1, temp2);

            return false;
        }

        /// <summary>
        /// Checks to see if the OT is valid for Colo and XD
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool CheckOTNameCompare(byte[] data, int start, int length)
        {
            byte[] temp1 = new byte[length];
            byte[] temp1bytes = new byte[2];
            string temp1String = string.Empty;

            arr.ArrayPart(temp1, data, start);

            for (int i = 0; i < length; i += 2)
            {
                arr.ArrayPart(temp1bytes, temp1, i);

                if (Convert.ToInt32(Convert.ToHexString(temp1bytes), 16) < 55296) //0xD800 = 55296 values after that are not valid
                    temp1String += char.ConvertFromUtf32(Convert.ToInt32(Convert.ToHexString(temp1bytes), 16));
            }

            temp1String.TrimStart().TrimEnd();

            if (temp1String != string.Empty)
                return true;

            return false;
        }
    }
}

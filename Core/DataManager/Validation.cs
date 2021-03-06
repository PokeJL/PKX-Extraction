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

        public bool ChecksumStart(byte[] inputFile, int option, int i, int gen, int subGen, bool inversion)
        {
            bool valid = false;
            offset_Data.SetValues(gen, subGen);

            if (option == 0) //Checksum does not equal 0
            {
                if (hex.LittleEndian(inputFile, i + offset_Data.GetChecksum(), 2, inversion) != 0)
                    valid = true;
            }
            else if (option == 1) //Fake checksum check for Colo and XD
            {
                if (CheckPokemonNameCompare(inputFile, i + offset_Data.GetNickname(), offset_Data.GetNicknameSize()) &&
                    CheckOTNameCompare(inputFile, i + offset_Data.GetOTName(), offset_Data.GetOTNameSize()) &&
                    inputFile[i + offset_Data.GetLanguage()] != 0 &&
                    inputFile[i + offset_Data.GetLanguage()] < 7 &&
                    ((inputFile[i + offset_Data.GetVersion()] == 9 || inputFile[i + offset_Data.GetVersion()] == 8 || inputFile[i + offset_Data.GetVersion()] == 10 || inputFile[i + offset_Data.GetVersion()] == 1 || inputFile[i + offset_Data.GetVersion()] == 2 && inputFile[i + 16] < 2) || (inputFile[i + offset_Data.GetVersion()] == 11 && inputFile[i + 16] == 0))) //78 = 0x4E & 56 = 0x38
                    valid = true;
            }
            else if (option == 2)
            {
                if ((inputFile[i + 3] > 1 && inputFile[i + 3] <= 100) && //Level between 2 and 100
                    (inputFile[i + 4] == 0 || inputFile[i + 4] == 0x04 || inputFile[i + 4] == 0x08 || inputFile[i + 4] == 0x10 || inputFile[i + 4] == 0x20 || inputFile[i + 4] == 0x40) && //Valid status condition
                    (inputFile[i + 5] == 0x00 || inputFile[i + 5] == 0x01 || inputFile[i + 5] == 0x02 || inputFile[i + 5] == 0x03 || inputFile[i + 5] == 0x04 || inputFile[i + 5] == 0x05 || inputFile[i + 5] == 0x07 || inputFile[i + 5] == 0x08 || inputFile[i + 5] == 0x14 || inputFile[i + 5] == 0x15 || inputFile[i + 5] == 0x16 || inputFile[i + 5] == 0x17 || inputFile[i + 5] == 0x18 || inputFile[i + 5] == 0x19 || inputFile[i + 5] == 0x1A) && //valid type 1
                    (inputFile[i + 6] == 0x00 || inputFile[i + 6] == 0x01 || inputFile[i + 6] == 0x02 || inputFile[i + 6] == 0x03 || inputFile[i + 6] == 0x04 || inputFile[i + 6] == 0x05 || inputFile[i + 6] == 0x07 || inputFile[i + 6] == 0x08 || inputFile[i + 6] == 0x14 || inputFile[i + 6] == 0x15 || inputFile[i + 6] == 0x16 || inputFile[i + 6] == 0x17 || inputFile[i + 6] == 0x18 || inputFile[i + 6] == 0x19 || inputFile[i + 6] == 0x1A) &&
                    hex.LittleEndian(inputFile, i + offset_Data.GetEXP(), offset_Data.GetSizeEXP(), false) <= 1250000 &&
                    hex.LittleEndian(inputFile, i + 1, 2, false) <= hex.LittleEndian(inputFile, i + 0x22, 2, false) && //Make sure current HP is less or equal to max HP
                    hex.LittleEndian(inputFile, i + 0x22, 2, false) != 0 && //Make sure max HP does not equal 0
                    hex.LittleEndian(inputFile, i + 0x22, 2, false) <= 710)
                {
                    valid = true;
                }
            }
            else if (option == 3)
            {
                if ((inputFile[i + 0x1F] > 1 && inputFile[i + 0x1F] <= 100) && //Level between 2 and 100
                    (inputFile[i + 0x20] == 0 || inputFile[i + 0x20] == 0x04 || inputFile[i + 0x20] == 0x08 || inputFile[i + 0x20] == 0x10 || inputFile[i + 0x20] == 0x20 || inputFile[i + 0x20] == 0x40) && //Valid status condition
                    hex.LittleEndian(inputFile, i + offset_Data.GetEXP(), offset_Data.GetSizeEXP(), false) <= 1250000 &&
                    hex.LittleEndian(inputFile, i + 0x22, 2, false) <= hex.LittleEndian(inputFile, i + 0x24, 2, false) && //Make sure current HP is less or equal to max HP
                    hex.LittleEndian(inputFile, i + 0x24, 2, false) != 0 && //Make sure make HP does not equal 0
                    hex.LittleEndian(inputFile, i + 0x24, 2, false) <= 713)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public bool ChecksumEnd(byte[] inputFile, int option, int column, bool inversion)
        {
            bool valid = false;

            if (option == 0) //Calcs checksum to see if it matches the value stored in data
            {
                if (Checksum(inputFile, offset_Data.GetChecksum(), offset_Data.GetChecksumCalcDataStart(), column, inversion))
                    valid = true;
            }
            else
                valid = true; //Return true if option is not 0 because there is no checksum

            return valid;
        }

        private bool Checksum(byte[] data, int chkOffest, int start, int size, bool inversion)
        {
            Data_Conversion con = new Data_Conversion();
            bool valid = false;
            ushort check = PokeCrypto.GetCHK(data, start, size); //Makes the checksum

            if (con.LittleEndian(data, chkOffest, 2, inversion) == check)
                valid = true;

            return valid;
        }

        public bool IVs(byte[] inputFile, int option)
        {
            bool valid = false;

            if (option == 0) //IVs stored in 3 bytes
            {
                if (bit.IV(inputFile, offset_Data.GetIV()))
                    valid = true;
            }
            else if (option == 1) //IVs stored in 6 bytes
            {
                if (inputFile[offset_Data.GetIV()] <= 31 &&
                    inputFile[offset_Data.GetIV() + offset_Data.GetSizeIV()] <= 31 &&
                    inputFile[offset_Data.GetIV() + offset_Data.GetSizeIV() * 2] <= 31 &&
                    inputFile[offset_Data.GetIV() + offset_Data.GetSizeIV() * 3] <= 31 &&
                    inputFile[offset_Data.GetIV() + offset_Data.GetSizeIV() * 4] <= 31 &&
                    inputFile[offset_Data.GetIV() + offset_Data.GetSizeIV() * 5] <= 31)
                {
                    valid = true;
                }
            }
            else if (option == 2 || option == 3)
            {
                valid = true; //Checking IVs in gens 1 and 2 is pointless
            }

            return valid;
        }

        public bool Pkrus(byte[] inputFile, int option)
        {
            bool valid = false;
             
            if (option == 0 || option == 3) //PkRus single byte
            {
                if (bit.Pokerus(inputFile[offset_Data.GetPkrus()]))
                    valid = true;
            }
            else if (option == 1) //PkRus Split in 2 bytes
            {
                int skip;
                if (offset_Data.GetPkrus() == 0xCA)
                    skip = 3; //Colo
                else
                    skip = 2; //XD

                byte[] tempArr = { inputFile[offset_Data.GetPkrus()] };
                string byte1 = Convert.ToHexString(tempArr);
                tempArr[0] = inputFile[offset_Data.GetPkrus() + skip];
                string byte2 = Convert.ToHexString(tempArr);
                byte pkrus;

                byte1 += byte2;
                tempArr = Convert.FromHexString(byte1);
                pkrus = tempArr[0];
                valid = bit.Pokerus(pkrus);
            }
            else if (option == 2)
            {
                valid = true;
            }

            return valid;
        }

        public bool EV(byte[] buffer, int totalEV, bool invert, int gen, int subGen, int option)
        {
            bool valid = false;
            offset_Data.SetValues(gen, subGen);

            if (option != 2)
            {
                if ((hex.LittleEndian(buffer, offset_Data.GetHPEV(), offset_Data.GetSizeHPEV(), invert) +
                    hex.LittleEndian(buffer, offset_Data.GetAttEV(), offset_Data.GetSizeAttEV(), invert) +
                    hex.LittleEndian(buffer, offset_Data.GetDefEV(), offset_Data.GetSizeDefEV(), invert) +
                    hex.LittleEndian(buffer, offset_Data.GetSpeedEV(), offset_Data.GetSizeSpeedEV(), invert) +
                    hex.LittleEndian(buffer, offset_Data.GetSpAttEV(), offset_Data.GetSizeSpAttEV(), invert) +
                    hex.LittleEndian(buffer, offset_Data.GetSpDefEV(), offset_Data.GetSizeSpDefEV(), invert)) <= totalEV)
                {
                    valid = true;
                }
            }
            else
            {
                valid = true; //Not worth checking EVs for gen 1 and 2
            }

            return valid;
        }

        private bool CheckPokemonNameCompare(byte[] data, int start, int length)
        {
            byte[] temp1 = new byte[length];
            byte[] temp2 = new byte[length];
            byte[] temp1bytes = new byte[2];
            byte[] temp2bytes = new byte[2];
            bool temp1Valid = false;
            bool temp2Valid = false;
            string temp1String = null;
            string temp2String = null;

            arr.ArrayPart(temp1, 0, length, data, start);
            arr.ArrayPart(temp2, 0, length, data, start + 22); //+22 = 0x64

            for (int i = 0; i < length; i += 2)
            {
                arr.ArrayPart(temp1bytes, 0, 2, temp1, i);
                arr.ArrayPart(temp2bytes, 0, 2, temp2, i);

                if (Convert.ToInt32(Convert.ToHexString(temp1bytes), 16) < 55296 &&
                    Convert.ToInt32(Convert.ToHexString(temp2bytes), 16) < 55296) //0xD800 = 55296
                {
                    temp1String = char.ConvertFromUtf32(Convert.ToInt32(Convert.ToHexString(temp1bytes), 16));
                    temp2String = char.ConvertFromUtf32(Convert.ToInt32(Convert.ToHexString(temp2bytes), 16));

                    if (temp1String != " ")
                        temp1Valid = true;
                    if (temp2String != " ")
                        temp2Valid = true;
                }
            }

            if (temp1Valid == true && temp2Valid == true)
                return arr.ArrayCompare(temp1, temp2);
            else
                return false;
        }

        private bool CheckOTNameCompare(byte[] data, int start, int length)
        {
            byte[] temp1 = new byte[length];
            byte[] temp1bytes = new byte[2];
            bool temp1Valid = false;
            string temp1String = null;

            arr.ArrayPart(temp1, 0, length, data, start);

            for (int i = 0; i < length; i += 2)
            {
                arr.ArrayPart(temp1bytes, 0, 2, temp1, i);

                if (Convert.ToInt32(Convert.ToHexString(temp1bytes), 16) < 55296) //0xD800 = 55296 values after that are not valid
                {
                    temp1String = char.ConvertFromUtf32(Convert.ToInt32(Convert.ToHexString(temp1bytes), 16));

                    if (temp1String != " ")
                        temp1Valid = true;
                }
            }

            return temp1Valid;
        }
    }
}

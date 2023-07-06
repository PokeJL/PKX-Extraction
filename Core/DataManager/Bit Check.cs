using System;
using static System.Buffers.Binary.BinaryPrimitives;

namespace PKX_Extraction.Core.DataManager
{
    class Bit_Check
    {
        /// <summary>
        /// Checks if Pkrus strain is valid
        /// </summary>
        /// <param name="bit">Bit being checked</param>
        /// <returns></returns>
        public static bool Pokerus(byte bit)
        {
            int strain = (bit >> 4);
            int days = bit & 15;

            //Calc PKRus Stuff here
            if (strain == 0 && days == 0)
                return true;
            else if (strain == 1 && days < 3)
                return true;
            else if (strain == 2 && days < 4)
                return true;
            else if (strain == 3 && days < 5)
                return true;
            else if (strain == 4 && days < 2)
                return true;
            else if (strain == 5 && days < 3)
                return true;
            else if (strain == 6 && days < 4)
                return true;
            else if (strain == 7 && days < 5)
                return true;
            else if (strain == 8 && days < 2)
                return true;
            else if (strain == 9 && days < 3)
                return true;
            else if (strain == 10 && days < 4)
                return true;
            else if (strain == 11 && days < 5)
                return true;
            else if (strain == 12 && days < 2)
                return true;
            else if (strain == 13 && days < 3)
                return true;
            else if (strain == 14 && days < 4)
                return true;
            else if (strain == 15 && days < 5)
                return true;

            return false;
        }

        /// <summary>
        /// Unused orgins data. Here incase has need in the future
        /// </summary>
        /// <param name="data">the data</param>
        /// <returns></returns>
        public bool Orgins(byte[] data)
        {
            if (data[70] == 0 && data[71] == 0)
                return false;
            if (data[70] == 255 && data[71] == 255)
                return false;

            ushort origins = ReadUInt16LittleEndian(data.AsSpan(0x46));
            int metLV = origins & 127;
            int gender = (origins >> 15) & 1;
            int version = (origins >> 7) & 15;
            int ball = (origins >> 11) & 15;

            if (metLV < 101 && gender < 2 && version < 6 && version != 0 && ball < 13 && ball != 0)
                return true;

            return false;
        }

        /// <summary>
        /// Gets each IV when stored in 4 bytes
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool IV(byte[] data)
        {
            int iv = ReadInt32LittleEndian(data.AsSpan(0x48));
            int hp = iv & 31;
            int att = (iv >> 5) & 31;
            int def = (iv >> 10) & 31;
            int speed = (iv >> 15) & 31;
            int spAtt = (iv >> 20) & 31;
            int spDef = (iv >> 25) & 31;
            //int ability = (iv >> 31) & 2; //might be wrong

            if (hp < 32 && att < 32 && def < 32 && speed < 32 && spAtt < 32 && spDef < 32 /*&& ability < 3*/)
                return true;

            return false;
        }
    }
}

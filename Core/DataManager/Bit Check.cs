using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    class Bit_Check
    {
        
        public bool Pokerus(byte bit)
        {
            Data_Conversion con = new Data_Conversion();
            bool validStrain = false;
            string firstHalf;
            string lastHalf;
            int strain;
            int days;
            byte[] temp = new byte[1];
            temp[0] = bit;

            //Calc PKRus Stuff here
            firstHalf = con.HexToBinaryString(temp, 0, 1);
            lastHalf = firstHalf.Substring(4, 4);
            firstHalf = firstHalf.Substring(0, 4);
            strain = Convert.ToInt32(firstHalf, 2);
            days = Convert.ToInt32(lastHalf, 2);

            if (strain == 0 && days == 0)
                validStrain = true;
            else if (strain == 1 && days < 3)
                validStrain = true;
            else if (strain == 2 && days < 4)
                validStrain = true;
            else if (strain == 3 && days < 5)
                validStrain = true;
            else if (strain == 4 && days < 2)
                validStrain = true;
            else if (strain == 5 && days < 3)
                validStrain = true;
            else if (strain == 6 && days < 4)
                validStrain = true;
            else if (strain == 7 && days < 5)
                validStrain = true;
            else if (strain == 8 && days < 2)
                validStrain = true;
            else if (strain == 9 && days < 3)
                validStrain = true;
            else if (strain == 10 && days < 4)
                validStrain = true;
            else if (strain == 11 && days < 5)
                validStrain = true;
            else if (strain == 12 && days < 2)
                validStrain = true;
            else if (strain == 13 && days < 3)
                validStrain = true;
            else if (strain == 14 && days < 4)
                validStrain = true;
            else if (strain == 15 && days < 5)
                validStrain = true;

            return validStrain;
        }

        public bool Orgins(byte[] data)
        {
            Data_Conversion con = new Data_Conversion();
            bool valid = false;
            string word;
            int metLV;
            int gender;

            word = con.HexToBinaryString(data, 70, 2);
            metLV = con.BinaryStringToInt(word, 0, 7);
            gender = con.BinaryStringToInt(word, 15, 1);

            if (metLV < 101  && gender < 2)
                valid = true;

            return valid;
        }

        public bool IV(byte[] data, int offset)
        {
            Data_Conversion con = new Data_Conversion();
            bool valid = false;
            string word;
            int hp;
            int att;
            int def;
            int spAtt;
            int spDef;
            int speed;

            word = con.HexToBinaryString(data, offset, 4);
            hp = con.BinaryStringToInt(word, 0, 4);
            att = con.BinaryStringToInt(word, 5, 4);
            def = con.BinaryStringToInt(word, 10, 4);
            speed = con.BinaryStringToInt(word, 15, 4);
            spAtt = con.BinaryStringToInt(word, 20, 4);
            spDef = con.BinaryStringToInt(word, 25, 4);

            if (hp < 32 && att < 32 && def < 32 && speed < 32 && spAtt < 32 && spDef < 32)
                valid = true;

            return valid;
        }
    }
}

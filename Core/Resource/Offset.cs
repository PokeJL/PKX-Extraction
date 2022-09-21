using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.Resource
{
    class Offset
    {
        public Offset() { }

        /// <summary>
        /// Returns the data stucture for a Pokemon in a given gen
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dex"></param>
        /// <param name="item"></param>
        /// <param name="id"></param>
        /// <param name="sid"></param>
        /// <param name="exp"></param>
        /// <param name="friendship"></param>
        /// <param name="ability"></param>
        /// <param name="hpEV"></param>
        /// <param name="attEV"></param>
        /// <param name="defEV"></param>
        /// <param name="speedEV"></param>
        /// <param name="spAttEV"></param>
        /// <param name="spDefEV"></param>
        /// <param name="cool"></param>
        /// <param name="beauty"></param>
        /// <param name="cute"></param>
        /// <param name="smart"></param>
        /// <param name="tough"></param>
        /// <param name="sheen"></param>
        /// <param name="move1"></param>
        /// <param name="move2"></param>
        /// <param name="move3"></param>
        /// <param name="move4"></param>
        /// <param name="iv"></param>
        /// <param name="nature"></param>
        /// <param name="sizePID"></param>
        /// <param name="sizeDex"></param>
        /// <param name="sizeItem"></param>
        /// <param name="sizeID"></param>
        /// <param name="sizeSID"></param>
        /// <param name="sizeEXP"></param>
        /// <param name="sizeFriendship"></param>
        /// <param name="sizeAbility"></param>
        /// <param name="sizeHPEV"></param>
        /// <param name="sizeAttEV"></param>
        /// <param name="sizeDefEV"></param>
        /// <param name="sizeSpeedEV"></param>
        /// <param name="sizeSpAttEV"></param>
        /// <param name="sizeSpDefEV"></param>
        /// <param name="sizeCool"></param>
        /// <param name="sizeBeauty"></param>
        /// <param name="sizeCute"></param>
        /// <param name="sizeSmart"></param>
        /// <param name="sizeTough"></param>
        /// <param name="sizeSheen"></param>
        /// <param name="sizeMove1"></param>
        /// <param name="sizeMove2"></param>
        /// <param name="sizeMove3"></param>
        /// <param name="sizeMove4"></param>
        /// <param name="sizeIV"></param>
        /// <param name="sizeNature"></param>
        /// <param name="encryption"></param>
        /// <param name="sizeEncryption"></param>
        /// <param name="pkrus"></param>
        /// <param name="checksum"></param>
        /// <param name="checksumCalcDataStart"></param>
        /// <param name="version"></param>
        /// <param name="nickname"></param>
        /// <param name="sizeNickname"></param>
        /// <param name="otName"></param>
        /// <param name="sizeOTName"></param>
        /// <param name="language"></param>
        /// <param name="gen"></param>
        /// <param name="subGen"></param>
        public void Offsets3Later(ref int pid, ref int dex, ref int item, ref int id, ref int sid, ref int exp, ref int friendship,
                                ref int ability, ref int hpEV, ref int attEV, ref int defEV, ref int speedEV, ref int spAttEV, ref int spDefEV,
                                ref int cool, ref int beauty, ref int cute, ref int smart, ref int tough, ref int sheen, ref int move1, ref int move2,
                                ref int move3, ref int move4, ref int iv, ref int nature, ref int sizePID, ref int sizeDex, ref int sizeItem,
                                ref int sizeID, ref int sizeSID, ref int sizeEXP, ref int sizeFriendship, ref int sizeAbility,
                                ref int sizeHPEV, ref int sizeAttEV, ref int sizeDefEV, ref int sizeSpeedEV, ref int sizeSpAttEV,
                                ref int sizeSpDefEV, ref int sizeCool, ref int sizeBeauty, ref int sizeCute, ref int sizeSmart,
                                ref int sizeTough, ref int sizeSheen, ref int sizeMove1, ref int sizeMove2, ref int sizeMove3, ref int sizeMove4,
                                ref int sizeIV, ref int sizeNature, ref int encryption, ref int sizeEncryption, ref int pkrus, ref int checksum, ref int checksumCalcDataStart, ref int version, 
                                ref int nickname, ref int sizeNickname, ref int otName, ref int sizeOTName, ref int language, int gen, int subGen)
        {
            //RBY
            if (gen == 1 && subGen == 0)
            {
                pid = 0; //Does not exist
                sizePID = 1;
                dex = 0;
                sizeDex = 1;
                item = 7; //Catch rate
                sizeItem = 1;
                id = 0x0C;
                sizeID = 2;
                sid = 0; //Does not exist
                sizeSID = 1;
                exp = 0x0E;
                sizeEXP = 3;
                friendship = 0; //Does not exist
                sizeFriendship = 1;
                ability = 0; //Does not exist
                sizeAbility = 1;
                hpEV = 0x11;
                sizeHPEV = 2;
                attEV = 0x13;
                sizeAttEV = 2;
                defEV = 0x15;
                sizeDefEV = 2;
                speedEV = 0x17;
                sizeSpeedEV = 2;
                spAttEV = 0x19;
                sizeSpAttEV = 2;
                spDefEV = 0; //SpAtt and SpDef is one stat special and in this case spAttEV is used in place of special
                sizeSpDefEV = 0;
                cool = 0; //Does not exist
                sizeCool = 1;
                beauty = 0; //Does not exist
                sizeBeauty = 1;
                cute = 0; //Does not exist
                sizeCute = 1;
                smart = 0; //Does not exist
                sizeSmart = 1;
                tough = 0; //Does not exist
                sizeTough = 1;
                sheen = 0; //Does not exist
                sizeSheen = 1;
                move1 = 8;
                sizeMove1 = 1;
                move2 = 9;
                sizeMove2 = 1;
                move3 = 10;
                sizeMove3 = 1;
                move4 = 11;
                sizeMove4 = 1;
                iv = 0x22;
                sizeIV = 1;
                nature = 0; //Does not exist
                sizeNature = 1;
                encryption = 0; //Does not exist
                sizeEncryption = 1; //Does not exist
                pkrus = 0; //Does not exist
                checksum = 0;
                checksumCalcDataStart = 0;
                version = 0; //Does not exist
                nickname = 0; //Does not exist
                sizeNickname = 0;
                otName = 0; //Does not exist
                sizeOTName = 0; //Does not exist
                language = 0; //Does not exist
            }

            //GSC
            if (gen == 2 && subGen == 0)
            {
                pid = 0; //Does not exist
                sizePID = 0; //Does not exist
                dex = 0x00;
                sizeDex = 1;
                item = 0x01;
                sizeItem = 1;
                id = 0x06;
                sizeID = 2;
                sid = 0; //Does not exist
                sizeSID = 0;
                exp = 0x08;
                sizeEXP = 3;
                friendship = 0x1B;
                sizeFriendship = 1;
                ability = 0; //Does not exist
                sizeAbility = 0;
                hpEV = 0x0B;
                sizeHPEV = 2;
                attEV = 0x0D;
                sizeAttEV = 2;
                defEV = 0x0F;
                sizeDefEV = 2;
                speedEV = 0x11;
                sizeSpeedEV = 2;
                spAttEV = 0x13; //Acts as the special stat
                sizeSpAttEV = 2;
                spDefEV = 0; //Is covered in the special stat
                sizeSpDefEV = 0;
                cool = 0; //Does not exist
                sizeCool = 0; //Does not exist
                beauty = 0; //Does not exist
                sizeBeauty = 0; //Does not exist
                cute = 0; //Does not exist
                sizeCute = 0;
                smart = 0; //Does not exist
                sizeSmart = 0;
                tough = 0; //Does not exist
                sizeTough = 0;
                sheen = 0; //Does not exist
                sizeSheen = 0;
                move1 = 0x02;
                sizeMove1 = 1;
                move2 = 0x03;
                sizeMove2 = 1;
                move3 = 0x04;
                sizeMove3 = 1;
                move4 = 0x05;
                sizeMove4 = 1;
                iv = 0x15;
                sizeIV = 2;
                nature = 0; //Does not exist
                sizeNature = 0;
                encryption = 0; //Does not exist
                sizeEncryption = 0;
                pkrus = 0x1C;
                checksum = 0; //Does not exist
                checksumCalcDataStart = 0; //Does not exist
                version = 0; //Does not exist
                nickname = 0; //Not apart of Pokemon structure
                sizeNickname = 0; //Not apart of Pokemon structure
                otName = 0; //Not apart of Pokemon structure
                sizeOTName = 0; //Not apart of Pokemon structure
                language = 0; //Not apart of Pokemon structure
            }

            //RSEFRLG
            if (gen == 3 && subGen == 0)
            {
                pid = 0;
                sizePID = 4;
                dex = 32;
                sizeDex = 2;
                item = 34;
                sizeItem = 2;
                id = 4;
                sizeID = 2;
                sid = 6;
                sizeSID = 2;
                exp = 36;
                sizeEXP = 4;
                friendship = 41;
                sizeFriendship = 1;
                ability = 0; //not clear in the structure
                sizeAbility = 1;
                hpEV = 56;
                sizeHPEV = 1;
                attEV = 57;
                sizeAttEV = 1;
                defEV = 58;
                sizeDefEV = 1;
                speedEV = 59;
                sizeSpeedEV = 1;
                spAttEV = 60;
                sizeSpAttEV = 1;
                spDefEV = 61;
                sizeSpDefEV = 1;
                cool = 62;
                sizeCool = 1;
                beauty = 63;
                sizeBeauty = 1;
                cute = 64;
                sizeCute = 1;
                smart = 65;
                sizeSmart = 1;
                tough = 66;
                sizeTough = 1;
                sheen = 67;
                sizeSheen = 1;
                move1 = 44;
                sizeMove1 = 2;
                move2 = 46;
                sizeMove2 = 2;
                move3 = 48;
                sizeMove3 = 2;
                move4 = 50;
                sizeMove4 = 2;
                iv = 72;
                sizeIV = 4;
                nature = 0; //not clear in structure
                sizeNature = 1;
                encryption = 0; //Value not used in generation but set here so I can reuse code
                sizeEncryption = 1;
                pkrus = 68;
                checksum = 28;
                checksumCalcDataStart = 32;
                version = 0x46; //Origin index
                nickname = 0x08;
                sizeNickname = 22;
                otName = 0x14;
                sizeOTName = 16;
                language = 0x12;
            }

            //Colo
            if (gen == 3 && subGen == 1)
            {
                pid = 0x04;
                sizePID = 4;
                dex = 0x00;
                sizeDex = 2;
                item = 0x88;
                sizeItem = 2;
                id = 0x16;
                sizeID = 2;
                sid = 0x14;
                sizeSID = 2;
                exp = 0x5C;
                sizeEXP = 4;
                friendship = 0xB0;
                sizeFriendship = 1;
                ability = 0xCC; //Bit only
                sizeAbility = 1;
                hpEV = 0x98;
                sizeHPEV = 2;
                attEV = 0x9A;
                sizeAttEV = 2;
                defEV = 0x9C;
                sizeDefEV = 2;
                speedEV = 0xA2; ;
                sizeSpeedEV = 2;
                spAttEV = 0x9E;
                sizeSpAttEV = 2;
                spDefEV = 0xA0;
                sizeSpDefEV = 2;
                cool = 0xB2;
                sizeCool = 2;
                beauty = 0xB3;
                sizeBeauty = 2;
                cute = 0xB4;
                sizeCute = 2;
                smart = 0xB5;
                sizeSmart = 2;
                tough = 0xB6;
                sizeTough = 2;
                sheen = 0xBC;
                sizeSheen = 2;
                move1 = 0x78;
                sizeMove1 = 2;
                move2 = 0x7C;
                sizeMove2 = 2;
                move3 = 0x80;
                sizeMove3 = 2;
                move4 = 0x84;
                sizeMove4 = 2;
                iv = 0xA4;
                sizeIV = 2;
                nature = 0x00; //???
                sizeNature = 1;
                encryption = 0x00; //Not in data;
                sizeEncryption = 1;
                pkrus = 0xCA; //Strain & 0xD0 Days
                checksum = 0x00;
                checksumCalcDataStart = 0;
                version = 0x08;
                nickname = 0x2E;
                sizeNickname = 20;
                otName = 0x18;
                sizeOTName = 20;
                language = 0x0B;
            }

            //XD
            if (gen == 3 && subGen == 2)
            {
                pid = 0x28;
                sizePID = 4;
                dex = 0x00;
                sizeDex = 2;
                item = 0x02;
                sizeItem = 2;
                id = 0x26;
                sizeID = 2;
                sid = 0x24;
                sizeSID = 2;
                exp = 0x20;
                sizeEXP = 4;
                friendship = 0x06;
                sizeFriendship = 1;
                ability = 0x00; //Not seperate value
                sizeAbility = 1;
                hpEV = 0x9C;
                sizeHPEV = 1;
                attEV = 0x9E;
                sizeAttEV = 1;
                defEV = 0xA0;
                sizeDefEV = 1;
                speedEV = 0xA6;
                sizeSpeedEV = 1;
                spAttEV = 0xA2;
                sizeSpAttEV = 1;
                spDefEV = 0xA4;
                sizeSpDefEV = 1;
                cool = 0xAE;
                sizeCool = 1;
                beauty = 0xAF;
                sizeBeauty = 1;
                cute = 0xB0;
                sizeCute = 1;
                smart = 0xB1;
                sizeSmart = 1;
                tough = 0xB2;
                sizeTough = 1;
                sheen = 0x12;
                sizeSheen = 1;
                move1 = 0x80;
                sizeMove1 = 2;
                move2 = 0x84;
                sizeMove2 = 2;
                move3 = 0x88;
                sizeMove3 = 2;
                move4 = 0x8C;
                sizeMove4 = 2;
                iv = 0xA8;
                sizeIV = 1;
                nature = 0x00; //Not seperate value
                sizeNature = 1;
                encryption = 0x00; //Does not exist in gen 3
                sizeEncryption = 1;
                pkrus = 0x13; //0x13 just contains the strain in the second bit where 0x15 stores the days in the second bit
                checksum = 0x00; //Not in data
                checksumCalcDataStart = 0;
                version = 0x34;
                nickname = 0x4E; //Nickname copy at 0x64
                sizeNickname = 20;
                otName = 0x38;
                sizeOTName = 20;
                language = 0x37;
            }

            //DPPtHGSSBWB2W2
            if (gen == 4 || gen == 5 && subGen == 0)
            {
                pid = 0;
                sizePID = 4;
                dex = 8;
                sizeDex = 2;
                item = 10;
                sizeItem = 2;
                id = 12;
                sizeID = 2;
                sid = 14;
                sizeSID = 2;
                exp = 16;
                sizeEXP = 4;
                friendship = 20;
                sizeFriendship = 1;
                ability = 21;
                sizeAbility = 1;
                hpEV = 24;
                sizeHPEV = 1;
                attEV = 25;
                sizeAttEV = 1;
                defEV = 26;
                sizeDefEV = 1;
                speedEV = 27;
                sizeSpeedEV = 1;
                spAttEV = 28;
                sizeSpAttEV = 1;
                spDefEV = 29;
                sizeSpDefEV = 1;
                cool = 30;
                sizeCool = 1;
                beauty = 31;
                sizeBeauty = 1;
                cute = 32;
                sizeCute = 1;
                smart = 33;
                sizeSmart = 1;
                tough = 34;
                sizeTough = 1;
                sheen = 35;
                sizeSheen = 1;
                move1 = 40;
                sizeMove1 = 2;
                move2 = 42;
                sizeMove2 = 2;
                move3 = 44;
                sizeMove3 = 2;
                move4 = 46;
                sizeMove4 = 2;
                iv = 40;
                sizeIV = 4;
                pkrus = 130;
                checksum = 6;
                checksumCalcDataStart = 8;
                version = 0x5F;
                nickname = 0x48;
                sizeNickname = 22;
                otName = 0x68;
                sizeOTName = 16;
                language = 0x17;
                if (gen == 4)
                {
                    //nature in gen 4 is not stored as its own value so just check first value of array
                    nature = 0;
                    sizeNature = 1;
                }
                else
                {
                    nature = 65;
                    sizeNature = 1;
                }
                encryption = 0; //Value not used in generation but set here so I can reuse code
                sizeEncryption = 1;
            }
            
            //XYSMUSUM
            if (gen == 6 || gen == 7 && subGen == 0)
            {
                pid = 24;
                sizePID = 4;
                dex = 8;
                sizeDex = 2;
                item = 10;
                sizeItem = 2;
                id = 12;
                sizeID = 2;
                sid = 14;
                sizeSID = 2;
                exp = 16;
                sizeEXP = 4;
                friendship = 0xCA;
                sizeFriendship = 1;
                ability = 20;
                sizeAbility = 1;
                hpEV = 30;
                sizeHPEV = 1;
                attEV = 31;
                sizeAttEV = 1;
                defEV = 32;
                sizeDefEV = 1;
                speedEV = 33;
                sizeSpeedEV = 1;
                spAttEV = 34;
                sizeSpAttEV = 1;
                spDefEV = 35;
                sizeSpDefEV = 1;
                cool = 36;
                sizeCool = 1;
                beauty = 37;
                sizeBeauty = 1;
                cute = 38;
                sizeCute = 1;
                smart = 39;
                sizeSmart = 1;
                tough = 40;
                sizeTough = 1;
                sheen = 41;
                sizeSheen = 1;
                move1 = 90;
                sizeMove1 = 2;
                move2 = 92;
                sizeMove2 = 2;
                move3 = 94;
                sizeMove3 = 2;
                move4 = 96;
                sizeMove4 = 2;
                iv = 116;
                sizeIV = 4;
                nature = 28;
                sizeNature = 1;
                encryption = 0;
                sizeEncryption = 4;
                pkrus = 43;
                checksum = 6;
                checksumCalcDataStart = 8;
                version = 0xDF;
                nickname = 0x40;
                sizeNickname = 24;
                otName = 0xB0;
                sizeOTName = 24;
                language = 0xE3;
            }

            //SWSH
            if (gen == 8 && subGen == 0)
            {
                pid = 0x1C;
                sizePID = 4;
                dex = 0x08;
                sizeDex = 2;
                item = 0x0A;
                sizeItem = 2;
                id = 0x0C;
                sizeID = 2;
                sid = 0x0E;
                sizeSID = 2;
                exp = 0x10;
                sizeEXP = 4;
                friendship = 0xC8;
                sizeFriendship = 1;
                ability = 0x14;
                sizeAbility = 1;
                hpEV = 0x26;
                sizeHPEV = 1;
                attEV = 0x27;
                sizeAttEV = 1;
                defEV = 0x28;
                sizeDefEV = 1;
                speedEV = 0x29;
                sizeSpeedEV = 1;
                spAttEV = 0x2A;
                sizeSpAttEV = 1;
                spDefEV = 0x2B;
                sizeSpDefEV = 1;
                cool = 0x2C;
                sizeCool = 1;
                beauty = 0x2D;
                sizeBeauty = 1;
                cute = 0x2E;
                sizeCute = 1;
                smart = 0x2F;
                sizeSmart = 1;
                tough = 0x30;
                sizeTough = 1;
                sheen = 0x31;
                sizeSheen = 1;
                move1 = 0x72;
                sizeMove1 = 2;
                move2 = 0x74;
                sizeMove2 = 2;
                move3 = 0x76;
                sizeMove3 = 2;
                move4 = 0x78;
                sizeMove4 = 2;
                iv = 0x8C;
                sizeIV = 4;
                nature = 0x20;
                sizeNature = 1;
                encryption = 0x00;
                sizeEncryption = 4;
                pkrus = 0x32;
                checksum = 0x06;
                checksumCalcDataStart = 0x08;
                version = 0xDE;
                nickname = 0x58;
                sizeNickname = 24;
                otName = 0xF8;
                sizeOTName = 24;
                language = 0xE2;
            }
        }
    }
}

//                pid = 
//                sizePID = 
//                dex = 
//                sizeDex = 
//                item = 
//                sizeItem = 
//                id = 
//                sizeID = 
//                sid = 
//                sizeSID = 
//                exp = 
//                sizeEXP = 
//                friendship = 
//                sizeFriendship = 
//                ability =
//                sizeAbility = 
//                hpEV = 
//                sizeHPEV = 
//                attEV = 
//                sizeAttEV = 
//                defEV = 
//                sizeDefEV = 
//                speedEV = 
//                sizeSpeedEV = 
//                spAttEV = 
//                sizeSpAttEV = 
//                spDefEV = 
//                sizeSpDefEV = 
//                cool = 
//                sizeCool = 
//                beauty = 
//                sizeBeauty = 
//                cute = 
//                sizeCute = 
//                smart = 
//                sizeSmart = 
//                tough = 
//                sizeTough = 
//                sheen = 
//                sizeSheen =
//                move1 =
//                sizeMove1 =
//                move2 =
//                sizeMove2 =
//                move3 =
//                sizeMove3 =
//                move4 =
//                sizeMove4 = 
//                iv = 
//                sizeIV = 
//                nature = 
//                sizeNature = 
//                encryption = 
//                sizeEncryption = 
//                pkrus = 
//                checksum = 
//                checksumCalcDataStart = 
//                version =
//                nickname =
//                sizeNickname =
//                otName =
//                sizeOTName = 
//                language =

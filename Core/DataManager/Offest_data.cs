using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.Resource;

namespace PKX_Extraction.Core.DataManager
{
    class Offest_data
    {
        Offset offset;

        //Offset data
        private int pid;
        private int sizePID;
        private int dex;
        private int sizeDex;
        private int item;
        private int sizeItem;
        private int id;
        private int sizeID;
        private int sid;
        private int sizeSID;
        private int exp;
        private int sizeEXP;
        private int friendship;
        private int sizeFriendship;
        private int ability;
        private int sizeAbility;
        private int hpEV;
        private int sizeHPEV;
        private int attEV;
        private int sizeAttEV;
        private int defEV;
        private int sizeDefEV;
        private int speedEV;
        private int sizeSpeedEV;
        private int spAttEV;
        private int sizeSpAttEV;
        private int spDefEV;
        private int sizeSpDefEV;
        private int cool;
        private int sizeCool;
        private int beauty;
        private int sizeBeauty;
        private int cute;
        private int sizeCute;
        private int smart;
        private int sizeSmart;
        private int tough;
        private int sizeTough;
        private int sheen;
        private int sizeSheen;
        private int move1;
        private int sizeMove1;
        private int move2;
        private int sizeMove2;
        private int move3;
        private int sizeMove3;
        private int move4;
        private int sizeMove4;
        private int iv;
        private int sizeIV;
        private int nature;
        private int sizeNature;
        private int encryption;
        private int sizeEncryption;
        private int pkrus;
        private int checksum;
        private int checksumCalcDataStart;
        private int version;
        private int nickname;
        private int nicknameSize;
        private int otName;
        private int otNameSize;
        private int language;

        public Offest_data()
        {
            offset = new Offset();

            pid = 0;
            sizePID = 0;
            dex = 0;
            sizeDex = 0;
            item = 0;
            sizeItem = 0;
            id = 0;
            sizeID = 0;
            sid = 0;
            sizeSID = 0;
            exp = 0;
            sizeEXP = 0;
            friendship = 0;
            sizeFriendship = 0;
            ability = 0;
            sizeAbility = 0;
            hpEV = 0;
            sizeHPEV = 0;
            attEV = 0;
            sizeAttEV = 0;
            defEV = 0;
            sizeDefEV = 0;
            speedEV = 0;
            sizeSpeedEV = 0;
            spAttEV = 0;
            sizeSpAttEV = 0;
            spDefEV = 0;
            sizeSpDefEV = 0;
            cool = 0;
            sizeCool = 0;
            beauty = 0;
            sizeBeauty = 0;
            cute = 0;
            sizeCute = 0;
            smart = 0;
            sizeSmart = 0;
            tough = 0;
            sizeTough = 0;
            sheen = 0;
            sizeSheen = 0;
            move1 = 0;
            sizeMove1 = 0;
            move2 = 0;
            sizeMove2 = 0;
            move3 = 0;
            sizeMove3 = 0;
            move4 = 0;
            sizeMove4 = 0;
            iv = 0;
            sizeIV = 0;
            nature = 0;
            sizeNature = 0;
            encryption = 0;
            sizeEncryption = 0;
            //numOfPokeInGen = 0;
            //numOfMovesInGen = 0;
            pkrus = 0;
            checksum = 0;
            checksumCalcDataStart = 0;
            version = 0;
            nickname = 0;
            nicknameSize = 0;
            otName = 0;
            otNameSize = 0;
            language = 0;
        }

        public int GetPID()
        {
            return pid;
        }

        public int GetSizePID()
        {
            return sizePID;
        }

        public int GetDex()
        {
            return dex;
        }

        public int GetSizeDex()
        {
            return sizeDex;
        }

        public int GetItem()
        {
            return item;
        }

        public int GetSizeItem()
        {
            return sizeItem;
        }

        public int GetID()
        {
            return id;
        }

        public int GetSizeID()
        {
            return sizeID;
        }

        public int GetSID()
        {
            return sid;
        }

        public int GetSizeSID()
        {
            return sizeSID;
        }

        public int GetEXP()
        {
            return exp;
        }

        public int GetSizeEXP()
        {
            return sizeEXP;
        }

        public int GetFriendship()
        {
            return friendship;
        }

        public int GetSizeFriendship()
        {
            return sizeFriendship;
        }

        public int GetAbility()
        {
            return ability;
        }

        public int GetSizeAbility()
        {
            return sizeAbility;
        }

        public int GetHPEV()
        {
            return hpEV;
        }

        public int GetSizeHPEV()
        {
            return sizeHPEV;
        }

        public int GetAttEV()
        {
            return attEV;
        }

        public int GetSizeAttEV()
        {
            return sizeAttEV;
        }

        public int GetDefEV()
        {
            return defEV;
        }

        public int GetSizeDefEV()
        {
            return sizeDefEV;
        }

        public int GetSpeedEV()
        {
            return speedEV;
        }

        public int GetSizeSpeedEV()
        {
            return sizeSpeedEV;
        }

        public int GetSpAttEV()
        {
            return spAttEV;
        }

        public int GetSizeSpAttEV()
        {
            return sizeSpAttEV;
        }

        public int GetSpDefEV()
        {
            return spDefEV;
        }

        public int GetSizeSpDefEV()
        {
            return sizeSpDefEV;
        }

        public int GetCool()
        {
            return cool;
        }

        public int GetSizeCool()
        {
            return sizeCool;
        }

        public int GetBeauty()
        {
            return beauty;
        }

        public int GetSizeBeauty()
        {
            return sizeBeauty;
        }

        public int GetCute()
        {
            return cute;
        }

        public int GetSizeCute()
        {
            return sizeCute;
        }

        public int GetSmart()
        {
            return smart;
        }

        public int GetSizeSmart()
        {
            return sizeSmart;
        }

        public int GetTough()
        {
            return tough;
        }

        public int GetSizeTough()
        {
            return sizeTough;
        }

        public int GetSheen()
        {
            return sheen;
        }

        public int GetSizeSheen()
        {
            return sizeSheen;
        }

        public int GetMove1()
        {
            return move1;
        }

        public int GetSizeMove1()
        {
            return sizeMove1;
        }

        public int GetMove2()
        {
            return move2;
        }

        public int GetSizeMove2()
        {
            return sizeMove2;
        }

        public int GetMove3()
        {
            return move3;
        }

        public int GetSizeMove3()
        {
            return sizeMove3;
        }

        public int GetMove4()
        {
            return move4;
        }

        public int GetSizeMove4()
        {
            return sizeMove4;
        }

        public int GetIV()
        {
            return iv;
        }

        public int GetSizeIV()
        {
            return sizeIV;
        }

        public int GetNature()
        {
            return nature;
        }

        public int GetSizeNature()
        {
            return sizeNature;
        }

        public int GetEncryption()
        {
            return encryption;
        }

        public int GetSizeEncryption()
        {
            return sizeEncryption;
        }

        public int GetPkrus()
        {
            return pkrus;
        }

        public int GetChecksum()
        {
            return checksum;
        }

        public int GetChecksumCalcDataStart()
        {
            return checksumCalcDataStart;
        }

        public int GetVersion()
        {
            return version;
        }

        public int GetNickname()
        {
            return nickname;
        }

        public int GetNicknameSize()
        {
            return nicknameSize;
        }

        public int GetOTName()
        {
            return otName;
        }
        public int GetOTNameSize()
        {
            return otNameSize;
        }

        public int GetLanguage()
        {
            return language;
        }

        public void SetValues(int gen, int subGen)
        {
            offset.Offsets3Later(ref pid, ref dex, ref item, ref id, ref sid, ref exp, ref friendship,
                                ref ability, ref hpEV, ref attEV, ref defEV, ref speedEV, ref spAttEV, ref spDefEV,
                                ref cool, ref beauty, ref cute, ref smart, ref tough, ref sheen, ref move1, ref move2,
                                ref move3, ref move4, ref iv, ref nature, ref sizePID, ref sizeDex, ref sizeItem,
                                ref sizeID, ref sizeSID, ref sizeEXP, ref sizeFriendship, ref sizeAbility,
                                ref sizeHPEV, ref sizeAttEV, ref sizeDefEV, ref sizeSpeedEV, ref sizeSpAttEV,
                                ref sizeSpDefEV, ref sizeCool, ref sizeBeauty, ref sizeCute, ref sizeSmart,
                                ref sizeTough, ref sizeSheen, ref sizeMove1, ref sizeMove2, ref sizeMove3, ref sizeMove4,
                                ref sizeIV, ref sizeNature, ref encryption, ref sizeEncryption, /*ref numOfPokeInGen,
                                ref numOfMovesInGen,*/ ref pkrus, ref checksum, ref checksumCalcDataStart, ref version, 
                                ref nickname, ref nicknameSize, ref otName, ref otNameSize, ref language, gen, subGen);
        }
    }
}

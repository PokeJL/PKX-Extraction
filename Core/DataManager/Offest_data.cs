using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.Resource;

namespace PKX_Extraction.Core.DataManager
{
    /// <summary>
    /// You're a Pokemon fan and a programmer. I'm
    /// sure you can figure this one out. ;)
    /// Fine stores the index of the data if
    /// the Pokemon is in a 1D array and the length
    /// of each value incase changes between games.
    /// </summary>
    public class Offest_data
    {
        Offset offset = new();

        public int PID { get; set; } = 0;
        public int SizePID { get; set; } = 0;
        public int Dex { get; set; } = 0;
        public int SizeDex { get; set; } = 0;
        public int Item { get; set; } = 0;
        public int SizeItem { get; set; } = 0;
        public int ID { get; set; } = 0;
        public int SizeID { get; set; } = 0;
        public int SID { get; set; } = 0;
        public int SizeSID { get; set; } = 0;
        public int EXP { get; set; } = 0;
        public int SizeEXP { get; set; } = 0;
        public int Friendship { get; set; } = 0;
        public int SizeFriendship { get; set; } = 0;
        public int Ability { get; set; } = 0;
        public int SizeAbility { get; set; } = 0;
        public int HPEV { get; set; } = 0;
        public int SizeHPEV { get; set; } = 0;
        public int AttEV { get; set; } = 0;
        public int SizeAttEV { get; set; } = 0;
        public int DefEV { get; set; } = 0;
        public int SizeDefEV { get; set; } = 0;
        public int SpeedEV { get; set; } = 0;
        public int SizeSpeedEV { get; set; } = 0;
        public int SpAttEV { get; set; } = 0;
        public int SizeSpAttEV { get; set; } = 0;
        public int SpDefEV { get; set; } = 0;
        public int SizeSpDefEV { get; set; } = 0;
        public int Cool { get; set; } = 0;
        public int SizeCool { get; set; } = 0;
        public int Beauty { get; set; } = 0;
        public int SizeBeauty { get; set; } = 0;
        public int Cute { get; set; } = 0;
        public int SizeCute { get; set; } = 0;
        public int Smart { get; set; } = 0;
        public int SizeSmart { get; set; } = 0;
        public int Tough { get; set; } = 0;
        public int SizeTough { get; set; } = 0;
        public int Sheen { get; set; } = 0;
        public int SizeSheen { get; set; } = 0;
        public int Move1 { get; set; } = 0;
        public int SizeMove1 { get; set; } = 0;
        public int Move2 { get; set; } = 0;
        public int SizeMove2 { get; set; } = 0;
        public int Move3 { get; set; } = 0;
        public int SizeMove3 { get; set; } = 0;
        public int Move4 { get; set; } = 0;
        public int SizeMove4 { get; set; } = 0;
        public int IV { get; set; } = 0;
        public int SizeIV { get; set; } = 0;
        public int Nature { get; set; } = 0;
        public int SizeNature { get; set; } = 0;
        public int Encryption { get; set; } = 0;
        public int SizeEncryption { get; set; } = 0;
        public int Pkrus { get; set; } = 0;
        public int Checksum { get; set; } = 0;
        public int ChecksumCalcDataStart { get; set; } = 0;
        public int Version { get; set; } = 0;
        public int Nickname { get; set; } = 0;
        public int NicknameSize { get; set; } = 0;
        public int OTName { get; set; } = 0;
        public int OTNameSize { get; set; } = 0;
        public int Language { get; set; } = 0;

        public void SetValues(int gen, int subGen)
        {
            int pid = 0, dex = 0, item = 0, id = 0, sid = 0, exp = 0, friendship = 0,
                ability = 0, hpEV = 0, attEV = 0, defEV = 0, speedEV = 0, spAttEV = 0, spDefEV = 0,
                cool = 0, beauty = 0, cute = 0, smart = 0, tough = 0, sheen = 0, move1 = 0, move2 = 0,
                move3 = 0, move4 = 0, iv = 0, nature = 0, sizePID = 0, sizeDex = 0, sizeItem = 0,
                sizeID = 0, sizeSID = 0, sizeEXP = 0, sizeFriendship = 0, sizeAbility = 0,
                sizeHPEV = 0, sizeAttEV = 0, sizeDefEV = 0, sizeSpeedEV = 0, sizeSpAttEV = 0,
                sizeSpDefEV = 0, sizeCool = 0, sizeBeauty = 0, sizeCute = 0, sizeSmart = 0,
                sizeTough = 0, sizeSheen = 0, sizeMove1 = 0, sizeMove2 = 0, sizeMove3 = 0, sizeMove4 = 0,
                sizeIV = 0, sizeNature = 0, encryption = 0, sizeEncryption = 0,
                pkrus = 0, checksum = 0, checksumCalcDataStart = 0, version = 0,
                nickname = 0, nicknameSize = 0, otName = 0, otNameSize = 0, language = 0;

            offset.Offsets3Later(ref pid, ref dex, ref item, ref id, ref sid, ref exp, ref friendship,
                                ref ability, ref hpEV, ref attEV, ref defEV, ref speedEV, ref spAttEV, ref spDefEV,
                                ref cool, ref beauty, ref cute, ref smart, ref tough, ref sheen, ref move1, ref move2,
                                ref move3, ref move4, ref iv, ref nature, ref sizePID, ref sizeDex, ref sizeItem,
                                ref sizeID, ref sizeSID, ref sizeEXP, ref sizeFriendship, ref sizeAbility,
                                ref sizeHPEV, ref sizeAttEV, ref sizeDefEV, ref sizeSpeedEV, ref sizeSpAttEV,
                                ref sizeSpDefEV, ref sizeCool, ref sizeBeauty, ref sizeCute, ref sizeSmart,
                                ref sizeTough, ref sizeSheen, ref sizeMove1, ref sizeMove2, ref sizeMove3, ref sizeMove4,
                                ref sizeIV, ref sizeNature, ref encryption, ref sizeEncryption, 
                                ref pkrus, ref checksum, ref checksumCalcDataStart, ref version,
                                ref nickname, ref nicknameSize, ref otName, ref otNameSize, ref language, gen, subGen);

            PID = pid;
            Dex = dex;
            Item = item;
            ID = id;
            SID = sid;
            EXP = exp;
            Friendship = friendship;
            Ability = ability;
            HPEV = hpEV;
            AttEV = attEV;
            DefEV = defEV;
            SpeedEV = speedEV;
            SpAttEV = spAttEV;
            SpDefEV = spDefEV;
            Cool = cool;
            Beauty = beauty;
            Cute = cute;
            Smart = smart;
            Tough = tough;
            Sheen = sheen;
            Move1 = move1;
            Move2 = move2;
            Move3 = move3;
            Move4 = move4;
            IV = iv;
            Nature = nature;
            SizePID = sizePID;
            SizeDex = sizeDex;
            SizeItem = sizeItem;
            SizeID = sizeID;
            SizeSID = sizeSID;
            SizeEXP = sizeEXP;
            SizeFriendship = sizeFriendship;
            SizeAbility = sizeAbility;
            SizeHPEV = sizeHPEV;
            SizeAttEV = sizeAttEV;
            SizeDefEV = sizeDefEV;
            SizeSpeedEV = sizeSpeedEV;
            SizeSpAttEV = sizeSpAttEV;
            SizeSpDefEV = sizeSpDefEV;
            SizeCool = sizeCool;
            SizeBeauty = sizeBeauty;
            SizeCute = sizeCute;
            SizeSmart = sizeSmart;
            SizeTough = sizeTough;
            SizeSheen = sizeSheen;
            SizeMove1 = sizeMove1;
            SizeMove2 = sizeMove2;
            SizeMove3 = sizeMove3;
            SizeMove4 = sizeMove4;
            SizeIV = sizeIV;
            SizeNature = sizeNature;
            Encryption = encryption;
            SizeEncryption = sizeEncryption;
            Pkrus = pkrus;
            Checksum = checksum;
            ChecksumCalcDataStart = checksumCalcDataStart;
            Version = version;
            Nickname = nickname;
            NicknameSize = nicknameSize;
            OTName = otName;
            OTNameSize = otNameSize;
            Language = language;
        }
    }
}

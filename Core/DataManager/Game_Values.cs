using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.Resource;

namespace PKX_Extraction.Core.DataManager
{
    public class Game_Values
    {
        Game_Values_Data data = new ();

        public int StorageDataSize { get; set; } = 0;
        public int PartyDataSize { get; set; } = 0;
        public int EffortTotal { get; set; } = 0;
        public bool IsEncrypted { get; set; } = true;
        public bool Invert { get; set; } = true;
        public int Option { get; set; } = 0;
        public int NumOfPokeInGen { get; set; } = 0;
        public int NumOfMovesInGen { get; set; } = 0;

        public void SetValues(int gen, int subGen)
        {
            int sds = 0, pds = 0, et = 0, o = 0, np = 0, nm = 0;
            bool ie = true, i = true;

            data.GameData(ref sds, ref pds, ref et, ref ie,
                        ref i, ref o, ref np, ref nm, gen, subGen);

            StorageDataSize = sds;
            PartyDataSize = pds;
            EffortTotal = et;
            IsEncrypted = ie;
            Invert = i;
            Option = o;
            NumOfPokeInGen = np;
            NumOfMovesInGen = nm;
        }
    }
}

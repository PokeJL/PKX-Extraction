using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.Resource;

namespace PKX_Extraction.Core.DataManager
{
    /// <summary>
    /// Stores the specific values of the targeted game
    /// </summary>
    public class Game_Values
    {
        Game_Values_Data data = new ();

        public int StorageDataSize { get; set; } = 0; //Size of Pokemon in the PC
        public int PartyDataSize { get; set; } = 0; //Size of Pokemon in the party
        public int EffortTotal { get; set; } = 0; //Max EV total
        public bool IsEncrypted { get; set; } = true; //If the game encryptes data
        public bool Invert { get; set; } = true; //Is the data little edian
        public int Option { get; set; } = 0; //Further contols for checksum
        public int NumOfPokeInGen { get; set; } = 0; //Number of Pokemon in gen
        public int NumOfMovesInGen { get; set; } = 0; //Number of moves in the game

        /// <summary>
        /// Fills targeted game data
        /// </summary>
        /// <param name="gen">Targeted gen</param>
        /// <param name="subGen">Used if games in same gen store data diffrently</param>
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

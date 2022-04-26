using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.Resource;

namespace PKX_Extraction.Core.DataManager
{
    class Game_Values
    {
        Game_Values_Data data;
        private int storageDataSize;
        private int partyDataSize;
        private int effortTotal;
        private bool isEncrypted;
        private bool invert;
        private int option;
        private int numOfPokeInGen;
        private int numOfMovesInGen;

        public Game_Values()
        {
            data = new();

            storageDataSize = 0;
            partyDataSize = 0;
            effortTotal = 0;
            isEncrypted = true;
            invert = true;
            option = 0;
            numOfPokeInGen = 0;
            numOfMovesInGen = 0;
        }

        public int GetColumn()
        {
            return storageDataSize;
        }

        public int GetSize()
        {
            return partyDataSize;
        }

        public int GetEffortTotal()
        {
            return effortTotal;
        }

        public bool GetIsEncrypted()
        {
            return isEncrypted;
        }

        public bool GetInvert()
        {
            return invert;
        }

        public int GetOption()
        {
            return option;
        }

        public int GetNumOfPokeInGen()
        {
            return numOfPokeInGen;
        }

        public int GetNumOfMovesInGen()
        {
            return numOfMovesInGen;
        }

        public void SetValues(int gen, int subGen)
        {
            data.GameData(ref storageDataSize, ref partyDataSize, ref effortTotal, ref isEncrypted,
                        ref invert, ref option, ref numOfPokeInGen, ref numOfMovesInGen, gen, subGen);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.DataManager;

namespace PKX_Extraction.Core.Resource
{
    class Game_Values_Data
    {
        public Game_Values_Data()
        {

        }

        public void GameData(ref int storageDataSize, ref int partyDataSize, ref int effortTotal, ref bool isEncrypted,
                            ref bool invert, ref int option, ref int numOfPokeInGen, ref int numOfMovesInGen, int gen,
                            int subGen)
        {
            if (gen == 1 && subGen == 0) //RBY
            {
                storageDataSize = PokeCrypto.SIZE_1STORED;
                partyDataSize = PokeCrypto.SIZE_1PARTY;
                effortTotal = 327675;
                isEncrypted = false;
                invert = false;
                option = 2;
                numOfPokeInGen = 151;
                numOfMovesInGen = 165;
            }

            if (gen == 2 && subGen == 0) //GSC
            {
                storageDataSize = PokeCrypto.SIZE_2STORED;
                partyDataSize = PokeCrypto.SIZE_2PARTY;
                effortTotal = 327675;
                isEncrypted = false;
                invert = false;
                option = 3;
                numOfPokeInGen = 251;
                numOfMovesInGen = 251;
            }

            if (gen == 2 && subGen == 2) //Space World
            {
                storageDataSize = 63;
                partyDataSize = 48;
                effortTotal = 327675;
                isEncrypted = false;
                invert = true;
                option = 0;
            }

            if (gen == 3 && subGen == 0) //RSEFRLG
            {
                storageDataSize = 80; //Storage Size
                partyDataSize = 100; //Party Size
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 386;
                numOfMovesInGen = 354;
            }

            if (gen == 3 && subGen == 1) //Colo
            {
                storageDataSize = 312;
                partyDataSize = 312;
                effortTotal = 510;
                isEncrypted = false;
                invert = false;
                option = 1;
                numOfPokeInGen = 386;
                numOfMovesInGen = 354;
            }

            if (gen == 3 && subGen == 2) //XD
            {
                storageDataSize = 196;
                partyDataSize = 196;
                effortTotal = 510;
                isEncrypted = false;
                invert = false;
                option = 1;
                numOfPokeInGen = 386;
                numOfMovesInGen = 354;
            }

            if (gen == 4 && subGen == 0) //DPPtHGSS
            {
                storageDataSize = 136;
                partyDataSize = 236;
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 493;
                numOfMovesInGen = 467;
            }

            if (gen == 5 && subGen == 0) //BWB2W2
            {
                storageDataSize = 136;
                partyDataSize = 236;
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 649;
                numOfMovesInGen = 559;
            }

            if (gen == 6 && subGen == 0) //XYORAS
            {
                storageDataSize = 232;
                partyDataSize = 260;
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 721;
                numOfMovesInGen = 621;
            }

            if (gen == 7 && subGen == 0) //SMUSUM
            {
                storageDataSize = 232;
                partyDataSize = 260;
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 809;
                numOfMovesInGen = 728;
            }

            if (gen == 8 && subGen == 0) //SS
            {
                storageDataSize = PokeCrypto.SIZE_8STORED;
                partyDataSize = PokeCrypto.SIZE_8PARTY;
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 898;
                numOfMovesInGen = 826;
            }
        }
    }
}

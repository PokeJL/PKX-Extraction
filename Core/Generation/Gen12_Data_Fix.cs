using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.DataManager;

namespace PKX_Extraction.Core.Generation
{
    class Gen12_Data_Fix
    {
        public Gen12_Data_Fix() { }

        public byte[] Gen12Fix(List<List<byte>> pokemon, int slot, int length, int gen)
        {
            int size = 0;

            if (gen == 1)
                size = PokeCrypto.SIZE_1ULIST;
            else
                size = PokeCrypto.SIZE_2ULIST;

            byte[] data = new byte[size];

            data[0] = 0x01;
            data[1] = pokemon[slot][1];
            data[2] = 0xFF;

            for(int i = 0; i < length; i++)
            {
                data[i + 3] = pokemon[slot][i];
            }

            for(int i = length + 3; i < data.Length; i++)
            {
                data[i] = 0x00;
            }

            return data;
        }
    }
}

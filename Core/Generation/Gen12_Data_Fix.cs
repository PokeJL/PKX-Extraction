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
        /// <summary>
        /// This function fixes gen 1 and 2 files by
        /// adding back in the header and adding 
        /// 0x00 padding to the end of the file.
        /// </summary>
        /// <param name="pokemon">List of list of Pokemon</param>
        /// <param name="slot">Current index in the list</param>
        /// <param name="length">Ize of Pokemon datya in storage</param>
        /// <param name="gen">Target gen</param>
        /// <returns></returns>
        public byte[] Gen12Fix(List<List<byte>> pokemon, int slot, int length, int gen)
        {
            int size;

            if (gen == 1)
                size = PokeCrypto.SIZE_1ULIST;
            else
                size = PokeCrypto.SIZE_2ULIST;

            byte[] data = new byte[size];
            //Add header into file
            data[0] = 0x01;
            data[1] = pokemon[slot][1];
            data[2] = 0xFF;
            //Add Pokemon data
            for(int i = 0; i < length; i++)
                data[i + 3] = pokemon[slot][i];

            //Add padding at the end
            for(int i = length + 3; i < data.Length; i++)
                data[i] = 0x00;

            return data;
        }
    }
}

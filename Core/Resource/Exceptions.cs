using System;
using PKX_Extraction.Core.DataManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.Resource
{
    class Exceptions
    {
        public Exceptions() { }

        public void FRLGTrainerTower(ref byte[] data)
        {
            //These Pokemon are encrypted twice; therefore, needs the encryption to be broken a second time
            if (data[0] == 0x0A && data[1] == 0x00 && data[2] == 0x00 && data[3] == 0x00 && data[4] == 0x0A &&
                data[5] == 0x00 && data[6] == 0x00 && data[7] == 0x00 && data[8] == 0xBF && data[9] == 0xCD &&
                data[10] == 0xCA && data[11] == 0xBF && data[12] == 0xC9 && data[13] == 0xC8 && data[14] == 0xFF &&
                data[15] == 0x00)
            {
                //Twins Jen and Kira shiny Espeon
                data = PokeCrypto.DecryptArray3(data);
            }
            else if (data[0] == 0x8A && data[1] == 0x00 && data[2] == 0x00 && data[3] == 0x00 && data[4] == 0x8A && 
                data[5] == 0x00 && data[6] == 0x00 && data[7] == 0x00 && data[8] == 0xC7 && data[9] == 0xBF && 
                data[10] == 0xC9 && data[11] == 0xD1 && data[12] == 0xCE && data[13] == 0xC2 && data[14] == 0xFF && 
                data[15] == 0x00)
            {
                //Burglar Jac shiny Meowth
                data = PokeCrypto.DecryptArray3(data);
            }
            else if (data[0] == 0x17 && data[1] == 0x00 && data[2] == 0x00 && data[3] == 0x00 && data[4] == 0x17 && 
                data[5] == 0x00 && data[6] == 0x00 && data[7] == 0x00 && data[8] == 0xCD && data[9] == 0xBF && 
                data[10] == 0xBB && data[11] == 0xC5 && data[12] == 0xC3 && data[13] == 0xC8 && data[14] == 0xC1 && 
                data[15] == 0xFF)
            {
                //Fisherman Kaden shiny Seaking
                data = PokeCrypto.DecryptArray3(data);
            }
        }

        public void BWB2W2VsSeeker (ref List<List<byte>> data, int length)
        {
            //Vs Seeker Pokemon Seem to have orgin game version wiped and PK5 files don't load without that
            for (int i = 0; i < length; i++)
            {
                if (data[i][95] == 0x00)
                {
                    data[i][95] = 0x15;
                }
            }
        }
    }
}

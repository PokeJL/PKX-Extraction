using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    class PokeCrypto_Start
    {
        public PokeCrypto_Start() { }

        //From PKHeX and modified to meet needs of this application needed to get decryption started
        public byte[] PK3(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted3(ref data);
            if (data.Length != PokeCrypto.SIZE_3PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_3PARTY);
            return data;
        }

        public byte[] PK4(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted45(ref data);
            if (data.Length != PokeCrypto.SIZE_4PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_4PARTY);
            return data;
        }

        public byte[] PK5(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted45(ref data);
            if (data.Length != PokeCrypto.SIZE_5PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_5PARTY);
            return data;
        }

        public byte[] PK67(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted67(ref data);
            if (data.Length != PokeCrypto.SIZE_6PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_6PARTY);
            return data;
        }

        public byte[] PK8(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted8(ref data);
            if (data.Length != PokeCrypto.SIZE_8PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_8PARTY);
            return data;
        }
    }
}

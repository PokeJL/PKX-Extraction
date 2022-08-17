using PKX_Extraction.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    class Data_Conversion
    {
        public Data_Conversion() { }

        /// <summary>
        /// Converts one hex byte to an int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <returns>Returns the converted hex value as an int</returns>
        public int ConOneHex(byte hex)
        {
            return Convert.ToInt32(hex);
        }

        /// <summary>
        /// Converts a hex string stored in
        /// Little Endian to and int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns the converted hex value as an int</returns>
        public int LittleEndian(byte[] hex, int start, int length, bool invertData)
        {
            byte[] buffer = new byte[length];
            int value = 0;

            Extract(hex, buffer, start, length);

            if (invertData == true)
                Invert(buffer);

            if(length == 1)
            {
                value = ConOneHex(buffer[0]);
            }
            if (length == 2)
            {
                value = Int16(buffer);
            }
            if (length == 3)
            {
                value = Int24(buffer);
            }
            if (length == 4)
            {
                value = Int32(buffer);
            }

            return value;
        }

        /// <summary>
        /// Converts a hex string stored in
        /// Little Endian to and int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns the converted hex value as an int from 2D array</returns>
        public int LittleEndian2D(List<List<byte>> hex, int row, int start, int length, bool invertData)
        {
            byte[] buffer = new byte[length];
            int value = 0;

            Extract2D(hex, buffer, row, start, length);

            if (invertData == true)
                Invert(buffer);

            if (length == 1)
            {
                value = ConOneHex(buffer[0]);
            }
            if (length == 2)
            {
                value = Int16(buffer);
            }
            if (length == 3)
            {
                value = Int24(buffer);
            }
            if (length == 4)
            {
                value = Int32(buffer);
            }

            return value;
        }

        /// <summary>
        /// Extracts a hex string from a array of hex values
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns array of extracted values</returns>
        private void Extract(byte[] hex, byte[] buffer, int start, int length) 
        {
            for(int i = 0; i < length; i++)
            {
                buffer[i] = hex[i + start];
            }
        }

        /// <summary>
        /// Extracts a hex string from a array of hex values
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns array of extracted values from 2D array</returns>
        private void Extract2D(List<List<byte>> hex, byte[] buffer, int row, int start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                buffer[i] = hex[row][i + start];
            }
        }

        /// <summary>
        /// Inverts a 1D array
        /// </summary>
        /// <param name="buffer">Data needing to be inverted</param>
        private static void Invert(byte[] buffer)
        {
            int m = buffer.Length - 1;
            byte temp;
            for (int i = 0; i < m; i++, m--)
            {
                temp = buffer[i];
                buffer[i] = buffer[m];
                buffer[m] = temp;
            }
        }

        //Two byte hex to int
        private int Int16(byte[] buffer)
        {
            return buffer[0] << 8 | buffer[1];
        }

        //Three byte hex to int.
        private int Int24(byte[] buffer)
        {
            return buffer[0] << 16 | buffer[1] << 8 | buffer[2];
        }

        //Four byte hex to int.
        private int Int32(byte[] buffer)
        {
            return buffer[0] << 32 | buffer[1] << 16 | buffer[2] << 8 | buffer[3];
        }

        /// <summary>
        /// Converts byte data to a string
        /// </summary>
        /// <param name="data">The provided data</param>
        /// <param name="offset">Where to start in the data</param>
        /// <param name="length">Length of data needing to be converted</param>
        /// <returns></returns>
        public string HexToBinaryString (byte[] data, int offset, int length)
        {
            string hexString;
            byte[] dataBuffer = new byte[length];

            Extract(data, dataBuffer, offset, length);
            if (length > 1)
            {
                Invert(dataBuffer);
            }

            hexString = Convert.ToString(dataBuffer[0], 2).PadLeft(8, '0');

            for (int i  = 1; i < length; i++)
            {
                hexString += Convert.ToString(dataBuffer[i], 2).PadLeft(8, '0');
            }

            return hexString;
        }

        /// <summary>
        /// Converts a sting of binary data to int
        /// </summary>
        /// <param name="word">The string needing to convert to int</param>
        /// <param name="start">Where to start in string</param>
        /// <param name="end">Where to stop in the string</param>
        /// <returns></returns>
        public int BinaryStringToInt(string word, int start, int end)
        {
            string temp;
            temp = word.Substring(start, end);
            temp = Reverse(temp);
            return Convert.ToInt32(temp, 2);
        }

        //Reverse a string. Code from https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

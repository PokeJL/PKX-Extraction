using PKX_Extraction.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.DataManager
{
    class Array_Manager
    {
        public Array_Manager() { }

        public void Array1Dto2D(List<List<byte>> a2d, int row, int column, byte[] a1d)
        {
            List<byte> temp = new List<byte>();
            a2d.Add(temp);
            for (int i = 0; i < column; i++)
            {
                a2d[row].Add(a1d[i]);// = a1d[i];
            }
        }

        public void ArrayPart(byte[] recipiant, int recipiantStart, int size, byte[] donor, int donorStart)
        {
            for (int i = recipiantStart; i < recipiantStart + size; i++, donorStart++)
            {
                recipiant[i] = donor[donorStart];
            }
        }

        public void UpdateCheck(List<List<byte>> pokemon, int found, byte[] convert, ref bool update, int gen, int subGen, bool inversion)
        {
            Data_Conversion hex = new();
            Offest_data offset_Data = new();
            Pokemon_Value_Check check = new();

            offset_Data.SetValues(gen, subGen);

            if (found != 0)
            {
                for (int f = 0; f < found && update == false; f++)
                {
                    if (check.Duplicate(pokemon, convert, inversion, f, offset_Data))
                    {
                        update = true;
                    }
                }
            }
        }

        public void AddPart1Dto2D(List<List<byte>> pokemon, int row, int start1, byte[] data, int start2, int length)
        {
            for (int i = 0; i < length; i++)
            {
                pokemon[row][start1 + i] = data[start2 + i];
            }
        }

        public bool ArrayCompare(byte[] arr1, byte[] arr2)
        {
            return arr1.SequenceEqual(arr2);
        }
    }
}

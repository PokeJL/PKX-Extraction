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

        /// <summary>
        /// Adds a 1D array to a list of lists
        /// </summary>
        /// <param name="a2d">the list of lists</param>
        /// <param name="row">index of the list</param>
        /// <param name="column">length of 1D array</param>
        /// <param name="a1d">1D array</param>
        public void Array1Dto2D(List<List<byte>> a2d, int row, int column, byte[] a1d)
        {
            List<byte> temp = new List<byte>();
            a2d.Add(temp);
            for (int i = 0; i < column; i++)
                a2d[row].Add(a1d[i]);
        }

        /// <summary>
        /// Extracts part of a 1D array into another 1D array
        /// </summary>
        /// <param name="recipiant">The array getting the part of the other array</param>
        /// <param name="donor">Array donating the data</param>
        /// <param name="donorStart">Where to start in the donor array</param>
        public void ArrayPart(byte[] recipiant, byte[] donor, int donorStart)
        {
            for (int i = 0; i < recipiant.Length; i++, donorStart++)
                recipiant[i] = donor[donorStart];
        }

        /// <summary>
        /// Checks if the Pokemon as alresdy been found
        /// </summary>
        /// <param name="pokemon">list of list of Pokemon</param>
        /// <param name="found">How many Pokemon are found</param>
        /// <param name="convert">The found Pokemon being checked</param>
        /// <param name="gen">Selected games gen</param>
        /// <param name="subGen">The targeted game in the gen</param>
        /// <param name="inversion">Is the data in little edian</param>
        public bool UpdateCheck(List<List<byte>> pokemon, int found, byte[] convert, int gen, int subGen, bool inversion)
        {
            Offest_data offset_Data = new();
            Pokemon_Value_Check check = new();

            offset_Data.SetValues(gen, subGen);

            if (found != 0)
            {
                for (int f = 0; f < found; f++)
                {
                    if (check.Duplicate(pokemon, convert, inversion, f, offset_Data))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Adds part of a 1D array to a list of list
        /// </summary>
        /// <param name="pokemon">list of list data is being added to</param>
        /// <param name="row">the index of the list of list the data is being added to</param>
        /// <param name="data">The 1d donor data</param>
        /// <param name="start2">where to start in the donor 1D array</param>
        /// <param name="length">The length of data to donate</param>
        public void AddPart1Dto2D(List<List<byte>> pokemon, int row, byte[] data, int start, int length)
        {
            for (int i = 0; i < length; i++)
                pokemon[row].Add(data[start + i]);
        }

        /// <summary>
        /// Compares 2 1D arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public bool ArrayCompare(byte[] arr1, byte[] arr2)
        {
            return arr1.SequenceEqual(arr2);
        }
    }
}

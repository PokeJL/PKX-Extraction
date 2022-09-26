using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Run Options
--------------------------------------------------------------------------
option 0 is for standard run of the program (mainline games gen 3 onward)
option 1 is Colo and XD run of the program
option 2 is for RBY run of the program
option 3 is for GSC run of the program
--------------------------------------------------------------------------
*/
namespace PKX_Extraction.Core.DataManager
{
    class Validation
    {
        readonly Data_Conversion hex;
        readonly Offest_data offset_Data;
        readonly Pokemon_Value_Check pvc;

        public Validation() 
        {
            hex = new();
            offset_Data = new();

            pvc = new();
        }

        /// <summary>
        /// Does basic check at start of loop to determine
        /// if the data is Pokemon like and worth checking further
        /// </summary>
        /// <param name="inputFile">Potential Pokemon data</param>
        /// <param name="option">Which run of the program are we using</param>
        /// <param name="i">index</param>
        /// <param name="gen">Target gen</param>
        /// <param name="subGen">Helps determine which gen of the gen 
        /// is being targeted</param>
        /// <param name="inversion">Is data in little edian</param>
        /// <returns></returns>
        public bool ChecksumStart(byte[] inputFile, int option, int i, int gen, int subGen, bool inversion)
        {
            offset_Data.SetValues(gen, subGen);

            if (option == 0) //Checksum does not equal 0
            {
                if (hex.LittleEndian(inputFile, i + offset_Data.Checksum, 2, inversion) != 0)
                    return true;
            }
            else if (option == 1) //Fake checksum check for Colo and XD
            {
                if (pvc.ColoXDChecksum(inputFile, i, offset_Data)) //78 = 0x4E & 56 = 0x38
                    return true;
            }
            else if (option == 2) //Fake checksum check for RBY
            {
                if (pvc.RBYChecksum(inputFile, i, offset_Data))
                    return true;
            }
            else if (option == 3) //Fake checksum check for GSC
            {
                if (pvc.GSCChecksum(inputFile, i, offset_Data))
                    return true;
            }

            return false;
        }
    }
}

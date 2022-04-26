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

            //Offset data
            offset_Data.SetValues(gen, subGen);

            if (found != 0)
            {
                for (int f = 0; f < found && update == false; f++)
                {
                    if(hex.LittleEndian2D(pokemon, f, offset_Data.GetPID(), offset_Data.GetSizePID(), inversion) == hex.LittleEndian(convert, offset_Data.GetPID(), offset_Data.GetSizePID(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetDex(), offset_Data.GetSizeDex(), inversion) == hex.LittleEndian(convert, offset_Data.GetDex(), offset_Data.GetSizeDex(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetID(), offset_Data.GetSizeID(), inversion) == hex.LittleEndian(convert, offset_Data.GetID(), offset_Data.GetSizeID(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetSID(), offset_Data.GetSizeSID(), inversion) == hex.LittleEndian(convert, offset_Data.GetSID(), offset_Data.GetSizeSID(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetItem(), offset_Data.GetSizeItem(), inversion) == hex.LittleEndian(convert, offset_Data.GetItem(), offset_Data.GetSizeItem(), inversion) && //May cause issue if item is consumed
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetFriendship(), offset_Data.GetSizeFriendship(), inversion) == hex.LittleEndian(convert, offset_Data.GetFriendship(), offset_Data.GetSizeFriendship(), inversion) && //May cause issue if Pokemon fraints
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetAbility(), offset_Data.GetSizeAbility(), inversion) == hex.LittleEndian(convert, offset_Data.GetAbility(), offset_Data.GetSizeAbility(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetHPEV(), offset_Data.GetSizeHPEV(), inversion) == hex.LittleEndian(convert, offset_Data.GetHPEV(), offset_Data.GetSizeHPEV(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetAttEV(), offset_Data.GetSizeAttEV(), inversion) == hex.LittleEndian(convert, offset_Data.GetAttEV(), offset_Data.GetSizeAttEV(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetDefEV(), offset_Data.GetSizeDefEV(), inversion) == hex.LittleEndian(convert, offset_Data.GetDefEV(), offset_Data.GetSizeDefEV(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetSpAttEV(), offset_Data.GetSizeSpAttEV(), inversion) == hex.LittleEndian(convert, offset_Data.GetSpAttEV(), offset_Data.GetSizeSpAttEV(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetSpDefEV(), offset_Data.GetSizeSpDefEV(), inversion) == hex.LittleEndian(convert, offset_Data.GetSpDefEV(), offset_Data.GetSizeSpDefEV(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetSpeedEV(), offset_Data.GetSizeSpeedEV(), inversion) == hex.LittleEndian(convert, offset_Data.GetSpeedEV(), offset_Data.GetSizeSpeedEV(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetCool(), offset_Data.GetSizeCool(), inversion) == hex.LittleEndian(convert, offset_Data.GetCool(), offset_Data.GetSizeCool(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetBeauty(), offset_Data.GetSizeBeauty(), inversion) == hex.LittleEndian(convert, offset_Data.GetBeauty(), offset_Data.GetSizeBeauty(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetCute(), offset_Data.GetSizeCute(), inversion) == hex.LittleEndian(convert, offset_Data.GetCute(), offset_Data.GetSizeCute(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetSmart(), offset_Data.GetSizeSmart(), inversion) == hex.LittleEndian(convert, offset_Data.GetSmart(), offset_Data.GetSizeSmart(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetTough(), offset_Data.GetSizeTough(), inversion) == hex.LittleEndian(convert, offset_Data.GetTough(), offset_Data.GetSizeTough(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetSheen(), offset_Data.GetSizeSheen(), inversion) == hex.LittleEndian(convert, offset_Data.GetSheen(), offset_Data.GetSizeSheen(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), inversion) == hex.LittleEndian(convert, offset_Data.GetMove1(), offset_Data.GetSizeMove1(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), inversion) == hex.LittleEndian(convert, offset_Data.GetMove2(), offset_Data.GetSizeMove2(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), inversion) == hex.LittleEndian(convert, offset_Data.GetMove3(), offset_Data.GetSizeMove3(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), inversion) == hex.LittleEndian(convert, offset_Data.GetMove4(), offset_Data.GetSizeMove4(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetNature(), offset_Data.GetSizeNature(), inversion) == hex.LittleEndian(convert, offset_Data.GetNature(), offset_Data.GetSizeNature(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetEncryption(), offset_Data.GetSizeEncryption(), inversion) == hex.LittleEndian(convert, offset_Data.GetEncryption(), offset_Data.GetSizeEncryption(), inversion) &&
                        hex.LittleEndian2D(pokemon, f, offset_Data.GetEXP(), offset_Data.GetSizeEXP(), inversion) == hex.LittleEndian(convert, offset_Data.GetEXP(), offset_Data.GetSizeEXP(), inversion)
                        )
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

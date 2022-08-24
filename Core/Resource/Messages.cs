using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKX_Extraction.Core.DataManager;

namespace PKX_Extraction.Core.Resource
{
    class Messages
    {
        public Messages() { }

        /// <summary>
        /// returns a messages for the selected main line target game
        /// </summary>
        /// <param name="gen"></param>
        /// <returns></returns>
        public string MainLine(int gen)
        {
            string message;

            if (gen == 1)
            {
                message = string.Format("-Some non existent Pokemon may be found.{0} " +
                    "-Result for Japanese versions may very.{0} " +
                    "-Level 1 and glitch Pokemon are excluded from results.{0} " +
                    "-Use PKHeX to fix Pokemon Name and OT Name.", Environment.NewLine);
            }
            else if (gen == 2)
            {
                message = string.Format("-Some non existent Pokemon may be found.{0} " +
                    "-Level 1 and glitch Pokemon are excluded from results.{0} " +
                    "-Use PKHeX to fix Pokemon Name and OT Name.", Environment.NewLine);
            }
            else if (gen == 3)
            {
                message = string.Format("To be used with Ruby, Sapphire, Emerald, Fire Red, and Leaf Green only.{0}Colosseum and XD under Spin Off Games.{0}The rip process will take some time. Opponent's Pokemon can be found after active party at the top of the list.", Environment.NewLine);
            }
            else if (gen == 4)
            {
                message = string.Format("The rip process will take a little time. Opponent's Pokemon can be found at the end of the list.");
            }
            else if (gen == 5)
            {
                message = string.Format("Vs. Recorder Pokemon may have game set to Black version. Party and opponent's Pokemon can be found at the end of the list.");
            }
            else if (gen == 6)
            {
                message = string.Format("Multi battle not tested. Use PKHeX to dump Vs. Recorder playback.");
            }
            else if (gen == 7)
            {
                message = string.Format("To be used with Sun, Moon, Ultra Sun, and Ultra Moon only.{0}Minimal testing done.Use PKHeX to dump Vs. Recorder playback.", Environment.NewLine);
            }
            else if (gen == 8)
            {
                message = string.Format("To be used with Sword and Shield only.{0}Should work, but not tested with an actual RAM dump.", Environment.NewLine);
            }
            else
            {
                message = string.Format("Error.");
            }

            return message;
        }

        /// <summary>
        /// returns a messages for the selected spin off target game
        /// </summary>
        /// <param name="sel"></param>
        /// <returns></returns>
        public string SpinOff(int sel)
        {
            string message;

            //if(sel == 1)
            //{
            //    //PAL Stadium 1/2
            //    message = string.Format("No info has been added.");
            //}
            if (sel == 1)
            {
                //Space World 97 Gen 2
                message = string.Format("-Put the Pokemon you want to dump in the first slot of the party.{0}" +
                "-In the emulator click on Tool -> Debug -> Memory Viewer then click the save option.{0}" +
                "-In the Address box input 0000D6B2 and in the \"Size\" box input 30. Then click OK.{0}" +
                "-Save the .dmp file somewhere that you can find it.{0}" +
                "-The name in the drop down menu is what the Pokemon will be in the game.", Environment.NewLine);
            }
            else if (sel == 2)
            {
                //Colosseum
                message = string.Format("The rip process will take some time.");
            }
            else if (sel == 3)
            {
                //XD
                message = string.Format("The rip process will take some time.");
            }
            //else if (sel == 4)
            //{
            //    //PBR Friend Pass
            //    message = string.Format("No info has been added.");
            //}
            else
            {
                message = string.Format("Error");
            }

            return message;
        }

        /// <summary>
        /// Returns a basic summary of the selected extracted Pokemon
        /// </summary>
        /// <param name="pokemon">The list of list of Pokemon</param>
        /// <param name="list">Needed to get the correct image</param>
        /// <param name="val">Applcation valuse</param>
        /// <param name="offest">Offsets of the target game</param>
        /// <param name="gv">Game values for the target game</param>
        /// <returns></returns>
        public string PokemonSummary(List<List<byte>>pokemon, List<string> list, 
            Applicaton_Values val, Offest_data offest, Game_Values gv)
        {
            Data_Conversion hex = new();
            Pokemon_Data data = new();
            Dex_Conversion dex = new();
            string message = string.Empty;

            if (val.Gen == 2 && val.SubGen == 2)
            {
                Gen_2_Beta_Data beta = new();
                if (val.DexNum >= 152)
                    list[0] = "d97_" + val.DexNum.ToString();
                else
                    list[0] = "b_" + val.DexNum.ToString();
                message = beta.GetNameString(val.DexNum) + Environment.NewLine;
                message += "ID: " + hex.LittleEndian2D(pokemon, val.SelectIndex, 9, 2, gv.Invert).ToString() + Environment.NewLine;
                message += "SID: 00000" + Environment.NewLine;
                message += "Move 1: " + data.getMove(hex.ConOneHex(pokemon[0][5])) + Environment.NewLine;
                message += "Move 2: " + data.getMove(hex.ConOneHex(pokemon[0][6])) + Environment.NewLine;
                message += "Move 3: " + data.getMove(hex.ConOneHex(pokemon[0][7])) + Environment.NewLine;
                message += "Move 4: " + data.getMove(hex.ConOneHex(pokemon[0][8])) + Environment.NewLine;
            }
            else
            {
                if (val.Gen == 3)
                    val.DexNum = dex.Gen3GetDexNum(hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Dex, offest.SizeDex, gv.Invert));
                else if (val.Gen == 1)
                    val.DexNum = dex.GetGen1Num(hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Dex, offest.SizeDex, gv.Invert));
                else
                    val.DexNum = hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Dex, offest.SizeDex, gv.Invert);

                message = data.getPokemonName(val.DexNum) + Environment.NewLine;
                message += "ID: " + hex.LittleEndian2D(pokemon, val.SelectIndex, offest.ID, offest.SizeID, gv.Invert).ToString() + Environment.NewLine;
                if (val.Gen == 1 || val.Gen == 2)
                    message += "SID: 00000" + Environment.NewLine;
                else
                    message += "SID: " + hex.LittleEndian2D(pokemon, val.SelectIndex, offest.SID, offest.SizeSID, gv.Invert).ToString() + Environment.NewLine;
                message += "Move 1: " + data.getMove(hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Move1, offest.SizeMove1, gv.Invert)) + Environment.NewLine;
                message += "Move 2: " + data.getMove(hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Move2, offest.SizeMove2, gv.Invert)) + Environment.NewLine;
                message += "Move 3: " + data.getMove(hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Move3, offest.SizeMove3, gv.Invert)) + Environment.NewLine;
                message += "Move 4: " + data.getMove(hex.LittleEndian2D(pokemon, val.SelectIndex, offest.Move4, offest.SizeMove4, gv.Invert)) + Environment.NewLine;

                list[0] = "b_" + val.DexNum.ToString();
            }

            return message;
        }
    }
}

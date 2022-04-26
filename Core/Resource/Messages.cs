using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX_Extraction.Core.Resource
{
    class Messages
    {
        public Messages() { }

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
    }
}

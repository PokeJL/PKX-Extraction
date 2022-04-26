using System;
using PKX_Extraction.Core.DataManager;
using PKX_Extraction.Core.Resource;
using PKX_Extraction.Core.Generation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace PKX_Extraction
{
    public partial class PKX_Exctraction : Form
    {
        readonly Data_Conversion hex;
        readonly Dex_Conversion dex;
        readonly Pokemon_Data data;
        readonly File_Manager fm;
        readonly Data_Ripper rip;
        readonly Applicaton_Values val;
        readonly Messages mess;
        Offest_data offest;
        Game_Values gv;
        Gen12_Data_Fix fix;
        readonly List<string> list;
        List<List<byte>> pokemon;

        private delegate void DataSetMethodInvoker();
        public delegate void MaxProgressMethodInvoker(int amount);
        public delegate void CurrentProgressMethodInvoker(int amount);
        public delegate bool EndThread();
        public PKX_Exctraction()
        {
            InitializeComponent();
            hex = new Data_Conversion();
            dex = new Dex_Conversion();
            data = new Pokemon_Data();
            fm = new File_Manager();
            rip = new Data_Ripper();
            val = new Applicaton_Values();
            mess = new Messages();
            offest = new();
            gv = new();
            fix = new();
            pokemon = new List<List<byte>>();

            fm.MP += new File_Manager.MaxProgressMethodInvoker(SetAmount);
            rip.CP += new Data_Ripper.CurrentProgressMethodInvoker(UpdateProgress);
            rip.End += new Data_Ripper.EndThread(Stopper);

            object[] games = new object[1];
            games[0] = "Select Game";
            selectGameCB.Items.AddRange(games);
            selectGameCB.SelectedIndex = 0;

            list = new List<string>();
        }

        private void OpenFileBTN_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileOpen();
            }
        }

        private void FileOpen()
        {
            try
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                OpenFileTXB.Text = string.Format("{0}", openFileDialog1.FileName); //Show file path in textbox
                val.SetFileAdded(true); //fileAdded = true;
                val.SetPath(string.Format("{0}", openFileDialog1.FileName));
                FileInfo fi = new(val.GetPath());
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }

            if (val.GetFileAdded() == true)
                extractBTN.Enabled = true;
        }

        private void extractBTN_Click(object sender, EventArgs e)
        {
            pokemon.Clear();
            if (!backgroundWorker1.IsBusy)
            {
                val.PartReset();
                backgroundWorker1.WorkerSupportsCancellation = true;
                saveBTN.Enabled = false;
                extractBTN.Text = "Stop";
                OpenFileBTN.Enabled = false;
                pkmSelect.Enabled = false;
                val.SetEndTask(false);
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                backgroundWorker1.CancelAsync();
                val.SetEndTask(true);
                pkmSelect.Items.Clear();
                OpenFileBTN.Enabled = true;
                RipProgressBar.Value = 0;
                extractBTN.Text = "Extract";
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RipProgressBar.Value = e.ProgressPercentage;
        }

        private void SaveDialog(int slot)
        {
            SaveFileDialog saveFileDialog1 = new();

            if (val.GetGen() == 3)
            {
                saveFileDialog1.Filter = "PK3|*.pk3";
            }
            if (val.GetGen() == 4)
            {
                saveFileDialog1.Filter = "PK4|*.pk4";
            }
            if (val.GetGen() == 5)
            {
                saveFileDialog1.Filter = "PK5|*.pk5";
            }
            if (val.GetGen() == 2)
            {
                saveFileDialog1.Filter = "PK6|*.pk6";
            }
            if (val.GetGen() == 2)
            {
                saveFileDialog1.Filter = "PK2|*.pk2";
            }
            if (val.GetGen() == 1)
            {
                saveFileDialog1.Filter = "PK1|*.pk1";
            }
            if (val.GetGen() == 7 && val.GetSubGen() == 0)
            {
                saveFileDialog1.Filter = "PK7|*.pk7";
            }
            if (val.GetGen() == 8 && val.GetSubGen() == 0)
            {
                saveFileDialog1.Filter = "PK8|*.pk8";
            }

            saveFileDialog1.Title = "Save Pokemon";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                byte[] saveData = new byte[gv.GetColumn()];

                if (val.GetGen() == 1 || val.GetGen() == 2)
                {
                    saveData = fix.Gen12Fix(pokemon, slot, gv.GetColumn(), val.GetGen());
                }
                else
                {
                    for (int i = 0; i < gv.GetColumn(); i++)
                    {
                        saveData[i] = pokemon[slot][i];
                    }
                }

                fm.WriteFile(string.Format("{0}", saveFileDialog1.FileName), saveData);
            }
        }

        private void pkmSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            val.SetSelectIndex(pkmSelect.SelectedIndex);

            if (list.Count == 0)
                list.Add("1");

            if (val.GetGen() == 2 && val.GetSubGen() == 2)
            {
                Gen_2_Beta_Data beta = new();
                if (val.GetDexNum() >= 152)
                    list[0] = "d97_" + val.GetDexNum().ToString();
                else
                    list[0] = "b_" + val.GetDexNum().ToString();
                pokemonInfoTXB.Text = beta.GetNameString(val.GetDexNum()) + Environment.NewLine;
                pokemonInfoTXB.Text += "ID: " + hex.LittleEndian2D(pokemon, val.GetSelectIndex(), 9, 2, gv.GetInvert()).ToString() + Environment.NewLine;
                pokemonInfoTXB.Text += "SID: 00000" + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 1: " + data.getMove(hex.ConOneHex(pokemon[0][5])) + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 2: " + data.getMove(hex.ConOneHex(pokemon[0][6])) + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 3: " + data.getMove(hex.ConOneHex(pokemon[0][7])) + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 4: " + data.getMove(hex.ConOneHex(pokemon[0][8])) + Environment.NewLine;
            }
            else
            {
                if (val.GetGen() == 3)
                    val.SetDexNum(dex.Gen3GetDexNum(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetDex()/*val.GetSpeciesIndex()*/, offest.GetSizeDex()/*2*/, gv.GetInvert()/*val.GetInvert()*/)));
                else if (val.GetGen() == 1)
                    val.SetDexNum(dex.GetGen1Num(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetDex(), offest.GetSizeDex(), gv.GetInvert())));
                else
                    val.SetDexNum(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetDex()/*val.GetSpeciesIndex()*/, offest.GetSizeDex()/*2*/, gv.GetInvert()/*val.GetInvert()*/));

                pokemonInfoTXB.Text = data.getPokemonName(val.GetDexNum()) + Environment.NewLine;
                pokemonInfoTXB.Text += "ID: " + hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetID(), offest.GetSizeID(), gv.GetInvert()).ToString() + Environment.NewLine;
                if (val.GetGen() == 1 || val.GetGen() == 2)
                    pokemonInfoTXB.Text += "SID: 00000" + Environment.NewLine;
                else
                    pokemonInfoTXB.Text += "SID: " + hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetSID(), offest.GetSizeSID(), gv.GetInvert()).ToString() + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 1: " + data.getMove(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetMove1(), offest.GetSizeMove1(), gv.GetInvert())) + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 2: " + data.getMove(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetMove2(), offest.GetSizeMove2(), gv.GetInvert())) + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 3: " + data.getMove(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetMove3(), offest.GetSizeMove3(), gv.GetInvert())) + Environment.NewLine;
                pokemonInfoTXB.Text += "Move 4: " + data.getMove(hex.LittleEndian2D(pokemon, val.GetSelectIndex(), offest.GetMove4(), offest.GetSizeMove4(), gv.GetInvert())) + Environment.NewLine;

                list[0] = "b_" + val.GetDexNum().ToString();
            }
            Icon.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(list[0]);
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            SaveDialog(val.GetSelectIndex());
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (val.GetFileAdded() == true)
            {

                if (mainGameRBT.Checked == true)
                {
                    if (val.GetComboSelect() == 1)
                    {
                        SetClasses(1, 0);
                    }
                    if (val.GetComboSelect() == 2)
                    {
                        SetClasses(2, 0);
                    }
                    if (val.GetComboSelect() == 3)
                    {
                        SetClasses(3, 0);
                    }
                    if (val.GetComboSelect() == 4)
                    {
                        SetClasses(4, 0);
                    }
                    if (val.GetComboSelect() == 5)
                    {
                        SetClasses(5, 0);
                    }
                    if (val.GetComboSelect() == 6)
                    {
                        SetClasses(6, 0);
                    }
                    if (val.GetComboSelect() == 7)
                    {
                        SetClasses(7, 0);
                    }
                    if (val.GetComboSelect() == 8)
                    {
                        SetClasses(8, 0);
                    }
                }

                if (spinOffRBT.Checked == true) //Fix all when stadium is added
                {
                    if (val.GetComboSelect() == 1)
                    {
                        SetClasses(2, 2);
                    }
                    if (val.GetComboSelect() == 2)
                    {
                        SetClasses(3, 1);
                    }
                    if (val.GetComboSelect() == 3)
                    {
                        SetClasses(3, 2);
                    }
                }

                if (spinOffRBT.Checked == true) //Fix when stadium is added
                {
                    if (val.GetComboSelect() == 1)
                    {
                        Gen_2_SW97 g2 = new();
                        g2.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), val, gv);
                    }
                    else if (val.GetComboSelect() == 2 || val.GetComboSelect() == 3)
                    {
                        fm.LoadData(string.Format("{0}", openFileDialog1.FileName), val);
                        rip.SearchPokemon(pokemon, val, offest, gv);
                    }
                }
                else
                {
                    fm.LoadData(string.Format("{0}", openFileDialog1.FileName), val);
                    rip.SearchPokemon(pokemon, val, offest, gv);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added.");
            }

            System.Windows.Forms.MessageBox.Show(val.GetFound().ToString() + " Pokemon found.");

            BindComboBoxData();
        }

        private void SetClasses(int gen, int subGen)
        {
            val.SetGen(gen);
            val.SetSubGen(subGen);
            gv.SetValues(gen, subGen);
            offest.SetValues(gen, subGen);
        }

        private void BindComboBoxData()
        {
            if (pkmSelect.InvokeRequired)
            {
                // Worker thread.
                pkmSelect.Invoke(new DataSetMethodInvoker(BindComboBoxData));
            }
            else
            {
                object[] ItemObject = new object[val.GetFound()];
                if (val.GetFound() != 0)
                {
                    pkmSelect.Items.Clear();
                    for (int i = 0; i < val.GetFound(); i++)
                    {
                        if (val.GetGen() == 3)
                            val.SetDexNum(dex.Gen3GetDexNum(hex.LittleEndian2D(pokemon, i, offest.GetDex()/*val.GetSpeciesIndex()*/, offest.GetSizeDex()/*2*/, gv.GetInvert()/*val.GetInvert()*/)));
                        else if (val.GetGen() == 1)
                            val.SetDexNum(dex.GetGen1Num(hex.LittleEndian2D(pokemon, i, offest.GetDex(), offest.GetSizeDex(), gv.GetInvert())));
                        else
                            val.SetDexNum(hex.LittleEndian2D(pokemon, i, offest.GetDex()/*val.GetSpeciesIndex()*/, offest.GetSizeDex()/*2*/, gv.GetInvert()/*val.GetInvert()*/));

                        ItemObject[i] = data.getPokemonName(val.GetDexNum());
                    }
                    pkmSelect.Items.AddRange(ItemObject);
                    pkmSelect.SelectedIndex = 0;
                    saveBTN.Enabled = true;
                    pkmSelect.Enabled = true;
                }
                extractBTN.Enabled = true;
                OpenFileBTN.Enabled = true;
                extractBTN.Text = "Extract";
            }
        }

        private void SetAmount(int amount)
        {
            if (RipProgressBar.InvokeRequired)
            {
                RipProgressBar.Invoke(new MaxProgressMethodInvoker(SetAmount), amount);
            }
            else
            {
                RipProgressBar.Maximum = amount;
                RipProgressBar.Value = 0;
            }
        }

        private void UpdateProgress(int amount)
        {
            if (RipProgressBar.InvokeRequired)
            {
                RipProgressBar.Invoke(new CurrentProgressMethodInvoker(UpdateProgress), amount);
            }
            else
            {
                RipProgressBar.Value = amount;
            }
        }

        public bool Stopper()
        {
            return val.GetEndTask();
        }

        private void mainGameRBT_CheckedChanged(object sender, EventArgs e)
        {
            selectGameCB.Items.Clear();
            object[] games = new object[9];
            games[0] = "Select Game";
            games[1] = "Gen 1";
            games[2] = "Gen 2";
            games[3] = "Gen 3";
            games[4] = "Gen 4";
            games[5] = "Gen 5";
            games[6] = "Gen 6";
            games[7] = "Gen 7 SMUSUM";
            games[8] = "Gen 8 SWSH";
            selectGameCB.Items.AddRange(games);
            selectGameCB.SelectedIndex = 0;

            Info.Text = "This mode is for main line games.";

            selectGameCB.Enabled = true;
        }

        private void spinOffRBT_CheckedChanged(object sender, EventArgs e)
        {
            selectGameCB.Items.Clear();
            object[] games = new object[4];
            games[0] = "Select Game";
            //games[1] = "PAL Stadium 1/2";
            games[1] = "Space World 97 Gen 2";
            games[2] = "Colosseum";
            games[3] = "XD";
            //games[5] = "PBR Friend Pass";
            selectGameCB.Items.AddRange(games); //Adjust combo box range
            selectGameCB.SelectedIndex = 0;

            Info.Text = "This mode is for spin off games.";

            selectGameCB.Enabled = true;
        }

        private void selectGameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectGameCB.SelectedIndex == 0)
            {
                OpenFileBTN.Enabled = false;
                OpenFileTXB.Enabled = false;
                extractBTN.Enabled = false;
                saveBTN.Enabled = false;
                pkmSelect.Enabled = false;
            }
            else
            {
                val.SetComboSelect(selectGameCB.SelectedIndex);
                OpenFileBTN.Enabled = true;
                OpenFileTXB.Enabled = true;

                if (mainGameRBT.Checked == true)
                    Info.Text = mess.MainLine(val.GetComboSelect());
                else
                    Info.Text = mess.SpinOff(val.GetComboSelect());
            }
        }

        private void PKX_ExtractionDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Any() && OpenFileBTN.Enabled == true)
            {
                openFileDialog1.FileName = files.First();
                FileOpen();
            }
        }

        private void PKX_ExtractionDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}

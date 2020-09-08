using BTD6DLLCreator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BTD6_DLL_Customizer
{
    public partial class Form1 : Form
    {
        public string BTD6CustomizerVersion = "2.0";
        public string JSONVersion = "";
        public int amountOfFiles;
        public Array[] moddedFiles = new Array[10];
        public Array[] normalFiles = new Array[10];
        public int[] numberOfOffsetsInSelectedHack = new int[10];
        public string[] arrayJSONName;
        public string[] suggestedFileName;
        public Point mouseLocation;
        public string thisApplicationDir = Directory.GetCurrentDirectory();
        public string versionDir;
        public string gameDir = SteamUtils.GetGameDir(960090, "BloonsTD6");
        public string steamDir = SteamUtils.GetSteamDir();
        public string gameVersionInstalled;
        public bool initialInstalledCurrent;
        public Color disabledColor = Color.Red;
        public Color enabledColor = Color.LimeGreen;
        public Color background = Color.Black;
        public Color TextForeColor = Color.White;
        public Color TextForeColor2 = Color.Black;
        public Color Window = Color.Red;
        public Color closeButtonColor = Color.Black;
        public List<EndlessLog> logs = new List<EndlessLog>();
        List<string> files = new List<string>();
        List<Button> button = new List<Button>();
        string resultEndlessFile = "";
        public const int offsetEcryptDecrypt = 0; // this adds a byte offset to the data (dont go too high or the number will go over 255 or below 0 so just stay below 11)
        public string Log = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                IsCurrentVersion();
                HasCurrentJson();
                toolStrip1.BackColor = Color.Red;
                versionDir = thisApplicationDir + "\\Versions";
                LoadVersions();
                BTD6VersionDetector BTD6 = new BTD6VersionDetector();
                gameVersionInstalled = BTD6.VersionDetector(gameDir + "\\BloonsTD6_Data\\globalgamemanagers");
                initialInstalledCurrent = HasCurrentVersion();
                CreateCurrentVersionFolder(initialInstalledCurrent);
                GetGameAssemblyFile(initialInstalledCurrent);
                CopyGameAssemblyFile(initialInstalledCurrent);
                SelectCurrentVersion();
                LoadJsonFile();
                LoadSelectionButtons();
                LoadAutoUpdatedMods(initialInstalledCurrent);
                RefreshModdedFiles();
                WelcomeScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HasCurrentJson2()
        {
            string dir = thisApplicationDir + "\\JSONVersion.txt";
            string dir2 = thisApplicationDir + "\\json.txt";
            if (File.Exists(dir))
            {
                JSONVersion = File.ReadAllText(dir);
            }
            System.Net.WebClient web = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 };
            string download = web.DownloadString("https://raw.githubusercontent.com/EndlessM0DZ/BTD6DLLCustomizerSettings/master/JSONVersion");
            string[] data = download.Split(new[] { "\n" }, StringSplitOptions.None);
            if (data[0] != JSONVersion || !(File.Exists(dir) || !(File.Exists(dir2))))
            {
                if (File.Exists(dir2))
                {
                    File.Delete(dir2);
                }
                byte[] downloadJSON = web.DownloadData("https://raw.githubusercontent.com/EndlessM0DZ/BTD6DLLCustomizerSettings/master/CurrentJSON");
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(dir2));
                for (int i = 2; i < downloadJSON.Length - 2; i++)
                {
                    writer.Write(downloadJSON[i]);
                }
                writer.BaseStream.Position = 0;
                writer.Write(downloadJSON);
                writer.Close();
                if (File.Exists(dir))
                {
                    File.Delete(dir);
                }
                File.WriteAllText(dir, data[0]);
            }
        }
        private void HasCurrentJson()
        {
            try
            {
                if (!(File.Exists(thisApplicationDir + "\\json.txt")))
                {
                    if (File.Exists(thisApplicationDir + "\\JSONVersion.txt"))
                    {
                        File.Delete(thisApplicationDir + "\\JSONVersion.txt");
                    }
                }
                else
                {
                    if (!(File.Exists(thisApplicationDir + "\\JSONVersion.txt")))
                    {
                        File.Delete(thisApplicationDir + "\\json.txt");
                    }
                }
                HasCurrentJson2();
            }
            catch (Exception)
            {
                if (!File.Exists(thisApplicationDir + "\\JSONVersion.txt"))
                {
                    try
                    {
                        File.Create(thisApplicationDir + "\\JSONVersion.txt");
                        File.WriteAllText(thisApplicationDir + "\\JSONVersion.txt", "0.0");
                        HasCurrentJson2();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void IsCurrentVersion()
        {
            try
            {
                System.Net.WebClient web = new System.Net.WebClient();
                string download = web.DownloadString("https://raw.githubusercontent.com/EndlessM0DZ/BTD6DLLCustomizerSettings/master/Version");
                string[] data = download.Split(new[] { "\n" }, StringSplitOptions.None);
                if (data[0] != BTD6CustomizerVersion)
                {
                    MessageBox.Show("Update Available!");
                    Process.Start(data[1]);
                }
            }
            catch (Exception)
            {

            }
        }
        private void LoadSelectionButtons()
        {
            foreach (var names in arrayJSONName)
            {
                createDLLModsToolStripMenuItem.DropDownItems.Add("Create " + names);
            }
            createDLLModsToolStripMenuItem.DropDownItemClicked += createDLLModsToolStripMenuItem_DropDownItemClicked;
        }
        private void createDLLModsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                var v = (ToolStripMenuItem)sender;
                int index = v.DropDownItems.IndexOf(e.ClickedItem);
                string path = CreateFilesFromJSONandSelected(index, true);
                if (path != "")
                {
                    ImportDLLMods(false, path);
                    RefreshModdedFiles();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadAutoUpdatedMods(bool hadCurrentVersion)
        {
            try
            {
                if (!hadCurrentVersion)
                {
                    for (int i = 0; i < amountOfFiles; i++)
                    {
                        string path = CreateFilesFromJSONandSelected(i, true);
                        if (path != "")
                        {
                            ImportDLLMods(false, path);
                            RefreshModdedFiles();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string CreateFilesFromJSONandSelected(int index, bool sentFromClick)
        {
            try 
            { 
            string returnPath = "";
            if (VersionComboBox.SelectedIndex != -1 || !(sentFromClick))
            {
                string baseDir = thisApplicationDir + "\\Versions\\";
                if (sentFromClick)
                {
                    baseDir += VersionComboBox.SelectedItem.ToString();
                }
                else
                {
                    baseDir += gameVersionInstalled;
                }
                string defaultDir = baseDir + "\\Default\\GameAssembly.dll";
                string newMod = baseDir + "\\Modded DLLs\\";
                string fullNewModPath = "";
                string fileNameWithoutExtension = suggestedFileName[index];
                string fileExtension = ".dll";
                if (!File.Exists(newMod + fileNameWithoutExtension + fileExtension))
                {
                    File.Copy(defaultDir, newMod + fileNameWithoutExtension + fileExtension);
                    fullNewModPath = newMod + fileNameWithoutExtension + fileExtension;
                }
                else
                {
                    bool hasNotMadeFile = true;
                    int i = 1;
                    while (hasNotMadeFile)
                    {
                        if (!File.Exists(newMod + fileNameWithoutExtension + " (" + i + ")" + fileExtension))
                        {
                            File.Copy(defaultDir, newMod + fileNameWithoutExtension + " (" + i + ")" + fileExtension);
                            fullNewModPath = newMod + fileNameWithoutExtension + " (" + i + ")" + fileExtension;
                            hasNotMadeFile = false;
                        }
                        i++;
                    }
                }
                ConvertStringToHex convertStringToHex = new ConvertStringToHex();
                byte[] originalBytes = File.ReadAllBytes(fullNewModPath);
                byte[] modifiedBytes = originalBytes;
                string[] moddedBytesStringLocal = (string[])moddedFiles[index];
                string[] originalBytesStringLocal = (string[])normalFiles[index];
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(fullNewModPath));
                Array[] moddedBytesLocal2 = new Array[moddedBytesStringLocal.Length];
                Array[] normalBytesLocal2 = new Array[originalBytesStringLocal.Length];
                int[] lengthModded = new int[moddedBytesStringLocal.Length];
                int[] lengthNormal = new int[originalBytesStringLocal.Length];
                for (int i = 0; i < numberOfOffsetsInSelectedHack[index]; i++)
                {
                    byte[] tempModded = convertStringToHex.ConvertString(moddedBytesStringLocal[i]);
                    byte[] tempNormal = convertStringToHex.ConvertString(originalBytesStringLocal[i]);

                    moddedBytesLocal2[i] = tempModded;
                    normalBytesLocal2[i] = tempNormal;
                    lengthModded[i] = tempModded.Length;
                    lengthNormal[i] = tempNormal.Length;
                }
                for (int i = 0; i < normalBytesLocal2.ToArray().Length; i++)
                {
                    if (normalBytesLocal2[i] != null)
                    {
                        byte[] moddedCompare = (byte[])moddedBytesLocal2[i];
                        byte[] normalCompare = (byte[])normalBytesLocal2[i];
                        for (int j = 0; j < originalBytes.Length; j++)
                        {
                            if (modifiedBytes[j] == normalCompare[0])
                            {
                                for (int n = 0; n < lengthNormal[i]; n++)
                                {
                                    if (modifiedBytes[j + n] == normalCompare[n])
                                    {
                                        if (n == lengthNormal[i] - 1)
                                        {
                                            for (int ii = 0; ii < lengthModded[i]; ii++)
                                            {
                                                bw.BaseStream.Position = j + ii;
                                                bw.Write(moddedCompare[ii]);
                                            }
                                        }
                                    }
                                    else//if not true excape
                                    {
                                        n = normalCompare.Length;
                                    }
                                }
                            }
                        }
                    }
                }
                bw.Close();
                if (sentFromClick)
                {
                    RefreshModdedFiles();
                }
                returnPath = fullNewModPath;
            }
            return returnPath;
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            return "";
        }
        }
        private void WelcomeScreen()
        {
            try
            {
                System.Net.WebClient web = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 };
                string welcome = web.DownloadString("https://raw.githubusercontent.com/EndlessM0DZ/BTD6DLLCustomizerSettings/master/Welcome");
                string[] data = welcome.Split(new[] { "\n" }, StringSplitOptions.None);
                string fullString = "";
                foreach (string dataPiece in data)
                {
                    fullString += dataPiece + Environment.NewLine;
                }
                if (data[0] != "")
                {
                    MessageBox.Show(fullString);
                }
            }
            catch (Exception)
            {

            }
        }
        private void LoadJsonFile()
        {
            try
            {
                string readalltext = thisApplicationDir + "\\json.txt";
                string json = File.ReadAllText(readalltext);
                var items = JsonConvert.DeserializeObject<List<Mods>>(json);
                string[] hackName = new string[items.Count];
                string[] fileName = new string[items.Count];
                amountOfFiles = items.Count;
                for (int i = 0; i < items.Count; i++)
                {
                    string[] moddedFile = new string[items[i].normal.Count];
                    string[] normalFile = new string[items[i].normal.Count];
                    hackName[i] = items[i].name;
                    fileName[i] = items[i].fileName;
                    for (int j = 0; j < items[i].modded.Count; j++)
                    {
                        moddedFile[j] = items[i].modded[j];
                        normalFile[j] = items[i].normal[j];
                        if (j == items[i].modded.Count - 1)
                        {
                            moddedFiles[i] = moddedFile;
                            normalFiles[i] = normalFile;
                            numberOfOffsetsInSelectedHack[i] = items[i].modded.Count;
                        }
                    }
                }
                arrayJSONName = hackName;
                suggestedFileName = fileName;
            }
            catch (Exception)
            {

            }
        }
        private void UpdateEnabledDisabled()
        {
            for(int i = 0; i < button.Count; i++)
            {
                if (button[i].Text == "Enabled")
                {
                    foreach(Control c in panel5.Controls)
                    {
                        if(c is Button)
                        {
                            Button tmpButton = (Button)c;
                            if(tmpButton.Name == button[i].Name)
                            {
                                tmpButton.Text = "Enabled";
                                tmpButton.BackColor = enabledColor;
                            }
                        }
                    }
                }
            }
        }
        private void CopyGameAssemblyFile(bool hadCurrentVersion)
        {
            if (hadCurrentVersion)
            {
                string dir1 = thisApplicationDir + "\\Versions\\" + gameVersionInstalled + "\\Default\\GameAssembly.dll";
                string dir2 = gameDir + "\\GameAssembly.dll";
                if (File.Exists(dir1) && File.Exists(dir2))
                {
                    File.Delete(dir2);
                    File.Copy(dir1, dir2);
                    Log += "COPIED DEFAULT FOLDER (GAMEASSEMBLY)" + Environment.NewLine + dir1 + Environment.NewLine + "TO" + Environment.NewLine + dir2 + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                }
            }
        }
        private void GetGameAssemblyFile(bool hadCurrentVersion)
        {
            if (!hadCurrentVersion)
            {
                if(File.Exists(gameDir + "\\GameAssembly.dll"))
                {
                    File.Copy(gameDir + "\\GameAssembly.dll", thisApplicationDir + "\\Versions\\" + gameVersionInstalled + "\\Default\\GameAssembly.dll");
                    Log += "COPIED ORIGINAL (GAMEASSEMBLY)" + Environment.NewLine + gameDir + "\\GameAssembly.dll" + Environment.NewLine + "TO" + Environment.NewLine + thisApplicationDir + "\\Versions\\" + gameVersionInstalled + "\\Default\\GameAssembly.dll" + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                }
            }
        }
        private void SelectCurrentVersion()
        {
            try
            {
                VersionComboBox.SelectedItem = gameVersionInstalled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateCurrentVersionFolder(bool hasCurrentVersion)
        {
            string newDir = thisApplicationDir + "\\Versions\\" + gameVersionInstalled;
            if (!hasCurrentVersion)
            {
                bool idk = Directory.Exists(newDir);
                if (!(Directory.Exists(newDir)))
                {
                    Directory.CreateDirectory(newDir);
                    Directory.CreateDirectory(newDir + "\\Default");
                    Directory.CreateDirectory(newDir + "\\Modded DLLs");
                    Directory.CreateDirectory(newDir + "\\Output");
                    LoadVersions();
                    CheckBTD6Running();
                    ValidateBTD6Files();
                    Log += "CREATED DIR" + Environment.NewLine + newDir + Environment.NewLine + Environment.NewLine;
                    Log += "CREATED DIR" + Environment.NewLine + newDir + "\\Default" + Environment.NewLine + Environment.NewLine;
                    Log += "CREATED DIR" + Environment.NewLine + newDir + "\\Modded DLLs" + Environment.NewLine + Environment.NewLine;
                    Log += "CREATED DIR" + Environment.NewLine + newDir + "\\Output" + Environment.NewLine + Environment.NewLine;
                    Log += "VALIDATED" + Environment.NewLine + gameDir + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                }
            }
        }
        private void ValidateBTD6Files()
        {
            Process.Start("steam://validate/960090");
            for (int i = 0; i < 300; i++)
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    if (!process.MainWindowTitle.Contains(" - 100%"))
                    {
                        continue;
                    }
                    i = 300;
                    process.CloseMainWindow();
                    break;
                }
                Thread.Sleep(100);
            }
        }
        private Button CreateEnableDisable(int i, string fileName)
        {
            Button b = new Button();
            b.Text = "Disabled";
            b.Location = new Point(3, 3 + ((i) * 49));
            b.FlatStyle = FlatStyle.Popup;
            b.BackColor = disabledColor;
            b.Width = 225;
            b.Height = 49;
            b.ForeColor = Color.Black;
            b.Name = "ModButton" + fileName;
            b.Click += new EventHandler(ModdedButton_Click);
            panel5.Controls.Add(b);
            return b;
        }
        private void CreateLabel(int i)
        {
            Label l = new Label();
            l.Text = Path.GetFileName(files[i]);
            l.Location = new Point(231, 3 + ((i) * 49));
            l.FlatStyle = FlatStyle.Popup;
            l.BackColor = Color.Black;
            l.Width = 600;
            l.Height = 49;
            l.ForeColor = Color.White;
            l.Name = "ModLabel" + i;
            l.BackColor = Color.Transparent;
            panel5.Controls.Add(l);
        }
        private void CreateTrash(int Victor, string fileName)
        {
            Button r = new Button();
            r.Text = "Trash";
            r.Location = new Point(831, 3 + ((Victor) * 49));
            r.FlatStyle = FlatStyle.Popup;
            r.BackColor = disabledColor;
            r.Width = 140;
            r.Height = 49;
            r.ForeColor = Color.Black;
            r.Name = "TrashButton" + fileName;
            r.Click += new EventHandler(TrashButton_Click);
            panel5.Controls.Add(r);
        }
        private void RefreshModdedFiles()
        {
            try
            {
                panel5.Controls.Clear();
                string refreshDir = thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Modded DLLs";
                List<Button> b = new List<Button>();
                files = (Directory.GetFiles(refreshDir)).ToList();
                for (int i = 0; i < files.Count; i++)
                {
                    b.Add(CreateEnableDisable(i, Path.GetFileName(files[i])));
                    CreateLabel(i);
                    CreateTrash(i, Path.GetFileName(files[i]));
                }
                if (button.Count <= 0 && VersionComboBox.SelectedItem.ToString() == gameVersionInstalled)
                {
                    foreach (Button b2 in b)
                    {
                        button.Add(b2);
                    }
                }
                else if (button.Count > 0 && VersionComboBox.SelectedItem.ToString() == gameVersionInstalled)
                {
                    UpdateEnabledDisabled();
                    button.Clear();
                    foreach (Button b2 in b)
                    {
                        button.Add(b2);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TrashButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedButton = (Button)sender;
                string fileName = clickedButton.Name.Substring(11, clickedButton.Name.Length - 11);
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + fileName + "?", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string dir = thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Modded DLLs\\" + fileName;
                    if (File.Exists(dir))
                    {
                        File.Delete(dir);
                    }
                    RefreshModdedFiles();
                    Log += "TRASHED" + Environment.NewLine + dir + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ModdedButton_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (gameVersionInstalled == VersionComboBox.SelectedItem.ToString())
            {
                Button changedMod = (Button)sender;
                string nameOfChangedMod = changedMod.Name.Substring(9, changedMod.Name.Length - 9);
                if (changedMod.Text == "Disabled")
                {
                    bool didChange = ModdedButtonOverwrite(true, changedMod);
                    if (didChange)
                    {
                        changedMod.Text = "Enabled";
                        changedMod.BackColor = enabledColor;
                        Log += "ENABLED" + Environment.NewLine + nameOfChangedMod + Environment.NewLine + "IN" + Environment.NewLine + gameDir + "\\GameAssembly.dll" + Environment.NewLine + Environment.NewLine;
                        if (logs.Count > 0)
                        {
                            logs[0].textBox1.Text = Log;
                        }
                    }
                }
                else
                {
                    bool didChange = ModdedButtonOverwrite(false, changedMod);
                    if (didChange)
                    {
                        changedMod.Text = "Disabled";
                        changedMod.BackColor = disabledColor;
                        Log += "DISABLED" + Environment.NewLine + nameOfChangedMod + Environment.NewLine + "IN" + Environment.NewLine + gameDir + "\\GameAssembly.dll" + Environment.NewLine + Environment.NewLine;
                        if (logs.Count > 0)
                        {
                            logs[0].textBox1.Text = Log;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Game versions do not match!");
                Log += "TRIED TO OVERWRITE WITH WRONG VERSION MOD" + Environment.NewLine + "IMPORTED VERSION: " + VersionComboBox.SelectedItem.ToString() + Environment.NewLine + "INSTALLED VERSION: " + gameVersionInstalled + Environment.NewLine + Environment.NewLine;
                if (logs.Count > 0)
                {
                    logs[0].textBox1.Text = Log;
                }
            }
        }
        catch(Exception ex)
        {
                MessageBox.Show(ex.Message);
            }
        }
        private bool CheckBTD6Running()// the returning bool is not if its running or not, but if it is running did the user stop btd6
        {
            try
            {
                Process[] p = Process.GetProcessesByName("BloonsTD6");
                if (p.Length > 0)
                {
                    var result = MessageBox.Show("Stop BloonsTD6?", "Bloons Tower Defense is running!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (Process process in Process.GetProcessesByName("BloonsTD6"))
                        {
                            process.Kill();
                            Thread.Sleep(100);
                        }
                        Thread.Sleep(400);
                        Log += "STOPPED PROCESS" + Environment.NewLine + gameDir + "\\BloonsTD6.exe" + Environment.NewLine + Environment.NewLine;
                        if (logs.Count > 0)
                        {
                            logs[0].textBox1.Text = Log;
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private List<byte> DecryptData(string dir, byte[] data)
        {
            List<byte> decrypted = new List<byte>();
            int offsetDecrypt = offsetEcryptDecrypt * (-1);
            for (int i = 0; i < data.Length; i++)
            {
                decrypted.Add((byte)(data[i] + offsetDecrypt));
                offsetDecrypt *= (-1);
            }
            return decrypted;
        }
        private bool ModdedButtonOverwrite(bool enabled, Button button)
        {
            try 
            { 
            string fileName = button.Name.Substring(9, button.Name.Length - 9);
            string dir = thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Modded DLLs\\" + fileName;
            byte[] data = File.ReadAllBytes(dir);
            List<byte> decrypted = DecryptData(dir, data);
            string dataText = Encoding.ASCII.GetString(decrypted.ToArray());
            ModdedJSON modded = new JavaScriptSerializer().Deserialize<ModdedJSON>(dataText);
            ConvertStringToHex toHex = new ConvertStringToHex();
            string gameVersionOnFile = modded.gameVersion;
            GetIntArray getInt = new GetIntArray();
            int[] offsets = getInt.GetInts(modded.offsets);
            byte[] moddedBytes = toHex.ConvertString(modded.modded);
            byte[] normalBytes = toHex.ConvertString(modded.normal);
            bool isSpeedHack = modded.isSpeedHack;
            bool didClose = CheckBTD6Running();
            if (!didClose)
            {
                return false;
            }
            if (enabled)
            {
                if (isSpeedHack)
                {
                    CustomSpeed custom = new CustomSpeed();
                    custom.ShowDialog();
                    byte[] speedBytes = BitConverter.GetBytes(Convert.ToSingle(custom.speed)).ToArray();
                    byte[] speedBytesInt = BitConverter.GetBytes(custom.speed).ToArray();
                    List<byte> combinedBytes = new List<byte>();
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i == 0 || i == 3)
                            {
                                combinedBytes.Add(speedBytes[j]);
                            }
                            else
                            {
                                combinedBytes.Add(speedBytesInt[j]);
                            }
                        }
                    }
                    BinaryWriter writer = new BinaryWriter(File.OpenWrite(gameDir + "\\GameAssembly.dll"));
                    for (int i = 0; i < offsets.Length; i++)
                    {
                        writer.BaseStream.Position = offsets[i];
                        writer.Write(combinedBytes[i]);
                    }
                    writer.Close();
                    return true;
                }
                else
                {
                    BinaryWriter writer = new BinaryWriter(File.OpenWrite(gameDir + "\\GameAssembly.dll"));
                    for (int i = 0; i < offsets.Length; i++)
                    {
                        writer.BaseStream.Position = offsets[i];
                        writer.Write(moddedBytes[i]);
                    }
                    writer.Close();
                    return true;
                }
            }
            else
            {
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(gameDir + "\\GameAssembly.dll"));
                for (int i = 0; i < offsets.Length; i++)
                {
                    writer.BaseStream.Position = offsets[i];
                    writer.Write(normalBytes[i]);
                }
                writer.Close();
                return true;
            }
        }
        catch(Exception ex)
        {
                MessageBox.Show(ex.Message);
                return false;
        }
        }
        private bool HasCurrentVersion()
        {
            for(int i = 0; i < VersionComboBox.Items.Count; i++)
            {
                if(VersionComboBox.Items[i].ToString() == gameVersionInstalled)
                {
                    return true;
                }
            }
            return false;
        }
        private void LoadVersions()
        {
            VersionComboBox.Items.Clear();
            string[] subDirs = Directory.GetDirectories(versionDir).Select(Path.GetFileName).ToArray();
            for(int i = 0; i < subDirs.Length; i++)
            {
                VersionComboBox.Items.Add(subDirs[i]);
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
                if(logs.Count > 0)
                {
                    logs[0].Location = new Point(this.Location.X + this.Width, this.Location.Y);
                }
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X - 346, mouseLocation.Y - 6);
                Location = mousePose;
                if (logs.Count > 0)
                {
                    logs[0].Location = new Point(this.Location.X + this.Width, this.Location.Y);
                }
            }
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("steam://launch/960090");
                Log += "STARTED PROCESS" + Environment.NewLine + "steam://launch/960090" + Environment.NewLine + Environment.NewLine;
                if (logs.Count > 0)
                {
                    logs[0].textBox1.Text = Log;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void openBTD6DirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(gameDir);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openVersionDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            { 
            Process.Start(thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
        private string CreateJSONDifferences(byte[] comparedFile, byte[] normalFile, bool isSpeedHack, bool fromButton, string dir1)
        {
            HexString hexString = new HexString();
            ModdedJSON modded = new ModdedJSON();
            modded.gameVersion = VersionComboBox.SelectedItem.ToString();
            modded.isSpeedHack = isSpeedHack;
            string offsets = "";
            string moddedBytes = "";
            string normalBytes = "";
            int speedHackRevs = 0;
            int speedHackOffset = -2;
            for(int i = 0; i < normalFile.Length; i++)
            {
                if(normalFile[i] != comparedFile[i])
                {
                    if (isSpeedHack)
                    {
                        if (speedHackRevs == 1)
                        {
                            speedHackOffset = 0;
                        }
                        else if(speedHackRevs == 3)
                        {
                            speedHackOffset = -2;
                        }
                        for(int j = 0; j < 4; j++)
                        {
                            offsets += (i + j + speedHackOffset) + " ";
                            moddedBytes += hexString.hexString[Convert.ToInt32(comparedFile[i + j + speedHackOffset])] + " ";
                            normalBytes += hexString.hexString[Convert.ToInt32(normalFile[i + j + speedHackOffset])] + " ";
                        }
                        i += 3;
                        speedHackRevs++;
                    }
                    else
                    {
                        offsets += i + " ";
                        moddedBytes += hexString.hexString[Convert.ToInt32(comparedFile[i])] + " ";
                        normalBytes += hexString.hexString[Convert.ToInt32(normalFile[i])] + " ";
                    }
                }
            }
            if(offsets.Length <= 0)
            {
                MessageBox.Show("You are importing the same file as the one in " + thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Default\\GameAssembly.dll");
                Log += "ERROR SAME FILE" + Environment.NewLine + thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Default\\GameAssembly.dll" + Environment.NewLine + "AND" + Environment.NewLine + "IMPORTED FILE" + Environment.NewLine + Environment.NewLine;
                if (logs.Count > 0)
                {
                    logs[0].textBox1.Text = Log;
                }
                return "";
            }
            modded.offsets = offsets.Substring(0, offsets.Length - 1);
            modded.modded = moddedBytes.Substring(0, moddedBytes.Length - 1);
            modded.normal = normalBytes.Substring(0, normalBytes.Length - 1);
            resultEndlessFile = JsonConvert.SerializeObject(modded);
            byte[] b = Encoding.ASCII.GetBytes(resultEndlessFile);
            List<byte> finished = new List<byte>();
            int offsetEncrpt = offsetEcryptDecrypt;
            for(int i = 0; i < b.Length; i++)
            {
                finished.Add((byte)(b[i] + offsetEncrpt));
                offsetEncrpt *= (-1);
            }
            string fileName = "";
            string extension = "";
            if (fromButton && dir1 == "")
            {
                fileName = Path.GetFileName(openFileDialog1.FileName);
                extension = Path.GetExtension(openFileDialog1.FileName);
            }
            else
            {
                fileName = Path.GetFileName(dir1);
                extension = Path.GetExtension(dir1);
            }
            fileName = fileName.Substring(0, fileName.Length - extension.Length);
            string dir = thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Modded DLLs\\";
            string dir3 = ReturnFileNotTaken(dir, fileName, ".endless");
            var myFile = File.Create(dir3);
            myFile.Close();
            File.WriteAllBytes(dir3, finished.ToArray());
            if (fromButton)
            {
                MessageBox.Show("File saved as: " + Path.GetFileName(dir3));
            }
            return dir3;
        }
        public void ImportDLLMods(bool fromButton, string dir1)
        {
            if (fromButton && dir1 == "")
            {
                openFileDialog1.Filter = "DLL Files|*.dll|All Files|*.*";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && Path.GetExtension(openFileDialog1.FileName) != ".btd6mod")
                {
                }
                else if (Path.GetExtension(openFileDialog1.FileName) == ".btd6mod")
                {
                    MessageBox.Show("Don't import a btd6mod file in this program!");
                    Log += "TRIED TO IMPORT A BTD6MOD FILE" + Environment.NewLine + "..." + Environment.NewLine + "You must be a noob" + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                    return;
                }
            }
            BTD6VersionDetector bTD6VersionDetector = new BTD6VersionDetector();
            string fileOpened = "";
            if (fromButton && dir1 == "")
            {
                fileOpened = openFileDialog1.FileName;
            }
            else
            {
                fileOpened = dir1;
            }
            byte[] comparedFile = File.ReadAllBytes(fileOpened);
            byte[] normalFile = File.ReadAllBytes(thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Default\\GameAssembly.dll");
            if (comparedFile.Length != normalFile.Length)
            {
                MessageBox.Show("Game versions of imported file and selected version do not match!");
                Log += "TRIED TO IMPORT A DIFFERENT VERSION FILE" + Environment.NewLine + "IMPORTED FILE SIZE: " + comparedFile.Length + Environment.NewLine + "SELECTED VERSION (" + VersionComboBox.SelectedItem.ToString() + ") FILE SIZE: " + normalFile.Length + Environment.NewLine + Environment.NewLine;
                if (logs.Count > 0)
                {
                    logs[0].textBox1.Text = Log;
                }
                return;
            }
            DialogResult dialogResult = DialogResult.None;
            bool isSpeedHack = false;
            if (fromButton)
            {
                dialogResult = MessageBox.Show("Are you importing a speedhack?", "Please answer", MessageBoxButtons.YesNo);
            }
            else
            {
                if (Path.GetFileName(dir1).Contains("speedhack"))
                {
                    isSpeedHack = true;
                }
            }
            if (dialogResult == DialogResult.Yes)
            {
                isSpeedHack = true;
            }
            string filePath = CreateJSONDifferences(comparedFile, normalFile, isSpeedHack, fromButton, dir1);
            if (filePath != "")
            {
                if (fromButton)
                {
                    RefreshModdedFiles();
                }
                Log += fileOpened + Environment.NewLine + "EXPORTED TO" + Environment.NewLine + filePath + Environment.NewLine + Environment.NewLine;
                Log += "CONTENTS OF EXPORT" + Environment.NewLine + resultEndlessFile + Environment.NewLine + Environment.NewLine;
                if (logs.Count > 0)
                {
                    logs[0].textBox1.Text = Log;
                }
                if (!fromButton)
                {
                    if(File.Exists(dir1))
                    File.Delete(dir1);
                    Log += "DELETED" + Environment.NewLine + dir1 + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                }
                else
                {
                    if (File.Exists(fileOpened))
                        File.Delete(fileOpened);
                    Log += "DELETED" + Environment.NewLine + fileOpened + Environment.NewLine + Environment.NewLine;
                    if (logs.Count > 0)
                    {
                        logs[0].textBox1.Text = Log;
                    }
                }
            }
        }
        private void importDLLModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            { 
                ImportDLLMods(true, "");
            }
            catch(Exception)
            {

            }
}

        private void AddModsButton_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.Filter = "Endless Files or DLLs (*.endless,*.dll)|*.endless;*.dll|All Files|*.*";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog2.FileName) == ".dll")
                    {
                        ImportDLLMods(true, openFileDialog2.FileName);
                        RefreshModdedFiles();
                        return;
                    }
                    else if (Path.GetExtension(openFileDialog2.FileName) == ".btd6mod")
                    {
                        MessageBox.Show("Don't import a btd6mod file in this program!");
                        Log += "TRIED TO IMPORT A BTD6MOD FILE" + Environment.NewLine + "..." + Environment.NewLine + "You must be a noob" + Environment.NewLine + Environment.NewLine;
                        if (logs.Count > 0)
                        {
                            logs[0].textBox1.Text = Log;
                        }
                        return;
                    }
                    else
                    {
                        string dir1 = openFileDialog2.FileName;
                        string fileName = Path.GetFileName(openFileDialog2.FileName);
                        string fileExtension = Path.GetExtension(openFileDialog2.FileName);
                        fileName = fileName.Substring(0, fileName.Length - fileExtension.Length);
                        string dir2 = thisApplicationDir + "\\Versions\\" + VersionComboBox.SelectedItem.ToString() + "\\Modded DLLs\\";
                        byte[] data = File.ReadAllBytes(dir1);
                        List<byte> decrypted = DecryptData(dir1, data);
                        string dataText = Encoding.ASCII.GetString(decrypted.ToArray());
                        ModdedJSON modded = new JavaScriptSerializer().Deserialize<ModdedJSON>(dataText);
                        if (modded.gameVersion != VersionComboBox.SelectedItem.ToString())
                        {
                            MessageBox.Show("The selected file is for version: " + modded.gameVersion + "\nPlease select an updated mod or change your version!", "ERROR!");
                            Log += "ERROR DID NOT COPY FROM (VERSIONS DO NOT MATCH)" + Environment.NewLine + dir1 + Environment.NewLine + "TO" + Environment.NewLine + dir2 + fileName + fileExtension + Environment.NewLine + Environment.NewLine;
                            if (logs.Count > 0)
                            {
                                logs[0].textBox1.Text = Log;
                            }
                            return;
                        }
                        string dir3 = ReturnFileNotTaken(dir2, fileName, fileExtension);
                        File.Copy(openFileDialog2.FileName, dir3);
                        MessageBox.Show("File saved as: " + Path.GetFileName(dir3));
                        RefreshModdedFiles();
                        Log += dir1 + Environment.NewLine + "COPIED TO" + Environment.NewLine + dir3 + Environment.NewLine + Environment.NewLine;
                        if (logs.Count > 0)
                        {
                            logs[0].textBox1.Text = Log;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string ReturnFileNotTaken(string dir, string initialFile, string extension)
        {
            if (!(File.Exists(dir + initialFile + extension)))
            {
                return dir + initialFile + extension;
            }
            else
            {
                bool hasNotMadeFile = true;
                int i = 1;
                while (hasNotMadeFile)
                {
                    if (!File.Exists(dir + initialFile + " (" + i + ")" + extension))
                    {
                        return dir + initialFile + " (" + i + ")" + extension;
                    }
                    i++;
                }
            }
            return "";
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try 
            { 
                RefreshModdedFiles();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void LogButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool opened = false;
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "EndlessLog")
                    {
                        opened = true;
                    }
                }
                if (!opened)
                {
                    foreach (var log in logs)
                        log.Close();

                    logs.Clear();
                }
                EndlessLog logForm = new EndlessLog(background, TextForeColor, Window);
                if (logs.Count <= 0)
                {
                    logForm.textBox1.Text = Log;
                    logForm.StartPosition = FormStartPosition.Manual;
                    logForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                    logForm.Show();
                    logs.Add(logForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createVersionDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateVersionDirectory createVersion = new CreateVersionDirectory(thisApplicationDir, background, TextForeColor, Window, logs, Log);
                createVersion.ShowDialog();
                if (createVersion.reachedCreate)
                {
                    Log = createVersion.Log;
                    LoadVersions();
                    SelectCurrentVersion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshModdedFiles();
        }
        private void RefreshColors()
        {
            panel1.BackColor = Window;
            panel2.BackColor = Window;
            panel3.BackColor = Window;
            panel4.BackColor = Window;
            toolStrip1.BackColor = Window;
            panel5.BackColor = background;
            groupBox1.BackColor = background;
            groupBox1.ForeColor = Window;
            label2.BackColor = Window;
            toolStrip1.ForeColor = TextForeColor2;
            label1.ForeColor = TextForeColor2;
            label2.ForeColor = TextForeColor2;
            CloseButton.ForeColor = closeButtonColor;
            RefreshModdedFiles();
    }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Settings settings = new Settings(Window, background, TextForeColor, TextForeColor2, enabledColor, disabledColor, closeButtonColor);
                settings.ShowDialog();
                if (settings.changedColors)
                {
                    int i = 0;
                    foreach (Color c in settings.selectedColors)
                    {
                        switch (i)
                        {
                            case 0: Window = c; break;
                            case 1: background = c; break;
                            case 2: TextForeColor = c; break;
                            case 3: TextForeColor2 = c; break;
                            case 4: enabledColor = c; break;
                            case 5: disabledColor = c; break;
                            case 6: closeButtonColor = c; break;
                            default: break;
                        }
                        i++;
                    }
                    RefreshColors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits(background, TextForeColor, Window);
            credits.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Net.WebClient web = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 };
                string welcome = web.DownloadString("https://raw.githubusercontent.com/EndlessM0DZ/BTD6DLLCustomizerSettings/master/YouTubeVid");
                string[] data = welcome.Split(new[] { "\n" }, StringSplitOptions.None);
                string fullString = "";
                foreach (string dataPiece in data)
                {
                    fullString += dataPiece + Environment.NewLine;
                }
                if (data[0] != "0")
                {
                    if (data[1] != "")
                        Process.Start(data[1]);
                }
            }
            catch (Exception)
            {

            }
                HowToUse howToUse = new HowToUse(background, TextForeColor, Window);
                howToUse.ShowDialog();
        }
    }
}
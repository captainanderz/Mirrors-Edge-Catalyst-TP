using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Mirrors_Edge_Catalyst_SpeedOMeter;
using Mirrors_Edge_Catalyst_TP.Helpers;

namespace Mirrors_Edge_Catalyst_TP
{
    public partial class Form1 : Form
    {
        private readonly MemoryManager Mem;
        private bool GameProcessIsOpen;
        private RegisterHotKeyIds HotkeyId;
        private bool IsGameInFocusBool = false;
        private int SHotkey;
        private int SHotkeyMods;
        private int THotkey;
        private int THotkeyMods;

        #region user32.dll's

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        internal static extern int UnregisterHotKey(IntPtr hwnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        #endregion

        public Form1()
        {
            InitializeComponent();

            KeyPreview = true;
            Mem = new MemoryManager();

            #region NSTheme sucks so had todo a workaround

            if (SavePosition.Focused)
            {
                KeyDown += SavePosition_KeyDown;
                KeyUp += SavePosition_KeyUp;
            }
            if (TelePosition.Focused)
            {
                KeyDown += SavePosition_KeyDown;
                KeyUp += SavePosition_KeyUp;
            }
            //RegisterHotKey(Handle, 2, (int) Modifiers.Control, (int)Keys.D1); // JUST A TEST

            #endregion
        }

        protected override void WndProc(ref Message keyPressed)
        {
            base.WndProc(ref keyPressed);
            if (keyPressed.Msg == 0x0312) // if hotkey pressed
            {
                switch ((int)keyPressed.WParam)
                {
                    case 1:
                        SaveMethod();
                        break;

                    case 2:
                        TeleMethod();
                        break;
                }
            }
        }

        private bool KeyisSet { get; set; }

        // 0x18
        private long SavePosAddressY_18 { get; set; }
        private long SavePosAddressX_18 { get; set; }
        private long SavePosAddressZ_18 { get; set; }
        private float SavePosAddressYFloat_18 { get; set; }
        private float SavePosAddressXFloat_18 { get; set; }
        private float SavePosAddressZFloat_18 { get; set; }
        // 0x20
        private long SavePosAddressY_20 { get; set; }
        private long SavePosAddressX_20 { get; set; }
        private long SavePosAddressZ_20 { get; set; }
        private float SavePosAddressYFloat_20 { get; set; }
        private float SavePosAddressXFloat_20 { get; set; }
        private float SavePosAddressZFloat_20 { get; set; }
        

        private void nsControlButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Timers

        private void CheckGameStatus_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MirrorsEdgeCatalyst").Length > 0)
            {
                GameStatus.Text = "RUNNING";
                GameStatus.ForeColor = Color.Green;

                IsGameInFocus.Enabled = true; // Start In Focus Checker

                if (!GameProcessIsOpen)
                {
                    Mem.openProcess("MirrorsEdgeCatalyst");
                    GameProcessIsOpen = true;
                }
            }
            else
            {
                GameStatus.Text = "NOT RUNNING";
                GameStatus.ForeColor = Color.Red;
            }
        }

        private void IsGameInFocus_Tick(object sender, EventArgs e)
        {
            IsGameInFocusBool = ApplicationIsActivated();
        //    var b = false;
        //    if (!IsGameInFocusBool)
        //    {
        //        UnregisterHotKey(Handle, 1);
        //        UnregisterHotKey(Handle, 2);
        //        b = false;
        //    }
        //    else
        //    {
        //        if (SHotkey != 0 || THotkey != 0)
        //        {
        //            if (!b)
        //            {
        //                RegisterHotKey(Handle, (int)RegisterHotKeyIds.SavePositionId, SHotkeyMods, SHotkey);
        //                RegisterHotKey(Handle, (int)RegisterHotKeyIds.SavePositionId, THotkeyMods, THotkey);
        //                b = true;
        //            }
        //        }
        //    }
        }

#endregion

        public bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);
            

            return activeProcId == 2836; //procId;
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveMethod();
        }

        private void TeleportButton_Click(object sender, EventArgs e)
        {
            TeleMethod();
        }

        // Save and Tele methods

        private void SaveMethod()
        {
            // If game is running
            if (GameProcessIsOpen)
            {
                try
                {
                    // 142578A68, 70, 98, 238, 18, 22d4 Y
                    SavePosAddressY_18 = Mem.ReadInt(Mem.GetModuleAddress("MirrorsEdgeCatalyst.exe") + 0x02578A68);
                    SavePosAddressY_18 = Mem.ReadInt(SavePosAddressY_18 + 0x70);
                    SavePosAddressY_18 = Mem.ReadInt(SavePosAddressY_18 + 0x98);
                    SavePosAddressY_18 = Mem.ReadInt(SavePosAddressY_18 + 0x238);
                    SavePosAddressY_18 = Mem.ReadInt(SavePosAddressY_18 + 0x18);
                    SavePosAddressY_20 = Mem.ReadInt(SavePosAddressY_18 + 0x20);

                    var quickReadAddress_20 = SavePosAddressY_20;
                    var quickReadAddress = SavePosAddressY_18;

                    // For 0x18
                    SavePosAddressY_18 += 0x22d4;
                    SavePosAddressX_18 = (quickReadAddress + 0x22d0);
                    SavePosAddressZ_18 = (quickReadAddress + 0x22d8);

                    // For 0x20
                    SavePosAddressY_20 += 0x22d4;
                    SavePosAddressX_20 = (quickReadAddress_20 + 0x22d0);
                    SavePosAddressZ_20 = (quickReadAddress_20 + 0x22d8);

                    // Read Float values for 0x18
                    SavePosAddressYFloat_18 = Mem.ReadFloat(SavePosAddressY_18);
                    SavePosAddressXFloat_18 = Mem.ReadFloat(SavePosAddressX_18);
                    SavePosAddressZFloat_18 = Mem.ReadFloat(SavePosAddressZ_18);

                    // Read Float values for 0x20
                    SavePosAddressYFloat_20 = Mem.ReadFloat(SavePosAddressY_20);
                    SavePosAddressXFloat_20 = Mem.ReadFloat(SavePosAddressX_20);
                    SavePosAddressZFloat_20 = Mem.ReadFloat(SavePosAddressZ_20);

                    Invalidate();
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        private void TeleMethod()
        {
            if (!GameProcessIsOpen) return;
            if (GameProcessIsOpen && SavePosAddressY_18 != 0 && SavePosAddressX_18 != 0 && SavePosAddressZ_18 != 0 && SavePosAddressY_20 != 0 && SavePosAddressX_20 != 0 && SavePosAddressZ_20 != 0)
            {
                // For 0x18
                Mem.WriteFloat(SavePosAddressY_18, SavePosAddressYFloat_18);
                Mem.WriteFloat(SavePosAddressX_18, SavePosAddressXFloat_18);
                Mem.WriteFloat(SavePosAddressZ_18, SavePosAddressZFloat_18);

                // For 0x20
                Mem.WriteFloat(SavePosAddressY_20, SavePosAddressYFloat_20);
                Mem.WriteFloat(SavePosAddressX_20, SavePosAddressXFloat_20);
                Mem.WriteFloat(SavePosAddressZ_20, SavePosAddressZFloat_20);

                Invalidate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 1);
            UnregisterHotKey(Handle, 2);
        }

        

        // HotKey setup

        #region Hotkey logic

        private void TelePosition_Enter(object sender, EventArgs e)
        {
            KeyDown += TelePosition_KeyDown;
            KeyUp += TelePosition_KeyUp;
        }

        private void TelePosition_Leave(object sender, EventArgs e)
        {
            KeyDown -= TelePosition_KeyDown;
            KeyUp -= TelePosition_KeyUp;
        }

        private void SavePosition_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true; //Suppress the key from being processed by the underlying control.
            SavePosition.Text = string.Empty; //Empty the content of the textbox
            KeyisSet = false; //At this point the user has not specified a shortcut.

            //Set the backspace button to specify that the user does not want to use a shortcut.
            if (e.KeyData == Keys.Back)
            {
                SavePosition.Text = Keys.None.ToString();
                return;
            }

            //A modifier is present. Process each modifier.
            //Modifiers are separated by a ",". So we'll split them and write each one to the textbox.
            foreach (var modifier in e.Modifiers.ToString().Split(','))
            {
                if (modifier == "None")
                {
                    SavePosition.Text += "";
                }
                else
                {
                    SavePosition.Text += modifier + " + ";
                }
            }

            //KEYCODE contains the last key pressed by the user.
            //If KEYCODE contains a modifier, then the user has not entered a shortcut. hence, KeyisSet is false
            //But if not, KeyisSet is true.
            if (e.KeyCode == Keys.ShiftKey | e.KeyCode == Keys.ControlKey | e.KeyCode == Keys.Menu)
            {
                KeyisSet = false;
            }
            else
            {
                SavePosition.Text += e.KeyCode.ToString();
                KeyisSet = true;
            }
        }

        private void SavePosition_KeyUp(object sender, KeyEventArgs e)
        {
            //On KeyUp if KeyisSet is False then clear the textbox.
            if (KeyisSet == false)
            {
                SavePosition.Text = Keys.None.ToString();
            }

            try
            {
                if (SavePosition.Text == Keys.None.ToString() || SavePosition.Text.Trim().EndsWith("+")) return;
                if (!string.IsNullOrEmpty("SavePosition") && HotKeyShared.IsValidHotkeyName(SavePosition.Text))
                {
                    // Add hotkey
                    SHotkey = (int)e.KeyCode;
                    SHotkeyMods = (int)e.Modifiers;

                    var modString = (new KeysConverter()).ConvertToString(e.Modifiers);
                    SavePosition.Text = modString.Substring(0, modString.Length - 4) +
                                        (new KeysConverter()).ConvertToString(SHotkey);

                    UnregisterHotKey(Handle, (int)RegisterHotKeyIds.SavePositionId);
                    RegisterHotKey(Handle, (int)RegisterHotKeyIds.SavePositionId, SHotkeyMods, SHotkey);

                    Cursor.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add Hotkey");
            }
        }

        private void SavePosition_Enter(object sender, EventArgs e)
        {
            KeyDown += SavePosition_KeyDown;
            KeyUp += SavePosition_KeyUp;
        }

        private void SavePosition_Leave(object sender, EventArgs e)
        {
            KeyDown -= SavePosition_KeyDown;
            KeyUp -= SavePosition_KeyUp;
        }

        private void TelePosition_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true; //Suppress the key from being processed by the underlying control.
            TelePosition.Text = string.Empty; //Empty the content of the textbox
            KeyisSet = false; //At this point the user has not specified a shortcut.

            //Set the backspace button to specify that the user does not want to use a shortcut.
            if (e.KeyData == Keys.Back)
            {
                TelePosition.Text = Keys.None.ToString();
                return;
            }

            //A modifier is present. Process each modifier.
            //Modifiers are separated by a ",". So we'll split them and write each one to the textbox.
            foreach (var modifier in e.Modifiers.ToString().Split(','))
            {
                if (modifier == "None")
                {
                    TelePosition.Text += "";
                }
                else
                {
                    TelePosition.Text += modifier + " + ";
                }
            }

            //KEYCODE contains the last key pressed by the user.
            //If KEYCODE contains a modifier, then the user has not entered a shortcut. hence, KeyisSet is false
            //But if not, KeyisSet is true.
            if (e.KeyCode == Keys.ShiftKey | e.KeyCode == Keys.ControlKey | e.KeyCode == Keys.Menu)
            {
                KeyisSet = false;
            }
            else
            {
                TelePosition.Text += e.KeyCode.ToString();
                KeyisSet = true;
            }
        }

        private void TelePosition_KeyUp(object sender, KeyEventArgs e)
        {
            //On KeyUp if KeyisSet is False then clear the textbox.
            if (KeyisSet == false)
            {
                TelePosition.Text = Keys.None.ToString();
            }

            try
            {
                if (TelePosition.Text == Keys.None.ToString() || TelePosition.Text.Trim().EndsWith("+")) return;
                if (!string.IsNullOrEmpty("SavePosition") && HotKeyShared.IsValidHotkeyName(TelePosition.Text))
                {
                    // Add hotkey
                    THotkey = (int) e.KeyCode;
                    THotkeyMods = (int) e.Modifiers;

                    var modString = (new KeysConverter()).ConvertToString(e.Modifiers);
                    TelePosition.Text = modString.Substring(0, modString.Length - 4) +
                                        (new KeysConverter()).ConvertToString(THotkey);

                    UnregisterHotKey(Handle, (int)RegisterHotKeyIds.TelePositionId);
                    RegisterHotKey(Handle, (int)RegisterHotKeyIds.TelePositionId, THotkeyMods, THotkey);

                    Cursor.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add Hotkey");
            }
        }

        #endregion

        private void HighTowerButton_Click(object sender, EventArgs e)
        {
            if (GameProcessIsOpen)
            {
                Mem.WriteFloat(SavePosAddressY_18, (float)206.101);
                Mem.WriteFloat(SavePosAddressX_18, (float)599.36);
                Mem.WriteFloat(SavePosAddressZ_18, (float)243.207);
                Invalidate();
            }
        }

        
    }
}
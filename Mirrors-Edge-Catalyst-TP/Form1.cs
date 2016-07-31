using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Mirrors_Edge_Catalyst_SpeedOMeter;

namespace Mirrors_Edge_Catalyst_TP
{
    public partial class Form1 : Form
    {
        private bool KeyisSet { get; set; }
        private long SavePosAddressY { get; set; }
        private long SavePosAddressX { get; set; }
        private long SavePosAddressZ { get; set; }
        private float SavePosAddressYFloat { get; set; }
        private float SavePosAddressXFloat { get; set; }
        private float SavePosAddressZFloat { get; set; }
        private MemoryManager Mem;
        private bool GameProcessIsOpen;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            Mem = new MemoryManager();
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
        }

        private void nsControlButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckGameStatus_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MirrorsEdgeCatalyst").Length > 0)
            {
                GameStatus.Text = "RUNNING";
                GameStatus.ForeColor = Color.Green;

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


        // HotKey setup
        #region 
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
                if (SavePosition.Text != Keys.None.ToString() && !SavePosition.Text.Trim().EndsWith("+"))
                    if (!string.IsNullOrEmpty("SavePosition") && HotKeyShared.IsValidHotkeyName(SavePosition.Text))
                    {
                        // Add hotkey
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
                if (TelePosition.Text != Keys.None.ToString() && !TelePosition.Text.Trim().EndsWith("+"))
                    if (!string.IsNullOrEmpty("SavePosition") && HotKeyShared.IsValidHotkeyName(TelePosition.Text))
                    {
                        // Add hotkey
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add Hotkey");
            }
        }

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
        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // If game is running
            if (GameProcessIsOpen)
            {
                try
                {
                    // 142578A68, 70, 98, 238, 18, 22d4 Y
                    SavePosAddressY = Mem.ReadInt(Mem.GetModuleAddress("MirrorsEdgeCatalyst.exe") + 0x02578A68);
                    SavePosAddressY = Mem.ReadInt(SavePosAddressY + 0x70);
                    SavePosAddressY = Mem.ReadInt(SavePosAddressY + 0x98);
                    SavePosAddressY = Mem.ReadInt(SavePosAddressY + 0x238);
                    SavePosAddressY = Mem.ReadInt(SavePosAddressY + 0x18);

                    var quickReadAddress = SavePosAddressY;

                    SavePosAddressY += 0x22d4;
                    SavePosAddressX = (quickReadAddress + 0x22d0);
                    SavePosAddressZ = (quickReadAddress + 0x22d8);

                    // Read Float values
                    SavePosAddressYFloat = (float)Mem.ReadFloat(SavePosAddressY);
                    SavePosAddressXFloat = (float)Mem.ReadFloat(SavePosAddressX);
                    SavePosAddressZFloat = (float)Mem.ReadFloat(SavePosAddressZ);

                    Invalidate();
                }
                catch (Exception)
                {
                    //ignore
                }
                
            }
        }

        private void TeleportButton_Click(object sender, EventArgs e)
        {
            if (GameProcessIsOpen && SavePosAddressY != 0 && SavePosAddressX != 0 && SavePosAddressZ != 0)
            {
                Mem.WriteFloat(SavePosAddressY, SavePosAddressYFloat);
                Mem.WriteFloat(SavePosAddressX, SavePosAddressXFloat);
                Mem.WriteFloat(SavePosAddressZ, SavePosAddressZFloat);
                Invalidate();
            }
        }
    }
}
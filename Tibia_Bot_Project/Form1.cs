using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace Tibia_Bot_Project
{

    public partial class LogiXBot : Form
    {

        private KeyboardSimulator keyboardSimulator;

        public LogiXBot()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogiXBot));
            this.hp_label = new System.Windows.Forms.Label();
            this.mana_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mana_hotkey = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.light_heal_hotkey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.intense_heal_hotkey = new System.Windows.Forms.ComboBox();
            this.start_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mana_percent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hp_percent_lh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hp_percent_ih = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hp_label
            // 
            this.hp_label.AutoSize = true;
            this.hp_label.ForeColor = System.Drawing.Color.Red;
            this.hp_label.Location = new System.Drawing.Point(44, 45);
            this.hp_label.Name = "hp_label";
            this.hp_label.Size = new System.Drawing.Size(45, 13);
            this.hp_label.TabIndex = 4;
            this.hp_label.Text = "Hp: ???";
            // 
            // mana_label
            // 
            this.mana_label.AutoSize = true;
            this.mana_label.ForeColor = System.Drawing.Color.Blue;
            this.mana_label.Location = new System.Drawing.Point(44, 82);
            this.mana_label.Name = "mana_label";
            this.mana_label.Size = new System.Drawing.Size(61, 13);
            this.mana_label.TabIndex = 5;
            this.mana_label.Text = " Mana: ???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mana Hotkey";
            // 
            // mana_hotkey
            // 
            this.mana_hotkey.FormattingEnabled = true;
            this.mana_hotkey.Location = new System.Drawing.Point(50, 153);
            this.mana_hotkey.Name = "mana_hotkey";
            this.mana_hotkey.Size = new System.Drawing.Size(121, 21);
            this.mana_hotkey.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Light Heal Hotkey";
            // 
            // light_heal_hotkey
            // 
            this.light_heal_hotkey.FormattingEnabled = true;
            this.light_heal_hotkey.Location = new System.Drawing.Point(215, 153);
            this.light_heal_hotkey.Name = "light_heal_hotkey";
            this.light_heal_hotkey.Size = new System.Drawing.Size(121, 21);
            this.light_heal_hotkey.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Intense Heal Hotkey";
            // 
            // intense_heal_hotkey
            // 
            this.intense_heal_hotkey.FormattingEnabled = true;
            this.intense_heal_hotkey.Location = new System.Drawing.Point(368, 153);
            this.intense_heal_hotkey.Name = "intense_heal_hotkey";
            this.intense_heal_hotkey.Size = new System.Drawing.Size(121, 21);
            this.intense_heal_hotkey.TabIndex = 11;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(47, 271);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 12;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mana < ";
            // 
            // mana_percent
            // 
            this.mana_percent.Location = new System.Drawing.Point(582, 203);
            this.mana_percent.Name = "mana_percent";
            this.mana_percent.Size = new System.Drawing.Size(27, 20);
            this.mana_percent.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "%  (Light Heal)";
            // 
            // hp_percent_lh
            // 
            this.hp_percent_lh.Location = new System.Drawing.Point(582, 229);
            this.hp_percent_lh.Name = "hp_percent_lh";
            this.hp_percent_lh.Size = new System.Drawing.Size(27, 20);
            this.hp_percent_lh.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Hp < ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(615, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "%  (Intense Heal)";
            // 
            // hp_percent_ih
            // 
            this.hp_percent_ih.Location = new System.Drawing.Point(582, 255);
            this.hp_percent_ih.Name = "hp_percent_ih";
            this.hp_percent_ih.Size = new System.Drawing.Size(27, 20);
            this.hp_percent_ih.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(530, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Hp < ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(533, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 126);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // LogiXBot
            // 
            this.ClientSize = new System.Drawing.Size(750, 319);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.hp_percent_ih);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hp_percent_lh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mana_percent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.intense_heal_hotkey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.light_heal_hotkey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mana_hotkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mana_label);
            this.Controls.Add(this.hp_label);
            this.Icon = global::Tibia_Bot_Project.Properties.Resources.LogiXBot;
            this.Name = "LogiXBot";
            this.Text = "LogiXBot Auto Healer";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setManaText(String text)
        {
            this.mana_label.Text = text;
        }
        public void setHpText(String text)
        {
            this.hp_label.Text = text;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            var source = new Dictionary<string, uint>();
            source.Add("F1", 0x70);
            source.Add("F2", 0x71);
            source.Add("F3", 0x72);
            source.Add("F4", 0x73);
            source.Add("F5", 0x74);
            source.Add("F6", 0x75);
            source.Add("F7", 0x76);
            source.Add("F8", 0x77);
            source.Add("F9", 0x78);
            source.Add("F10", 0x79);
            source.Add("F11", 0x80);
            source.Add("F12", 0x81);

            this.mana_hotkey.DataSource = source.ToList();
            this.mana_hotkey.DisplayMember = "Key";
            this.mana_hotkey.ValueMember = "Value";

            this.light_heal_hotkey.DataSource = source.ToList();
            this.light_heal_hotkey.DisplayMember = "Key";
            this.light_heal_hotkey.ValueMember = "Value";

            this.intense_heal_hotkey.DataSource = source.ToList();
            this.intense_heal_hotkey.DisplayMember = "Key";
            this.intense_heal_hotkey.ValueMember = "Value";

        }

        private void start_button_Click(object sender, EventArgs e)
        {
            uint selectedManaHotkey = (uint)this.mana_hotkey.SelectedValue;
            uint selectedLightHealHotkey = (uint)this.light_heal_hotkey.SelectedValue;
            uint selctedIntenseHealHotkey = (uint)this.intense_heal_hotkey.SelectedValue;

            double manaPercentInput;
            double hpPercentLightHealInput;
            double hpPercentIntenseHealInput;

            Double.TryParse(this.mana_percent.Text, out manaPercentInput);
            Double.TryParse(this.hp_percent_lh.Text, out hpPercentLightHealInput);
            Double.TryParse(this.hp_percent_ih.Text, out hpPercentIntenseHealInput);


            keyboardSimulator = new KeyboardSimulator(selectedManaHotkey, selectedLightHealHotkey, selctedIntenseHealHotkey);
            new MemoryReader(keyboardSimulator, this, manaPercentInput/100, hpPercentLightHealInput/100, hpPercentIntenseHealInput/100);
        }
    }
}

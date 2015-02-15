namespace HSv4
{
  partial class HSv4
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HSv4));
      this.classBox = new System.Windows.Forms.ComboBox();
      this.winBox = new System.Windows.Forms.ComboBox();
      this.LossBox = new System.Windows.Forms.ComboBox();
      this.arenaButton = new System.Windows.Forms.Button();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.pictureBox4 = new System.Windows.Forms.PictureBox();
      this.statBox = new System.Windows.Forms.ComboBox();
      this.statButton = new System.Windows.Forms.Button();
      this.manageBox = new System.Windows.Forms.ComboBox();
      this.manageButton = new System.Windows.Forms.Button();
      this.pictureBox5 = new System.Windows.Forms.PictureBox();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.richTextBox2 = new System.Windows.Forms.RichTextBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pictureBox6 = new System.Windows.Forms.PictureBox();
      this.pictureBox7 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
      this.SuspendLayout();
      // 
      // classBox
      // 
      this.classBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.classBox.FormattingEnabled = true;
      this.classBox.Items.AddRange(new object[] {
            "Druid",
            "Hunter",
            "Mage",
            "Paladin",
            "Priest",
            "Rogue",
            "Shaman",
            "Warlock",
            "Warrior"});
      this.classBox.Location = new System.Drawing.Point(50, 205);
      this.classBox.Name = "classBox";
      this.classBox.Size = new System.Drawing.Size(121, 21);
      this.classBox.TabIndex = 6;
      this.classBox.Text = "Class";
      this.classBox.SelectedIndexChanged += new System.EventHandler(this.combo_Box_Class);
      // 
      // winBox
      // 
      this.winBox.ForeColor = System.Drawing.Color.Black;
      this.winBox.FormattingEnabled = true;
      this.winBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
      this.winBox.Location = new System.Drawing.Point(50, 255);
      this.winBox.Name = "winBox";
      this.winBox.Size = new System.Drawing.Size(121, 21);
      this.winBox.TabIndex = 7;
      this.winBox.Text = "Wins";
      this.winBox.SelectedIndexChanged += new System.EventHandler(this.combo_Box_Win);
      // 
      // LossBox
      // 
      this.LossBox.FormattingEnabled = true;
      this.LossBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
      this.LossBox.Location = new System.Drawing.Point(50, 307);
      this.LossBox.Name = "LossBox";
      this.LossBox.Size = new System.Drawing.Size(121, 21);
      this.LossBox.TabIndex = 8;
      this.LossBox.Text = "Losses";
      this.LossBox.SelectedIndexChanged += new System.EventHandler(this.combo_Box_Losses);
      // 
      // arenaButton
      // 
      this.arenaButton.ForeColor = System.Drawing.Color.Black;
      this.arenaButton.Location = new System.Drawing.Point(72, 363);
      this.arenaButton.Name = "arenaButton";
      this.arenaButton.Size = new System.Drawing.Size(75, 23);
      this.arenaButton.TabIndex = 9;
      this.arenaButton.Text = "Add Arena";
      this.arenaButton.UseVisualStyleBackColor = true;
      this.arenaButton.Click += new System.EventHandler(this.Button_Add_Arena);
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox2.Image = global::HSv4.Properties.Resources.cooltext1909678512;
      this.pictureBox2.Location = new System.Drawing.Point(247, 323);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(252, 63);
      this.pictureBox2.TabIndex = 10;
      this.pictureBox2.TabStop = false;
      // 
      // pictureBox3
      // 
      this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox3.Image = global::HSv4.Properties.Resources.cooltext1909677615;
      this.pictureBox3.Location = new System.Drawing.Point(47, 134);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(124, 46);
      this.pictureBox3.TabIndex = 11;
      this.pictureBox3.TabStop = false;
      // 
      // pictureBox4
      // 
      this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox4.Image = global::HSv4.Properties.Resources.cooltext1909678888;
      this.pictureBox4.Location = new System.Drawing.Point(236, 134);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new System.Drawing.Size(113, 41);
      this.pictureBox4.TabIndex = 12;
      this.pictureBox4.TabStop = false;
      // 
      // statBox
      // 
      this.statBox.FormattingEnabled = true;
      this.statBox.Items.AddRange(new object[] {
            "Best Played Class",
            "Class Stat",
            "Latest Game",
            "Most Played Class",
            "Most Wins",
            "Winning Stats",
            "Worst Played Class"});
      this.statBox.Location = new System.Drawing.Point(228, 205);
      this.statBox.Name = "statBox";
      this.statBox.Size = new System.Drawing.Size(121, 21);
      this.statBox.TabIndex = 13;
      this.statBox.Text = "Stats";
      this.statBox.SelectedIndexChanged += new System.EventHandler(this.combo_Box_Stats);
      // 
      // statButton
      // 
      this.statButton.ForeColor = System.Drawing.Color.Black;
      this.statButton.Location = new System.Drawing.Point(247, 253);
      this.statButton.Name = "statButton";
      this.statButton.Size = new System.Drawing.Size(75, 23);
      this.statButton.TabIndex = 14;
      this.statButton.Text = "See Stats";
      this.statButton.UseVisualStyleBackColor = true;
      this.statButton.Click += new System.EventHandler(this.Button_Stats);
      // 
      // manageBox
      // 
      this.manageBox.FormattingEnabled = true;
      this.manageBox.Items.AddRange(new object[] {
            "Delete Run",
            "Recover Run"});
      this.manageBox.Location = new System.Drawing.Point(394, 205);
      this.manageBox.Name = "manageBox";
      this.manageBox.Size = new System.Drawing.Size(121, 21);
      this.manageBox.TabIndex = 16;
      this.manageBox.Text = "Manage";
      this.manageBox.SelectedIndexChanged += new System.EventHandler(this.combo_Box_Manage);
      // 
      // manageButton
      // 
      this.manageButton.ForeColor = System.Drawing.Color.Black;
      this.manageButton.Location = new System.Drawing.Point(415, 253);
      this.manageButton.Name = "manageButton";
      this.manageButton.Size = new System.Drawing.Size(75, 23);
      this.manageButton.TabIndex = 17;
      this.manageButton.Text = "Manage";
      this.manageButton.UseVisualStyleBackColor = true;
      this.manageButton.Click += new System.EventHandler(this.Button_Manage);
      // 
      // pictureBox5
      // 
      this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox5.Image = global::HSv4.Properties.Resources.cooltext1909731317;
      this.pictureBox5.Location = new System.Drawing.Point(389, 134);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new System.Drawing.Size(136, 34);
      this.pictureBox5.TabIndex = 18;
      this.pictureBox5.TabStop = false;
      // 
      // richTextBox1
      // 
      this.richTextBox1.BackColor = System.Drawing.Color.Black;
      this.richTextBox1.ForeColor = System.Drawing.Color.White;
      this.richTextBox1.Location = new System.Drawing.Point(87, 425);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ReadOnly = true;
      this.richTextBox1.Size = new System.Drawing.Size(250, 125);
      this.richTextBox1.TabIndex = 19;
      this.richTextBox1.Text = "";
      this.richTextBox1.TextChanged += new System.EventHandler(this.preOutput_Box);
      // 
      // richTextBox2
      // 
      this.richTextBox2.BackColor = System.Drawing.Color.Black;
      this.richTextBox2.ForeColor = System.Drawing.Color.White;
      this.richTextBox2.Location = new System.Drawing.Point(334, 425);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.ReadOnly = true;
      this.richTextBox2.Size = new System.Drawing.Size(460, 125);
      this.richTextBox2.TabIndex = 20;
      this.richTextBox2.Text = "";
      this.richTextBox2.TextChanged += new System.EventHandler(this.Output_Box);
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Image = global::HSv4.Properties.Resources.cooltext1909988044;
      this.pictureBox1.Location = new System.Drawing.Point(130, 29);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(453, 77);
      this.pictureBox1.TabIndex = 21;
      this.pictureBox1.TabStop = false;
      // 
      // pictureBox6
      // 
      this.pictureBox6.BackColor = System.Drawing.Color.Black;
      this.pictureBox6.Location = new System.Drawing.Point(1, 541);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new System.Drawing.Size(216, 37);
      this.pictureBox6.TabIndex = 22;
      this.pictureBox6.TabStop = false;
      // 
      // pictureBox7
      // 
      this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox7.Image = global::HSv4.Properties.Resources._1423255006_tux1;
      this.pictureBox7.Location = new System.Drawing.Point(1, 12);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new System.Drawing.Size(146, 124);
      this.pictureBox7.TabIndex = 23;
      this.pictureBox7.TabStop = false;
      // 
      // HSv4
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::HSv4.Properties.Resources.http___wall_anonforge_com_wp_content_uploads_Anime_TokyoGhoul_c_ken_kaneki_mask_white_hair_tokyo_ghoul_1920x1080;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(884, 572);
      this.Controls.Add(this.richTextBox2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.pictureBox7);
      this.Controls.Add(this.pictureBox5);
      this.Controls.Add(this.manageButton);
      this.Controls.Add(this.manageBox);
      this.Controls.Add(this.statButton);
      this.Controls.Add(this.statBox);
      this.Controls.Add(this.pictureBox4);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.arenaButton);
      this.Controls.Add(this.LossBox);
      this.Controls.Add(this.winBox);
      this.Controls.Add(this.classBox);
      this.Controls.Add(this.pictureBox6);
      this.Controls.Add(this.pictureBox3);
      this.ForeColor = System.Drawing.SystemColors.Control;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "HSv4";
      this.Text = "HSv4";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox classBox;
    private System.Windows.Forms.ComboBox winBox;
    private System.Windows.Forms.ComboBox LossBox;
    private System.Windows.Forms.Button arenaButton;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.PictureBox pictureBox4;
    private System.Windows.Forms.ComboBox statBox;
    private System.Windows.Forms.Button statButton;
    private System.Windows.Forms.ComboBox manageBox;
    private System.Windows.Forms.Button manageButton;
    private System.Windows.Forms.PictureBox pictureBox5;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.RichTextBox richTextBox2;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox pictureBox6;
    private System.Windows.Forms.PictureBox pictureBox7;


  }
}


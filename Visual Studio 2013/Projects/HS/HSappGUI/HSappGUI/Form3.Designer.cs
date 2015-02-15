namespace HSv4
{
  partial class formDelete
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDelete));
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.deleteList = new System.Windows.Forms.CheckedListBox();
      this.deleteButton = new System.Windows.Forms.Button();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.backButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Image = global::HSv4.Properties.Resources._1423255006_tux;
      this.pictureBox1.Location = new System.Drawing.Point(24, 27);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(131, 116);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // deleteList
      // 
      this.deleteList.BackColor = System.Drawing.SystemColors.Window;
      this.deleteList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.deleteList.ForeColor = System.Drawing.Color.Black;
      this.deleteList.FormattingEnabled = true;
      this.deleteList.Location = new System.Drawing.Point(190, 27);
      this.deleteList.Name = "deleteList";
      this.deleteList.Size = new System.Drawing.Size(281, 349);
      this.deleteList.TabIndex = 1;
      this.deleteList.SelectedIndexChanged += new System.EventHandler(this.deleteList_SelectedIndexChanged);
      // 
      // deleteButton
      // 
      this.deleteButton.Location = new System.Drawing.Point(52, 229);
      this.deleteButton.Name = "deleteButton";
      this.deleteButton.Size = new System.Drawing.Size(75, 23);
      this.deleteButton.TabIndex = 2;
      this.deleteButton.Text = "Delete";
      this.deleteButton.UseVisualStyleBackColor = true;
      this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(12, 280);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(162, 96);
      this.richTextBox1.TabIndex = 3;
      this.richTextBox1.Text = "";
      this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
      // 
      // backButton
      // 
      this.backButton.Location = new System.Drawing.Point(52, 185);
      this.backButton.Name = "backButton";
      this.backButton.Size = new System.Drawing.Size(75, 23);
      this.backButton.TabIndex = 4;
      this.backButton.Text = "Back";
      this.backButton.UseVisualStyleBackColor = true;
      this.backButton.Click += new System.EventHandler(this.backButton_Click);
      // 
      // formDelete
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.DarkRed;
      this.ClientSize = new System.Drawing.Size(483, 397);
      this.Controls.Add(this.backButton);
      this.Controls.Add(this.richTextBox1);
      this.Controls.Add(this.deleteButton);
      this.Controls.Add(this.deleteList);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "formDelete";
      this.Text = "Delete Run";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.CheckedListBox deleteList;
    private System.Windows.Forms.Button deleteButton;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button backButton;
  }
}
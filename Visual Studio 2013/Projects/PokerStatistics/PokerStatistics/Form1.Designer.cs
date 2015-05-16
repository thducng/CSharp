namespace PokerStatistics
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.BalanceBox = new System.Windows.Forms.RichTextBox();
      this.TypeBox = new System.Windows.Forms.ComboBox();
      this.BuyInBox = new System.Windows.Forms.TextBox();
      this.CashOutBox = new System.Windows.Forms.TextBox();
      this.ResultBox = new System.Windows.Forms.ComboBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.SessionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.NameBox = new System.Windows.Forms.TextBox();
      this.DWMChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.StartButton = new System.Windows.Forms.Button();
      this.EndButton = new System.Windows.Forms.Button();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.GameBox = new System.Windows.Forms.RichTextBox();
      this.StatusBox = new System.Windows.Forms.RichTextBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.moreFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.allGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.moreChartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SessionChart)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DWMChart)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // BalanceBox
      // 
      this.BalanceBox.BackColor = System.Drawing.Color.DimGray;
      this.BalanceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BalanceBox.ForeColor = System.Drawing.Color.White;
      this.BalanceBox.Location = new System.Drawing.Point(443, 123);
      this.BalanceBox.Name = "BalanceBox";
      this.BalanceBox.ReadOnly = true;
      this.BalanceBox.Size = new System.Drawing.Size(181, 141);
      this.BalanceBox.TabIndex = 0;
      this.BalanceBox.Text = "";
      // 
      // TypeBox
      // 
      this.TypeBox.BackColor = System.Drawing.Color.DimGray;
      this.TypeBox.Font = new System.Drawing.Font("Kristen ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TypeBox.ForeColor = System.Drawing.Color.White;
      this.TypeBox.FormattingEnabled = true;
      this.TypeBox.Items.AddRange(new object[] {
            "Cash Game",
            "Sit n Go",
            "Spin n Go",
            "Tournament"});
      this.TypeBox.Location = new System.Drawing.Point(12, 123);
      this.TypeBox.Name = "TypeBox";
      this.TypeBox.Size = new System.Drawing.Size(130, 24);
      this.TypeBox.TabIndex = 1;
      this.TypeBox.Text = "Game Type";
      // 
      // BuyInBox
      // 
      this.BuyInBox.BackColor = System.Drawing.Color.DimGray;
      this.BuyInBox.Font = new System.Drawing.Font("Kristen ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BuyInBox.ForeColor = System.Drawing.Color.White;
      this.BuyInBox.Location = new System.Drawing.Point(148, 125);
      this.BuyInBox.Name = "BuyInBox";
      this.BuyInBox.Size = new System.Drawing.Size(130, 22);
      this.BuyInBox.TabIndex = 2;
      this.BuyInBox.Text = "Buy-In";
      this.BuyInBox.Click += new System.EventHandler(this.BuyInBox_Click);
      // 
      // CashOutBox
      // 
      this.CashOutBox.BackColor = System.Drawing.Color.DimGray;
      this.CashOutBox.Font = new System.Drawing.Font("Kristen ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CashOutBox.ForeColor = System.Drawing.Color.White;
      this.CashOutBox.Location = new System.Drawing.Point(12, 223);
      this.CashOutBox.Name = "CashOutBox";
      this.CashOutBox.Size = new System.Drawing.Size(266, 22);
      this.CashOutBox.TabIndex = 3;
      this.CashOutBox.Text = "Cash-Out";
      this.CashOutBox.Click += new System.EventHandler(this.CashOutBox_Click);
      // 
      // ResultBox
      // 
      this.ResultBox.BackColor = System.Drawing.Color.DimGray;
      this.ResultBox.Font = new System.Drawing.Font("Kristen ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResultBox.ForeColor = System.Drawing.Color.White;
      this.ResultBox.FormattingEnabled = true;
      this.ResultBox.Items.AddRange(new object[] {
            "Win",
            "Draw",
            "Loss"});
      this.ResultBox.Location = new System.Drawing.Point(12, 193);
      this.ResultBox.Name = "ResultBox";
      this.ResultBox.Size = new System.Drawing.Size(266, 24);
      this.ResultBox.TabIndex = 4;
      this.ResultBox.Text = "Result";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Black;
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(41, 35);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(574, 68);
      this.pictureBox1.TabIndex = 5;
      this.pictureBox1.TabStop = false;
      // 
      // SessionChart
      // 
      this.SessionChart.BackColor = System.Drawing.Color.DimGray;
      this.SessionChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
      this.SessionChart.BackSecondaryColor = System.Drawing.Color.Gray;
      chartArea1.AxisX.MaximumAutoSize = 40F;
      chartArea1.AxisY.MaximumAutoSize = 40F;
      chartArea1.BackColor = System.Drawing.Color.DimGray;
      chartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent;
      chartArea1.BackSecondaryColor = System.Drawing.Color.Gray;
      chartArea1.Name = "ChartArea1";
      this.SessionChart.ChartAreas.Add(chartArea1);
      legend1.Enabled = false;
      legend1.Name = "Legend1";
      this.SessionChart.Legends.Add(legend1);
      this.SessionChart.Location = new System.Drawing.Point(12, 270);
      this.SessionChart.Name = "SessionChart";
      series1.BackSecondaryColor = System.Drawing.Color.White;
      series1.BorderWidth = 3;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series1.LabelBackColor = System.Drawing.Color.White;
      series1.LabelBorderColor = System.Drawing.Color.Black;
      series1.LabelBorderWidth = 5;
      series1.Legend = "Legend1";
      series1.MarkerBorderColor = System.Drawing.Color.Black;
      series1.MarkerColor = System.Drawing.Color.Black;
      series1.MarkerSize = 3;
      series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
      series1.Name = "Sessions";
      series2.BorderWidth = 3;
      series2.ChartArea = "ChartArea1";
      series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series2.Legend = "Legend1";
      series2.MarkerSize = 3;
      series2.Name = "StartBalance";
      this.SessionChart.Series.Add(series1);
      this.SessionChart.Series.Add(series2);
      this.SessionChart.Size = new System.Drawing.Size(423, 342);
      this.SessionChart.TabIndex = 6;
      this.SessionChart.Text = "Sessions";
      // 
      // NameBox
      // 
      this.NameBox.BackColor = System.Drawing.Color.DimGray;
      this.NameBox.Font = new System.Drawing.Font("Kristen ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.NameBox.ForeColor = System.Drawing.Color.White;
      this.NameBox.Location = new System.Drawing.Point(12, 151);
      this.NameBox.Name = "NameBox";
      this.NameBox.Size = new System.Drawing.Size(266, 22);
      this.NameBox.TabIndex = 7;
      this.NameBox.Text = "Name";
      this.NameBox.Click += new System.EventHandler(this.NameBox_Click);
      // 
      // DWMChart
      // 
      this.DWMChart.BackColor = System.Drawing.Color.DimGray;
      this.DWMChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
      this.DWMChart.BackSecondaryColor = System.Drawing.Color.Gray;
      this.DWMChart.BorderSkin.BackColor = System.Drawing.Color.DimGray;
      chartArea2.BackColor = System.Drawing.Color.DimGray;
      chartArea2.Name = "ChartArea1";
      this.DWMChart.ChartAreas.Add(chartArea2);
      legend2.Enabled = false;
      legend2.Name = "Legend1";
      this.DWMChart.Legends.Add(legend2);
      this.DWMChart.Location = new System.Drawing.Point(443, 348);
      this.DWMChart.Name = "DWMChart";
      series3.BorderWidth = 3;
      series3.ChartArea = "ChartArea1";
      series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series3.Legend = "Legend1";
      series3.MarkerBorderColor = System.Drawing.Color.Black;
      series3.MarkerColor = System.Drawing.Color.Black;
      series3.MarkerSize = 3;
      series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
      series3.Name = "Daily";
      series4.BorderWidth = 3;
      series4.ChartArea = "ChartArea1";
      series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series4.Legend = "Legend1";
      series4.MarkerSize = 3;
      series4.Name = "StartBalance";
      this.DWMChart.Series.Add(series3);
      this.DWMChart.Series.Add(series4);
      this.DWMChart.Size = new System.Drawing.Size(363, 264);
      this.DWMChart.TabIndex = 8;
      this.DWMChart.Text = "Weekly";
      // 
      // pictureBox2
      // 
      this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
      this.pictureBox2.Location = new System.Drawing.Point(621, 12);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(154, 106);
      this.pictureBox2.TabIndex = 9;
      this.pictureBox2.TabStop = false;
      // 
      // StartButton
      // 
      this.StartButton.BackColor = System.Drawing.Color.DimGray;
      this.StartButton.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StartButton.ForeColor = System.Drawing.Color.White;
      this.StartButton.Location = new System.Drawing.Point(284, 123);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(151, 50);
      this.StartButton.TabIndex = 10;
      this.StartButton.Text = "Start Game";
      this.StartButton.UseVisualStyleBackColor = false;
      this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
      // 
      // EndButton
      // 
      this.EndButton.BackColor = System.Drawing.Color.DimGray;
      this.EndButton.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.EndButton.ForeColor = System.Drawing.Color.White;
      this.EndButton.Location = new System.Drawing.Point(284, 191);
      this.EndButton.Name = "EndButton";
      this.EndButton.Size = new System.Drawing.Size(151, 54);
      this.EndButton.TabIndex = 11;
      this.EndButton.Text = "End Game";
      this.EndButton.UseVisualStyleBackColor = false;
      this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
      // 
      // pictureBox3
      // 
      this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.pictureBox3.Location = new System.Drawing.Point(461, 250);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(292, 151);
      this.pictureBox3.TabIndex = 12;
      this.pictureBox3.TabStop = false;
      // 
      // GameBox
      // 
      this.GameBox.BackColor = System.Drawing.Color.DimGray;
      this.GameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.GameBox.ForeColor = System.Drawing.Color.White;
      this.GameBox.Location = new System.Drawing.Point(630, 124);
      this.GameBox.Name = "GameBox";
      this.GameBox.ReadOnly = true;
      this.GameBox.Size = new System.Drawing.Size(176, 218);
      this.GameBox.TabIndex = 13;
      this.GameBox.Text = "";
      // 
      // StatusBox
      // 
      this.StatusBox.BackColor = System.Drawing.Color.DimGray;
      this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.StatusBox.ForeColor = System.Drawing.Color.White;
      this.StatusBox.Location = new System.Drawing.Point(443, 270);
      this.StatusBox.Name = "StatusBox";
      this.StatusBox.ReadOnly = true;
      this.StatusBox.Size = new System.Drawing.Size(181, 72);
      this.StatusBox.TabIndex = 14;
      this.StatusBox.Text = "Status Box\n\nGreen  = Profit\nOrange = Loss";
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
      this.menuStrip1.Font = new System.Drawing.Font("Kristen ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moreFeaturesToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(818, 25);
      this.menuStrip1.TabIndex = 15;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // moreFeaturesToolStripMenuItem
      // 
      this.moreFeaturesToolStripMenuItem.BackColor = System.Drawing.Color.Black;
      this.moreFeaturesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allGamesToolStripMenuItem,
            this.moreChartsToolStripMenuItem});
      this.moreFeaturesToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
      this.moreFeaturesToolStripMenuItem.Name = "moreFeaturesToolStripMenuItem";
      this.moreFeaturesToolStripMenuItem.Size = new System.Drawing.Size(121, 21);
      this.moreFeaturesToolStripMenuItem.Text = "More Features";
      // 
      // allGamesToolStripMenuItem
      // 
      this.allGamesToolStripMenuItem.BackColor = System.Drawing.Color.Black;
      this.allGamesToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
      this.allGamesToolStripMenuItem.Name = "allGamesToolStripMenuItem";
      this.allGamesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.allGamesToolStripMenuItem.Text = "All Games";
      this.allGamesToolStripMenuItem.Click += new System.EventHandler(this.allGamesToolStripMenuItem_Click);
      // 
      // moreChartsToolStripMenuItem
      // 
      this.moreChartsToolStripMenuItem.BackColor = System.Drawing.Color.Black;
      this.moreChartsToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
      this.moreChartsToolStripMenuItem.Name = "moreChartsToolStripMenuItem";
      this.moreChartsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.moreChartsToolStripMenuItem.Text = "More Charts";
      this.moreChartsToolStripMenuItem.Click += new System.EventHandler(this.moreChartsToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.ClientSize = new System.Drawing.Size(818, 624);
      this.Controls.Add(this.StatusBox);
      this.Controls.Add(this.GameBox);
      this.Controls.Add(this.EndButton);
      this.Controls.Add(this.StartButton);
      this.Controls.Add(this.DWMChart);
      this.Controls.Add(this.NameBox);
      this.Controls.Add(this.SessionChart);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.ResultBox);
      this.Controls.Add(this.CashOutBox);
      this.Controls.Add(this.BuyInBox);
      this.Controls.Add(this.TypeBox);
      this.Controls.Add(this.BalanceBox);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "PokerStatistics";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SessionChart)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DWMChart)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox BalanceBox;
    private System.Windows.Forms.ComboBox TypeBox;
    private System.Windows.Forms.TextBox BuyInBox;
    private System.Windows.Forms.TextBox CashOutBox;
    private System.Windows.Forms.ComboBox ResultBox;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.DataVisualization.Charting.Chart SessionChart;
    private System.Windows.Forms.TextBox NameBox;
    private System.Windows.Forms.DataVisualization.Charting.Chart DWMChart;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Button StartButton;
    private System.Windows.Forms.Button EndButton;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.RichTextBox GameBox;
    private System.Windows.Forms.RichTextBox StatusBox;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem moreFeaturesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem allGamesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem moreChartsToolStripMenuItem;

  }
}


namespace PokerStatistics
{
  partial class MoreChartsForm
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoreChartsForm));
      this.Weekly = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.Monthly = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.monthlyAva = new System.Windows.Forms.Label();
      this.weeklyAva = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.Weekly)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Monthly)).BeginInit();
      this.SuspendLayout();
      // 
      // Weekly
      // 
      this.Weekly.BackColor = System.Drawing.Color.DimGray;
      this.Weekly.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
      this.Weekly.BackSecondaryColor = System.Drawing.Color.DimGray;
      chartArea1.BackColor = System.Drawing.Color.DimGray;
      chartArea1.Name = "ChartArea1";
      this.Weekly.ChartAreas.Add(chartArea1);
      legend1.Enabled = false;
      legend1.Name = "Legend1";
      this.Weekly.Legends.Add(legend1);
      this.Weekly.Location = new System.Drawing.Point(12, 42);
      this.Weekly.Name = "Weekly";
      series1.BorderWidth = 3;
      series1.ChartArea = "ChartArea1";
      series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series1.Color = System.Drawing.Color.DodgerBlue;
      series1.Legend = "Legend1";
      series1.MarkerBorderColor = System.Drawing.Color.Black;
      series1.MarkerColor = System.Drawing.Color.Black;
      series1.MarkerSize = 3;
      series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
      series1.Name = "Weekly";
      series2.BorderWidth = 3;
      series2.ChartArea = "ChartArea1";
      series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series2.Color = System.Drawing.Color.Yellow;
      series2.Legend = "Legend1";
      series2.Name = "StartBalance";
      this.Weekly.Series.Add(series1);
      this.Weekly.Series.Add(series2);
      this.Weekly.Size = new System.Drawing.Size(785, 300);
      this.Weekly.TabIndex = 0;
      this.Weekly.Text = "Weekly";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(121, 22);
      this.label1.TabIndex = 1;
      this.label1.Text = "Weekly Chart";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(12, 357);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(123, 22);
      this.label2.TabIndex = 2;
      this.label2.Text = "Montly Chart";
      // 
      // Monthly
      // 
      this.Monthly.BackColor = System.Drawing.Color.DimGray;
      this.Monthly.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
      this.Monthly.BackSecondaryColor = System.Drawing.Color.DimGray;
      chartArea2.BackColor = System.Drawing.Color.DimGray;
      chartArea2.Name = "ChartArea1";
      this.Monthly.ChartAreas.Add(chartArea2);
      legend2.Enabled = false;
      legend2.Name = "Legend1";
      this.Monthly.Legends.Add(legend2);
      this.Monthly.Location = new System.Drawing.Point(12, 383);
      this.Monthly.Name = "Monthly";
      series3.BorderWidth = 3;
      series3.ChartArea = "ChartArea1";
      series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series3.Color = System.Drawing.Color.DodgerBlue;
      series3.Legend = "Legend1";
      series3.MarkerBorderColor = System.Drawing.Color.Black;
      series3.MarkerColor = System.Drawing.Color.Black;
      series3.MarkerSize = 3;
      series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
      series3.Name = "Monthly";
      series4.BorderWidth = 3;
      series4.ChartArea = "ChartArea1";
      series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
      series4.Color = System.Drawing.Color.Yellow;
      series4.Legend = "Legend1";
      series4.Name = "StartBalance";
      this.Monthly.Series.Add(series3);
      this.Monthly.Series.Add(series4);
      this.Monthly.Size = new System.Drawing.Size(785, 300);
      this.Monthly.TabIndex = 3;
      this.Monthly.Text = "Monthly";
      // 
      // monthlyAva
      // 
      this.monthlyAva.AutoSize = true;
      this.monthlyAva.Font = new System.Drawing.Font("Kristen ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.monthlyAva.ForeColor = System.Drawing.Color.White;
      this.monthlyAva.Location = new System.Drawing.Point(111, 503);
      this.monthlyAva.Name = "monthlyAva";
      this.monthlyAva.Size = new System.Drawing.Size(602, 66);
      this.monthlyAva.TabIndex = 4;
      this.monthlyAva.Text = "No Chart Available Yet";
      this.monthlyAva.Visible = false;
      // 
      // weeklyAva
      // 
      this.weeklyAva.AutoSize = true;
      this.weeklyAva.Font = new System.Drawing.Font("Kristen ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.weeklyAva.ForeColor = System.Drawing.Color.White;
      this.weeklyAva.Location = new System.Drawing.Point(111, 154);
      this.weeklyAva.Name = "weeklyAva";
      this.weeklyAva.Size = new System.Drawing.Size(602, 66);
      this.weeklyAva.TabIndex = 5;
      this.weeklyAva.Text = "No Chart Available Yet";
      this.weeklyAva.Visible = false;
      // 
      // MoreChartsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(809, 695);
      this.Controls.Add(this.weeklyAva);
      this.Controls.Add(this.monthlyAva);
      this.Controls.Add(this.Monthly);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Weekly);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MoreChartsForm";
      this.Text = "More Charts";
      this.Load += new System.EventHandler(this.MoreChartsForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.Weekly)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Monthly)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart Weekly;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataVisualization.Charting.Chart Monthly;
    private System.Windows.Forms.Label monthlyAva;
    private System.Windows.Forms.Label weeklyAva;
  }
}
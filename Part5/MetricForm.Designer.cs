namespace Part5
{
    partial class MetricForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWeightage = new System.Windows.Forms.TextBox();
            this.tbMark = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddMetric = new System.Windows.Forms.Button();
            this.tbMetric = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStudentId = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.Year = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Metric";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weightage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mark";
            // 
            // tbWeightage
            // 
            this.tbWeightage.Location = new System.Drawing.Point(283, 157);
            this.tbWeightage.Name = "tbWeightage";
            this.tbWeightage.Size = new System.Drawing.Size(100, 26);
            this.tbWeightage.TabIndex = 3;
            // 
            // tbMark
            // 
            this.tbMark.Location = new System.Drawing.Point(283, 202);
            this.tbMark.Name = "tbMark";
            this.tbMark.Size = new System.Drawing.Size(100, 26);
            this.tbMark.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(283, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAddMetric
            // 
            this.btnAddMetric.Location = new System.Drawing.Point(283, 283);
            this.btnAddMetric.Name = "btnAddMetric";
            this.btnAddMetric.Size = new System.Drawing.Size(158, 34);
            this.btnAddMetric.TabIndex = 6;
            this.btnAddMetric.Text = "Add Metric";
            this.btnAddMetric.UseVisualStyleBackColor = true;
            this.btnAddMetric.Click += new System.EventHandler(this.btnAddMetric_Click);
            // 
            // tbMetric
            // 
            this.tbMetric.Location = new System.Drawing.Point(460, 101);
            this.tbMetric.Name = "tbMetric";
            this.tbMetric.Size = new System.Drawing.Size(100, 26);
            this.tbMetric.TabIndex = 7;
            this.tbMetric.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "StudentId";
            // 
            // tbStudentId
            // 
            this.tbStudentId.Location = new System.Drawing.Point(283, 27);
            this.tbStudentId.Name = "tbStudentId";
            this.tbStudentId.Size = new System.Drawing.Size(100, 26);
            this.tbStudentId.TabIndex = 9;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(283, 60);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(100, 26);
            this.tbYear.TabIndex = 10;
            // 
            // Year
            // 
            this.Year.AutoSize = true;
            this.Year.Location = new System.Drawing.Point(189, 66);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(43, 20);
            this.Year.TabIndex = 11;
            this.Year.Text = "Year";
            // 
            // MetricFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbStudentId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMetric);
            this.Controls.Add(this.btnAddMetric);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tbMark);
            this.Controls.Add(this.tbWeightage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MetricFormcs";
            this.Text = "MetricFormcs";
            this.Load += new System.EventHandler(this.MetricFormcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWeightage;
        private System.Windows.Forms.TextBox tbMark;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAddMetric;
        private System.Windows.Forms.TextBox tbMetric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStudentId;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label Year;
    }
}
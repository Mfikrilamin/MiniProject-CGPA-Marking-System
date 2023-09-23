namespace Part5
{
    partial class Form1
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
            this.tbStudentId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStudentName = new System.Windows.Forms.TextBox();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.btnCalculateCGPA = new System.Windows.Forms.Button();
            this.btnAddMetric = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCGPA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbStudentId
            // 
            this.tbStudentId.Location = new System.Drawing.Point(173, 30);
            this.tbStudentId.Name = "tbStudentId";
            this.tbStudentId.Size = new System.Drawing.Size(520, 26);
            this.tbStudentId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Student Name";
            // 
            // tbStudentName
            // 
            this.tbStudentName.Location = new System.Drawing.Point(173, 77);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.Size = new System.Drawing.Size(520, 26);
            this.tbStudentName.TabIndex = 3;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(95, 236);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(170, 39);
            this.btnAddStudent.TabIndex = 4;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(503, 236);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(166, 39);
            this.btnAddSubject.TabIndex = 5;
            this.btnAddSubject.Text = "Add Subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // btnCalculateCGPA
            // 
            this.btnCalculateCGPA.Location = new System.Drawing.Point(303, 318);
            this.btnCalculateCGPA.Name = "btnCalculateCGPA";
            this.btnCalculateCGPA.Size = new System.Drawing.Size(185, 41);
            this.btnCalculateCGPA.TabIndex = 6;
            this.btnCalculateCGPA.Text = "CaclulateCGPA";
            this.btnCalculateCGPA.UseVisualStyleBackColor = true;
            this.btnCalculateCGPA.Click += new System.EventHandler(this.btnCalculateCGPA_Click);
            // 
            // btnAddMetric
            // 
            this.btnAddMetric.Location = new System.Drawing.Point(330, 236);
            this.btnAddMetric.Name = "btnAddMetric";
            this.btnAddMetric.Size = new System.Drawing.Size(135, 39);
            this.btnAddMetric.TabIndex = 7;
            this.btnAddMetric.Text = "Add Metric";
            this.btnAddMetric.UseVisualStyleBackColor = true;
            this.btnAddMetric.Click += new System.EventHandler(this.btnAddMetric_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Year";
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(173, 130);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(156, 26);
            this.tbYear.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "CGPA";
            // 
            // lblCGPA
            // 
            this.lblCGPA.AutoSize = true;
            this.lblCGPA.Location = new System.Drawing.Point(173, 182);
            this.lblCGPA.Name = "lblCGPA";
            this.lblCGPA.Size = new System.Drawing.Size(0, 20);
            this.lblCGPA.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCGPA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddMetric);
            this.Controls.Add(this.btnCalculateCGPA);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.tbStudentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbStudentId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStudentId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStudentName;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnCalculateCGPA;
        private System.Windows.Forms.Button btnAddMetric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCGPA;
    }
}


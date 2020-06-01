namespace Problema_2
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
            this.pB = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelEnumPoints = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
            this.SuspendLayout();
            // 
            // pB
            // 
            this.pB.BackColor = System.Drawing.Color.White;
            this.pB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pB.Location = new System.Drawing.Point(12, 12);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(234, 387);
            this.pB.TabIndex = 0;
            this.pB.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 408);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(58, 21);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(12, 439);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(39, 13);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "Points:";
            // 
            // labelEnumPoints
            // 
            this.labelEnumPoints.AutoSize = true;
            this.labelEnumPoints.Location = new System.Drawing.Point(47, 439);
            this.labelEnumPoints.Name = "labelEnumPoints";
            this.labelEnumPoints.Size = new System.Drawing.Size(16, 13);
            this.labelEnumPoints.TabIndex = 3;
            this.labelEnumPoints.Text = "...";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(76, 408);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(58, 21);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next ";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 463);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelEnumPoints);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pB;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelEnumPoints;
        private System.Windows.Forms.Button buttonNext;
    }
}


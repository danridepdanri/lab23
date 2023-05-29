namespace WinFormsApp18
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtRR = new TextBox();
            txtr = new TextBox();
            btnPlot = new Button();
            graphPictureBox = new PictureBox();
            txtT = new TextBox();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            SuspendLayout();
            // 
            // txtRR
            // 
            txtRR.Location = new Point(23, 12);
            txtRR.Name = "txtRR";
            txtRR.Size = new Size(100, 23);
            txtRR.TabIndex = 0;
            // 
            // txtr
            // 
            txtr.Location = new Point(129, 12);
            txtr.Name = "txtr";
            txtr.Size = new Size(100, 23);
            txtr.TabIndex = 1;
            // 
            // btnPlot
            // 
            btnPlot.Location = new Point(374, 11);
            btnPlot.Name = "btnPlot";
            btnPlot.Size = new Size(75, 23);
            btnPlot.TabIndex = 2;
            btnPlot.Text = "btnPlot";
            btnPlot.UseVisualStyleBackColor = true;
            btnPlot.Click += btnPlot_Click;
            // 
            // graphPictureBox
            // 
            graphPictureBox.Location = new Point(45, 83);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(1145, 588);
            graphPictureBox.TabIndex = 3;
            graphPictureBox.TabStop = false;
            // 
            // txtT
            // 
            txtT.Location = new Point(235, 11);
            txtT.Name = "txtT";
            txtT.Size = new Size(100, 23);
            txtT.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 711);
            Controls.Add(txtT);
            Controls.Add(graphPictureBox);
            Controls.Add(btnPlot);
            Controls.Add(txtr);
            Controls.Add(txtRR);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRR;
        private TextBox txtr;
        private Button btnPlot;
        private PictureBox graphPictureBox;
        private TextBox txtT;
    }
}
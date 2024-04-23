namespace ToDoReminder
{
    partial class AboutBox
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
            pictureBoxHelp = new PictureBox();
            lblPicture = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHelp).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxHelp
            // 
            pictureBoxHelp.Location = new Point(73, 65);
            pictureBoxHelp.Name = "pictureBoxHelp";
            pictureBoxHelp.Size = new Size(150, 75);
            pictureBoxHelp.TabIndex = 0;
            pictureBoxHelp.TabStop = false;
            pictureBoxHelp.Click += pictureBoxHelp_Click;
            // 
            // lblPicture
            // 
            lblPicture.AutoSize = true;
            lblPicture.Location = new Point(87, 172);
            lblPicture.Name = "lblPicture";
            lblPicture.Size = new Size(77, 25);
            lblPicture.TabIndex = 1;
            lblPicture.Text = "Min bild";
            lblPicture.Click += lblPicture_Click;
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPicture);
            Controls.Add(pictureBoxHelp);
            Name = "AboutBox";
            Text = "AboutBox";
            ((System.ComponentModel.ISupportInitialize)pictureBoxHelp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxHelp;
        private Label lblPicture;
    }
}
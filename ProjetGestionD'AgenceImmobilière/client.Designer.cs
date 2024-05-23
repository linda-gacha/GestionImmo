namespace ProjetGestionD_AgenceImmobilière
{
    partial class client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client));
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button7 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(251, 459);
            panel1.TabIndex = 30;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(39, 238);
            button2.Name = "button2";
            button2.Size = new Size(163, 23);
            button2.TabIndex = 34;
            button2.Text = "Imprimer La Facture";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(39, 177);
            button1.Name = "button1";
            button1.Size = new Size(166, 24);
            button1.TabIndex = 28;
            button1.Text = "Consulter les Annonces";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ButtonHighlight;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(19, 23);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 27;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(39, 288);
            button3.Name = "button3";
            button3.Size = new Size(166, 23);
            button3.TabIndex = 6;
            button3.Text = "Notifactions";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 82);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(13, 99);
            label1.Name = "label1";
            label1.Size = new Size(189, 17);
            label1.TabIndex = 2;
            label1.Text = "Gestion D'Agence Immobilière";
            // 
            // button7
            // 
            button7.Location = new Point(779, -4);
            button7.Name = "button7";
            button7.Size = new Size(22, 23);
            button7.TabIndex = 92;
            button7.Text = "X";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "client";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox3;
        private Button button3;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button7;
    }
}
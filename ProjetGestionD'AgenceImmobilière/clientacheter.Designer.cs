namespace ProjetGestionD_AgenceImmobilière
{
    partial class clientacheter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientacheter));
            panel1 = new Panel();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dataGridView = new DataGridView();
            comboBox = new ComboBox();
            label2 = new Label();
            button7 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(251, 459);
            panel1.TabIndex = 34;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(42, 166);
            button1.Name = "button1";
            button1.Size = new Size(163, 26);
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
            pictureBox3.Click += pictureBox3_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(42, 210);
            button3.Name = "button3";
            button3.Size = new Size(163, 23);
            button3.TabIndex = 6;
            button3.Text = "Notifactions";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(257, 95);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(541, 275);
            dataGridView.TabIndex = 36;
            dataGridView.CellContentClick += dataGridView_CellContentClick_1;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Vendre", "Louer" });
            comboBox.Location = new Point(635, 52);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(153, 23);
            comboBox.TabIndex = 37;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(540, 52);
            label2.Name = "label2";
            label2.Size = new Size(89, 23);
            label2.TabIndex = 38;
            label2.Text = "Recherche :";
            // 
            // button7
            // 
            button7.Location = new Point(776, -4);
            button7.Name = "button7";
            button7.Size = new Size(22, 23);
            button7.TabIndex = 92;
            button7.Text = "X";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // clientacheter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(label2);
            Controls.Add(comboBox);
            Controls.Add(dataGridView);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "clientacheter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "clientacheter";
            Load += clientacheter_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox3;
        private Button button3;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private DataGridView dataGridView;
        private ComboBox comboBox;
        private Label label2;
        private Button button7;
    }
}
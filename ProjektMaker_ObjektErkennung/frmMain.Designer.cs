namespace ProjektMaker_ObjektErkennung
{
    partial class frmMain
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
            btnObjekterkennung = new Button();
            pictureBox1 = new PictureBox();
            btnBildLaden = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnObjekterkennung
            // 
            btnObjekterkennung.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnObjekterkennung.Location = new Point(674, 50);
            btnObjekterkennung.Name = "btnObjekterkennung";
            btnObjekterkennung.Size = new Size(114, 32);
            btnObjekterkennung.TabIndex = 0;
            btnObjekterkennung.Text = "Objekterkennung";
            btnObjekterkennung.UseVisualStyleBackColor = true;
            btnObjekterkennung.Click += btnObjekterkennung_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(650, 433);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnBildLaden
            // 
            btnBildLaden.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBildLaden.Location = new Point(674, 12);
            btnBildLaden.Name = "btnBildLaden";
            btnBildLaden.Size = new Size(114, 32);
            btnBildLaden.TabIndex = 2;
            btnBildLaden.Text = "Bild auswählen";
            btnBildLaden.UseVisualStyleBackColor = true;
            btnBildLaden.Click += btnBildLaden_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 458);
            Controls.Add(btnBildLaden);
            Controls.Add(pictureBox1);
            Controls.Add(btnObjekterkennung);
            Name = "frmMain";
            Text = "Projektmaker - Objekterkennung mit .Net";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnObjekterkennung;
        private PictureBox pictureBox1;
        private Button btnBildLaden;
    }
}
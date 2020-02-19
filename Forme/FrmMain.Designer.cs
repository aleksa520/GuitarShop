namespace Forme
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.slidePanel = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnGuitars = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnAddGuitar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.guitarStickerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewGuitars = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.addGuitarControl = new Forme.AddGuitarControl();
            this.viewGuitarsControl = new Forme.ViewGuitarsControl();
            this.billControl = new Forme.BillControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guitarStickerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.slidePanel);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.btnGuitars);
            this.panel1.Controls.Add(this.btnBill);
            this.panel1.Controls.Add(this.btnAddGuitar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 515);
            this.panel1.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(9, 131);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(164, 54);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // slidePanel
            // 
            this.slidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.slidePanel.Location = new System.Drawing.Point(0, 131);
            this.slidePanel.Name = "slidePanel";
            this.slidePanel.Size = new System.Drawing.Size(10, 54);
            this.slidePanel.TabIndex = 6;
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogOut.Image = global::Forme.Properties.Resources.icons8_logout_rounded_down_25;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(9, 343);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(164, 54);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnGuitars
            // 
            this.btnGuitars.FlatAppearance.BorderSize = 0;
            this.btnGuitars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuitars.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuitars.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuitars.Image = ((System.Drawing.Image)(resources.GetObject("btnGuitars.Image")));
            this.btnGuitars.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuitars.Location = new System.Drawing.Point(9, 202);
            this.btnGuitars.Name = "btnGuitars";
            this.btnGuitars.Size = new System.Drawing.Size(164, 54);
            this.btnGuitars.TabIndex = 4;
            this.btnGuitars.Text = "Guitars";
            this.btnGuitars.UseVisualStyleBackColor = true;
            this.btnGuitars.Click += new System.EventHandler(this.btnGuitars_Click);
            // 
            // btnBill
            // 
            this.btnBill.FlatAppearance.BorderSize = 0;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBill.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBill.Image = ((System.Drawing.Image)(resources.GetObject("btnBill.Image")));
            this.btnBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Location = new System.Drawing.Point(9, 271);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(164, 54);
            this.btnBill.TabIndex = 5;
            this.btnBill.Text = "Bill";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnAddGuitar
            // 
            this.btnAddGuitar.FlatAppearance.BorderSize = 0;
            this.btnAddGuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGuitar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGuitar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddGuitar.Image = global::Forme.Properties.Resources.icons8_add_25__1_;
            this.btnAddGuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddGuitar.Location = new System.Drawing.Point(9, 271);
            this.btnAddGuitar.Name = "btnAddGuitar";
            this.btnAddGuitar.Size = new System.Drawing.Size(164, 54);
            this.btnAddGuitar.TabIndex = 8;
            this.btnAddGuitar.Text = "Add Guitar";
            this.btnAddGuitar.UseVisualStyleBackColor = true;
            this.btnAddGuitar.Click += new System.EventHandler(this.btnAddGuitar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(173, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 35);
            this.panel2.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.Control;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(668, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 35);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.Control;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(713, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 35);
            this.button5.TabIndex = 6;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // guitarStickerPanel
            // 
            this.guitarStickerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.guitarStickerPanel.Controls.Add(this.pictureBox1);
            this.guitarStickerPanel.Controls.Add(this.label2);
            this.guitarStickerPanel.Location = new System.Drawing.Point(233, 12);
            this.guitarStickerPanel.Name = "guitarStickerPanel";
            this.guitarStickerPanel.Size = new System.Drawing.Size(104, 128);
            this.guitarStickerPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Guitar shop";
            // 
            // btnViewGuitars
            // 
            this.btnViewGuitars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.btnViewGuitars.FlatAppearance.BorderSize = 0;
            this.btnViewGuitars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGuitars.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewGuitars.ForeColor = System.Drawing.SystemColors.Control;
            this.btnViewGuitars.Location = new System.Drawing.Point(469, 348);
            this.btnViewGuitars.Name = "btnViewGuitars";
            this.btnViewGuitars.Size = new System.Drawing.Size(203, 54);
            this.btnViewGuitars.TabIndex = 4;
            this.btnViewGuitars.Text = "View Guitars";
            this.btnViewGuitars.UseVisualStyleBackColor = false;
            this.btnViewGuitars.Click += new System.EventHandler(this.btnViewGuitars_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(63, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblName.Location = new System.Drawing.Point(63, 380);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 22);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::Forme.Properties.Resources.Guitars_filter_1024x1024;
            this.mainPanel.Controls.Add(this.btnViewGuitars);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.lblName);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(173, 35);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(752, 480);
            this.mainPanel.TabIndex = 9;
            // 
            // addGuitarControl
            // 
            this.addGuitarControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.addGuitarControl.Location = new System.Drawing.Point(234, 161);
            this.addGuitarControl.Name = "addGuitarControl";
            this.addGuitarControl.Size = new System.Drawing.Size(632, 329);
            this.addGuitarControl.TabIndex = 13;
            // 
            // viewGuitarsControl
            // 
            this.viewGuitarsControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.viewGuitarsControl.ForeColor = System.Drawing.SystemColors.Control;
            this.viewGuitarsControl.Location = new System.Drawing.Point(234, 161);
            this.viewGuitarsControl.Name = "viewGuitarsControl";
            this.viewGuitarsControl.Size = new System.Drawing.Size(632, 329);
            this.viewGuitarsControl.TabIndex = 14;
            // 
            // billControl
            // 
            this.billControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.billControl.Location = new System.Drawing.Point(234, 161);
            this.billControl.Name = "billControl";
            this.billControl.Size = new System.Drawing.Size(632, 329);
            this.billControl.TabIndex = 15;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 515);
            this.Controls.Add(this.guitarStickerPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.billControl);
            this.Controls.Add(this.viewGuitarsControl);
            this.Controls.Add(this.addGuitarControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guitar Shop";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.guitarStickerPanel.ResumeLayout(false);
            this.guitarStickerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel guitarStickerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuitars;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnViewGuitars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel slidePanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAddGuitar;
        private System.Windows.Forms.Panel mainPanel;
        private AddGuitarControl addGuitarControl;
        private ViewGuitarsControl viewGuitarsControl;
        private BillControl billControl;
    }
}


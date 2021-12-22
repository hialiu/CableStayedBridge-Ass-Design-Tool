namespace cable_stayed01
{
    partial class main01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main01));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_bridge = new System.Windows.Forms.Label();
            this.label_model = new System.Windows.Forms.Label();
            this.label_manage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label_bridge
            // 
            this.label_bridge.BackColor = System.Drawing.Color.Transparent;
            this.label_bridge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_bridge.Location = new System.Drawing.Point(125, 178);
            this.label_bridge.Name = "label_bridge";
            this.label_bridge.Size = new System.Drawing.Size(147, 226);
            this.label_bridge.TabIndex = 1;
            this.label_bridge.Click += new System.EventHandler(this.label_bridge_Click);
            // 
            // label_model
            // 
            this.label_model.BackColor = System.Drawing.Color.Transparent;
            this.label_model.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_model.Location = new System.Drawing.Point(333, 178);
            this.label_model.Name = "label_model";
            this.label_model.Size = new System.Drawing.Size(147, 226);
            this.label_model.TabIndex = 2;
            this.label_model.Click += new System.EventHandler(this.label_model_Click);
            // 
            // label_manage
            // 
            this.label_manage.BackColor = System.Drawing.Color.Transparent;
            this.label_manage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_manage.Location = new System.Drawing.Point(536, 178);
            this.label_manage.Name = "label_manage";
            this.label_manage.Size = new System.Drawing.Size(147, 226);
            this.label_manage.TabIndex = 3;
            this.label_manage.Click += new System.EventHandler(this.label_manage_Click);
            // 
            // main01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(796, 552);
            this.Controls.Add(this.label_manage);
            this.Controls.Add(this.label_model);
            this.Controls.Add(this.label_bridge);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "main01";
            this.Text = "main01";
            this.Load += new System.EventHandler(this.main01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_bridge;
        private System.Windows.Forms.Label label_model;
        private System.Windows.Forms.Label label_manage;


    }
}
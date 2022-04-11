namespace MedemySchool
{
    partial class Loader
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
            this.components = new System.ComponentModel.Container();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pic_loader = new System.Windows.Forms.PictureBox();
            this.shape_right = new Bunifu.UI.WinForms.BunifuShapes();
            this.shape_bottom = new Bunifu.UI.WinForms.BunifuShapes();
            this.bunifuShapes3 = new Bunifu.UI.WinForms.BunifuShapes();
            this.shape_left = new Bunifu.UI.WinForms.BunifuShapes();
            this.loader_ld = new Bunifu.UI.WinForms.BunifuLoader();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_loader)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(205, 103);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(372, 27);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Welcome From Medemy School";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic_loader
            // 
            this.pic_loader.Image = global::MedemySchool.Properties.Resources.loader_image;
            this.pic_loader.Location = new System.Drawing.Point(328, 174);
            this.pic_loader.Name = "pic_loader";
            this.pic_loader.Size = new System.Drawing.Size(118, 119);
            this.pic_loader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_loader.TabIndex = 1;
            this.pic_loader.TabStop = false;
            // 
            // shape_right
            // 
            this.shape_right.Angle = 0F;
            this.shape_right.BackColor = System.Drawing.Color.Transparent;
            this.shape_right.BorderColor = System.Drawing.Color.White;
            this.shape_right.BorderThickness = 2;
            this.shape_right.FillColor = System.Drawing.Color.White;
            this.shape_right.FillShape = true;
            this.shape_right.Location = new System.Drawing.Point(646, -63);
            this.shape_right.Name = "shape_right";
            this.shape_right.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Circle;
            this.shape_right.Sides = 5;
            this.shape_right.Size = new System.Drawing.Size(295, 295);
            this.shape_right.TabIndex = 2;
            this.shape_right.Text = "bunifuShapes1";
            // 
            // shape_bottom
            // 
            this.shape_bottom.Angle = 0F;
            this.shape_bottom.BackColor = System.Drawing.Color.Transparent;
            this.shape_bottom.BorderColor = System.Drawing.Color.White;
            this.shape_bottom.BorderThickness = 2;
            this.shape_bottom.FillColor = System.Drawing.Color.White;
            this.shape_bottom.FillShape = true;
            this.shape_bottom.Location = new System.Drawing.Point(-64, 298);
            this.shape_bottom.Name = "shape_bottom";
            this.shape_bottom.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Circle;
            this.shape_bottom.Sides = 5;
            this.shape_bottom.Size = new System.Drawing.Size(264, 264);
            this.shape_bottom.TabIndex = 2;
            this.shape_bottom.Text = "bunifuShapes1";
            // 
            // bunifuShapes3
            // 
            this.bunifuShapes3.Angle = 0F;
            this.bunifuShapes3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShapes3.BorderColor = System.Drawing.Color.White;
            this.bunifuShapes3.BorderThickness = 2;
            this.bunifuShapes3.FillColor = System.Drawing.Color.White;
            this.bunifuShapes3.FillShape = true;
            this.bunifuShapes3.Location = new System.Drawing.Point(210, 133);
            this.bunifuShapes3.Name = "bunifuShapes3";
            this.bunifuShapes3.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Line;
            this.bunifuShapes3.Sides = 5;
            this.bunifuShapes3.Size = new System.Drawing.Size(367, 16);
            this.bunifuShapes3.TabIndex = 2;
            this.bunifuShapes3.Text = "bunifuShapes1";
            // 
            // shape_left
            // 
            this.shape_left.Angle = 0F;
            this.shape_left.BackColor = System.Drawing.Color.Transparent;
            this.shape_left.BorderColor = System.Drawing.Color.White;
            this.shape_left.BorderThickness = 2;
            this.shape_left.FillColor = System.Drawing.Color.White;
            this.shape_left.FillShape = true;
            this.shape_left.Location = new System.Drawing.Point(-64, -119);
            this.shape_left.Name = "shape_left";
            this.shape_left.Shape = Bunifu.UI.WinForms.BunifuShapes.Shapes.Circle;
            this.shape_left.Sides = 5;
            this.shape_left.Size = new System.Drawing.Size(249, 249);
            this.shape_left.TabIndex = 2;
            this.shape_left.Text = "bunifuShapes1";
            // 
            // loader_ld
            // 
            this.loader_ld.AllowStylePresets = true;
            this.loader_ld.BackColor = System.Drawing.Color.Transparent;
            this.loader_ld.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Round;
            this.loader_ld.Color = System.Drawing.Color.LightCyan;
            this.loader_ld.Colors = new Bunifu.UI.WinForms.Bloom[0];
            this.loader_ld.Customization = "";
            this.loader_ld.DashWidth = 0.5F;
            this.loader_ld.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loader_ld.Image = null;
            this.loader_ld.Location = new System.Drawing.Point(364, 326);
            this.loader_ld.Name = "loader_ld";
            this.loader_ld.NoRounding = false;
            this.loader_ld.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Solid;
            this.loader_ld.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Solid;
            this.loader_ld.ShowText = false;
            this.loader_ld.Size = new System.Drawing.Size(62, 66);
            this.loader_ld.Speed = 7;
            this.loader_ld.TabIndex = 3;
            this.loader_ld.Text = "Loding ...";
            this.loader_ld.TextPadding = new System.Windows.Forms.Padding(0);
            this.loader_ld.Thickness = 6;
            this.loader_ld.Transparent = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(800, 433);
            this.Controls.Add(this.loader_ld);
            this.Controls.Add(this.bunifuShapes3);
            this.Controls.Add(this.shape_bottom);
            this.Controls.Add(this.shape_left);
            this.Controls.Add(this.shape_right);
            this.Controls.Add(this.pic_loader);
            this.Controls.Add(this.lbl_title);
            this.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Loader";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loader";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pic_loader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.PictureBox pic_loader;
        private Bunifu.UI.WinForms.BunifuShapes shape_right;
        private Bunifu.UI.WinForms.BunifuShapes shape_bottom;
        private Bunifu.UI.WinForms.BunifuShapes bunifuShapes3;
        private Bunifu.UI.WinForms.BunifuShapes shape_left;
        private Bunifu.UI.WinForms.BunifuLoader loader_ld;
        private System.Windows.Forms.Timer timer;
    }
}
namespace GUI
{
    partial class SoDoPhongControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Panel_tool = new Guna.UI2.WinForms.Guna2GradientPanel();
            btn_capnhat = new Guna.UI2.WinForms.Guna2Button();
            panel_btn = new Panel();
            btn_dadat = new Guna.UI2.WinForms.Guna2Button();
            btn_phgtrong = new Guna.UI2.WinForms.Guna2Button();
            btn_cokhach = new Guna.UI2.WinForms.Guna2Button();
            lbl_dango = new Label();
            lbl_dattruoc = new Label();
            lbl_phongtrong = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            Panel_showdata = new Guna.UI2.WinForms.Guna2GradientPanel();
            panel_data_container = new FlowLayoutPanel();
            Panel_tool.SuspendLayout();
            panel_btn.SuspendLayout();
            Panel_showdata.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_tool
            // 
            Panel_tool.BackColor = SystemColors.ButtonFace;
            Panel_tool.BorderRadius = 20;
            Panel_tool.BorderThickness = 10;
            Panel_tool.Controls.Add(btn_capnhat);
            Panel_tool.Controls.Add(panel_btn);
            Panel_tool.Controls.Add(lbl_dango);
            Panel_tool.Controls.Add(lbl_dattruoc);
            Panel_tool.Controls.Add(lbl_phongtrong);
            Panel_tool.Controls.Add(guna2Panel1);
            Panel_tool.CustomizableEdges = customizableEdges11;
            Panel_tool.FillColor = Color.FromArgb(253, 169, 169);
            Panel_tool.FillColor2 = Color.FromArgb(253, 169, 169);
            Panel_tool.Location = new Point(11, 33);
            Panel_tool.Name = "Panel_tool";
            Panel_tool.ShadowDecoration.CustomizableEdges = customizableEdges12;
            Panel_tool.Size = new Size(1160, 114);
            Panel_tool.TabIndex = 1;
            // 
            // btn_capnhat
            // 
            btn_capnhat.BorderColor = Color.DarkBlue;
            btn_capnhat.CustomizableEdges = customizableEdges1;
            btn_capnhat.DisabledState.BorderColor = Color.DarkGray;
            btn_capnhat.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_capnhat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_capnhat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_capnhat.FillColor = Color.FromArgb(253, 169, 169);
            btn_capnhat.Font = new Font("Modern No. 20", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_capnhat.ForeColor = Color.Black;
            btn_capnhat.Image = Properties.Resources.updating;
            btn_capnhat.ImageOffset = new Point(0, -16);
            btn_capnhat.ImageSize = new Size(50, 50);
            btn_capnhat.Location = new Point(554, 16);
            btn_capnhat.Name = "btn_capnhat";
            btn_capnhat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_capnhat.Size = new Size(129, 95);
            btn_capnhat.TabIndex = 21;
            btn_capnhat.Text = "Cập nhật";
            btn_capnhat.TextAlign = HorizontalAlignment.Left;
            btn_capnhat.TextOffset = new Point(17, 30);
            btn_capnhat.Click += btn_capnhat_Click;
            // 
            // panel_btn
            // 
            panel_btn.BackColor = Color.Transparent;
            panel_btn.Controls.Add(btn_dadat);
            panel_btn.Controls.Add(btn_phgtrong);
            panel_btn.Controls.Add(btn_cokhach);
            panel_btn.Dock = DockStyle.Left;
            panel_btn.Location = new Point(0, 0);
            panel_btn.Name = "panel_btn";
            panel_btn.Size = new Size(527, 114);
            panel_btn.TabIndex = 0;
            // 
            // btn_dadat
            // 
            btn_dadat.BorderColor = Color.DarkBlue;
            btn_dadat.CustomizableEdges = customizableEdges3;
            btn_dadat.DisabledState.BorderColor = Color.DarkGray;
            btn_dadat.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_dadat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_dadat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_dadat.FillColor = Color.FromArgb(253, 169, 169);
            btn_dadat.Font = new Font("Modern No. 20", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_dadat.ForeColor = Color.Black;
            btn_dadat.Image = Properties.Resources.calendar__1_;
            btn_dadat.ImageOffset = new Point(0, -16);
            btn_dadat.ImageSize = new Size(50, 50);
            btn_dadat.Location = new Point(397, 16);
            btn_dadat.Name = "btn_dadat";
            btn_dadat.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_dadat.Size = new Size(129, 95);
            btn_dadat.TabIndex = 20;
            btn_dadat.Text = "Được đặt";
            btn_dadat.TextAlign = HorizontalAlignment.Left;
            btn_dadat.TextOffset = new Point(17, 30);
            btn_dadat.Click += btn_Click;
            // 
            // btn_phgtrong
            // 
            btn_phgtrong.BorderColor = Color.DarkBlue;
            btn_phgtrong.CustomizableEdges = customizableEdges5;
            btn_phgtrong.DisabledState.BorderColor = Color.DarkGray;
            btn_phgtrong.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_phgtrong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_phgtrong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_phgtrong.FillColor = Color.FromArgb(253, 169, 169);
            btn_phgtrong.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            btn_phgtrong.ForeColor = Color.Black;
            btn_phgtrong.Image = Properties.Resources.bed;
            btn_phgtrong.ImageOffset = new Point(0, -15);
            btn_phgtrong.ImageSize = new Size(50, 50);
            btn_phgtrong.Location = new Point(86, 16);
            btn_phgtrong.Name = "btn_phgtrong";
            btn_phgtrong.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_phgtrong.Size = new Size(129, 95);
            btn_phgtrong.TabIndex = 7;
            btn_phgtrong.Text = "Phòng trống";
            btn_phgtrong.TextAlign = HorizontalAlignment.Left;
            btn_phgtrong.TextOffset = new Point(0, 30);
            btn_phgtrong.Click += btn_Click;
            // 
            // btn_cokhach
            // 
            btn_cokhach.BorderColor = Color.DarkBlue;
            btn_cokhach.CustomizableEdges = customizableEdges7;
            btn_cokhach.DisabledState.BorderColor = Color.DarkGray;
            btn_cokhach.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_cokhach.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_cokhach.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_cokhach.FillColor = Color.FromArgb(253, 169, 169);
            btn_cokhach.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            btn_cokhach.ForeColor = Color.Black;
            btn_cokhach.Image = Properties.Resources.sleeping;
            btn_cokhach.ImageOffset = new Point(0, -15);
            btn_cokhach.ImageSize = new Size(50, 50);
            btn_cokhach.Location = new Point(236, 16);
            btn_cokhach.Name = "btn_cokhach";
            btn_cokhach.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_cokhach.Size = new Size(129, 95);
            btn_cokhach.TabIndex = 19;
            btn_cokhach.Text = "Có khách";
            btn_cokhach.TextAlign = HorizontalAlignment.Left;
            btn_cokhach.TextOffset = new Point(18, 30);
            btn_cokhach.Click += btn_Click;
            // 
            // lbl_dango
            // 
            lbl_dango.AutoSize = true;
            lbl_dango.BackColor = Color.FromArgb(248, 96, 27);
            lbl_dango.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_dango.ForeColor = Color.White;
            lbl_dango.Location = new Point(890, 66);
            lbl_dango.Name = "lbl_dango";
            lbl_dango.Padding = new Padding(5);
            lbl_dango.Size = new Size(81, 35);
            lbl_dango.TabIndex = 18;
            lbl_dango.Text = "Đang ở";
            // 
            // lbl_dattruoc
            // 
            lbl_dattruoc.AutoSize = true;
            lbl_dattruoc.BackColor = Color.FromArgb(255, 151, 113);
            lbl_dattruoc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_dattruoc.ForeColor = Color.White;
            lbl_dattruoc.Location = new Point(757, 66);
            lbl_dattruoc.Name = "lbl_dattruoc";
            lbl_dattruoc.Padding = new Padding(5);
            lbl_dattruoc.Size = new Size(97, 35);
            lbl_dattruoc.TabIndex = 17;
            lbl_dattruoc.Text = "Đặt trước";
            // 
            // lbl_phongtrong
            // 
            lbl_phongtrong.AutoSize = true;
            lbl_phongtrong.BackColor = Color.FromArgb(91, 164, 88);
            lbl_phongtrong.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_phongtrong.ForeColor = Color.White;
            lbl_phongtrong.Location = new Point(757, 20);
            lbl_phongtrong.Name = "lbl_phongtrong";
            lbl_phongtrong.Padding = new Padding(5);
            lbl_phongtrong.Size = new Size(123, 35);
            lbl_phongtrong.TabIndex = 16;
            lbl_phongtrong.Text = "Phòng trống";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(1, 18, 43);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Location = new Point(717, 1);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(1, 114);
            guna2Panel1.TabIndex = 15;
            // 
            // Panel_showdata
            // 
            Panel_showdata.BorderRadius = 40;
            Panel_showdata.Controls.Add(panel_data_container);
            Panel_showdata.CustomizableEdges = customizableEdges13;
            Panel_showdata.FillColor = Color.FromArgb(253, 169, 169);
            Panel_showdata.FillColor2 = Color.FromArgb(253, 169, 169);
            Panel_showdata.Location = new Point(10, 171);
            Panel_showdata.Name = "Panel_showdata";
            Panel_showdata.ShadowDecoration.CustomizableEdges = customizableEdges14;
            Panel_showdata.Size = new Size(1160, 664);
            Panel_showdata.TabIndex = 2;
            // 
            // panel_data_container
            // 
            panel_data_container.AutoScroll = true;
            panel_data_container.BackColor = Color.Transparent;
            panel_data_container.Location = new Point(45, 38);
            panel_data_container.Name = "panel_data_container";
            panel_data_container.Size = new Size(1072, 595);
            panel_data_container.TabIndex = 0;
            // 
            // SoDoPhongControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Panel_showdata);
            Controls.Add(Panel_tool);
            Name = "SoDoPhongControl";
            Size = new Size(1180, 854);
            Panel_tool.ResumeLayout(false);
            Panel_tool.PerformLayout();
            panel_btn.ResumeLayout(false);
            Panel_showdata.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel Panel_tool;
        private Label lbl_dango;
        private Label lbl_dattruoc;
        private Label lbl_phongtrong;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btn_phgtrong;
        private Guna.UI2.WinForms.Guna2GradientPanel Panel_showdata;
        private FlowLayoutPanel panel_data_container;
        private Guna.UI2.WinForms.Guna2Button btn_dadat;
        private Guna.UI2.WinForms.Guna2Button btn_cokhach;
        private Panel panel_btn;
        private Guna.UI2.WinForms.Guna2Button btn_capnhat;
    }
}

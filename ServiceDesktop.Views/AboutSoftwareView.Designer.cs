namespace ServiceDesktop.Views.AboutSoftware
{
    partial class AboutSoftwareView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutSoftwareView));
            this.SoftwareName = new System.Windows.Forms.RichTextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelPagesOfProject = new System.Windows.Forms.Label();
            this.LinkToProjectPage = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.License = new System.Windows.Forms.ToolStripButton();
            this.OtherLicenses = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SoftwareName
            // 
            this.SoftwareName.BackColor = System.Drawing.Color.White;
            this.SoftwareName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SoftwareName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoftwareName.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SoftwareName.Location = new System.Drawing.Point(0, 0);
            this.SoftwareName.Name = "SoftwareName";
            this.SoftwareName.ReadOnly = true;
            this.SoftwareName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SoftwareName.ShowSelectionMargin = true;
            this.SoftwareName.Size = new System.Drawing.Size(289, 67);
            this.SoftwareName.TabIndex = 0;
            this.SoftwareName.Text = "Удалённое управление \nгенератором сигналов и источником питания";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthor.Location = new System.Drawing.Point(202, 93);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(107, 19);
            this.labelAuthor.TabIndex = 49;
            this.labelAuthor.Text = "Shamrik.Dmitriy";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SoftwareName);
            this.panel2.Location = new System.Drawing.Point(156, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 67);
            this.panel2.TabIndex = 48;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ServiceDesktop.Views.Properties.Resources.monitor__;
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // LabelPagesOfProject
            // 
            this.LabelPagesOfProject.AutoSize = true;
            this.LabelPagesOfProject.Location = new System.Drawing.Point(19, 136);
            this.LabelPagesOfProject.Name = "LabelPagesOfProject";
            this.LabelPagesOfProject.Size = new System.Drawing.Size(99, 13);
            this.LabelPagesOfProject.TabIndex = 1;
            this.LabelPagesOfProject.Text = "Страница проекта";
            // 
            // LinkToProjectPage
            // 
            this.LinkToProjectPage.AutoSize = true;
            this.LinkToProjectPage.Location = new System.Drawing.Point(19, 150);
            this.LinkToProjectPage.Name = "LinkToProjectPage";
            this.LinkToProjectPage.Size = new System.Drawing.Size(258, 26);
            this.LinkToProjectPage.TabIndex = 2;
            this.LinkToProjectPage.TabStop = true;
            this.LinkToProjectPage.Text = "https://github.com/shamrik-dmitriy/\r\nremote-desktop-signal-generator-and-power-su" +
    "pply.git";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::ServiceDesktop.Views.Properties.Resources.GitHub_Mark_32px;
            this.pictureBox2.Location = new System.Drawing.Point(156, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 52;
            this.pictureBox2.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.License,
            this.OtherLicenses});
            this.toolStrip1.Location = new System.Drawing.Point(0, 190);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(360, 25);
            this.toolStrip1.TabIndex = 55;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // License
            // 
            this.License.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.License.Image = ((System.Drawing.Image)(resources.GetObject("License.Image")));
            this.License.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.License.Name = "License";
            this.License.Size = new System.Drawing.Size(225, 22);
            this.License.Text = "Лицензия программного обеспечения";
            // 
            // OtherLicenses
            // 
            this.OtherLicenses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OtherLicenses.Image = ((System.Drawing.Image)(resources.GetObject("OtherLicenses.Image")));
            this.OtherLicenses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OtherLicenses.Name = "OtherLicenses";
            this.OtherLicenses.Size = new System.Drawing.Size(65, 22);
            this.OtherLicenses.Text = "Лицензии";
            // 
            // AboutSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 215);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LinkToProjectPage);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.LabelPagesOfProject);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutSoftware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О Программе";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SoftwareName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelPagesOfProject;
        private System.Windows.Forms.LinkLabel LinkToProjectPage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton License;
        private System.Windows.Forms.ToolStripButton OtherLicenses;
    }
}
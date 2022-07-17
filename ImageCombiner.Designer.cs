namespace ImageCombiner
{
    partial class ImageCombiner
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCombiner));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.leftPanel = new System.Windows.Forms.Panel();
			this.clearLeftBtn = new System.Windows.Forms.Button();
			this.leftImg = new System.Windows.Forms.PictureBox();
			this.img1Lbl = new System.Windows.Forms.Label();
			this.rightPanel = new System.Windows.Forms.Panel();
			this.clearRightBtn = new System.Windows.Forms.Button();
			this.rightImg = new System.Windows.Forms.PictureBox();
			this.img2Lbl = new System.Windows.Forms.Label();
			this.horizontalRadio = new System.Windows.Forms.RadioButton();
			this.verticalRadio = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.resetBtn = new System.Windows.Forms.Button();
			this.combineBtn = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnSwapImages = new System.Windows.Forms.Button();
			this.aboutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAbout = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.leftImg)).BeginInit();
			this.rightPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rightImg)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.aboutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.leftPanel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.rightPanel, 1, 0);
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 85);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.11369F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.8863F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1105, 564);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// leftPanel
			// 
			this.leftPanel.AllowDrop = true;
			this.leftPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.leftPanel.Controls.Add(this.clearLeftBtn);
			this.leftPanel.Controls.Add(this.leftImg);
			this.leftPanel.Controls.Add(this.img1Lbl);
			this.leftPanel.Location = new System.Drawing.Point(5, 6);
			this.leftPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.Size = new System.Drawing.Size(542, 552);
			this.leftPanel.TabIndex = 0;
			// 
			// clearLeftBtn
			// 
			this.clearLeftBtn.Location = new System.Drawing.Point(414, 492);
			this.clearLeftBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.clearLeftBtn.Name = "clearLeftBtn";
			this.clearLeftBtn.Size = new System.Drawing.Size(107, 38);
			this.clearLeftBtn.TabIndex = 3;
			this.clearLeftBtn.Tag = "clearLeftBtn";
			this.clearLeftBtn.Text = "Clear";
			this.clearLeftBtn.UseVisualStyleBackColor = true;
			this.clearLeftBtn.Visible = false;
			this.clearLeftBtn.Click += new System.EventHandler(this.ClearImage);
			// 
			// leftImg
			// 
			this.leftImg.AllowDrop = true;
			this.leftImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.leftImg.BackColor = System.Drawing.SystemColors.ControlDark;
			this.leftImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.leftImg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.leftImg.Image = global::ImageCombiner.Properties.Resources.DefaultImg;
			this.leftImg.InitialImage = global::ImageCombiner.Properties.Resources.LoadingImg;
			this.leftImg.Location = new System.Drawing.Point(19, 68);
			this.leftImg.Margin = new System.Windows.Forms.Padding(0);
			this.leftImg.Name = "leftImg";
			this.leftImg.Size = new System.Drawing.Size(501, 411);
			this.leftImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.leftImg.TabIndex = 2;
			this.leftImg.TabStop = false;
			this.leftImg.Tag = "leftImg";
			this.leftImg.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropLoad);
			this.leftImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterEffects);
			this.leftImg.DoubleClick += new System.EventHandler(this.SelectImageWithFileDialog);
			// 
			// img1Lbl
			// 
			this.img1Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.img1Lbl.AutoSize = true;
			this.img1Lbl.Location = new System.Drawing.Point(214, 22);
			this.img1Lbl.Margin = new System.Windows.Forms.Padding(0);
			this.img1Lbl.Name = "img1Lbl";
			this.img1Lbl.Size = new System.Drawing.Size(96, 25);
			this.img1Lbl.TabIndex = 1;
			this.img1Lbl.Text = "Left Image";
			// 
			// rightPanel
			// 
			this.rightPanel.AllowDrop = true;
			this.rightPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rightPanel.Controls.Add(this.clearRightBtn);
			this.rightPanel.Controls.Add(this.rightImg);
			this.rightPanel.Controls.Add(this.img2Lbl);
			this.rightPanel.Location = new System.Drawing.Point(557, 6);
			this.rightPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rightPanel.Name = "rightPanel";
			this.rightPanel.Size = new System.Drawing.Size(543, 552);
			this.rightPanel.TabIndex = 1;
			// 
			// clearRightBtn
			// 
			this.clearRightBtn.Location = new System.Drawing.Point(416, 493);
			this.clearRightBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.clearRightBtn.Name = "clearRightBtn";
			this.clearRightBtn.Size = new System.Drawing.Size(107, 38);
			this.clearRightBtn.TabIndex = 4;
			this.clearRightBtn.Tag = "clearRightBtn";
			this.clearRightBtn.Text = "Clear";
			this.clearRightBtn.UseVisualStyleBackColor = true;
			this.clearRightBtn.Visible = false;
			this.clearRightBtn.Click += new System.EventHandler(this.ClearImage);
			// 
			// rightImg
			// 
			this.rightImg.AllowDrop = true;
			this.rightImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rightImg.BackColor = System.Drawing.SystemColors.ControlDark;
			this.rightImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.rightImg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rightImg.Image = global::ImageCombiner.Properties.Resources.DefaultImg;
			this.rightImg.InitialImage = global::ImageCombiner.Properties.Resources.LoadingImg;
			this.rightImg.Location = new System.Drawing.Point(20, 68);
			this.rightImg.Margin = new System.Windows.Forms.Padding(0);
			this.rightImg.Name = "rightImg";
			this.rightImg.Size = new System.Drawing.Size(501, 411);
			this.rightImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.rightImg.TabIndex = 3;
			this.rightImg.TabStop = false;
			this.rightImg.Tag = "rightImg";
			this.rightImg.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropLoad);
			this.rightImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterEffects);
			this.rightImg.DoubleClick += new System.EventHandler(this.SelectImageWithFileDialog);
			// 
			// img2Lbl
			// 
			this.img2Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.img2Lbl.AutoSize = true;
			this.img2Lbl.Location = new System.Drawing.Point(223, 22);
			this.img2Lbl.Margin = new System.Windows.Forms.Padding(0);
			this.img2Lbl.Name = "img2Lbl";
			this.img2Lbl.Size = new System.Drawing.Size(109, 25);
			this.img2Lbl.TabIndex = 0;
			this.img2Lbl.Text = "Right Image";
			this.img2Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// horizontalRadio
			// 
			this.horizontalRadio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.horizontalRadio.AutoSize = true;
			this.horizontalRadio.Checked = true;
			this.horizontalRadio.Location = new System.Drawing.Point(183, 20);
			this.horizontalRadio.Margin = new System.Windows.Forms.Padding(0);
			this.horizontalRadio.Name = "horizontalRadio";
			this.horizontalRadio.Size = new System.Drawing.Size(119, 29);
			this.horizontalRadio.TabIndex = 1;
			this.horizontalRadio.TabStop = true;
			this.horizontalRadio.Text = "Horizontal";
			this.horizontalRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.horizontalRadio.UseVisualStyleBackColor = true;
			this.horizontalRadio.CheckedChanged += new System.EventHandler(this.horizontalRadio_CheckedChanged);
			// 
			// verticalRadio
			// 
			this.verticalRadio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.verticalRadio.AutoSize = true;
			this.verticalRadio.Location = new System.Drawing.Point(302, 20);
			this.verticalRadio.Margin = new System.Windows.Forms.Padding(0);
			this.verticalRadio.Name = "verticalRadio";
			this.verticalRadio.Size = new System.Drawing.Size(93, 29);
			this.verticalRadio.TabIndex = 2;
			this.verticalRadio.Text = "Vertical";
			this.verticalRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.verticalRadio.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Combine Orientation:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// resetBtn
			// 
			this.resetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resetBtn.Location = new System.Drawing.Point(884, 5);
			this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Size = new System.Drawing.Size(107, 63);
			this.resetBtn.TabIndex = 4;
			this.resetBtn.Tag = "resetBtn";
			this.resetBtn.Text = "Reset";
			this.resetBtn.UseVisualStyleBackColor = true;
			this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
			// 
			// combineBtn
			// 
			this.combineBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.combineBtn.Location = new System.Drawing.Point(999, 5);
			this.combineBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.combineBtn.Name = "combineBtn";
			this.combineBtn.Size = new System.Drawing.Size(107, 63);
			this.combineBtn.TabIndex = 5;
			this.combineBtn.Text = "Combine";
			this.combineBtn.UseVisualStyleBackColor = true;
			this.combineBtn.Click += new System.EventHandler(this.combineBtn_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.combineBtn, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.resetBtn, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnSwapImages, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 8);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(1110, 73);
			this.tableLayoutPanel2.TabIndex = 6;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.horizontalRadio);
			this.flowLayoutPanel1.Controls.Add(this.verticalRadio);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1, 20, 0, 17);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(744, 73);
			this.flowLayoutPanel1.TabIndex = 0;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// btnSwapImages
			// 
			this.btnSwapImages.AutoSize = true;
			this.btnSwapImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSwapImages.Enabled = false;
			this.btnSwapImages.Visible = false;
			this.btnSwapImages.Location = new System.Drawing.Point(748, 5);
			this.btnSwapImages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSwapImages.Name = "btnSwapImages";
			this.btnSwapImages.Size = new System.Drawing.Size(128, 63);
			this.btnSwapImages.TabIndex = 6;
			this.btnSwapImages.TabStop = false;
			this.btnSwapImages.Tag = "btnSwapImages";
			this.btnSwapImages.Text = "Swap Images";
			this.btnSwapImages.UseVisualStyleBackColor = true;
			this.btnSwapImages.Click += new System.EventHandler(this.btnSwapImages_Click);
			// 
			// aboutPanel
			// 
			this.aboutPanel.Controls.Add(this.btnAbout);
			this.aboutPanel.Location = new System.Drawing.Point(19, 655);
			this.aboutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.aboutPanel.Name = "aboutPanel";
			this.aboutPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.aboutPanel.Size = new System.Drawing.Size(550, 72);
			this.aboutPanel.TabIndex = 7;
			this.aboutPanel.WrapContents = false;
			// 
			// btnAbout
			// 
			this.btnAbout.AutoSize = true;
			this.btnAbout.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnAbout.Location = new System.Drawing.Point(0, 5);
			this.btnAbout.Margin = new System.Windows.Forms.Padding(0);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(106, 58);
			this.btnAbout.TabIndex = 0;
			this.btnAbout.TabStop = false;
			this.btnAbout.Text = "About";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// ImageCombiner
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1143, 732);
			this.Controls.Add(this.aboutPanel);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "ImageCombiner";
			this.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Image Combiner";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.leftPanel.ResumeLayout(false);
			this.leftPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.leftImg)).EndInit();
			this.rightPanel.ResumeLayout(false);
			this.rightPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.rightImg)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.aboutPanel.ResumeLayout(false);
			this.aboutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private RadioButton horizontalRadio;
        private RadioButton verticalRadio;
        private Label label1;
        private Button resetBtn;
        private Button combineBtn;
        private Panel leftPanel;
        private Label img1Lbl;
        private Panel rightPanel;
        private Label img2Lbl;
        private Button clearLeftBtn;
        private PictureBox leftImg;
        private Button clearRightBtn;
        private PictureBox rightImg;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel aboutPanel;
        private Button btnAbout;
		private Button btnSwapImages;
	}
}
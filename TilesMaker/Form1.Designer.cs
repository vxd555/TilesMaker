namespace TilesMaker
{
    partial class TilesMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesMaker));
            this.BrushPixelButton = new System.Windows.Forms.Button();
            this.BrushesLabel = new System.Windows.Forms.Label();
            this.BrushLineButton = new System.Windows.Forms.Button();
            this.BrushFillButton = new System.Windows.Forms.Button();
            this.NewGfxButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.RootLeft = new System.Windows.Forms.Button();
            this.RootRight = new System.Windows.Forms.Button();
            this.HorMirrorButton = new System.Windows.Forms.Button();
            this.VerMirrorButton = new System.Windows.Forms.Button();
            this.LupeMinusButton = new System.Windows.Forms.Button();
            this.LupePlusButton = new System.Windows.Forms.Button();
            this.MainImage = new System.Windows.Forms.PictureBox();
            this.GrayImage = new System.Windows.Forms.PictureBox();
            this.ColorGrid = new System.Windows.Forms.PictureBox();
            this.GrayGrid = new System.Windows.Forms.PictureBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.OpenImageWin = new System.Windows.Forms.OpenFileDialog();
            this.DEBUG = new System.Windows.Forms.Label();
            this.SetColorWin = new System.Windows.Forms.ColorDialog();
            this.SaveImageWin = new System.Windows.Forms.SaveFileDialog();
            this.ColorSelector = new System.Windows.Forms.PictureBox();
            this.SavePaletteButton = new System.Windows.Forms.Button();
            this.LoadPaletteButton = new System.Windows.Forms.Button();
            this.SizePlusButton = new System.Windows.Forms.Button();
            this.SizeMinusButton = new System.Windows.Forms.Button();
            this.BrushLabel = new System.Windows.Forms.Label();
            this.ToolsLabel = new System.Windows.Forms.Label();
            this.RealTimeBrush = new System.Windows.Forms.CheckBox();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.GridScaleLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.ImageScaleValueLabel = new System.Windows.Forms.Label();
            this.GridScaleValueLabel = new System.Windows.Forms.Label();
            this.ImageSizeValueLabel = new System.Windows.Forms.Label();
            this.IncreaseImage = new System.Windows.Forms.Button();
            this.DecreaseImage = new System.Windows.Forms.Button();
            this.SizeImageLabel = new System.Windows.Forms.Label();
            this.SizeNewImageLabel = new System.Windows.Forms.Label();
            this.SaveTypeLabel = new System.Windows.Forms.Label();
            this.SaveBothRadio = new System.Windows.Forms.RadioButton();
            this.SaveColorRadio = new System.Windows.Forms.RadioButton();
            this.SaveGrayRadio = new System.Windows.Forms.RadioButton();
            this.ChangeGrayScaleLabel = new System.Windows.Forms.Label();
            this.GrayMaskedText = new System.Windows.Forms.MaskedTextBox();
            this.BrushSquareButton = new System.Windows.Forms.Button();
            this.BrushCircleButton = new System.Windows.Forms.Button();
            this.RightMoveButton = new System.Windows.Forms.Button();
            this.DownMoveButton = new System.Windows.Forms.Button();
            this.UpMoveButton = new System.Windows.Forms.Button();
            this.LeftMoveButton = new System.Windows.Forms.Button();
            this.HostButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.IPAdress = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.ConnectionInfo = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // BrushPixelButton
            // 
            this.BrushPixelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.BrushPixelButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushPixelButton.Image")));
            this.BrushPixelButton.Location = new System.Drawing.Point(1065, 117);
            this.BrushPixelButton.Name = "BrushPixelButton";
            this.BrushPixelButton.Size = new System.Drawing.Size(40, 40);
            this.BrushPixelButton.TabIndex = 0;
            this.BrushPixelButton.UseVisualStyleBackColor = false;
            this.BrushPixelButton.Click += new System.EventHandler(this.BrushPixelButton_Click);
            // 
            // BrushesLabel
            // 
            this.BrushesLabel.AutoSize = true;
            this.BrushesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BrushesLabel.Location = new System.Drawing.Point(1147, 85);
            this.BrushesLabel.Name = "BrushesLabel";
            this.BrushesLabel.Size = new System.Drawing.Size(60, 17);
            this.BrushesLabel.TabIndex = 1;
            this.BrushesLabel.Text = "Brushes";
            // 
            // BrushLineButton
            // 
            this.BrushLineButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BrushLineButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushLineButton.Image")));
            this.BrushLineButton.Location = new System.Drawing.Point(1111, 117);
            this.BrushLineButton.Name = "BrushLineButton";
            this.BrushLineButton.Size = new System.Drawing.Size(40, 40);
            this.BrushLineButton.TabIndex = 2;
            this.BrushLineButton.UseVisualStyleBackColor = false;
            this.BrushLineButton.Click += new System.EventHandler(this.BrushLineButton_Click);
            // 
            // BrushFillButton
            // 
            this.BrushFillButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BrushFillButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushFillButton.Image")));
            this.BrushFillButton.Location = new System.Drawing.Point(1157, 117);
            this.BrushFillButton.Name = "BrushFillButton";
            this.BrushFillButton.Size = new System.Drawing.Size(40, 40);
            this.BrushFillButton.TabIndex = 3;
            this.BrushFillButton.UseVisualStyleBackColor = false;
            this.BrushFillButton.Click += new System.EventHandler(this.BrushFillButton_Click);
            // 
            // NewGfxButton
            // 
            this.NewGfxButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.NewGfxButton.Image = ((System.Drawing.Image)(resources.GetObject("NewGfxButton.Image")));
            this.NewGfxButton.Location = new System.Drawing.Point(1084, 32);
            this.NewGfxButton.Name = "NewGfxButton";
            this.NewGfxButton.Size = new System.Drawing.Size(40, 40);
            this.NewGfxButton.TabIndex = 6;
            this.NewGfxButton.UseVisualStyleBackColor = false;
            this.NewGfxButton.Click += new System.EventHandler(this.NewGfxButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(1130, 32);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(40, 40);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.SaveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsButton.Image")));
            this.SaveAsButton.Location = new System.Drawing.Point(1176, 32);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(40, 40);
            this.SaveAsButton.TabIndex = 8;
            this.SaveAsButton.UseVisualStyleBackColor = false;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.UndoButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoButton.Image")));
            this.UndoButton.Location = new System.Drawing.Point(1130, 200);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(40, 40);
            this.UndoButton.TabIndex = 9;
            this.UndoButton.UseVisualStyleBackColor = false;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RedoButton.Image = ((System.Drawing.Image)(resources.GetObject("RedoButton.Image")));
            this.RedoButton.Location = new System.Drawing.Point(1176, 200);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(40, 40);
            this.RedoButton.TabIndex = 10;
            this.RedoButton.UseVisualStyleBackColor = false;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // RootLeft
            // 
            this.RootLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RootLeft.Image = ((System.Drawing.Image)(resources.GetObject("RootLeft.Image")));
            this.RootLeft.Location = new System.Drawing.Point(1084, 247);
            this.RootLeft.Name = "RootLeft";
            this.RootLeft.Size = new System.Drawing.Size(40, 40);
            this.RootLeft.TabIndex = 11;
            this.RootLeft.UseVisualStyleBackColor = false;
            this.RootLeft.Click += new System.EventHandler(this.RootLeft_Click);
            // 
            // RootRight
            // 
            this.RootRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RootRight.Image = ((System.Drawing.Image)(resources.GetObject("RootRight.Image")));
            this.RootRight.Location = new System.Drawing.Point(1130, 247);
            this.RootRight.Name = "RootRight";
            this.RootRight.Size = new System.Drawing.Size(40, 40);
            this.RootRight.TabIndex = 12;
            this.RootRight.UseVisualStyleBackColor = false;
            this.RootRight.Click += new System.EventHandler(this.RootRight_Click);
            // 
            // HorMirrorButton
            // 
            this.HorMirrorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.HorMirrorButton.Image = ((System.Drawing.Image)(resources.GetObject("HorMirrorButton.Image")));
            this.HorMirrorButton.Location = new System.Drawing.Point(1176, 247);
            this.HorMirrorButton.Name = "HorMirrorButton";
            this.HorMirrorButton.Size = new System.Drawing.Size(40, 40);
            this.HorMirrorButton.TabIndex = 13;
            this.HorMirrorButton.UseVisualStyleBackColor = false;
            this.HorMirrorButton.Click += new System.EventHandler(this.HorMirrorButton_Click);
            // 
            // VerMirrorButton
            // 
            this.VerMirrorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.VerMirrorButton.Image = ((System.Drawing.Image)(resources.GetObject("VerMirrorButton.Image")));
            this.VerMirrorButton.Location = new System.Drawing.Point(1222, 247);
            this.VerMirrorButton.Name = "VerMirrorButton";
            this.VerMirrorButton.Size = new System.Drawing.Size(40, 40);
            this.VerMirrorButton.TabIndex = 14;
            this.VerMirrorButton.UseVisualStyleBackColor = false;
            this.VerMirrorButton.Click += new System.EventHandler(this.VerMirrorButton_Click);
            // 
            // LupeMinusButton
            // 
            this.LupeMinusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LupeMinusButton.Image = ((System.Drawing.Image)(resources.GetObject("LupeMinusButton.Image")));
            this.LupeMinusButton.Location = new System.Drawing.Point(1084, 293);
            this.LupeMinusButton.Name = "LupeMinusButton";
            this.LupeMinusButton.Size = new System.Drawing.Size(40, 40);
            this.LupeMinusButton.TabIndex = 15;
            this.LupeMinusButton.UseVisualStyleBackColor = false;
            this.LupeMinusButton.Click += new System.EventHandler(this.LupeMinusButton_Click);
            // 
            // LupePlusButton
            // 
            this.LupePlusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LupePlusButton.Image = ((System.Drawing.Image)(resources.GetObject("LupePlusButton.Image")));
            this.LupePlusButton.Location = new System.Drawing.Point(1130, 293);
            this.LupePlusButton.Name = "LupePlusButton";
            this.LupePlusButton.Size = new System.Drawing.Size(40, 40);
            this.LupePlusButton.TabIndex = 16;
            this.LupePlusButton.UseVisualStyleBackColor = false;
            this.LupePlusButton.Click += new System.EventHandler(this.LupePlusButton_Click);
            // 
            // MainImage
            // 
            this.MainImage.Location = new System.Drawing.Point(199, 9);
            this.MainImage.Name = "MainImage";
            this.MainImage.Size = new System.Drawing.Size(427, 394);
            this.MainImage.TabIndex = 18;
            this.MainImage.TabStop = false;
            this.MainImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginDraw);
            this.MainImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SetMousePosition);
            this.MainImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EndDraw);
            // 
            // GrayImage
            // 
            this.GrayImage.Location = new System.Drawing.Point(632, 9);
            this.GrayImage.Name = "GrayImage";
            this.GrayImage.Size = new System.Drawing.Size(427, 394);
            this.GrayImage.TabIndex = 19;
            this.GrayImage.TabStop = false;
            // 
            // ColorGrid
            // 
            this.ColorGrid.Location = new System.Drawing.Point(199, 409);
            this.ColorGrid.Name = "ColorGrid";
            this.ColorGrid.Size = new System.Drawing.Size(427, 394);
            this.ColorGrid.TabIndex = 20;
            this.ColorGrid.TabStop = false;
            // 
            // GrayGrid
            // 
            this.GrayGrid.Location = new System.Drawing.Point(632, 409);
            this.GrayGrid.Name = "GrayGrid";
            this.GrayGrid.Size = new System.Drawing.Size(427, 394);
            this.GrayGrid.TabIndex = 21;
            this.GrayGrid.TabStop = false;
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LoadButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadButton.Image")));
            this.LoadButton.Location = new System.Drawing.Point(1222, 32);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(40, 40);
            this.LoadButton.TabIndex = 22;
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // OpenImageWin
            // 
            this.OpenImageWin.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenImage_FileOk);
            // 
            // DEBUG
            // 
            this.DEBUG.AutoSize = true;
            this.DEBUG.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DEBUG.Location = new System.Drawing.Point(196, 817);
            this.DEBUG.Name = "DEBUG";
            this.DEBUG.Size = new System.Drawing.Size(31, 17);
            this.DEBUG.TabIndex = 23;
            this.DEBUG.Text = "info";
            // 
            // ColorSelector
            // 
            this.ColorSelector.Location = new System.Drawing.Point(12, 12);
            this.ColorSelector.Name = "ColorSelector";
            this.ColorSelector.Size = new System.Drawing.Size(181, 754);
            this.ColorSelector.TabIndex = 62;
            this.ColorSelector.TabStop = false;
            this.ColorSelector.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ChangeColorInColorSelector);
            this.ColorSelector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChooseColorFromSelector);
            // 
            // SavePaletteButton
            // 
            this.SavePaletteButton.Location = new System.Drawing.Point(12, 772);
            this.SavePaletteButton.Name = "SavePaletteButton";
            this.SavePaletteButton.Size = new System.Drawing.Size(78, 31);
            this.SavePaletteButton.TabIndex = 63;
            this.SavePaletteButton.Text = "Save";
            this.SavePaletteButton.UseVisualStyleBackColor = true;
            this.SavePaletteButton.Click += new System.EventHandler(this.SavePaletteButton_Click);
            // 
            // LoadPaletteButton
            // 
            this.LoadPaletteButton.Location = new System.Drawing.Point(105, 772);
            this.LoadPaletteButton.Name = "LoadPaletteButton";
            this.LoadPaletteButton.Size = new System.Drawing.Size(78, 31);
            this.LoadPaletteButton.TabIndex = 64;
            this.LoadPaletteButton.Text = "Open";
            this.LoadPaletteButton.UseVisualStyleBackColor = true;
            this.LoadPaletteButton.Click += new System.EventHandler(this.LoadPaletteButton_Click);
            // 
            // SizePlusButton
            // 
            this.SizePlusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.SizePlusButton.Image = ((System.Drawing.Image)(resources.GetObject("SizePlusButton.Image")));
            this.SizePlusButton.Location = new System.Drawing.Point(1222, 293);
            this.SizePlusButton.Name = "SizePlusButton";
            this.SizePlusButton.Size = new System.Drawing.Size(40, 40);
            this.SizePlusButton.TabIndex = 66;
            this.SizePlusButton.UseVisualStyleBackColor = false;
            this.SizePlusButton.Click += new System.EventHandler(this.SizePlusButton_Click);
            // 
            // SizeMinusButton
            // 
            this.SizeMinusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.SizeMinusButton.Image = ((System.Drawing.Image)(resources.GetObject("SizeMinusButton.Image")));
            this.SizeMinusButton.Location = new System.Drawing.Point(1176, 293);
            this.SizeMinusButton.Name = "SizeMinusButton";
            this.SizeMinusButton.Size = new System.Drawing.Size(40, 40);
            this.SizeMinusButton.TabIndex = 65;
            this.SizeMinusButton.UseVisualStyleBackColor = false;
            this.SizeMinusButton.Click += new System.EventHandler(this.SizeMinusButton_Click);
            // 
            // BrushLabel
            // 
            this.BrushLabel.AutoSize = true;
            this.BrushLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BrushLabel.Location = new System.Drawing.Point(1155, 9);
            this.BrushLabel.Name = "BrushLabel";
            this.BrushLabel.Size = new System.Drawing.Size(30, 17);
            this.BrushLabel.TabIndex = 67;
            this.BrushLabel.Text = "File";
            // 
            // ToolsLabel
            // 
            this.ToolsLabel.AutoSize = true;
            this.ToolsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ToolsLabel.Location = new System.Drawing.Point(1153, 172);
            this.ToolsLabel.Name = "ToolsLabel";
            this.ToolsLabel.Size = new System.Drawing.Size(43, 17);
            this.ToolsLabel.TabIndex = 68;
            this.ToolsLabel.Text = "Tools";
            // 
            // RealTimeBrush
            // 
            this.RealTimeBrush.AutoSize = true;
            this.RealTimeBrush.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RealTimeBrush.Location = new System.Drawing.Point(1084, 604);
            this.RealTimeBrush.Name = "RealTimeBrush";
            this.RealTimeBrush.Size = new System.Drawing.Size(188, 21);
            this.RealTimeBrush.TabIndex = 69;
            this.RealTimeBrush.Text = "Real time brush overview";
            this.RealTimeBrush.UseVisualStyleBackColor = true;
            this.RealTimeBrush.CheckedChanged += new System.EventHandler(this.RealTimeBrush_CheckedChanged);
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SettingsLabel.Location = new System.Drawing.Point(1147, 581);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(59, 17);
            this.SettingsLabel.TabIndex = 70;
            this.SettingsLabel.Text = "Settings";
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScaleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ScaleLabel.Location = new System.Drawing.Point(1080, 398);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(106, 20);
            this.ScaleLabel.TabIndex = 71;
            this.ScaleLabel.Text = "Image Scale:";
            // 
            // GridScaleLabel
            // 
            this.GridScaleLabel.AutoSize = true;
            this.GridScaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GridScaleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridScaleLabel.Location = new System.Drawing.Point(1080, 428);
            this.GridScaleLabel.Name = "GridScaleLabel";
            this.GridScaleLabel.Size = new System.Drawing.Size(91, 20);
            this.GridScaleLabel.TabIndex = 72;
            this.GridScaleLabel.Text = "Grid scale:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SizeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SizeLabel.Location = new System.Drawing.Point(1080, 460);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(47, 20);
            this.SizeLabel.TabIndex = 73;
            this.SizeLabel.Text = "Size:";
            // 
            // ImageScaleValueLabel
            // 
            this.ImageScaleValueLabel.AutoSize = true;
            this.ImageScaleValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ImageScaleValueLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ImageScaleValueLabel.Location = new System.Drawing.Point(1200, 398);
            this.ImageScaleValueLabel.Name = "ImageScaleValueLabel";
            this.ImageScaleValueLabel.Size = new System.Drawing.Size(35, 20);
            this.ImageScaleValueLabel.TabIndex = 74;
            this.ImageScaleValueLabel.Text = "x10";
            // 
            // GridScaleValueLabel
            // 
            this.GridScaleValueLabel.AutoSize = true;
            this.GridScaleValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GridScaleValueLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridScaleValueLabel.Location = new System.Drawing.Point(1201, 428);
            this.GridScaleValueLabel.Name = "GridScaleValueLabel";
            this.GridScaleValueLabel.Size = new System.Drawing.Size(26, 20);
            this.GridScaleValueLabel.TabIndex = 75;
            this.GridScaleValueLabel.Text = "x1";
            // 
            // ImageSizeValueLabel
            // 
            this.ImageSizeValueLabel.AutoSize = true;
            this.ImageSizeValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ImageSizeValueLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ImageSizeValueLabel.Location = new System.Drawing.Point(1201, 460);
            this.ImageSizeValueLabel.Name = "ImageSizeValueLabel";
            this.ImageSizeValueLabel.Size = new System.Drawing.Size(80, 20);
            this.ImageSizeValueLabel.TabIndex = 76;
            this.ImageSizeValueLabel.Text = "32 x 32px";
            // 
            // IncreaseImage
            // 
            this.IncreaseImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IncreaseImage.BackgroundImage")));
            this.IncreaseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.IncreaseImage.Location = new System.Drawing.Point(1267, 517);
            this.IncreaseImage.Name = "IncreaseImage";
            this.IncreaseImage.Size = new System.Drawing.Size(22, 17);
            this.IncreaseImage.TabIndex = 77;
            this.IncreaseImage.UseVisualStyleBackColor = true;
            this.IncreaseImage.Click += new System.EventHandler(this.IncreaseImage_Click);
            // 
            // DecreaseImage
            // 
            this.DecreaseImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DecreaseImage.BackgroundImage")));
            this.DecreaseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DecreaseImage.Location = new System.Drawing.Point(1267, 538);
            this.DecreaseImage.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.DecreaseImage.Name = "DecreaseImage";
            this.DecreaseImage.Size = new System.Drawing.Size(22, 17);
            this.DecreaseImage.TabIndex = 78;
            this.DecreaseImage.UseVisualStyleBackColor = true;
            this.DecreaseImage.Click += new System.EventHandler(this.DecreaseImage_Click);
            // 
            // SizeImageLabel
            // 
            this.SizeImageLabel.AutoSize = true;
            this.SizeImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SizeImageLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SizeImageLabel.Location = new System.Drawing.Point(1234, 526);
            this.SizeImageLabel.Name = "SizeImageLabel";
            this.SizeImageLabel.Size = new System.Drawing.Size(27, 20);
            this.SizeImageLabel.TabIndex = 79;
            this.SizeImageLabel.Text = "32";
            // 
            // SizeNewImageLabel
            // 
            this.SizeNewImageLabel.AutoSize = true;
            this.SizeNewImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SizeNewImageLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SizeNewImageLabel.Location = new System.Drawing.Point(1079, 526);
            this.SizeNewImageLabel.Name = "SizeNewImageLabel";
            this.SizeNewImageLabel.Size = new System.Drawing.Size(132, 20);
            this.SizeNewImageLabel.TabIndex = 80;
            this.SizeNewImageLabel.Text = "Size new image:";
            // 
            // SaveTypeLabel
            // 
            this.SaveTypeLabel.AutoSize = true;
            this.SaveTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SaveTypeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveTypeLabel.Location = new System.Drawing.Point(1084, 644);
            this.SaveTypeLabel.Name = "SaveTypeLabel";
            this.SaveTypeLabel.Size = new System.Drawing.Size(87, 20);
            this.SaveTypeLabel.TabIndex = 81;
            this.SaveTypeLabel.Text = "Save type:";
            // 
            // SaveBothRadio
            // 
            this.SaveBothRadio.AutoSize = true;
            this.SaveBothRadio.Checked = true;
            this.SaveBothRadio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveBothRadio.Location = new System.Drawing.Point(1084, 678);
            this.SaveBothRadio.Name = "SaveBothRadio";
            this.SaveBothRadio.Size = new System.Drawing.Size(58, 21);
            this.SaveBothRadio.TabIndex = 82;
            this.SaveBothRadio.TabStop = true;
            this.SaveBothRadio.Text = "Both";
            this.SaveBothRadio.UseVisualStyleBackColor = true;
            this.SaveBothRadio.CheckedChanged += new System.EventHandler(this.SaveBothRadio_CheckedChanged);
            // 
            // SaveColorRadio
            // 
            this.SaveColorRadio.AutoSize = true;
            this.SaveColorRadio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveColorRadio.Location = new System.Drawing.Point(1084, 705);
            this.SaveColorRadio.Name = "SaveColorRadio";
            this.SaveColorRadio.Size = new System.Drawing.Size(93, 21);
            this.SaveColorRadio.TabIndex = 83;
            this.SaveColorRadio.TabStop = true;
            this.SaveColorRadio.Text = "Only color";
            this.SaveColorRadio.UseVisualStyleBackColor = true;
            this.SaveColorRadio.CheckedChanged += new System.EventHandler(this.SaveColorRadio_CheckedChanged);
            // 
            // SaveGrayRadio
            // 
            this.SaveGrayRadio.AutoSize = true;
            this.SaveGrayRadio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveGrayRadio.Location = new System.Drawing.Point(1084, 732);
            this.SaveGrayRadio.Name = "SaveGrayRadio";
            this.SaveGrayRadio.Size = new System.Drawing.Size(90, 21);
            this.SaveGrayRadio.TabIndex = 84;
            this.SaveGrayRadio.Text = "Only gray";
            this.SaveGrayRadio.UseVisualStyleBackColor = true;
            this.SaveGrayRadio.CheckedChanged += new System.EventHandler(this.SaveGrayRadio_CheckedChanged);
            // 
            // ChangeGrayScaleLabel
            // 
            this.ChangeGrayScaleLabel.AutoSize = true;
            this.ChangeGrayScaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangeGrayScaleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChangeGrayScaleLabel.Location = new System.Drawing.Point(1084, 772);
            this.ChangeGrayScaleLabel.Name = "ChangeGrayScaleLabel";
            this.ChangeGrayScaleLabel.Size = new System.Drawing.Size(149, 20);
            this.ChangeGrayScaleLabel.TabIndex = 86;
            this.ChangeGrayScaleLabel.Text = "Gray scale(0-100):";
            // 
            // GrayMaskedText
            // 
            this.GrayMaskedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.GrayMaskedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrayMaskedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GrayMaskedText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrayMaskedText.Location = new System.Drawing.Point(1250, 772);
            this.GrayMaskedText.Mask = "999";
            this.GrayMaskedText.Name = "GrayMaskedText";
            this.GrayMaskedText.PromptChar = ' ';
            this.GrayMaskedText.Size = new System.Drawing.Size(39, 20);
            this.GrayMaskedText.TabIndex = 87;
            this.GrayMaskedText.Text = "50";
            this.GrayMaskedText.TextChanged += new System.EventHandler(this.ChangeGrayValue);
            // 
            // BrushSquareButton
            // 
            this.BrushSquareButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BrushSquareButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushSquareButton.Image")));
            this.BrushSquareButton.Location = new System.Drawing.Point(1203, 117);
            this.BrushSquareButton.Name = "BrushSquareButton";
            this.BrushSquareButton.Size = new System.Drawing.Size(40, 40);
            this.BrushSquareButton.TabIndex = 88;
            this.BrushSquareButton.UseVisualStyleBackColor = false;
            this.BrushSquareButton.Click += new System.EventHandler(this.BrushSquareButton_Click);
            // 
            // BrushCircleButton
            // 
            this.BrushCircleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.BrushCircleButton.Image = ((System.Drawing.Image)(resources.GetObject("BrushCircleButton.Image")));
            this.BrushCircleButton.Location = new System.Drawing.Point(1249, 117);
            this.BrushCircleButton.Name = "BrushCircleButton";
            this.BrushCircleButton.Size = new System.Drawing.Size(40, 40);
            this.BrushCircleButton.TabIndex = 89;
            this.BrushCircleButton.UseVisualStyleBackColor = false;
            this.BrushCircleButton.Click += new System.EventHandler(this.BrushCircleButton_Click);
            // 
            // RightMoveButton
            // 
            this.RightMoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RightMoveButton.Image = ((System.Drawing.Image)(resources.GetObject("RightMoveButton.Image")));
            this.RightMoveButton.Location = new System.Drawing.Point(1222, 339);
            this.RightMoveButton.Name = "RightMoveButton";
            this.RightMoveButton.Size = new System.Drawing.Size(40, 40);
            this.RightMoveButton.TabIndex = 93;
            this.RightMoveButton.UseVisualStyleBackColor = false;
            this.RightMoveButton.Click += new System.EventHandler(this.RightMoveButton_Click);
            // 
            // DownMoveButton
            // 
            this.DownMoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.DownMoveButton.Image = ((System.Drawing.Image)(resources.GetObject("DownMoveButton.Image")));
            this.DownMoveButton.Location = new System.Drawing.Point(1176, 339);
            this.DownMoveButton.Name = "DownMoveButton";
            this.DownMoveButton.Size = new System.Drawing.Size(40, 40);
            this.DownMoveButton.TabIndex = 92;
            this.DownMoveButton.UseVisualStyleBackColor = false;
            this.DownMoveButton.Click += new System.EventHandler(this.DownMoveButton_Click);
            // 
            // UpMoveButton
            // 
            this.UpMoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.UpMoveButton.Image = ((System.Drawing.Image)(resources.GetObject("UpMoveButton.Image")));
            this.UpMoveButton.Location = new System.Drawing.Point(1130, 339);
            this.UpMoveButton.Name = "UpMoveButton";
            this.UpMoveButton.Size = new System.Drawing.Size(40, 40);
            this.UpMoveButton.TabIndex = 91;
            this.UpMoveButton.UseVisualStyleBackColor = false;
            this.UpMoveButton.Click += new System.EventHandler(this.UpMoveButton_Click);
            // 
            // LeftMoveButton
            // 
            this.LeftMoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LeftMoveButton.Image = ((System.Drawing.Image)(resources.GetObject("LeftMoveButton.Image")));
            this.LeftMoveButton.Location = new System.Drawing.Point(1084, 339);
            this.LeftMoveButton.Name = "LeftMoveButton";
            this.LeftMoveButton.Size = new System.Drawing.Size(40, 40);
            this.LeftMoveButton.TabIndex = 90;
            this.LeftMoveButton.UseVisualStyleBackColor = false;
            this.LeftMoveButton.Click += new System.EventHandler(this.LeftMoveButton_Click);
            // 
            // HostButton
            // 
            this.HostButton.Location = new System.Drawing.Point(1222, 805);
            this.HostButton.Name = "HostButton";
            this.HostButton.Size = new System.Drawing.Size(68, 31);
            this.HostButton.TabIndex = 94;
            this.HostButton.Text = "Host";
            this.HostButton.UseVisualStyleBackColor = true;
            this.HostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(1130, 805);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(86, 31);
            this.ConnectButton.TabIndex = 95;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // IPAdress
            // 
            this.IPAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.IPAdress.Location = new System.Drawing.Point(992, 805);
            this.IPAdress.Name = "IPAdress";
            this.IPAdress.Size = new System.Drawing.Size(135, 27);
            this.IPAdress.TabIndex = 96;
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IPLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.IPLabel.Location = new System.Drawing.Point(954, 813);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(29, 20);
            this.IPLabel.TabIndex = 97;
            this.IPLabel.Text = "IP:";
            // 
            // ConnectionInfo
            // 
            this.ConnectionInfo.AutoSize = true;
            this.ConnectionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConnectionInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConnectionInfo.Location = new System.Drawing.Point(628, 818);
            this.ConnectionInfo.Name = "ConnectionInfo";
            this.ConnectionInfo.Size = new System.Drawing.Size(21, 20);
            this.ConnectionInfo.TabIndex = 98;
            this.ConnectionInfo.Text = "...";
            this.ConnectionInfo.Visible = false;
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(65, 808);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(68, 28);
            this.buttonSend.TabIndex = 99;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // TilesMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1302, 861);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.ConnectionInfo);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IPAdress);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.HostButton);
            this.Controls.Add(this.RightMoveButton);
            this.Controls.Add(this.DownMoveButton);
            this.Controls.Add(this.UpMoveButton);
            this.Controls.Add(this.LeftMoveButton);
            this.Controls.Add(this.BrushCircleButton);
            this.Controls.Add(this.BrushSquareButton);
            this.Controls.Add(this.GrayMaskedText);
            this.Controls.Add(this.ChangeGrayScaleLabel);
            this.Controls.Add(this.SaveGrayRadio);
            this.Controls.Add(this.SaveColorRadio);
            this.Controls.Add(this.SaveBothRadio);
            this.Controls.Add(this.SaveTypeLabel);
            this.Controls.Add(this.SizeNewImageLabel);
            this.Controls.Add(this.SizeImageLabel);
            this.Controls.Add(this.DecreaseImage);
            this.Controls.Add(this.IncreaseImage);
            this.Controls.Add(this.ImageSizeValueLabel);
            this.Controls.Add(this.GridScaleValueLabel);
            this.Controls.Add(this.ImageScaleValueLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.GridScaleLabel);
            this.Controls.Add(this.ScaleLabel);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.RealTimeBrush);
            this.Controls.Add(this.ToolsLabel);
            this.Controls.Add(this.BrushLabel);
            this.Controls.Add(this.SizePlusButton);
            this.Controls.Add(this.SizeMinusButton);
            this.Controls.Add(this.LoadPaletteButton);
            this.Controls.Add(this.SavePaletteButton);
            this.Controls.Add(this.ColorSelector);
            this.Controls.Add(this.DEBUG);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.GrayGrid);
            this.Controls.Add(this.ColorGrid);
            this.Controls.Add(this.GrayImage);
            this.Controls.Add(this.MainImage);
            this.Controls.Add(this.LupePlusButton);
            this.Controls.Add(this.LupeMinusButton);
            this.Controls.Add(this.VerMirrorButton);
            this.Controls.Add(this.HorMirrorButton);
            this.Controls.Add(this.RootRight);
            this.Controls.Add(this.RootLeft);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.SaveAsButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NewGfxButton);
            this.Controls.Add(this.BrushFillButton);
            this.Controls.Add(this.BrushLineButton);
            this.Controls.Add(this.BrushesLabel);
            this.Controls.Add(this.BrushPixelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TilesMaker";
            this.Text = "TilesMaker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetHotKeys);
            ((System.ComponentModel.ISupportInitialize)(this.MainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrushPixelButton;
        private System.Windows.Forms.Label BrushesLabel;
        private System.Windows.Forms.Button BrushLineButton;
        private System.Windows.Forms.Button BrushFillButton;
        private System.Windows.Forms.Button NewGfxButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button RootLeft;
        private System.Windows.Forms.Button RootRight;
        private System.Windows.Forms.Button HorMirrorButton;
        private System.Windows.Forms.Button VerMirrorButton;
        private System.Windows.Forms.Button LupeMinusButton;
        private System.Windows.Forms.Button LupePlusButton;
        private System.Windows.Forms.PictureBox MainImage;
        private System.Windows.Forms.PictureBox GrayImage;
        private System.Windows.Forms.PictureBox ColorGrid;
        private System.Windows.Forms.PictureBox GrayGrid;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog OpenImageWin;
        private System.Windows.Forms.Label DEBUG;
        private System.Windows.Forms.ColorDialog SetColorWin;
        private System.Windows.Forms.SaveFileDialog SaveImageWin;
        private System.Windows.Forms.PictureBox ColorSelector;
        private System.Windows.Forms.Button SavePaletteButton;
        private System.Windows.Forms.Button LoadPaletteButton;
        private System.Windows.Forms.Button SizePlusButton;
        private System.Windows.Forms.Button SizeMinusButton;
        private System.Windows.Forms.Label BrushLabel;
        private System.Windows.Forms.Label ToolsLabel;
        private System.Windows.Forms.CheckBox RealTimeBrush;
        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.Label ScaleLabel;
        private System.Windows.Forms.Label GridScaleLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label ImageScaleValueLabel;
        private System.Windows.Forms.Label GridScaleValueLabel;
        private System.Windows.Forms.Label ImageSizeValueLabel;
        private System.Windows.Forms.Button IncreaseImage;
        private System.Windows.Forms.Button DecreaseImage;
        private System.Windows.Forms.Label SizeImageLabel;
        private System.Windows.Forms.Label SizeNewImageLabel;
        private System.Windows.Forms.Label SaveTypeLabel;
        private System.Windows.Forms.RadioButton SaveBothRadio;
        private System.Windows.Forms.RadioButton SaveColorRadio;
        private System.Windows.Forms.RadioButton SaveGrayRadio;
        private System.Windows.Forms.Label ChangeGrayScaleLabel;
        private System.Windows.Forms.MaskedTextBox GrayMaskedText;
        private System.Windows.Forms.Button BrushSquareButton;
        private System.Windows.Forms.Button BrushCircleButton;
        private System.Windows.Forms.Button RightMoveButton;
        private System.Windows.Forms.Button DownMoveButton;
        private System.Windows.Forms.Button UpMoveButton;
        private System.Windows.Forms.Button LeftMoveButton;
        private System.Windows.Forms.Button HostButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox IPAdress;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label ConnectionInfo;
        private System.Windows.Forms.Button buttonSend;
    }
}


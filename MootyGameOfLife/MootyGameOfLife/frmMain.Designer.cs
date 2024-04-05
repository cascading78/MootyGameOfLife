namespace MootyGameOfLife
{
    partial class frmMain
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsBtnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnStepEvolve = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPlayEvolve = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStopEvolve = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsBtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnDrawLine = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawRect = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawGlider = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawGliderGun = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawPincer = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawSparkCoil = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawPentamino = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDrawPufferTrain = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTxtDelay = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnFillColor = new System.Windows.Forms.ToolStripButton();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.lblGenerations = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.picLifeCanvas = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDebug = new System.Windows.Forms.Label();
            this.vsb = new System.Windows.Forms.VScrollBar();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLifeCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnOpen,
            this.tsBtnReset,
            this.toolStripSeparator1,
            this.tsBtnStepEvolve,
            this.tsBtnPlayEvolve,
            this.tsBtnStopEvolve,
            this.toolStripSeparator5,
            this.tsBtnZoomIn,
            this.tsBtnZoomOut,
            this.toolStripSeparator2,
            this.tsBtnDrawLine,
            this.tsBtnDrawRect,
            this.tsBtnDrawGlider,
            this.tsBtnDrawGliderGun,
            this.tsBtnDrawPincer,
            this.tsBtnDrawSparkCoil,
            this.tsBtnDrawPentamino,
            this.tsBtnDrawPufferTrain,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tsTxtDelay,
            this.toolStripSeparator4,
            this.tsBtnFillColor});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1599, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.AutoSize = false;
            this.tsBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSave.Image = global::MootyGameOfLife.Properties.Resources.save;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(36, 36);
            this.tsBtnSave.Text = "Save State";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnOpen
            // 
            this.tsBtnOpen.AutoSize = false;
            this.tsBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnOpen.Image = global::MootyGameOfLife.Properties.Resources.open;
            this.tsBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpen.Name = "tsBtnOpen";
            this.tsBtnOpen.Size = new System.Drawing.Size(36, 36);
            this.tsBtnOpen.Text = "Load State";
            this.tsBtnOpen.Click += new System.EventHandler(this.tsBtnOpen_Click);
            // 
            // tsBtnReset
            // 
            this.tsBtnReset.AutoSize = false;
            this.tsBtnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnReset.Image = global::MootyGameOfLife.Properties.Resources.eraser;
            this.tsBtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReset.Name = "tsBtnReset";
            this.tsBtnReset.Size = new System.Drawing.Size(36, 36);
            this.tsBtnReset.Text = "Reset State";
            this.tsBtnReset.Click += new System.EventHandler(this.tsBtnReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnStepEvolve
            // 
            this.tsBtnStepEvolve.AutoSize = false;
            this.tsBtnStepEvolve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStepEvolve.Image = global::MootyGameOfLife.Properties.Resources.step_evolve;
            this.tsBtnStepEvolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStepEvolve.Name = "tsBtnStepEvolve";
            this.tsBtnStepEvolve.Size = new System.Drawing.Size(36, 36);
            this.tsBtnStepEvolve.Text = "Step Evolve";
            this.tsBtnStepEvolve.Click += new System.EventHandler(this.tsBtnStepEvolve_Click);
            // 
            // tsBtnPlayEvolve
            // 
            this.tsBtnPlayEvolve.AutoSize = false;
            this.tsBtnPlayEvolve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPlayEvolve.Image = global::MootyGameOfLife.Properties.Resources.play;
            this.tsBtnPlayEvolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPlayEvolve.Name = "tsBtnPlayEvolve";
            this.tsBtnPlayEvolve.Size = new System.Drawing.Size(36, 36);
            this.tsBtnPlayEvolve.Text = "Evolve";
            this.tsBtnPlayEvolve.Click += new System.EventHandler(this.tsBtnPlayEvolve_Click);
            // 
            // tsBtnStopEvolve
            // 
            this.tsBtnStopEvolve.AutoSize = false;
            this.tsBtnStopEvolve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnStopEvolve.Image = global::MootyGameOfLife.Properties.Resources.stop;
            this.tsBtnStopEvolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStopEvolve.Name = "tsBtnStopEvolve";
            this.tsBtnStopEvolve.Size = new System.Drawing.Size(36, 36);
            this.tsBtnStopEvolve.Text = "Stop Evolve";
            this.tsBtnStopEvolve.Click += new System.EventHandler(this.tsBtnStopEvolve_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnZoomIn
            // 
            this.tsBtnZoomIn.AutoSize = false;
            this.tsBtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnZoomIn.Image = global::MootyGameOfLife.Properties.Resources.zoom_in;
            this.tsBtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnZoomIn.Name = "tsBtnZoomIn";
            this.tsBtnZoomIn.Size = new System.Drawing.Size(36, 36);
            this.tsBtnZoomIn.Text = "Zoom In";
            this.tsBtnZoomIn.Click += new System.EventHandler(this.tsBtnZoomIn_Click);
            // 
            // tsBtnZoomOut
            // 
            this.tsBtnZoomOut.AutoSize = false;
            this.tsBtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnZoomOut.Image = global::MootyGameOfLife.Properties.Resources.zoom_out;
            this.tsBtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnZoomOut.Name = "tsBtnZoomOut";
            this.tsBtnZoomOut.Size = new System.Drawing.Size(36, 36);
            this.tsBtnZoomOut.Text = "Zoom Out";
            this.tsBtnZoomOut.Click += new System.EventHandler(this.tsBtnZoomOut_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnDrawLine
            // 
            this.tsBtnDrawLine.AutoSize = false;
            this.tsBtnDrawLine.CheckOnClick = true;
            this.tsBtnDrawLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawLine.Image = global::MootyGameOfLife.Properties.Resources.Editing_Line_icon;
            this.tsBtnDrawLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawLine.Name = "tsBtnDrawLine";
            this.tsBtnDrawLine.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawLine.Text = "Draw Line";
            this.tsBtnDrawLine.Click += new System.EventHandler(this.tsBtnDrawLine_Click);
            // 
            // tsBtnDrawRect
            // 
            this.tsBtnDrawRect.AutoSize = false;
            this.tsBtnDrawRect.Checked = true;
            this.tsBtnDrawRect.CheckOnClick = true;
            this.tsBtnDrawRect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsBtnDrawRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawRect.Image = global::MootyGameOfLife.Properties.Resources.Editing_Square;
            this.tsBtnDrawRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawRect.Name = "tsBtnDrawRect";
            this.tsBtnDrawRect.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawRect.Text = "Draw Rectangle";
            this.tsBtnDrawRect.Click += new System.EventHandler(this.tsBtnDrawRect_Click);
            // 
            // tsBtnDrawGlider
            // 
            this.tsBtnDrawGlider.AutoSize = false;
            this.tsBtnDrawGlider.CheckOnClick = true;
            this.tsBtnDrawGlider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawGlider.Image = global::MootyGameOfLife.Properties.Resources.hang_glider;
            this.tsBtnDrawGlider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawGlider.Name = "tsBtnDrawGlider";
            this.tsBtnDrawGlider.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawGlider.Text = "Place Glider";
            this.tsBtnDrawGlider.Click += new System.EventHandler(this.tsBtnDrawGlider_Click);
            // 
            // tsBtnDrawGliderGun
            // 
            this.tsBtnDrawGliderGun.AutoSize = false;
            this.tsBtnDrawGliderGun.CheckOnClick = true;
            this.tsBtnDrawGliderGun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawGliderGun.Image = global::MootyGameOfLife.Properties.Resources.laser_gun;
            this.tsBtnDrawGliderGun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawGliderGun.Name = "tsBtnDrawGliderGun";
            this.tsBtnDrawGliderGun.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawGliderGun.Text = "Place Glider Gun";
            this.tsBtnDrawGliderGun.Click += new System.EventHandler(this.tsBtnDrawGliderGun_Click);
            // 
            // tsBtnDrawPincer
            // 
            this.tsBtnDrawPincer.AutoSize = false;
            this.tsBtnDrawPincer.CheckOnClick = true;
            this.tsBtnDrawPincer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawPincer.Image = global::MootyGameOfLife.Properties.Resources.crab;
            this.tsBtnDrawPincer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawPincer.Name = "tsBtnDrawPincer";
            this.tsBtnDrawPincer.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawPincer.Text = "Place Pincer";
            this.tsBtnDrawPincer.Click += new System.EventHandler(this.tsBtnDrawPincer_Click);
            // 
            // tsBtnDrawSparkCoil
            // 
            this.tsBtnDrawSparkCoil.AutoSize = false;
            this.tsBtnDrawSparkCoil.CheckOnClick = true;
            this.tsBtnDrawSparkCoil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawSparkCoil.Image = global::MootyGameOfLife.Properties.Resources.spark_plug;
            this.tsBtnDrawSparkCoil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawSparkCoil.Name = "tsBtnDrawSparkCoil";
            this.tsBtnDrawSparkCoil.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawSparkCoil.Text = "Place Spark Coil";
            this.tsBtnDrawSparkCoil.Click += new System.EventHandler(this.tsBtnDrawSparkCoil_Click);
            // 
            // tsBtnDrawPentamino
            // 
            this.tsBtnDrawPentamino.AutoSize = false;
            this.tsBtnDrawPentamino.CheckOnClick = true;
            this.tsBtnDrawPentamino.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawPentamino.Image = global::MootyGameOfLife.Properties.Resources.Pentomino;
            this.tsBtnDrawPentamino.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawPentamino.Name = "tsBtnDrawPentamino";
            this.tsBtnDrawPentamino.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawPentamino.Text = "Place R-Pentamino";
            this.tsBtnDrawPentamino.Click += new System.EventHandler(this.tsBtnDrawPentamino_Click);
            // 
            // tsBtnDrawPufferTrain
            // 
            this.tsBtnDrawPufferTrain.AutoSize = false;
            this.tsBtnDrawPufferTrain.CheckOnClick = true;
            this.tsBtnDrawPufferTrain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDrawPufferTrain.Image = global::MootyGameOfLife.Properties.Resources.train;
            this.tsBtnDrawPufferTrain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDrawPufferTrain.Name = "tsBtnDrawPufferTrain";
            this.tsBtnDrawPufferTrain.Size = new System.Drawing.Size(36, 36);
            this.tsBtnDrawPufferTrain.Text = "Place Puffer Train";
            this.tsBtnDrawPufferTrain.Click += new System.EventHandler(this.tsBtnDrawPufferTrain_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 36);
            this.toolStripLabel1.Text = "Delay(ms)";
            // 
            // tsTxtDelay
            // 
            this.tsTxtDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsTxtDelay.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsTxtDelay.Name = "tsTxtDelay";
            this.tsTxtDelay.Size = new System.Drawing.Size(35, 39);
            this.tsTxtDelay.Text = "50";
            this.tsTxtDelay.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tsTxtDelay.Leave += new System.EventHandler(this.tsTxtDelay_Leave);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnFillColor
            // 
            this.tsBtnFillColor.AutoSize = false;
            this.tsBtnFillColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tsBtnFillColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnFillColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFillColor.Name = "tsBtnFillColor";
            this.tsBtnFillColor.Size = new System.Drawing.Size(25, 25);
            this.tsBtnFillColor.Text = "Set Fill Color";
            this.tsBtnFillColor.Click += new System.EventHandler(this.tsBtnFillColor_Click);
            // 
            // lblPopulation
            // 
            this.lblPopulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopulation.Location = new System.Drawing.Point(121, 64);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(111, 25);
            this.lblPopulation.TabIndex = 3;
            this.lblPopulation.Text = "999999999";
            this.lblPopulation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGenerations
            // 
            this.lblGenerations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGenerations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerations.Location = new System.Drawing.Point(396, 64);
            this.lblGenerations.Name = "lblGenerations";
            this.lblGenerations.Size = new System.Drawing.Size(111, 25);
            this.lblGenerations.TabIndex = 4;
            this.lblGenerations.Text = "9999999999";
            this.lblGenerations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Population:";
            // 
            // picLifeCanvas
            // 
            this.picLifeCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLifeCanvas.Location = new System.Drawing.Point(9, 100);
            this.picLifeCanvas.Name = "picLifeCanvas";
            this.picLifeCanvas.Size = new System.Drawing.Size(1202, 348);
            this.picLifeCanvas.TabIndex = 8;
            this.picLifeCanvas.TabStop = false;
            this.picLifeCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picLifeCanvas_Paint);
            this.picLifeCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLifeCanvas_MouseDown);
            this.picLifeCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLifeCanvas_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Generations:";
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebug.Location = new System.Drawing.Point(587, 64);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(53, 20);
            this.lblDebug.TabIndex = 11;
            this.lblDebug.Text = "label3";
            // 
            // vsb
            // 
            this.vsb.Location = new System.Drawing.Point(1559, 100);
            this.vsb.Name = "vsb";
            this.vsb.Size = new System.Drawing.Size(21, 360);
            this.vsb.TabIndex = 12;
            this.vsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsb_Scroll);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 794);
            this.Controls.Add(this.vsb);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLifeCanvas);
            this.Controls.Add(this.lblGenerations);
            this.Controls.Add(this.lblPopulation);
            this.Controls.Add(this.tsMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conway\'s Game of Life - Jon Mooty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLifeCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnOpen;
        private System.Windows.Forms.ToolStripButton tsBtnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnStepEvolve;
        private System.Windows.Forms.ToolStripButton tsBtnPlayEvolve;
        private System.Windows.Forms.ToolStripButton tsBtnStopEvolve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnDrawLine;
        private System.Windows.Forms.ToolStripButton tsBtnDrawRect;
        private System.Windows.Forms.ToolStripButton tsBtnDrawGlider;
        private System.Windows.Forms.ToolStripButton tsBtnDrawGliderGun;
        private System.Windows.Forms.ToolStripButton tsBtnDrawPincer;
        private System.Windows.Forms.ToolStripButton tsBtnDrawSparkCoil;
        private System.Windows.Forms.ToolStripButton tsBtnDrawPentamino;
        private System.Windows.Forms.ToolStripButton tsBtnDrawPufferTrain;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Label lblGenerations;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsTxtDelay;
        private System.Windows.Forms.PictureBox picLifeCanvas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsBtnFillColor;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsBtnZoomIn;
        private System.Windows.Forms.ToolStripButton tsBtnZoomOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.VScrollBar vsb;
    }
}


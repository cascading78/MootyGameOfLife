using LifeShell1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * Jon Mooty - CSC 153 001
 * Fall 2022 - Term Project
 * Purpose: Recreate John Conway's Game of Life.
 *
*/

namespace MootyGameOfLife
{
    public partial class frmMain : Form
    {

        const double CANVAS_HEIGHT_RATIO = 0.83; // ratio of the picture box's height compared to the current size of the form
        const double CANVAS_WIDTH_RATIO = 0.97; // ratio of the picture box's width compared to the current size of the form
        const int MIN_CELL_SIZE = 3;
        const int MAX_CELL_SIZE = 16;

        private int ROWS = 200; // number of rows to initiate grid to
        private int COLS = 400; // number of columns to initiate grid to
        private int CSIZE = Properties.Settings.Default.CellSize;

        // the delay is ms between each evolution, recover value from user settings
        private int delay_ms = Properties.Settings.Default.DelayMS;

        // brushColor is used to fill each cell that is alive, recover value from user settings
        private Color brushColor = Color.FromArgb(Properties.Settings.Default.CellFillColor);

        // color to draw lines of grid
        private Color penColor = Color.FromArgb(163, 163, 163);

        // background color of the picturebox used to draw grid
        private Color boardBackColor = Color.FromArgb(225, 225, 220);

        // fullStop is set to true to cause evolution loop to stop
        private bool fullStop = false;

        // main object to store data for grid
        private LifeStates states;

        // Lifestates obejct used to hold objects to draw to grid
        //  will be instantiated when user chooses a draw button from toolstrip
        private LifeStates states_to_copy = null;

        // used to store the initial point on the grid when user is drawing on the grid
        private Point begin_drag_point = new Point(0, 0);

        public frmMain()
        {
            InitializeComponent();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.CellFillColor = brushColor.ToArgb();
            Properties.Settings.Default.DelayMS = delay_ms;
            Properties.Settings.Default.CellSize = CSIZE;
            Properties.Settings.Default.Save();
        }

        private void SetupFileDialogs()
        {
            // setup the save file dialog
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Life State files (*.lif)|*.lif|All files (*.*)|*.*";
            sfd.FileName = "";

            // setup the open file dialog
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "Life State files (*.lif)|*.lif|All files (*.*)|*.*";
            ofd.FileName = "";
        }

        private void DisplayStatistics()
        {
            lblPopulation.Text = states.LiveCells.ToString();
            lblGenerations.Text = states.Generations.ToString();
        }

        private Point TranslatePoint(Point pt)
        {
            return new Point(pt.X, pt.Y + vsb.Value / CSIZE);
        }

        private bool isPointInBounds(Point pt)
        {
            return (pt.X < states.Cols) && (pt.Y < states.Rows) && (pt.X >= 0) && (pt.Y >= 0);
        }

        private void ResizeScrollbars()
        {
            Point vsbLoc = new Point(0, 0);
            vsbLoc.X = picLifeCanvas.Location.X + picLifeCanvas.Width;
            vsbLoc.Y = picLifeCanvas.Location.Y;

            vsb.Location = vsbLoc;
            vsb.Height = picLifeCanvas.Height;
            vsb.Minimum = 0;
            vsb.Maximum = (ROWS * CSIZE + 1) - picLifeCanvas.Height;

            if (vsb.Minimum < 0)
            {
                vsb.Minimum = 0;
                vsb.Maximum = 0;
                vsb.Visible = false;
            }
            else
            {
                vsb.Visible = true;
            }

            vsb.Value = 0;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            states = new LifeStates(ROWS, COLS);

            // select an initial object as the draw state
            tsBtnDrawRect.Checked = true;

            SetupFileDialogs();

            DisplayStatistics();

            // set the fill option button to the current fill color
            tsBtnFillColor.BackColor = brushColor;

            // set the delay according to the current delay
            tsTxtDelay.Text = delay_ms.ToString();

            picLifeCanvas.BackColor = boardBackColor;

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            // resize the picture box proportionate to the form's size
            picLifeCanvas.Width = (int)(this.Width * CANVAS_WIDTH_RATIO);
            picLifeCanvas.Height = (int)(this.Height * CANVAS_HEIGHT_RATIO);

            ResizeScrollbars();
            
        }

        private void picLifeCanvas_Paint(object sender, PaintEventArgs e)
        {
            
            // set the pen and brush to draw with
            Pen pen = new Pen(penColor);
            SolidBrush brush = new SolidBrush(brushColor);

            // prepare the canvas to draw to
            Bitmap out_img = new Bitmap(COLS * CSIZE + 1, ROWS * CSIZE + 1);
            Graphics g = Graphics.FromImage(out_img);

            // draw the live cells
            for (int x = 0; x < states.Cols; x++)
                for (int y = 0; y < states.Rows; y++)
                    if (states.isAlive(x, y))
                    {
                        Rectangle rect = new Rectangle(x * CSIZE + 1, y * CSIZE + 1, CSIZE - 1, CSIZE - 1);
                        g.FillRectangle(brush, rect);
                    }

            // draw the grid
            for (int x = 0; x < states.Cols + 1; x++)
                g.DrawLine(pen, x * CSIZE, 0, x * CSIZE, states.Rows * CSIZE);

            for (int y = 0; y < states.Rows + 1; y++)
                g.DrawLine(pen, 0, y * CSIZE, states.Cols * CSIZE, y * CSIZE);

            lblDebug.Text = "PBH:" + picLifeCanvas.Height.ToString() + " PBW:" + picLifeCanvas.Width.ToString();
            lblDebug.Text += "**IH:" + out_img.Height.ToString() + " IW: " + out_img.Width.ToString();
            lblDebug.Text += "**VSBMAX: " + vsb.Maximum.ToString() + " VVAL: " + vsb.Value.ToString(); 
            // draw the results to the picture box
            e.Graphics.DrawImage(out_img, 0, -vsb.Value);

            brush.Dispose();
        }

        private void picLifeCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point currentPoint = new Point(e.X / CSIZE, e.Y / CSIZE);

                MessageBox.Show("TY=" + TranslatePoint(currentPoint).Y.ToString());  // Debug

                if (isPointInBounds(currentPoint))
                {
                    // if the left click button is pressed and the point is in the bounds of the grid, then 
                    //  set the beginning drag point to the current cell
                    begin_drag_point = currentPoint;
                }
                else
                {
                    // if the initial click is outside the bounds of the grid, set the beginning drag point
                    //  to the last cell in the row/column (avoids drawing erroneous objects and fatal index
                    //  out of bounds errors)
                    int x = e.X / CSIZE > states.Cols ? states.Cols - 1 : e.X / CSIZE;
                    int y = e.Y / CSIZE > states.Rows ? states.Rows - 1 : e.Y / CSIZE;
                    begin_drag_point = new Point(x, y);
                }
            }
        }

        private void picLifeCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                int x = e.X / CSIZE;
                int y = e.Y / CSIZE;

                // ensure both points are within the bounds of the grid
                if (isPointInBounds(new Point(x, y)) && (isPointInBounds(begin_drag_point)))
                {

                    // if user clicked a single cell
                    if (x == begin_drag_point.X && y == begin_drag_point.Y)
                    {
                        if (tsBtnDrawRect.Checked || tsBtnDrawLine.Checked)
                            // if no object is selected to draw and user clicked on a single cell, then 
                            //  toggle that cells state
                            states.Toggle(x, y);
                        else
                            // if user has selected one of the saved object to copy to the grid, then copy the object
                            //  that is loaded to the grid
                            states.CopyToGrid(states_to_copy, x, y);
                        
                    }
                    else
                    {
                        // if the cell when the button was released is diiferent than the cell when the left click
                        //  was initially selected, then resurrect the appropriate shape
                        if (tsBtnDrawLine.Checked)
                            states.ResurrectLine(begin_drag_point.X, begin_drag_point.Y, x, y);
                        else if (tsBtnDrawRect.Checked)
                            states.ResurrectRect(begin_drag_point.X, begin_drag_point.Y, x, y);

                    }

                    // show statistics and redraw picture box
                    DisplayStatistics();
                    picLifeCanvas.Invalidate();
                }
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // if user selected a file and clicked ok, then save the state of the grid to the 
                //  file path chosen
                states.SaveState(sfd.FileName);
            }
        }

        private void tsBtnOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // load the .lif file chosen by the user and display it on the canvas
                states = new LifeStates(ofd.FileName);
                ROWS = states.Rows;
                COLS = states.Cols;
                picLifeCanvas.Invalidate();
            }
        }

        private void tsBtnStepEvolve_Click(object sender, EventArgs e)
        {
            // perform a single evolution, display results and redraw the picture box
            states.Evolve();
            DisplayStatistics();
            picLifeCanvas.Invalidate();
        }

        private void tsBtnPlayEvolve_Click(object sender, EventArgs e)
        {
            fullStop = false;
            tsBtnStepEvolve.Enabled = false;  // disable the step evolve button while loop is running
            tsBtnPlayEvolve.Enabled = false;
            tsBtnStopEvolve.Select();

            // continue evolving until there are no more living cell or the user
            //  presses the stop button
            while (states.LiveCells > 0 && fullStop == false)
            {
                // evolve the board
                states.Evolve();

                DisplayStatistics();

                // redraw the canvas
                picLifeCanvas.Invalidate();

                // delay for the appropriate number of milliseconds
                System.Threading.Thread.Sleep(delay_ms);

                // allow application to process other events
                Application.DoEvents();

            }

            tsBtnPlayEvolve.Enabled = true;
            tsBtnStepEvolve.Enabled = true;
            DisplayStatistics();
            fullStop = false;
        }

        private void tsBtnStopEvolve_Click(object sender, EventArgs e)
        {
            // if the main evolution loop is running, setting fullStop to true will terminate it
            fullStop = true;
        }

        private void tsBtnZoomIn_Click(object sender, EventArgs e)
        {
            // if cell size within bound then increase by 1 and redraw canvas
            if (CSIZE < MAX_CELL_SIZE)
            {
                CSIZE++;
                ResizeScrollbars();
                picLifeCanvas.Invalidate();
            }
        }

        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            // if cell size within bound then increase by 1 and redraw canvas
            if (CSIZE > MIN_CELL_SIZE)
            {
                CSIZE--;
                ResizeScrollbars();
                picLifeCanvas.Invalidate();
            }
        }

        private void tsBtnReset_Click(object sender, EventArgs e)
        {
            // fully reset the state of board
            states = new LifeStates(ROWS, COLS);
            DisplayStatistics();
            picLifeCanvas.Invalidate();
        }

        private void tsBtnDrawLine_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawRect.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;
        }

        private void tsBtnDrawRect_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawLine.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;
        }

        private void tsBtnDrawGlider_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawLine.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawRect.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;

            // load the glider object
            states_to_copy = new LifeStates("GOL\\glider.gol");
        }

        private void tsBtnDrawGliderGun_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawLine.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawRect.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;

            // load the glider gun object
            states_to_copy = new LifeStates("GOL\\glider_gun.gol");
        }

        private void tsBtnDrawPincer_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawLine.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawRect.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;

            // load the pincer object
            states_to_copy = new LifeStates("GOL\\pincer.gol");
        }

        private void tsBtnDrawSparkCoil_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawLine.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawRect.Checked = false;

            // load the spark coil object
            states_to_copy = new LifeStates("GOL\\spark_coil.gol");
        }

        private void tsBtnDrawPentamino_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawLine.Checked = false;
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawPufferTrain.Checked = false;
            tsBtnDrawRect.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;

            // load the r-pentamino object
            states_to_copy = new LifeStates("GOL\\rpentamino.gol");
        }

        private void tsBtnDrawPufferTrain_Click(object sender, EventArgs e)
        {
            // ensure no other draw state is selected
            tsBtnDrawGlider.Checked = false;
            tsBtnDrawGliderGun.Checked = false;
            tsBtnDrawLine.Checked = false;
            tsBtnDrawPentamino.Checked = false;
            tsBtnDrawPincer.Checked = false;
            tsBtnDrawRect.Checked = false;
            tsBtnDrawSparkCoil.Checked = false;

            // load the puffer train object
            states_to_copy = new LifeStates("GOL\\puffertrain.gol");
        }

        private void tsTxtDelay_Leave(object sender, EventArgs e)
        {
            // validate user input and set delay if it is within range of 0-500
            // if anything else is entered change the value back to the previous
            //  value
            if (int.TryParse(tsTxtDelay.Text, out int delay))
                if (delay >= 0 && delay <= 500)
                    delay_ms = delay;
                else
                    tsTxtDelay.Text = delay_ms.ToString();
            else
                tsTxtDelay.Text = delay_ms.ToString();

        }

        private void tsBtnFillColor_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                // set brush color to user selection, display the color in the 
                //  button and redraw the canvas
                brushColor = colorPicker.Color;
                tsBtnFillColor.BackColor = brushColor;
                picLifeCanvas.Invalidate();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save all the settings before exiting application
            SaveSettings();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stops the evolution loop if user closes the form while it is still running
            //  so application can terminate
            fullStop = true;
        }

        private void vsb_Scroll(object sender, ScrollEventArgs e)
        {
            picLifeCanvas.Invalidate();
        }
    }
}

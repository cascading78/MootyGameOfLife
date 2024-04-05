using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;


namespace LifeShell1
{
    class LifeStates
    {
        // this array of bytes holds the state of each cell in the grid.  Each bit in each byte
        //  corresponds to the state of each cell
        private byte[] _states;

        private int _generations = 0; // the count of how many generations have passed
        private int _live_cells = 0; // the number of live cells at any given point 

        // fields
        public int Rows { get; } // read-only, Rows can only be set using constructor
        public int Cols { get; } // read-only, Cols can only be set using constructor
        public int Generations { get { return _generations; } } // read-only, generations is incremented by evolve()
        public int LiveCells { get { return _live_cells; } } // read-only live_cells is only updated by kill() & resurrect()

        // returns the size of the array for the number of rows and columns provided.
        // if the result of (rows * cols / 8) is not a whole number, then we need to add a 
        //  single byte to the array to account for any extra bits
        private int getArraySize(int rows, int cols)
        {
            // compare the result as a double and an int.  if the double is higher than
            //  the integer than we need to an element to the array
            if ((((double)rows * (double)cols / 8.0)) > ((int)(rows * cols / 8)))
                return rows * cols / 8 + 1;
            else
                return rows * cols / 8;
        }

        // returns the index of the byte in the byte array the holds the bit that corresponds to the coordinate passed
        //  in to x and y.
        private int getByteIndex(int x, int y, out int bitPosition)
        {
            bitPosition = (x * (this.Rows) + y) % 8;
            return (x * (this.Rows) + y) / 8;
        }

        // returns true if the bit at bitposition is set to 1, false if 0
        private bool getBit(byte b, int bitPosition)
        {
            // use logical & and a a mask to get the bit at bitposition
            return (b & (1 << bitPosition)) != 0;
        }

        // returns the byte after altering the bit
        private byte SetBit(byte b, int bitPosition, bool value)
        {
            byte mask = (byte)(1 << bitPosition);
            if (value == true)
                // if turning the bit on, use the mask and logical or to change the bit to 1
                b |= mask;
            else
                // if turning the bit on, use the inverted mask and logical & to change the bit to 0
                b &= (byte)~mask;
            return b;
        }

        // creates a LifeStates objects based on the number of rows and columns provided
        public LifeStates(int rows, int cols)
        {

            _states = new byte[getArraySize(rows, cols)];

            Rows = rows;
            Cols = cols;

        }

        // this constructor loads the states of the board from a binary file.
        // the first 16 bytes correspond to the fields (in order) Rows, Cols, _generations,
        //  _live_cells.
        // the remaining data is the state of each cell in the grid, it should be equivalent to 
        // rows * cols / 8
        public LifeStates(string filePath)
        {
            byte[] bytes_in = File.ReadAllBytes(filePath);

            Rows = BitConverter.ToInt32(bytes_in, 0);
            Cols = BitConverter.ToInt32(bytes_in, 4);
            _generations = BitConverter.ToInt32(bytes_in, 8);
            _live_cells = BitConverter.ToInt32(bytes_in, 12);

            // set the size of the grid array based on extracted data
            _states = new byte[getArraySize(Rows, Cols)];

            // copy the remainder off the bytes into the _states array by skipping
            //  the first 4 elements
            _states = bytes_in.Skip(16).ToArray();



        }

        // checks the bit that corresponds to the x, y coordinate provided and returns
        //  it's value (0 = false, 1 = true)
        public Boolean isAlive(int x, int y)
        {
            int byte_index = getByteIndex(x, y, out int bitPosition);
            return getBit(_states[byte_index], bitPosition);
        }

        // changes the bit that corresponds to the x, y coordinate provided to 0 (dead state) and decrements
        //  the live_cells field
        public void Kill(int x, int y)
        {
            int byte_index = getByteIndex(x, y, out int bitPosition);
            _states[byte_index] = SetBit(_states[byte_index], bitPosition, false);
            _live_cells = _live_cells == 0 ? 0 : _live_cells - 1;
        }

        // changes the bit that corresponds to the x, y coordinate provided to 1 (alive state) and increment
        //  the live_cells field
        public void Resurrect(int x, int y)
        {
            int byte_index = getByteIndex(x, y, out int bitPosition);
            _states[byte_index] = SetBit(_states[byte_index], bitPosition, true);
            _live_cells++;
        }

        // toggles value of the cell at the x, y coordinate provided
        public void Toggle(int x, int y)
        {
            if (isAlive(x, y))
                Kill(x, y);
            else
                Resurrect(x, y);
        }

        // this function copies the states of the copy_states object passed to it into the grid
        //  starting at the coordinate provided.  If copy_states extends beyond the bounds of 
        //  the grid than those cells will not be copied
        public void CopyToGrid(LifeStates copy_states, int x, int y)
        {
            //int xend = x + copy_states.Cols;
            //int yend = y + copy_states.Rows;

            for (int c_x = 0; c_x < copy_states.Cols; c_x++)
                for (int c_y = 0; c_y < copy_states.Rows; c_y++)
                    if (copy_states.isAlive(c_x, c_y))
                    {
                        if (x + c_x < Cols && y + c_y < Rows) // ensure destination cell is within bound of grid
                            if (!isAlive(x + c_x, y + c_y)) // only resurrect if necessary to preserve cell count
                                Resurrect(x + c_x, y + c_y); 
                    }
                    else
                    {
                        if (x + c_x < Cols && y + c_y < Rows) // ensure destination cell is within bounds of grid
                            if (isAlive(x + c_x, y + c_y)) // only kill if necessary to preserve cell count
                                Kill(x + c_x, y + c_y); 
                    }

        }

        // resurrects every cell in a rectangle from x1, y1 to x2, y2
        public void ResurrectRect(int x1, int y1, int x2, int y2)
        {
            int xstart, ystart, xend, yend;

            // determine start/end position to iterate through the cells
            //  this is necessary in case the rectange extends in the direction
            //  of negative x or y
            xstart = x2 > x1 ? x1 : x2;
            xend = x2 > x1 ? x2 : x1;

            ystart = y2 > y1 ? y1 : y2;
            yend = y2 > y1 ? y2 : y1;

            for (int c_x = xstart; c_x <= xend; c_x++)
                for (int c_y = ystart; c_y <= yend; c_y++)
                    Resurrect(c_x, c_y);
        }

        // Bresenham's Line Algorithm - code found on the internet and modified to work with this class
        //
        // resurrects the cells along the line from x1, y1 to x2, y2
        public void ResurrectLine(int x1, int y1, int x2, int y2)
        {
            int w = x2 - x1;
            int h = y2 - y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            dx1 = (w < 0) ? -1 : 1;
            dy1 = (h < 0) ? -1 : 1;
            dx2 = (w < 0) ? -1 : 1;

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                Resurrect(x1, y1);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x1 += dx1;
                    y1 += dy1;
                }
                else
                {
                    x1 += dx2;
                    y1 += dy2;
                }
            }

        }

        // Adjusts the state of the board based on the rules for the game of life:
        //  1) Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        //  2) Any live cell with two or three live neighbours lives on to the next generation.
        //  3) Any live cell with more than three live neighbours dies, as if by overpopulation.
        //  4) Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        public void Evolve()
        {
            // copy the current state of the grid to a new array.  _previous_states will 
            //  be used to decide the states of the _states grid
            byte[] _previous_states = new byte[getArraySize(Rows, Cols)];
            _states.CopyTo(_previous_states, 0);

            for (int x = 0; x < Cols; x++)
                for (int y = 0; y < Rows; y++)
                {
                    // retrieve the number of living neighbors for each cell
                    int neighbors = neighborCount(_previous_states, x, y);
                    if (isAlive(x, y))
                    {
                        // if the cell is alive and has less than 2 lving neighbors (rule 1) or more
                        //  than 3 living neighbors (rule 3) then kill the cell, if the cell has 2 or 3
                        //  living neighbors (rule 3) than leave the cell in it's current state (alive)
                        if (neighbors < 2 || neighbors > 3)
                            Kill(x, y);
                    }
                    else
                    {
                        // if the cell is dead and has exactly 3 living neighbors (rule 4), then resurrect
                        //  the cell
                        if (neighbors == 3)
                            Resurrect(x, y);
                    }
                }

            // increment the number of generations passed by 1
            _generations++;

        }

        

        // returns the number of living cells surrounding the cell at coordinate x, y.  if any of the 
        //  surrounding cells are out of bounds, they will not be checked
        private int neighborCount(byte[] bytes, int x, int y)
        {
            int count = 0;
            int bitPos = 0;

            // visualization of cells to be checked, X is the coordinate passed to x, y
            // |0|1|2|
            // |3|X|4|
            // |5|6|7|

            if ((y - 1) >= 0 && (x - 1) >= 0) // check state of cell 0
                count += this.getBit(bytes[getByteIndex(x - 1, y - 1, out bitPos)], bitPos) ? 1 : 0;

            if ((y + 1) < Rows && (x + 1) < Cols) // check state of cell 7
                count += this.getBit(bytes[getByteIndex(x + 1, y + 1, out bitPos)], bitPos) ? 1 : 0;

            if (((x + 1) < Cols) && ((y - 1) >= 0)) // check state of cell 2
                count += this.getBit(bytes[getByteIndex(x + 1, y - 1, out bitPos)], bitPos) ? 1 : 0;

            if (((y + 1) < Cols) && ((x - 1) >= 0)) // check state of cell 5
                count += this.getBit(bytes[getByteIndex(x - 1, y + 1, out bitPos)], bitPos) ? 1 : 0;

            if (x + 1 < Cols) // check state of cell 4
                count += this.getBit(bytes[getByteIndex(x + 1, y, out bitPos)], bitPos) ? 1 : 0; // Van Neumann

            if (y + 1 < Rows) // check state of cell 6
                count += this.getBit(bytes[getByteIndex(x, y + 1, out bitPos)], bitPos) ? 1 : 0; // Van Neumann

            if (y - 1 >= 0) // check state of cell 1
                count += this.getBit(bytes[getByteIndex(x, y - 1, out bitPos)], bitPos) ? 1 : 0; // Van Neumann

            if (x - 1 >= 0) // check state of cell 3
                count += this.getBit(bytes[getByteIndex(x - 1, y, out bitPos)], bitPos) ? 1 : 0; // Van Neumann

            return count;
        }

        // Saves the state of the grid to a binary file with the following format:
        //  bytes 1-4 are the number of Rows
        //  bytes 5-8 are the number columns
        //  bytes 9-12 are the current number of generations
        //  bytes 13-16 are the number of live cells
        //  bytes 17-EOF are the contents of the _states array (total bytes equal to _states.count)
        
        public bool SaveState(string filePath)
        {

            // convert int values to byte arrays
            byte[] row_bytes = BitConverter.GetBytes(this.Rows);
            byte[] col_bytes = BitConverter.GetBytes(this.Cols);
            byte[] gen_bytes = BitConverter.GetBytes(this.Generations);
            byte[] live_cell_bytes = BitConverter.GetBytes(this.LiveCells);

            // concatenate all the arrays into 1 array
            byte[] bytes_out = row_bytes.Concat(col_bytes).ToArray();
            bytes_out = bytes_out.Concat(gen_bytes).ToArray().Concat(live_cell_bytes).ToArray();
            bytes_out = bytes_out.Concat(_states).ToArray();

            // write the binary file to the filePath provided
            File.WriteAllBytes(filePath, bytes_out);

            return true;
        }

        /*
        
        // wrapper function used to make neighborCount public, used for debugging
        public int livingNeighbors(int x, int y)
        {
            return neighborCount(_states, x, y);
        }

        // function used for debugging purposes
        public bool predictEvolution(int x, int y)
        {
            int neighbors = neighborCount(_states, x, y);
            if (isAlive(x, y))
            {
                if (neighbors < 2 || neighbors > 3)
                    return false;
            }
            else
            {
                if (neighbors == 3)
                    return true;
                else
                    return false;
            }

            return true;

        }*/


    }
}


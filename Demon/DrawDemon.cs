using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon
{
    public class DrawDemon : IDisposable
    {
        private const int NUMCOLS = 320;
        private const int NUMROWS = 240;
        private const int TWO = 2;
        private const int NUMSTATE = 8;

        private int numberGeneration;
        private int rules;
        private int palettes;

        private Bitmap buffer;
        private Graphics panelGraphics;
        private Graphics bufferGraphics;

        private Cell[,] cells;
        private Cell[,] newCells;
        private Cell[,] tempArray;

        private Brush[] brushes;
        private Color[] colors;

        private static Color[] rainbow;
        private static Color[] malachite;
        private static Color[] purpleSky;
        private static Color[] coralReef;

        private Panel mainPanel;

        List<Rectangle>[] squares;

        public int Rules
        {
            get { return rules; }
            set { rules = value; }
        }

        public int Palettes
        {
            get { return palettes; }
            set { palettes = value; }
        }

        public int NumberGeneration
        {
            get { return numberGeneration; }
            set { numberGeneration = value; }
        }

        public DrawDemon(Panel panel)
        {
            mainPanel = panel;
            // set up background bitmap and associated graphics drawing object
            buffer = new Bitmap(NUMCOLS * TWO, NUMROWS * TWO);
            bufferGraphics = Graphics.FromImage(buffer);
            // displayGraphics allow to draw to panel
            panelGraphics = mainPanel.CreateGraphics();
            brushes = new Brush[NUMSTATE];
            //Create (NUMCOLS * NUMROWS) instances of Rectangle Class
            squares = new List<Rectangle>[(NUMCOLS * NUMROWS)];
            for (int i = 0; i < (NUMCOLS * NUMROWS); i++)
            {
                squares[i] = new List<Rectangle>();
            }
            CreateCellsState();
            GenerateSquares();
        }


        private void CreateCellsState()
        {
            cells = new Cell[NUMROWS, NUMCOLS];
            newCells = new Cell[NUMROWS, NUMCOLS];
            for (int row = 0; row < NUMROWS; row++)
            {
                for (int col = 0; col < NUMCOLS; col++)
                {
                    //<Summary>
                    //Create instances of Cell class & put them in array
                    //Resulting Array > cells[i,j].State = 0
                    //cells for storing Automa and 
                    //newCells for building new line when rule is applied
                    //Note -> required to work out the changes to all cells
                    //at once before changing them
                    //</>Summary
                    cells[row, col] = new Cell();
                    newCells[row, col] = new Cell();
                }
            }
        }


        //Generate Squares of 2 pixel for each cell position
        private void GenerateSquares()
        {
            int x, y, index = 0;
            while (index < (NUMCOLS * NUMROWS))
            {
                for (int row = 0; row < NUMROWS; row++)
                {
                    y = row * TWO;
                    for (int col = 0; col < NUMCOLS; col++)
                    {
                        x = col * TWO;
                        //Initialize new instances of rectangle class 
                        //with specific location and size
                        squares[index].Add(new Rectangle(x, y, TWO, TWO));
                        index++;
                    }
                }
            }
        }


        //Based on selected rule number, run the automata 
        public void RunAutomata()
        {
            if (rules == 0)
            {
                ApplyRuleOrthogonal();
            }
            if (rules == 1)
            {
                ApplyRuleDiagonal();
            }

            if (rules == TWO)
            {
                ApplyRuleOrthogonal();
                ApplyRuleDiagonal();
            }
        }


        private void ApplyRuleOrthogonal()
        {
            for (int row = 0; row < NUMROWS; row++)
            {
                //a =  row , () ( e.g. row = 239 ) - for position top
                //b = row , () ( e.g. row=  1 ) - for position below
                int top = (row + NUMROWS - 1) % NUMROWS; //a
                int below = (row + 1) % NUMROWS; //b

                for (int col = 0; col < NUMCOLS; col++)
                {
                    //c = () , col ( e.g. col = 319 ) - for position left
                    //d = () , col ( e.g. col = 1 ) - for position right
                    int left = (col + NUMCOLS - 1) % NUMCOLS; //c
                    int right = (col + 1) % NUMCOLS; //d
                    SetStateOrthogonal(row, col,top, below, left, right);
                }
            }

            //make newCells the cells by swapping the two lines
            tempArray = cells;
            cells = newCells;
            newCells = tempArray;
        }

        private void SetStateOrthogonal(int i, int j, int a, int b, int c, int d)
        {
            //Nextstate of current cell
            int nextState = cells[i, j].NextState(NUMSTATE);
            //Orthogonal Neighbors position
            int left = cells[i, c].State;
            int right = cells[i, d].State;
            int top = cells[a, j].State;
            int below = cells[b, j].State;

            //Apply Orthogonal rules
            if (left == nextState || right == nextState)
            {
                newCells[i, j].State = nextState;
            }
            else if (top == nextState || below == nextState)
            {
                newCells[i, j].State = nextState;
            }
            else
            {
                newCells[i, j].State = cells[i, j].State;
            }
        }


        private void ApplyRuleDiagonal()
        {
            for (int row = 0; row < NUMROWS; row++)
            {
                //a =  row , () ( e.g. row = 239 ) - for position top_left & top_right
                // b = row , () ( e.g. row=  1 ) - for position below_left & below_right
                int tRow = (row + NUMROWS - 1) % NUMROWS; //a
                int bRow = (row + 1) % NUMROWS;  //b

                for (int col = 0; col < NUMCOLS; col++)
                {
                    //c = () , col ( e.g. col = 319 ) for position top_left & below_left
                    //d = () , col ( e.g. col = 1 ) - for position top_right & below_right
                    int leftCol = (col + NUMCOLS - 1) % NUMCOLS;//c
                    int rightCol = (col + 1) % NUMCOLS; //d
                    SetStateDiagonal(row, col, tRow, bRow, leftCol, rightCol);
                }
            }

            //make newCells the cells by swapping the two lines
            tempArray = cells;
            cells = newCells;
            newCells = tempArray;
        }

        private void SetStateDiagonal(int i, int j, int a, int b, int c, int d)
        {
            //Nextstate of current cell
            int nextState = cells[i, j].NextState(NUMSTATE);
            // Diagonal Neighbors position
            int topRight = cells[a, d].State;
            int belowRight = cells[b, d].State;
            int topLeft = cells[a, c].State;
            int belowLeft = cells[b, c].State;
            
            //Apply diagonal rules
            if (belowLeft == nextState || belowRight == nextState)
            {
                newCells[i, j].State = nextState;
            }
            else if (topLeft == nextState || topRight == nextState)
            {
                newCells[i, j].State = nextState;
            }
            else
            {
                newCells[i, j].State = cells[i, j].State;
            }
        }


        //Based on state number select the brush & fill the squares 
        //Note-> There are toal 8 brush with different colors
        private void FillSquares()
        {
            int state, index = 0;
            while (index < (NUMCOLS * NUMROWS))
            {
                for (int row = 0; row < NUMROWS; row++)
                {
                    for (int col = 0; col < NUMCOLS; col++)
                    {
                        state = cells[row, col].State;
                        bufferGraphics.FillRectangles(brushes[state], squares[index].ToArray());
                        index++;
                    }
                }
            }
        }


        public void PaintPanel()
        {
            FillSquares();
            //Draw the current buffer to panel using its graphic object
            panelGraphics.DrawImageUnscaled(buffer, 0, 0);
        }


        //Method for mainPanel_Paint event
        //Don't need to recalculate squares again
        public void ReDraw()
        {
            panelGraphics.DrawImageUnscaled(buffer, 0, 0);
        }


        //Randomly initialise the cells
        public void Reset(int seed)
        {
            Random random = new Random(seed);
            for (int row = 0; row < NUMROWS; row++)
            {
                for (int col = 0; col < NUMCOLS; col++)
                {
                    cells[row, col].State = random.Next(NUMSTATE);
                }
            }
        }


        //Automata Hash value formula is applied
        public uint GetHash()
        {
            int state, hash = 0;
            for (int col = 0; col < NUMCOLS; col++)
            {
                for (int row = 0; row < NUMROWS; row++)
                {
                    state = cells[row, col].State;
                    hash ^= ((row * col + 1) * (state + 1));
                }
            }
            return (uint)hash;
        }


        //Based on selected palette number, return the colors
        //Set the brushes according to colors
        public void SelectPalette()
        {
            colors = new Color[NUMSTATE];
            for (int i = 0; i < NUMSTATE; i++)
            {
                colors[i] = SetColors(palettes, i);
                brushes[i] = new SolidBrush(colors[i]);
            }
            PaintPanel();
        }


        //Each pallete contains 8 colors ( indexing from 0 to 7 )
        private static Color SetColors(int palette, int i)
        {
            //palette number = 0
            rainbow = new Color[NUMSTATE]
            {
                Color.Red, Color.Orange, Color.Yellow, Color.Green,
                Color.DarkBlue, Color.Cyan, Color.PaleVioletRed, Color.RoyalBlue
            };
            //palette number = 1
            malachite = new Color[NUMSTATE]
            {
                Color.Green, Color.DarkGreen, Color.Black, Color.Green,
                Color.LimeGreen, Color.ForestGreen, Color.DarkGreen, Color.Green
            };
            //palette number = 2
            purpleSky = new Color[NUMSTATE]
            {
                 Color.Purple, Color.Magenta, Color.Fuchsia, Color.DarkMagenta,
                 Color.Purple, Color.Magenta, Color.Fuchsia, Color.MediumPurple
            };
            //palette number = 3
            coralReef = new Color[NUMSTATE]
            {
                 Color.DeepSkyBlue, Color.Orchid, Color.BurlyWood, Color.Azure,
                Color.Pink, Color.Orchid, Color.Orchid, Color.Azure
             };

            //If palette 0 is selected, return 8 colors of rainbow
            if (palette == 0)
            {
                return rainbow[i]; // e.g when i = 0 , return red and so on
            }
            else if (palette == 1)
            {
                return malachite[i];
            }
            else if (palette == TWO)
            {
                return purpleSky[i];
            }
            else return coralReef[i];
        }


        //In order to Suppress warning Microsoft recommendation for 
        //implementing IDisposable Interface is followed.
        //Protected implementation of Dispose pattern --
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Dispose managed resources
                if (panelGraphics != null) panelGraphics.Dispose();
                if (bufferGraphics != null) bufferGraphics.Dispose();
                if (buffer != null) buffer.Dispose();
                for (int i = 0; i < NUMSTATE; i++)
                {
                    if (brushes[i] != null)
                    {
                        brushes[i].Dispose();
                    }
                }
            }

        }

        //Public implementation of Dispose pattern that is callable
        public void Dispose()
        {
            //Dispose of unmanaged resources
            Dispose(true);
            //Suppress finalization
            GC.SuppressFinalize(this);
        }

    }
}

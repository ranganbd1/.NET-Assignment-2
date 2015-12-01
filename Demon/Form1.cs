using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon
{
    public partial class DemonForm : Form
    {
        private const int TWO = 2;
        private const int WIDTH = 640;
        private const int HEIGHT = 480;
        private const int BASEWIDTH = 660;
        private const int BASEHEIGHT = 620;
        private const string GENERATION = "100";
        private DrawDemon demon;

        public DemonForm()
        {
            InitializeComponent();
            base.Width = BASEWIDTH;
            base.Height = BASEHEIGHT;
            mainPanel.Width = WIDTH;
            mainPanel.Height = HEIGHT;
            demon = new DrawDemon(mainPanel);
            PaletteComBox.SelectedIndex = 0;
            RulesComBox.SelectedIndex = 0;
            seedBox.Text = "0";
            genBox.Text = GENERATION;
        }


        private void RulesComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RulesComBox.SelectedIndex == 0) //Orthogonal
            {
                demon.Rules = 0;
            }
            if (RulesComBox.SelectedIndex == 1) //Diagonal
            {
                demon.Rules = 1;
            }
            if (RulesComBox.SelectedIndex == TWO) //Alternating
            {
                demon.Rules = TWO;
            }
        }


        private void PaletteComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaletteComBox.SelectedIndex == 0) //Rainbow
            {
                demon.Palettes = 0;
            }
            if (PaletteComBox.SelectedIndex == 1) //Malachite
            {
                demon.Palettes = 1;
            }
            if (PaletteComBox.SelectedIndex == TWO) //PurpleSky
            {
                demon.Palettes = TWO;
            }
            if (PaletteComBox.SelectedIndex == (TWO +1)) //Coral Reef
            {
                demon.Palettes = (TWO + 1);
            }
            demon.SelectPalette();
        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            int seed;
            if (int.TryParse(seedBox.Text, out seed))
            {
                demon.NumberGeneration = 0; //Reset the num of gen
                demon.Reset(seed); //Initialises cells to random state by using seed
                demon.PaintPanel(); //Display newly generated automata
                //Display Generation number
                generationCounter.Text = demon.NumberGeneration.ToString(); 
                finalHashValue.Text = demon.GetHash().ToString();//Display hash value
            }
            else 
                MessageBox.Show("Reset failed with the following error" +
                    Environment.NewLine +
                    "Invalid Seed Value");
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            topPanel.Enabled = false; //lock the top panel
            int gen;

            if (int.TryParse(genBox.Text, out gen) && gen > 0)
            {
                for (int i = 0; i < gen; i++)
                {
                    demon.RunAutomata(); //Run automata using selected colors & rules
                    demon.PaintPanel(); //Display automata after each generation
                    //Count & Display the generation number
                    demon.NumberGeneration += 1;
                    generationCounter.Text = demon.NumberGeneration.ToString();
                    bottomStatusStrip.Update();
                }
                //Display the hash value of automata after all generations
                finalHashValue.Text = demon.GetHash().ToString();
            }
            else
                MessageBox.Show("Unable to start the demon with the following error" +
                    Environment.NewLine +
                    "Generations to run must be greater than 0");

            topPanel.Enabled = true; //Unlock the top panel
        }


        //Event occurs before a form is displayed for the first time
        //Reset condition 
        private void DemonForm_Load(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
        }


        //Redraw the bitmap back to the panel - paint event handler
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
           demon.ReDraw();
        }

    }
}

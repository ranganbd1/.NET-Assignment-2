using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demon
{
    class Cell
    {

        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        //Constructor that populate the property 
        public Cell()
        {
            state = 0;
        }

        //Given number of state, return nextstate of the cell
        public int NextState(int numState)
        {
            return (state + 1) % numState;
        }

    }
}

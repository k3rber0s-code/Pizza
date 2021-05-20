using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BetterPizza.Program;

namespace BetterPizza
{
    class Orders
    {
        private int numOfPizza;
        private int[] slices;

        public int ONE { get => slices[0]; }
        public int TWO { get => slices[1]; }
        public int THREE { get => slices[2]; }
        public int FOUR { get => slices[3]; }
        public int FIVE { get => slices[4]; }
        public int NUM_OF_PIZZA { get => numOfPizza; }

        public Orders()
        {
            slices = new int[5];
        }
        public void Add(int num)
        {
            numOfPizza += num / 6;
            slices[num % 6 - 1]++;
        }

        public void AddWhole(int count)
        {
            numOfPizza += count;
        }

        public int NumberOfSlices(Slice slice)
        {
            return slices[(int)slice];
        }

        public void RemoveSlices(Slice slice, int count)
        {
            slices[(int)slice] -= count;
        }

        public void ChangeToWhole(Slice slice, int count)
        {
            AddWhole(count);
            slices[(int)slice] -= count;
        }

        public void ChangeAllToWhole(Slice slice)
        {
            AddWhole(slices[(int)slice]);
            slices[(int)slice] = 0;
        }

    }
}

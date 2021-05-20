using System;
using System.Collections.Generic;
using System.IO;

namespace Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary> 
            /// sort all the values
            /// 
            /// take those greater than full pizza (6), subtract 6 until they are < 6 and every time you subtract add 1 to total count
            /// 
            /// take 5s & 4s and create new pizza for each of them, add the rests to a list
            /// 
            /// for every other number of slices (<=3 ) check the rest list for 1. value greater than them 2. same value as them
            /// case 1: subtract the number from the rest and add rest of the rest to the list again, remove the original rest piece from the list
            /// case 2: just remove the rest from the list
            /// 
            /// if neither of these values has been found, create new pizza (total count += 1), 
            /// subtract number of pieces from it and add the rest to the list again.
            /// 
            /// </summary>
            
            var orders = new List<int>();
            var restList = new List<int>();

            using (var sr = new StreamReader(@"C:\Users\toman\source\repos\Pizza\Pizza\vstup.txt"))
            {
                string line = sr.ReadLine();
                string[] nums = line.Split(" ");
                foreach (string s in nums)
                {
                    orders.Add(int.Parse(s));
                }
            }

            restList.Add(0);

            orders.Sort();
            orders.Reverse();

            int totalCount = 0;

            for (int i = 0; i < orders.Count; i++)
            {
                var order = orders[i];
                while (order >= 6)
                {
                    totalCount += 1;
                    order -= 6;
                }
                orders[i] = order;
            }

            orders.Sort();
            orders.Reverse();

            foreach (int order in orders)
            {
                if (order == 4 || order == 5)
                {
                    totalCount += 1;
                    int rest = 6 - order;
                    restList.Add(rest);
                }
                else
                {
                    restList.Sort();
                    restList.Reverse();
                    
                    if (restList[0] >= order)
                    {
                        restList[0] -= order;
                        continue;
                    }
                    else
                    {
                        totalCount += 1;
                        int rest = 6 - order;
                        restList.Add(rest);
                        continue;
                    }
                }
            }
            Console.WriteLine(totalCount);

        }

    }
}

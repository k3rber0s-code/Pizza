﻿using BetterPizza.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPizza
{
    class Program
    {
        static void Main()
        {
            Orders orders = new Orders();
            string[] nums = LoadNums();
            foreach (string s in nums)
            {
                orders.Add(int.Parse(s));
            }

            Fives(orders);
            Fours(orders);
            Threes(orders);
            Twos(orders);
            Ones(orders);

            Rest(orders);

            PrintResult(orders.NUM_OF_PIZZA);
        }

        private static void PrintResult(int numOfPizza) // <<<<<<<<<<<<<<<<<<<<<<<<<<< CHANGE THIS METHOD TO PRINT THE RESULTS
        {
            Console.WriteLine(numOfPizza);
        }

        private static string[] LoadNums() // <<<<<<<<<<<<<<<<<<<<< CHANGE THIS METHOD TO LOAD THE NUMBERS
        {
            return Resources.vstup.Split(' ');
        }

        private static void Rest(Orders orders)
        {
            if (orders.FOUR > 0 && orders.ONE > 0) orders.RemoveSlices(Slice.ONE, 1);
            orders.ChangeAllToWhole(Slice.FOUR);

            int rmTwos = Math.Min(orders.THREE, orders.TWO);
            orders.RemoveSlices(Slice.TWO, rmTwos);
            orders.ChangeToWhole(Slice.THREE, rmTwos);

            if (orders.THREE == 1) orders.RemoveSlices(Slice.ONE, orders.ONE);
            orders.ChangeAllToWhole(Slice.THREE);

            if (orders.TWO > 0) orders.RemoveSlices(Slice.ONE, orders.ONE);
            orders.ChangeAllToWhole(Slice.TWO);

            if (orders.ONE > 0) orders.AddWhole(1);
            orders.RemoveSlices(Slice.ONE, orders.ONE);
        }

        private static void Ones(Orders orders)
        {
            orders.ChangeToWhole(Slice.ONE, orders.ONE / 6);
        }

        private static void Twos(Orders orders)
        {
            int rmTwos = orders.TWO / 3 * 3;
            orders.ChangeToWhole(Slice.TWO, rmTwos);

            int rmOneTwo = Math.Min(orders.TWO / 2, orders.ONE / 2) * 2;
            orders.RemoveSlices(Slice.ONE, rmOneTwo);
            orders.ChangeToWhole(Slice.TWO, rmOneTwo);

            int rmOne = Math.Min(orders.TWO, orders.ONE / 4) * 4;
            orders.RemoveSlices(Slice.ONE, rmOne);

            orders.ChangeToWhole(Slice.TWO, rmOne);
        }

        private static void Threes(Orders orders)
        {
            int rmThrees = orders.THREE / 2 * 2;
            orders.ChangeToWhole(Slice.THREE, rmThrees);

            int rmTwoOne = Math.Min(orders.THREE, Math.Min(orders.TWO, orders.ONE));
            orders.RemoveSlices(Slice.TWO, rmTwoOne);
            orders.RemoveSlices(Slice.ONE, rmTwoOne);
            orders.ChangeToWhole(Slice.THREE, rmTwoOne);

            int rmOne = Math.Min(orders.THREE, orders.ONE / 3) * 3;
            orders.RemoveSlices(Slice.ONE, rmOne);

            orders.ChangeToWhole(Slice.THREE, rmOne);
        }

        private static void Fours(Orders orders)
        {
            int rmTwos = Math.Min(orders.FOUR, orders.TWO);
            orders.RemoveSlices(Slice.TWO, rmTwos);
            orders.ChangeToWhole(Slice.FOUR, rmTwos);

            int rmOnes = Math.Min(orders.FOUR, orders.ONE / 2) * 2;
            orders.RemoveSlices(Slice.ONE, rmOnes);

            orders.ChangeToWhole(Slice.FOUR, rmOnes);
        }

        private static void Fives(Orders orders)
        {
            int rmOnes = Math.Min(orders.FIVE, orders.ONE);
            orders.RemoveSlices(Slice.ONE, rmOnes);
            orders.ChangeAllToWhole(Slice.FIVE);
        }

        public enum Slice
        {
            ONE, TWO, THREE, FOUR, FIVE
        }
    }
}
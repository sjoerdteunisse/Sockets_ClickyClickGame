/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System;

namespace ClickyClickServer
{
    public class Randomizer
    {
        private static Random _random = new Random();

        /// <summary>
        /// Returns a letter between A - Z
        /// </summary>
        /// <returns></returns>
        public static char GetLetter()
        {
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = _random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }

        /// <summary>
        /// Returns a random number between xMin and xMax
        /// </summary>
        /// <param name="xMin">min on random</param>
        /// <param name="xMax">max of random</param>
        /// <returns></returns>
        public static int GetNumber(int xMin, int xMax)
        {
            return _random.Next(xMin, xMax);
        }
    }
}

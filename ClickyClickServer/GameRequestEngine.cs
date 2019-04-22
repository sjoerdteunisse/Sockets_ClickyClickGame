/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace ClickyClickServer
{
    public class GameRequestEngine
    {
        private static GameRequestEngine _vGameEngineInstance;
        private List<string> highScores = new List<string>();

        public string HandleMove(string dataReceived)
        {
            //For now, as the sequence might be upgraded to a full string, instead of a single char.
            return Randomizer.GetLetter().ToString();
        }

        public void StoreHighScore(string highScore)
        {
            highScores.Add(highScore.Substring("highscore".Length));
            PrintStats();
        }

        public List<int> GetTop10HighScores()
        {
            List<int> topHighScores = highScores.Select(int.Parse).ToList();
            var enumerable = topHighScores.GroupBy(x => x).SelectMany(x => x.OrderBy(z=> z.ToString().Take(10))).ToList();
            return enumerable;
        }

        private void PrintStats()
        {
            Console.WriteLine("\nHigh scores:");

            for (int i = 0; i < highScores.Count; i++)
            {
                Console.WriteLine("score: " + highScores[i]);
            }

            Console.WriteLine("\n");
        }

        //Singleton Instance
        public static GameRequestEngine Instance => _vGameEngineInstance ?? (_vGameEngineInstance = new GameRequestEngine());
    }
}

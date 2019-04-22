/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System;
using System.Drawing;

namespace ClickyClickClient
{
    public class Player
    {
        private int _score;
        private Random _rnd;
        private Color _color;
        private readonly int _posX;
        private readonly int _posY;

        /// <summary>
        /// V2 with running on map
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public Player(int posX, int posY)
        {
            _score = 0;
            _posX = posX;
            _posY = posY;

            _rnd = new Random();
            _color = Color.FromArgb((byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255));
        }

        /// <summary>
        /// V1 
        /// </summary>
        public Player()
        {
            _score = 0;
            _rnd = new Random();
            _color = Color.FromArgb((byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255));
        }

        public int PlayerXPosition => _posX;

        public int PlayerYPosition => _posY;

        public Color PlayerColor => _color;

        public int PlayerScore
        { 
             get => _score;
             set => _score = value;
        }

        public void Reset()
        {
            _score = 0;
        }
    }
}

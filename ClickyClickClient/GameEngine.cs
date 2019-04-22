/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System;
using System.Drawing;
using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace ClickyClickClient
{
    public class GameEngine
    {
        private bool _start;
        private Random _rnd;
        private Player _player;
        private Label _gameText;
        private char _keyToPress;
        private Label _scoreScreen;
        private Label _timeRemaining;
        private TCPClient _tcpClient;
        private Bitmap _gameDrawArea;
        private GUIManager _guiManager;
        private PictureBox _gameScreen;
        private Stopwatch _timeTaken;
        private CountDownTimer _countDownTimer;
        private SpeechSynthesizer _speechSynthesizer;
        private static GameEngine _vGameEngineInstance;


        public void Initialize(PictureBox gameScreen, Label scoreScreen, Label gameText, Label timeRemaining)
        {
            _gameText = gameText;
            _gameScreen = gameScreen;
            _scoreScreen = scoreScreen;
            _timeRemaining = timeRemaining;

            _start = false;
            _rnd = new Random();
            _tcpClient = new TCPClient();
            _player = new Player(20, 20);
            _guiManager = new GUIManager(_gameScreen);

            //Drawing area of game.
            _gameScreen.Image = _gameDrawArea;
            _gameDrawArea = new Bitmap(_gameScreen.Size.Width, _gameScreen.Size.Height);

            //For time measuring the users click time
            _timeTaken = new Stopwatch();
       
            _gameText.Text = "Press W to start";
            _speechSynthesizer = new SpeechSynthesizer();
        }

        /// <summary>
        /// When game is finished, reset the objects.
        /// </summary>
        private void OnGameFinished()
        {
            MessageBox.Show($@"You scored {_player.PlayerScore} ", "", MessageBoxButtons.OK);
            _start = false;
            _scoreScreen.Text = "";
            _gameScreen.Image = _gameDrawArea;
            _gameDrawArea = new Bitmap(_gameScreen.Size.Width, _gameScreen.Size.Height);
            
            //High scores
            //_tcpClient.TransferKeystroke("highscore:" + _player.PlayerScore);

            _player.Reset();
            _gameText.Text = "Press W to start";
        }

        /// <summary>
        /// Set labels, and invalidate to repaint
        /// </summary>
        private void UpdateScreen()
        {
            _scoreScreen.Text = _player.PlayerScore.ToString();
            _scoreScreen.Invalidate();
        }

        /// <summary>
        /// Handle client keyboard click event.
        /// </summary>
        /// <param name="e"></param>
        public void HandleClientKeyAction(KeyPressEventArgs e)
        {
            //When key char is the key that needs to be pressed
            if (e.KeyChar == _keyToPress)
            {
                //Stop taken time
                _timeTaken.Stop();

                //Speak, gimmick.
                _speechSynthesizer.SpeakAsync(e.KeyChar.ToString());

                //Check what the score is that the user receives
                if (_timeTaken.ElapsedMilliseconds < 1200)
                    _player.PlayerScore += 45;

                if (_timeTaken.ElapsedMilliseconds < 1750)
                    _player.PlayerScore += 30;

                if (_timeTaken.ElapsedMilliseconds < 2000)
                    _player.PlayerScore += 15;
                else
                    _player.PlayerScore += 5;

                //Reset timer.
                _timeTaken.Reset();

                try
                {
                    //Send key, so we get a new one.
                    _tcpClient.TransferKeystroke(e.KeyChar.ToString());

                }
                catch (Exception exception)
                {
                    if (exception.InnerException is SocketException)
                        _gameText.Text = "Connection not initiated. Please try again. Press: W";
                }
            }
            else  //When filled in wrong.
            {
                //Penalty deduction
                if (_player.PlayerScore - 10 > 0)
                {
                    _player.PlayerScore -= 10;
                }
            }

            //Refreshes labels
            UpdateScreen();


            //Only true when game is just opened
            //and W is pressed or game is restarted after a game has finished.
            if (e.KeyChar == 119 && !_start)
            {

                try
                {
                    //Send key, so we get a new one.
                    _tcpClient.TransferKeystroke(e.KeyChar.ToString());

                }
                catch (Exception exception)
                {
                    if (exception is SocketException)
                        _gameText.Text = "Connection not initiated. Please try again. Press: W";

                    //Game could not be started due to an exception.
                    return;
                }

                //Set start bool
                _start = true;

                //Start countdown timer and the events
                _countDownTimer = new CountDownTimer(0, 5);
                _countDownTimer.TimeChanged += () => _timeRemaining.Text = _countDownTimer.TimeLeftMsStr;
                _countDownTimer.StepMs = 33;
                _countDownTimer.CountDownFinished += OnGameFinished;
                _countDownTimer.Start();

            }
        }

        /// <summary>
        /// OnReceive new char from server, store it and draw it on the screen.
        /// </summary>
        /// <param name="newString">passed in string that is drawn on screen</param>
        public void OnServerMessageReceived(string newString)
        {
            newString = newString.Replace("\0", string.Empty);
            _keyToPress = newString[0];
            _gameText.Text = "Press the new letter!";

            DrawNewCharacter(newString);

            //Drawn, so call update to check how long user takes to click
            _timeTaken.Start();
        }

        /// <summary>
        /// Draws the new char on the bitmap
        /// </summary>
        /// <param name="newString"></param>
        private void DrawNewCharacter(string newString)
        {
            var c = Color.FromArgb((byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255));
            _guiManager.DrawString(newString[0].ToString(), _rnd.Next(0, _gameDrawArea.Width - 20), _rnd.Next(30, _gameDrawArea.Height - 30), c);
        }

        /// <summary>
        /// Returns the current instance of the engine as singleton
        /// </summary>
        public static GameEngine Instance => _vGameEngineInstance ?? (_vGameEngineInstance = new GameEngine());
    }
}

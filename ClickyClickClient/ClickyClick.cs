/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System.Windows.Forms;

namespace ClickyClickClient
{
    public partial class ClickyClick : Form
    {
        public ClickyClick()
        {
            InitializeComponent();
            GameEngine.Instance.Initialize(pbx_game, lbl_Score, lbl_GameText, lbl_TimeRemaining);
        }

        private void ClickyClick_KeyPress(object sender, KeyPressEventArgs e)
        {
            GameEngine.Instance.HandleClientKeyAction(e);
        }
    }
}

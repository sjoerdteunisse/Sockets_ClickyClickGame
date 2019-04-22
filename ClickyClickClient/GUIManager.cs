/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */

using System.Drawing;
using System.Windows.Forms;

namespace ClickyClickClient
{
    public class GUIManager
    {
        private PictureBox _form;

        public GUIManager(PictureBox form)
        {
            _form = form;
        }

        public void DrawString(string text, int x, int y, Color color)
        {
            DrawString(_form, text, x, y, color);
        }

        public void DrawString(PictureBox target, string text, int x, int y, Color color)
        {
            Graphics formGraphics = target.CreateGraphics();
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(color);
            StringFormat drawFormat = new StringFormat();
            formGraphics.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}

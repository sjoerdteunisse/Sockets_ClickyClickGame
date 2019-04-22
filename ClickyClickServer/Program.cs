/*
 * Copyright (c) 2019. All rights reserved.
 * Author: Sjoerd Teunisse
 * Contact details: sjoerdteunisse at googleMailDns server dot com
 */


namespace ClickyClickServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServerCore serverCore = new TCPServerCore();
            serverCore.Initialize();
        }
    }
}

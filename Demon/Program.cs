﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DemonForm());
        }
    }
}
//-------------------------------------------------//
// Name : Md Rubaiyat Bin Sattar;   ID : 11789005  //
//------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DXApplicationTangche.UC.门店下单.form;
using DXApplicationTangche.UC.任务;
using DXApplicationTangche.原型;

namespace DXApplicationTangche
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

            BonusSkins.Register();
            Application.Run(new FluentMainFrame());
            //Application.Run(new OrderQA());

        }
    }
}

using System;
using System.Windows.Forms;
using OfficeOpenXml;
using Hospital_Management.PL;

namespace Hospital_Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set the EPPlus license context for non-commercial use
            ExcelPackage.License.SetNonCommercialPersonal("Cursor AI");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PL.Form1());
        }
    }
}
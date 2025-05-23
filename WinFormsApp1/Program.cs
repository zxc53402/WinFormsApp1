using WinFormsApp1.ªì¦¸½m²ß;
using WinFormsApp1.ª«¥ó½m²ß;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new createorders());

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //login frm = new login();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new frmMain());
            //}
        }
    }
}
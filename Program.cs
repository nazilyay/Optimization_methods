using Optimization_methods.Bit_Method;
using Optimization_methods.Dichotomies_Method;
using Optimization_methods.Middle_Methods;

namespace Optimization_methods
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
            //Application.Run(new GraphForm_Middle("Sin(x) + 2", 0.1, 2, 5));
            Application.Run(new MenuForms());
        }
    }


}


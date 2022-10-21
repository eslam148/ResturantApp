using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new AddSeller());
            //  Application.Run(new spplier());
            //   Application.Run(new Bill());
             Application.Run(new Inventory());
            //Application.Run(new AddItem());

            
            // Application.Run(new ReturnedItem());


        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WORK_ONE.Models;
using WORK_ONE.Views;

namespace WORK_ONE.View_Models
{
    public static class AuthViewModel
    {
        public static bool Log_in(string pass)
        {
            if (pass != String.Empty && pass != null)
            {
                if (pass == "0000")
                {
                    MainWindow main = new MainWindow(pass);
                    main.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный код..");
                }
            }
            else
            {
                MainWindow main = new MainWindow(pass);
                main.Show();
                return true;
            }
            return false;

        }
    }
}

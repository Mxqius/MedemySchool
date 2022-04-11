using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;

namespace MedemySchool
{
    public static class TextBoxValueCheck
    {
        public static async Task<bool> CheckAccountFields(Control _control)
        {
            return await Task.Run<bool>(() =>
            {
                foreach (Control control in _control.Controls)
                {
                    if (control.GetType() == typeof(BunifuTextBox))
                    {
                        if (((BunifuTextBox)control).Text == string.Empty || ((BunifuTextBox)control).Text.Equals("") || ((BunifuTextBox)control).Text.StartsWith(" "))
                            return false;
                    }
                }

                return true;
            });
        }
        public static async Task<bool> CheckAccountFields(Control _control, BunifuTextBox passControl)
        {
            return await Task.Run<bool>(() =>
            {
                foreach (Control control in _control.Controls)
                {
                    if (control.GetType() == typeof(BunifuTextBox))
                    {
                        if (((BunifuTextBox)control).Name != passControl.Name)
                            if (((BunifuTextBox)control).Text == string.Empty || ((BunifuTextBox)control).Text.Equals("") || ((BunifuTextBox)control).Text.StartsWith(" "))
                                return false;
                    }
                }

                return true;
            });
        }
        public static async Task<bool> CheckGunaTextBoxs(Control _control, BunifuTextBox passControl)
        {
            return await Task.Run<bool>(() =>
            {
                foreach (Control control in _control.Controls)
                {
                    if (control.GetType() == typeof(Guna2TextBox))
                    {
                        if (((Guna2TextBox)control).Name != passControl.Name)
                            if (((Guna2TextBox)control).Text == string.Empty || ((Guna2TextBox)control).Text.Equals("") || ((Guna2TextBox)control).Text.StartsWith(" "))
                                return false;
                    }
                }

                return true;
            });
        }
    }
}

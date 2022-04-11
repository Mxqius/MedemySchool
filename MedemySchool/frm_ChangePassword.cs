using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedemySchool
{
    public partial class frm_ChangePassword : Form
    {

        // Class Time And Date
        TimeAndDate TimeAndDate = new TimeAndDate();
        // Class Convert Image 
        ImageMethodSql ims = new ImageMethodSql();
        // Object Interface
        ISqlMehtods SqlCommands;
        // Class for SendEamil
        SendEmail email = new SendEmail();
        // Bool Show Password Checked
        bool ShowPassword = false;
        // Code Send 
        int Code = 0;
        public frm_ChangePassword()
        {
            InitializeComponent();
            SqlCommands = new _SqlCommands();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool PasswordLengthCheck(string password)
        {
            if (password.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool SaveChanges(int ID, string Role)
        {
            try
            {
                switch (Role)
                {
                    case "Manager":

                        SqlCommands.EditAdmins(ID, Information.Name, txt_new_password.Text, Information.FirstName, Information.LastName, Information.PhoneNumber,
                                  Information.Email, Information.Address, Information.NationalCode, GenderCheck(), 1, ims.ConvertImageToByte(Information.Picture), Information.DateOfBirthDay, 1, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                    case "Admin":
                        SqlCommands.EditAdmins(ID, Information.Name, txt_new_password.Text, Information.FirstName, Information.LastName, Information.PhoneNumber,
                                  Information.Email, Information.Address, Information.NationalCode, GenderCheck(), 1, ims.ConvertImageToByte(Information.Picture), Information.DateOfBirthDay, 0, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                    case "Student":
                        SqlCommands.EditStudents(ID, Information.Name, txt_new_password.Text, Information.FirstName, Information.LastName, Information.PhoneNumber,
                                  Information.Email, Information.Address, Information.NationalCode, GenderCheck(), 1, ims.ConvertImageToByte(Information.Picture), Information.DateOfBirthDay, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                    case "Teacher":
                        SqlCommands.EditTeachers(ID, Information.Name, txt_new_password.Text, Information.FirstName, Information.LastName, Information.PhoneNumber,
                                  Information.Email, Information.Address, Information.NationalCode, GenderCheck(), 1, ims.ConvertImageToByte(Information.Picture), Information.DateOfBirthDay, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                }
                GetData();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        int GenderCheck()
        {
            if (Information.Gender == "Male")
                return 1;
            else
                return 0;
        }
        bool GetData()
        {
            GetAccountData gad = new GetAccountData();
            bool check = gad.GetData(Information.Name, Information.Password);
            return check;
        }
        int RandomCode()
        {
            Random r = new Random();
            Code = r.Next(100000, 999999);
            return Code;
        }
        void VisibleChange(bool statePassword, bool stateCode)
        {
            txt_new_password.Visible = lbl_old_pass.Visible = lbl_new_pass.Visible = btn_confirm.Visible = txt_oldPassword.Visible = btn_show_password.Visible = statePassword;
            btn_confirm_code.Visible = txt_code.Visible = lbl_code.Visible = stateCode;
        }
        void NextStep()
        {
            VisibleChange(false, true);
            lbl_log.ForeColor = Color.Orange;
            lbl_log.Text = "Check your email to see the code sent";
        }
        Task<bool> SendMail()
        {
            return Task.Run<bool>(() =>
            {
                return email.SendEmailTo(Information.Email, "Password Change", $"Hello, according to your password change request, you must confirm your request.\n \tYour code:{RandomCode()}");
            });
        }

        private bool CheckCodeEmpty()
        {
            if (txt_code.Text == string.Empty || txt_code.Text.StartsWith(" ") || txt_code.Text.Equals(""))
                return false;
            return true;
        }
        private async void btn_confirm_Click(object sender, EventArgs e)
        {
            bool Check = await TextBoxValueCheck.CheckAccountFields(this, txt_code);
            if (!Check)
            {
                lbl_log.Text = "Fields is Empty";
                return;
            }
            bool checkpass = PasswordLengthCheck(txt_new_password.Text);
            if (checkpass)
            {
                if (MessageBox.Show("Are You Sure ?\nYou must log in again after changing your password", "Password Changing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txt_oldPassword.Text == Information.Password)
                    {
                        NextStep();
                        await SendMail();
                    }
                    else
                    {
                        lbl_log.ForeColor = Color.Red;
                        lbl_log.Text = "The previous password is incorrect";
                    }
                }
            }
            else
            {
                lbl_log.ForeColor = Color.Red;
                lbl_log.Text = "The password entered is weak";
            }

        }

        private void btn_show_password_Click(object sender, EventArgs e)
        {
            ShowPassword = !ShowPassword;
            if (ShowPassword)
            {
                txt_new_password.PasswordChar = '\0';
            }
            else
            {
                txt_new_password.PasswordChar = '*';
            }
        }

        private void btn_confirm_code_Click(object sender, EventArgs e)
        {
            if (!CheckCodeEmpty())
            {
                lbl_log.Text = "Fields is Empty";
                return;
            }
            if (txt_code.Text == Code.ToString())
            {
                bool check = SaveChanges(Information.ID, Information.Role);
                lbl_log.ForeColor = Color.Green;
                lbl_log.Text = "Your account password was changed successfully";
                Application.Restart();
            }
            else
            {
                lbl_log.ForeColor = Color.Red;
                lbl_log.Text = "Code is wrong , please try again";
            }
        }
        void OnlyDigit(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDigit(sender, e);
        }
    }
}

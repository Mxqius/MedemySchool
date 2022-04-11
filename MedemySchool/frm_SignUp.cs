using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedemySchool;
namespace MedemySchool
{
    public partial class frm_SignUp : Form
    {
        // Image Class
        ImageMethodSql ims = new ImageMethodSql();
        // Clas Time And Date
        TimeAndDate TimeAndDate = new TimeAndDate();
        // Class Send Email
        SendEmail email = new SendEmail();
        // Interface
        ISqlMehtods SqlCommands;
        // Code Email Confirm
        int Code = 0;
        // Email Send
        bool sendEmail = false;
        public frm_SignUp()
        {
            InitializeComponent();
            SqlCommands = new _SqlCommands();
        }
        bool CheckEmailSingleStudent()
        {
            return CheckEmailExist.CheckEmailSingleStudent(txt_email.Text);
        }
        bool CheckEmailSingleTeacher()
        {
            return CheckEmailExist.CheckEmailSingleTeacher(txt_email.Text);
        }
        bool CheckEmpty()
        {
            if (txt_username.Text == string.Empty || txt_password.Text == string.Empty || txt_email.Text == string.Empty || txt_confirm_password.Text == string.Empty)
            {
                return true;
            }
            return false;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ChangeVisible(bool signup, bool code)
        {
            txt_password.Visible = txt_username.Visible = txt_email.Visible = gb_gender.Visible = gb_role.Visible = lbl_username.Visible = lbl_password.Visible = lbl_confirm_password.Visible = lbl_email.Visible = txt_confirm_password.Visible = btn_signup.Visible = signup;
            txt_code.Visible = lbl_code.Visible = lbl_resend.Visible = btn_confirm_code.Visible = code;
        }
        int RandomCode()
        {
            Random r = new Random();
            Code = r.Next(100000, 999999);
            return Code;
        }
        Task<bool> EmailSendAsync(string title, string bodyMessage)
        {
            return Task.Run<bool>(() =>
            {
                SendEmail email = new SendEmail();
                bool Send = email.SendEmailTo(txt_email.Text, title, bodyMessage);
                sendEmail = Send;
                return Send;
            });
        }
        bool ConfirmCode()
        {
            if (txt_code.Text == Code.ToString())
                return true;
            return false;
        }
        bool RegisterUser()
        {
            if (txt_confirm_password.Text == txt_password.Text)
            {
                ChangeVisible(false, true);
                return true;
            }
            return false;
        }
        int GenderCheck()
        {
            if (rb_man.Checked)
                return 1;
            return 0;
        }
        int RoleCheck()
        {
            if (rb_student.Checked)
                return 1;
            return 0;
        }
        bool PasswordLengthCheck(string password)
        {
            if (password.Length >= 8)
                return true;
            return false;
        }
        private async void btn_signup_Click(object sender, EventArgs e)
        {
            if (!await TextBoxValueCheck.CheckGunaTextBoxs(this, txt_code))
            {
                lbl_log.ForeColor = Color.Orange;
                lbl_log.Text = "Please Fill All Fields";
                return;
            }
            bool checkemail = CheckEmailInput();
            if (!checkemail)
            {
                bool pcheck = PasswordLengthCheck(txt_password.Text);
                if (!pcheck)
                {
                    lbl_log.ForeColor = Color.Red;
                    lbl_log.Text = "The password entered is weak";
                    return;
                }
                bool Register = RegisterUser();
                if (!Register)
                {
                    lbl_log.ForeColor = Color.Red;
                    lbl_log.Text = "The password entered does not match";
                }
                else
                {
                    lbl_back_to_signup.Visible = true;
                    bool check = await EmailSendAsync("Confirm You Email", String.Format("Your Code : {0}", RandomCode()));
                    if (check)
                    {
                        lbl_log.ForeColor = Color.Green;
                        lbl_log.Text = "Please Check You Email For Code";
                    }
                    else
                    {
                        lbl_log.ForeColor = Color.Red;
                        lbl_log.Text = "There was a problem sending the confirmation email";
                    }
                }
            }
            else
            {
                lbl_log.Text = "An account has already been registered with this email";
            }

        }
        bool CheckEmailInput()
        {
            if (RoleCheck() == 1)
            {
                return CheckEmailSingleStudent();
            }
            return CheckEmailSingleTeacher();
        }
        bool FinalyRegister()
        {
            if (RoleCheck() == 1)
            {
                SqlCommands.AddStudents(txt_username.Text.TrimEnd(), txt_password.Text, String.Empty, String.Empty, String.Empty, txt_email.Text, String.Empty, String.Empty, GenderCheck(), 1, ims.ConvertImageToByte(Properties.Resources.defult_profile), Convert.ToDateTime("2022-1-1"), TimeAndDate.GetDate(), TimeAndDate.GetTime());
                return true;
            }
            else
            {
                SqlCommands.AddTeachers(txt_username.Text.TrimEnd(), txt_password.Text, String.Empty, String.Empty, String.Empty, txt_email.Text, String.Empty, String.Empty, GenderCheck(), 1, ims.ConvertImageToByte(Properties.Resources.defult_profile), Convert.ToDateTime("2022-1-1"), TimeAndDate.GetDate(), TimeAndDate.GetTime());
                return true;
            }
        }
        bool StrongPassword(string password)
        {
            PasswordScore PasswordScore = PasswordAdvisor.CheckStrength(password);
            switch (PasswordScore)
            {
                case PasswordScore.Blank:
                    return false;
                case PasswordScore.Weak:
                    return false;
                case PasswordScore.VeryWeak:
                    return false;
            }
            return true;

        }

        bool CheckCodeEmpty()
        {
            if (txt_code.Text == string.Empty || txt_code.Text.StartsWith(" "))
                return false;
            return true;
        }
        private async void btn_confirm_code_Click(object sender, EventArgs e)
        {
            if (sendEmail)
            {
                if (CheckCodeEmpty())
                {
                    bool check = ConfirmCode();
                    if (check)
                    {
                        bool checkRegister = FinalyRegister();
                        if (checkRegister)
                        {
                            lbl_log.ForeColor = Color.Green;
                            lbl_log.Text = "Account created successfully";
                            await EmailSendAsync("Register", @"Your account was created successfully.
Thank you. This is an email from the app. 
Please do not reply.");
                            this.Close();
                        }
                    }
                }
                else
                {
                    lbl_log.ForeColor = Color.Red;
                    lbl_log.Text = "Please Enter Code";
                }
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

        private void lbl_back_to_signup_Click(object sender, EventArgs e)
        {
            ChangeVisible(true, false);
            lbl_back_to_signup.Visible = false;
            Code = 0;
            RestLog();
        }
        void RestLog()
        {
            lbl_log.Text = String.Empty;
        }

        private async void lbl_resend_Click(object sender, EventArgs e)
        {
            bool check = await EmailSendAsync("Confirm You Email", String.Format("Your Code : {0}", RandomCode()));
            if (check)
            {
                lbl_log.ForeColor = Color.Green;
                lbl_log.Text = "Confirmation Email Resend For You";
            }
        }
    }

}
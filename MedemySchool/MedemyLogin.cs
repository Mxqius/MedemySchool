using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;

namespace MedemySchool
{
    public partial class MedemyLogin : Form
    {
        // Time And Date Object
        private TimeAndDate TimeAndDate = new TimeAndDate();
        // Class Convert Image 
        ImageMethodSql ims = new ImageMethodSql();
        // Query String 
        string query = "";
        //Connection String 
        private static string sqlcon = _SqlConnection.ConnectionString;
        // false = login page
        // true = captcha page
        bool StateForm = false;
        int numberCaptcha = 0;
        int Wrong = 1;
        // SqlConnection
        private SqlConnection sq = new SqlConnection(sqlcon);
        public MedemyLogin()
        {
            InitializeComponent();
            Visible(false, false);
            lbl_title.Text = "Please Choose Role ";
        }
        bool Login(string Role)
        {
            if (Role == "Admin")
                query = $"SELECT * FROM uvw_ShowAdmins WHERE AdminName = @Username and AdminPassword = @Password and AdminRole = 0";
            else if (Role == "Student")
                query = $"SELECT * FROM uvw_ShowStudents WHERE StudentName = @Username and StudentPassword = @Password";
            else if (Role == "Manager")
                query = $"SELECT * FROM uvw_ShowAdmins WHERE AdminName = @Username and AdminPassword = @Password and AdminRole = 1";
            else if (Role == "Teacher")
                query = $"SELECT * FROM uvw_ShowTeachers WHERE TeacherName = @Username and TeacherPassword = @Password";
            try
            {
                SqlCommand sc = new SqlCommand(query, sq);
                CheckSqlScStatus();
                SqlDataAdapter sda = new SqlDataAdapter(query, sq);
                sda.SelectCommand.Parameters.AddWithValue("@Username", txt_username.Text);
                sda.SelectCommand.Parameters.AddWithValue("@Password", txt_password.Text);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GetData(query);
                    sq.Close();
                    return true;
                }
                sq.Close();
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem connecting to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        void CheckSqlScStatus()
        {
            if (sq.State == ConnectionState.Open)
                sq.Close();
            else
                sq.Open();
        }
        bool GetData(string query)
        {
            GetAccountData gad = new GetAccountData();
            GetAccountData.Query = query;
            bool check = gad.GetData(txt_username.Text, txt_password.Text);
            Information.LoginDate = TimeAndDate.GetDate();
            Information.LoginTime = TimeAndDate.GetTime();
            return check;
        }
        void VisibleRoleSelectPage(bool state)
        {
            btn_confirm_role.Visible = lbl_role.Visible = cb_role.Visible = state;
        }
        bool CheckCaptcha()
        {
            if (txt_captcha.Text.Trim() == numberCaptcha.ToString())
                return true;
            return false;
        }
        private int loadCaptchaImage()
        {
            Random r1 = new Random();
            int number = r1.Next(100000, 999999);
            var image = new Bitmap(this.pic_captcha.Width, this.pic_captcha.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            pic_captcha.Image = image;
            return number;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MedemyLogin_Load(object sender, EventArgs e)
        {
            numberCaptcha = loadCaptchaImage();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            numberCaptcha = loadCaptchaImage();
        }
        void Visible(bool Captcha, bool login)
        {

            btn_refresh.Visible = txt_captcha.Visible = pic_captcha.Visible = lbl_captcha.Visible = btn_confirm_captcha.Visible = Captcha;
            btn_login.Visible = txt_password.Visible = lbl_signup.Visible = txt_username.Visible = lbl_password.Visible = lbl_username.Visible = login;
        }
        void LoginMethod()
        {
            bool Check = CheckEmpty();
            if (Check)
                return;
            bool CheckData = Login(Information.Role);
            if (CheckData)
            {
                if (Information.Status == "Deactive")
                {
                    lbl_log.Text = "Your account is inactive. Please contact the\nsystem administrator.";
                    return;
                }
                StateForm = true;
                Visible(true, false);
                lbl_title.Text = "Please Enter Captcha";
                lbl_back.Visible = true;
                lbl_log.Text = String.Empty;
                numberCaptcha = loadCaptchaImage();
                lbl_back_to_select_role.Visible = false;
            }
            else
            {
                lbl_log.Text = "Wrong username or password";
                txt_password.Focus();
                txt_password.Clear();
            }

        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            LoginMethod();
        }
        private Task<bool> CheckBot()
        {
            return Task.Run<bool>(() =>
            {
                System.Threading.Thread.Sleep(10000);
                return true;
            });
        }
        bool CheckEmptyCaptcha()
        {
            if (txt_captcha.Text == String.Empty)
            {
                return false;
            }
            return true;
        }
        async void CaptchaConfirm()
        {
            bool Empty = CheckEmptyCaptcha();
            if (!Empty)
            {
                lbl_log.Text = "Fields is empty";
                return;
            }
            bool Check = CheckCaptcha();
            if (Check)
            {
                MedemyMain MDM = new MedemyMain();
                this.Hide();
                MDM.ShowDialog();
            }
            else
            {
                numberCaptcha = loadCaptchaImage();
                lbl_log.Text = "Wrong Code";
                if (Wrong > 3)
                {

                    btn_confirm_captcha.Enabled = false;
                    txt_captcha.Text = string.Empty;
                    txt_captcha.Enabled = false;
                    bool DelayEnd = await CheckBot();
                    if (DelayEnd)
                    {
                        btn_confirm_captcha.Enabled = true;
                        txt_captcha.Text = string.Empty;
                        txt_captcha.Enabled = true;
                        Wrong = 0;
                    }
                    return;
                }
                Wrong++;
            }

        }
        private void btn_confirm_captcha_Click(object sender, EventArgs e)
        {
            CaptchaConfirm();
        }
        void IsDigit(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        bool CheckEmpty()
        {
            if (txt_password.Text == String.Empty || txt_username.Text == String.Empty)
            {
                lbl_log.Text = "Fields is empty";
                return true;
            }
            return false;
        }
        void LoginWithKeyboard(object send, KeyEventArgs e, bool Pos)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Pos)
                {
                    LoginMethod();
                }
                else
                {
                    CaptchaConfirm();
                }
            }
        }
        private void txt_captcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigit(sender, e);
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            lbl_title.Text = "Please Login First";
            txt_captcha.Text = String.Empty;
            StateForm = false;
            Visible(false, true);
            lbl_back.Visible = false;
            lbl_log.Text = String.Empty;
            lbl_back_to_select_role.Visible = true;
        }

        private void MedemyLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (cb_role.Visible == false)
            {
                if (!StateForm)
                    LoginWithKeyboard(sender, e, true);
                else
                    LoginWithKeyboard(sender, e, false);
            }
        }
        void ConfirmRole()
        {
            VisibleRoleSelectPage(false);
            Visible(false, true);
            lbl_back_to_select_role.Visible = true;
            lbl_title.Text = "Please Login First";
            // GET DATA 
            Information.Role = cb_role.Text;

        }
        private void btn_confirm_role_Click(object sender, EventArgs e)
        {
            ConfirmRole();
            if (Information.Role == "Manager" || Information.Role == "Admin")
            {
                lbl_signup.Visible = false;
            }

        }
        private void lbl_back_to_select_role_Click(object sender, EventArgs e)
        {
            lbl_title.Text = "Please Choose Role ";
            lbl_back_to_select_role.Visible = false;
            Visible(false, false);
            VisibleRoleSelectPage(true);
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            frm_SignUp fsu = new frm_SignUp();
            fsu.ShowDialog();
        }
    }
}

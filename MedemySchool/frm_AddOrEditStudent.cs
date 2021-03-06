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
    public partial class frm_AddOrEditStudent : Form
    {
        // Time And Date Object
        TimeAndDate TimeAndDate = new TimeAndDate();
        ImageMethodSql ims = new ImageMethodSql();
        bool Gender;
        bool Status;
        ISqlMehtods SqlCommands;
        public bool EditMode = false;
        public int ID = 0;
        public frm_AddOrEditStudent()
        {
            InitializeComponent();
            SqlCommands = new _SqlCommands();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        void SetGender()
        {
            if (!Gender)
            {
                rb_woman.Checked = true;
            }
            else
            {
                rb_man.Checked = true;
            }
        }
        void SetStatus()
        {
            if (!Status)
            {
                rb_deactive.Checked = true;
            }
            else
            {
                rb_active.Checked = true;
            }
        }
        private void frm_AddOrEditStudent_Load(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                lbl_title.Text = "Add Student";
            }
            else
            {
                lbl_title.Text = "Edit Student";
                DataTable dt = SqlCommands.StudentSelectRow(ID);
                if (dt.Rows[0][11].ToString() == "Male")
                    Gender = true;
                else
                    Gender = false;
                if (dt.Rows[0][12].ToString() == "Active")
                    Status = true;
                else
                    Status = false;
                txt_username.Text = dt.Rows[0][1].ToString();
                txt_password.Text = dt.Rows[0][2].ToString();
                txt_firstname.Text = dt.Rows[0][3].ToString();
                txt_lastname.Text = dt.Rows[0][4].ToString();
                txt_email.Text = dt.Rows[0][5].ToString();
                txt_phonenumber.Text = dt.Rows[0][6].ToString();
                txt_nationalcode.Text = dt.Rows[0][7].ToString();
                txt_address.Text = dt.Rows[0][8].ToString();
                dp_date_birth.Text = dt.Rows[0][9].ToString();
                pic_student.Image = ims.ConvertByteToImage((byte[])dt.Rows[0][10], Properties.Resources.defult_profile);
                SetGender();
                SetStatus();
            }
        }

        int GenderCheck()
        {
            if (rb_man.Checked)
            {
                return 1;
            }
            return 0;
        }
        int StatusCheck()
        {
            if (rb_active.Checked)
            {
                return 1;
            }
            return 0;
        }
        void Clear()
        {
            txt_address.Text = txt_email.Text = txt_lastname.Text = txt_firstname.Text = txt_nationalcode.Text = txt_password.Text = txt_username.Text = txt_phonenumber.Text = txt_email.Text = String.Empty;
        }
        bool EditStudent()
        {
            try
            {
                SqlCommands.EditStudents(ID, txt_username.Text, txt_password.Text, txt_firstname.Text, txt_lastname.Text, txt_phonenumber.Text,
                          txt_email.Text, txt_address.Text, txt_nationalcode.Text, GenderCheck(), StatusCheck(), ims.ConvertImageToByte(pic_student.Image), dp_date_birth.Value, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        bool AddStudent()
        {
            try
            {
                SqlCommands.AddStudents(txt_username.Text, txt_password.Text, txt_firstname.Text, txt_lastname.Text, txt_phonenumber.Text,
                          txt_email.Text, txt_address.Text, txt_nationalcode.Text, GenderCheck(), StatusCheck(), ims.ConvertImageToByte(pic_student.Image), dp_date_birth.Value, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            bool check = CheckEmpty();
            if (!check)
            {
                if (!EditMode)
                {
                    bool res = AddStudent();
                    if (res)
                    {
                        Clear();
                        txt_username.Focus();
                        lbl_log.ForeColor = Color.Green;
                        lbl_log.Text = "New student added successfully";
                    }
                    else
                    {
                        lbl_log.ForeColor = Color.Red;
                        lbl_log.Text = "There was a problem adding a new student, please try again";
                    }
                }
                else
                {
                    bool res = EditStudent();
                    if (res)
                    {
                        lbl_log.ForeColor = Color.Green;
                        lbl_log.Text = "Student information changed successfully";
                    }
                    else
                    {
                        lbl_log.ForeColor = Color.Red;
                        lbl_log.Text = "There was a problem changing the student information. Please try again";
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_upload_pic_Click(object sender, EventArgs e)
        {
            if (ofd_picture.ShowDialog() == DialogResult.OK)
            {
                pic_student.Image = Image.FromFile(ofd_picture.FileName);
            }
        }
        bool CheckEmpty()
        {
            if (txt_username.Text == string.Empty || txt_password.Text == string.Empty || txt_phonenumber.Text == string.Empty ||
                txt_email.Text == string.Empty || txt_firstname.Text == string.Empty || txt_lastname.Text == string.Empty ||
                txt_address.Text == string.Empty || txt_nationalcode.Text == string.Empty)
            {
                lbl_log.ForeColor = Color.Red;
                lbl_log.Text = "Please fill in all fields";
                return true;

            }
            return false;
        }
        void OnlyDigit(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txt_phonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDigit(sender, e);
        }
    }
}

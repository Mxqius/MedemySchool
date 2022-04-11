using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using IWshRuntimeLibrary;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;


namespace MedemySchool
{
    public partial class MedemyMain : Form
    {
        // Class Convert Image 
        ImageMethodSql ims = new ImageMethodSql();
        // Class Time and Date
        TimeAndDate TimeAndDate = new TimeAndDate();
        // Object Interface
        ISqlMehtods SqlCommands;
        // Path Application
        string PathShortcut = Application.StartupPath + "\\MedemySchool.exe";
        public MedemyMain()
        {
            InitializeComponent();
            SqlCommands = new _SqlCommands();
        }
        void LoadData()
        {
            lbl_role_dashboard.Text = "Role : " + Information.Role;
            lbl_user_welcome.Text = "Welcome : " + Information.FirstName;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void PermissionRoles()
        {
            switch (Information.Role)
            {
                case "Manager":
                    lbl_total_student.Visible = lbl_total_female.Visible = lbl_select_class.Visible =
                        lbl_total_male.Visible = cb_class_select.Visible = false;
                    break;
                case "Admin":
                    lbl_total_student.Visible = lbl_total_female.Visible = lbl_select_class.Visible =
                        lbl_total_male.Visible = cb_class_select.Visible = false;
                    break;
                case "Student":
                    lbl_total_student.Visible = lbl_total_female.Visible = lbl_select_class.Visible =
                        lbl_total_male.Visible = cb_class_select.Visible = false;
                    break;
                case "Teacher":
                    lbl_total_student.Visible = lbl_total_female.Visible = lbl_select_class.Visible =
                        lbl_total_male.Visible = cb_class_select.Visible = true;
                    break;
            }
        }
        int RoleCheck()
        {
            switch (Information.Role)
            {
                case "Manager":
                    return 1;
                case "Admin":
                    return 2;
                case "Student":
                    return 3;
                case "Teacher":
                    return 4;
                default:
                    return 0;
            }
        }
        void LoadDashboard()
        {
            int Role = RoleCheck();
            if (Role == 1)
            {
                lbl_blue_count.Text = SqlCommands.RowCountAdmins().ToString();
                lbl_green_count.Text = SqlCommands.RowCountTeachers().ToString();
                lbl_orange_count.Text = SqlCommands.RowCountStudents().ToString();
            }
        }
        private void MedemyMain_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            LoadData();
            LoadDashboard();
            PermissionRoles();

        }

        private void MedemyMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            page_control.SetPage(0);
            LoadDashboard();
            lbl_title_main.Text = "Dashboard";
            lbl_title_main.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            page_control.SetPage(1);
            lbl_title_main.Text = "Students";
            lbl_title_main.TextAlign = ContentAlignment.MiddleLeft;
            Refresh("Students", dgv_students);
        }

        private void btn_course_Click(object sender, EventArgs e)
        {
            page_control.SetPage(2);
        }

        private void btn_score_Click(object sender, EventArgs e)
        {
            page_control.SetPage(3);
        }

        private void btn_admins_Click(object sender, EventArgs e)
        {
            page_control.SetPage(4);
            lbl_title_main.Text = "Admins";
            lbl_title_main.TextAlign = ContentAlignment.MiddleLeft;
            Refresh("Admins", dgv_admins);
        }

        private void btn_teachers_Click(object sender, EventArgs e)
        {
            page_control.SetPage(5);
            lbl_title_main.Text = "Teachers";
            lbl_title_main.TextAlign = ContentAlignment.MiddleLeft;
            Refresh("Teachers", dgv_teacher);
        }
        void LoadDataAccount()
        {
            txt_username.Text = Information.Name;
            txt_password.Text = Information.Password;
            txt_email.Text = Information.Email;
            txt_firstname.Text = Information.FirstName;
            txt_lastname.Text = Information.LastName;
            txt_phonenumber.Text = Information.PhoneNumber;
            txt_ntc.Text = Information.NationalCode;
            txt_address.Text = Information.Address;
            if (Information.Gender == "Male")
                rb_man.Checked = true;
            else
                rb_woman.Checked = true;
            lbl_role.Text = Information.Role;
            pic_profile.Image = Information.Picture;
            dp_date_birth.Value = Information.DateOfBirthDay;

        }
        bool SaveChanges(int ID, string Role)
        {
            try
            {
                switch (Role)
                {
                    case "Manager":

                        SqlCommands.EditAdmins(ID, Information.Name, Information.Password, txt_firstname.Text, txt_lastname.Text, txt_phonenumber.Text,
                                  txt_email.Text, txt_address.Text, txt_ntc.Text, GenderCheck(), 1, ims.ConvertImageToByte(pic_profile.Image), dp_date_birth.Value, 1, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                    case "Admin":
                        SqlCommands.EditAdmins(ID, Information.Name, Information.Password, txt_firstname.Text, txt_lastname.Text, txt_phonenumber.Text,
                                  txt_email.Text, txt_address.Text, txt_ntc.Text, GenderCheck(), 1, ims.ConvertImageToByte(pic_profile.Image), dp_date_birth.Value, 0, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                    case "Student":
                        SqlCommands.EditStudents(ID, Information.Name, Information.Password, txt_firstname.Text, txt_lastname.Text, txt_phonenumber.Text,
                                  txt_email.Text, txt_address.Text, txt_ntc.Text, GenderCheck(), 1, ims.ConvertImageToByte(pic_profile.Image), dp_date_birth.Value, TimeAndDate.GetDate(), TimeAndDate.GetTime());
                        break;
                    case "Teacher":
                        SqlCommands.EditTeachers(ID, Information.Name, Information.Password, txt_firstname.Text, txt_lastname.Text, txt_phonenumber.Text,
                                  txt_email.Text, txt_address.Text, txt_ntc.Text, GenderCheck(), 1, ims.ConvertImageToByte(pic_profile.Image), dp_date_birth.Value, TimeAndDate.GetDate(), TimeAndDate.GetTime());
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
        bool GetData()
        {
            GetAccountData gad = new GetAccountData();
            bool check = gad.GetData(Information.Name, Information.Password);
            return check;
        }
        int GenderCheck()
        {
            if (rb_man.Checked)
                return 1;
            else
                return 0;
        }
        private void btn_account_Click(object sender, EventArgs e)
        {
            page_control.SetPage(6);
            lbl_title_main.Text = "Account";
            lbl_title_main.TextAlign = ContentAlignment.TopCenter;
            LoadDataAccount();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            page_control.SetPage(7);
            // Check Settings
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (registryKey.GetValue("MedemySchool") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                cb_runStartup.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                cb_runStartup.Checked = true;
            }
            registryKey.Close();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_AddOrEditStudent frm_addedit = new frm_AddOrEditStudent();
            if (frm_addedit.ShowDialog() == DialogResult.OK)
            {
                Refresh("Students", dgv_students);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            frm_AddOrEditStudent frm_addedit = new frm_AddOrEditStudent();
            if (dgv_students.CurrentRow.Cells[0].Value.ToString() != null)
            {
                frm_addedit.ID = int.Parse(dgv_students.CurrentRow.Cells[0].Value.ToString());
                frm_addedit.EditMode = true;
                if (frm_addedit.ShowDialog() == DialogResult.OK)
                {
                    Refresh("Students", dgv_students);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Refresh(string ViewName, DataGridView dgvName)
        {
            dgvName.DataSource = SqlCommands.SelectAll(ViewName);
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh("Students", dgv_students);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlCommands.DeleteStudents(int.Parse(dgv_students.CurrentRow.Cells[0].Value.ToString()));
        }

        private void btn_refresh_admin_Click(object sender, EventArgs e)
        {
            Refresh("Admins", dgv_admins);
        }

        private void btn_add_admin_Click(object sender, EventArgs e)
        {
            frm_AddOrEditAdmin fad = new frm_AddOrEditAdmin();
            if (fad.ShowDialog() == DialogResult.OK)
            {
                Refresh("Admins", dgv_admins);
            }
        }

        private void btn_edit_admin_Click(object sender, EventArgs e)
        {
            frm_AddOrEditAdmin frm_addedit = new frm_AddOrEditAdmin();
            if (dgv_admins.CurrentRow.Cells[0].Value.ToString() != null)
            {
                frm_addedit.ID = int.Parse(dgv_admins.CurrentRow.Cells[0].Value.ToString());
                frm_addedit.EditMode = true;
                if (frm_addedit.ShowDialog() == DialogResult.OK)
                {
                    Refresh("Admins", dgv_admins);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_admin_Click(object sender, EventArgs e)
        {
            SqlCommands.DeleteAdmins(int.Parse(dgv_admins.CurrentRow.Cells[0].Value.ToString()));
        }
        private void btn_add_teacher_Click(object sender, EventArgs e)
        {
            frm_AddOrEditTeacher fda = new frm_AddOrEditTeacher();
            if (fda.ShowDialog() == DialogResult.OK)
            {
                Refresh("Teachers", dgv_teacher);
            }
        }
        private void btn_edit_teacher_Click(object sender, EventArgs e)
        {
            frm_AddOrEditTeacher frm_addedit = new frm_AddOrEditTeacher();
            if (dgv_teacher.CurrentRow.Cells[0].Value.ToString() != null)
            {
                frm_addedit.ID = int.Parse(dgv_teacher.CurrentRow.Cells[0].Value.ToString());
                frm_addedit.EditMode = true;
                if (frm_addedit.ShowDialog() == DialogResult.OK)
                {
                    Refresh("Teachers", dgv_teacher);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btn_delete_teacher_Click(object sender, EventArgs e)
        {
            if (dgv_teacher.CurrentRow != null)
                SqlCommands.DeleteTeachers(int.Parse(dgv_teacher.CurrentRow.Cells[0].Value.ToString()));
        }

        private void btn_refresh_teacher_Click(object sender, EventArgs e)
        {
            Refresh("Teachers", dgv_teacher);
        }
        bool CheckEmailSingleStudent()
        {
            return CheckEmailExist.CheckEmailSingleStudent(txt_email.Text);
        }
        bool CheckEmailSingleTeacher()
        {
            return CheckEmailExist.CheckEmailSingleTeacher(txt_email.Text);
        }
        bool EmailCheckSingle()
        {
            int role = RoleCheck();
            if (role == 3)
            {
                return CheckEmailExist.CheckEmailSingleStudentAccount(txt_email.Text, Information.ID);
            }
            else if (role == 4)
            {
                return CheckEmailExist.CheckEmailSingleTeacherAccount(txt_email.Text, Information.ID);
            }
            else
            {
                return CheckEmailExist.CheckEmailSingleAdminAccount(txt_email.Text, Information.ID);
            }
        }
        Task<bool> EmailSendAsync(string title, string bodyMessage)
        {
            return Task.Run<bool>(() =>
            {
                SendEmail email = new SendEmail();
                bool Send = email.SendEmailTo(txt_email.Text, title, bodyMessage);
                return Send;
            });
        }


        private async void btn_save_change_Click(object sender, EventArgs e)
        {
            if (!await TextBoxValueCheck.CheckAccountFields(tp_account))
            {
                MessageBox.Show("Please fill in all fields to record changes !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool res = EmailCheckSingle();
                if (!res)
                {
                    if (MessageBox.Show("Are You Sure ?", "Warning", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveChanges(Information.ID, Information.Role);
                        await EmailSendAsync("Save Changes", @"Changes to your account were successful
thank you
Please do not reply to this email");
                    }
                }
                else
                {
                    MessageBox.Show("An account has already been registered with this email", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_rest_fields_Click(object sender, EventArgs e)
        {
            LoadDataAccount();
        }

        private void btn_upload_picture_Click(object sender, EventArgs e)
        {
            if (ofd_picture.ShowDialog() == DialogResult.OK)
            {
                pic_profile.Image = Image.FromFile(ofd_picture.FileName);
            }
        }

        private void btn_remove_picture_profile_Click(object sender, EventArgs e)
        {
            pic_profile.Image = Properties.Resources.defult_profile;
        }

        private void btn_change_password_Click(object sender, EventArgs e)
        {
            frm_ChangePassword frm = new frm_ChangePassword();
            frm.ShowDialog();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        void OnlyDigit(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txt_ntc_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDigit(sender, e);
        }

        private void cb_runStartup_CheckedChanged(object sender, EventArgs e)
        {
            Shortcut Shortcut = new Shortcut();
            Shortcut.CreateShortcut("MedemySchool", Application.StartupPath, PathShortcut);
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (cb_runStartup.Checked)
            {
                registryKey.SetValue("MedemySchool", Application.StartupPath + @"\MedemySchool.lnk");
            }
            else
            {
                registryKey.DeleteValue("MedemySchool");
            }
            registryKey.Close();
        }

        private void txt_search_admin_TextChange(object sender, EventArgs e)
        {
            List<uvw_ShowAdmins> uvwS = new List<uvw_ShowAdmins>();
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                uvwS = mse.uvw_ShowAdmins.Where(n => n.AdminName.Contains(txt_search_admin.Text) || n.AdminFirstName.Contains(txt_search_admin.Text) || n.AdminLastName.Contains(txt_search_admin.Text)).ToList();
            }
            dgv_admins.DataSource = uvwS;
        }

        private void txt_search_teacher_TextChanged(object sender, EventArgs e)
        {
            List<uvw_ShowTeachers> uvwS = new List<uvw_ShowTeachers>();
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                uvwS = mse.uvw_ShowTeachers.Where(n => n.TeacherName.Contains(txt_search_teacher.Text) || n.TeacherFirstName.Contains(txt_search_teacher.Text) || n.TeacherLastName.Contains(txt_search_teacher.Text)).ToList();
            }
            dgv_teacher.DataSource = uvwS;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            List<uvw_ShowStudents> uvwS = new List<uvw_ShowStudents>();
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                uvwS = mse.uvw_ShowStudents.Where(n => n.StudentName.Contains(txt_search.Text) || n.StudentFirstName.Contains(txt_search.Text) || n.StudentLastName.Contains(txt_search.Text)).ToList();
            }
            dgv_students.DataSource = uvwS;
        }

        private void pbl_status_MouseMove(object sender, MouseEventArgs e)
        {
            pnl_status.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void pbl_status_MouseLeave(object sender, EventArgs e)
        {
            pnl_status.BackColor = Color.FromArgb(23, 205, 830);
        }
    }
}

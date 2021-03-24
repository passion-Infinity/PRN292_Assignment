using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PresentationLayer.Presenter;

namespace PresentationLayer.Views.Admin
{
    public partial class FormAccount : Form, IAccountView
    {
        DataTable da;
        string flag;
        string profile;
        string absolutePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        int index;
        AccountPresenter accountPresenter;
        public FormAccount()
        {
            InitializeComponent();
        }

        public string UserID { get => txtUserID.Text; set => txtUserID.Text = value; }
        public string FullName { get => txtFullName.Text; set => txtFullName.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public string Phone { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string IdentityCard { get => txtIdentity.Text; set => txtIdentity.Text = value; }
        private string GetGender()
        {
            string result = "Female";
            if (rdMale.Checked)
            {
                result = "Male";
            }
            return result;
        }
        public string Gender { get => GetGender(); }
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public string Image { get => profile; set => profile = value; }
        public bool Status { get => chkStatus.Checked; set => chkStatus.Checked = value; }
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value; MessageBox.Show(_message, "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public string Search { get => txtSearch.Text; set => txtSearch.Text = value; }


        private bool CheckData()
        {
            if (string.IsNullOrEmpty(txtUserID.Text.Trim()) || string.IsNullOrEmpty(txtFullName.Text.Trim())
                || string.IsNullOrEmpty(txtPassword.Text.Trim()) || string.IsNullOrEmpty(txtPhone.Text.Trim())
                    || string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(txtAddress.Text.Trim())
                    || string.IsNullOrEmpty(txtIdentity.Text.Trim()))
            {
                MessageBox.Show("All fields are required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Text = txtUserID.Text.Trim();
                txtFullName.Text = txtFullName.Text.Trim();
                txtPassword.Text = txtPassword.Text.Trim();
                txtPhone.Text = txtPhone.Text.Trim();
                txtEmail.Text = txtEmail.Text.Trim();
                txtAddress.Text = txtAddress.Text.Trim();
                txtIdentity.Text = txtIdentity.Text.Trim();
                return false;
            }
            if (!Regex.IsMatch(txtPhone.Text, @"\d{8,15}"))
            {
                MessageBox.Show("Phone is not avaliable", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"\w+([-._])?(\w+)?@\w{3,7}\.\w{3,7}(\.\w{3,7})?(\.\w{3,7})?"))
            {
                MessageBox.Show("Email is not avaliable", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtIdentity.Text, @"\d{12}"))
            {
                MessageBox.Show("Identity Card is not avaliable", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdentity.Focus();
                return false;
            }
            return true;
        }
        private void ControlBlock()
        {
            btnAdd.Enabled = false;
            btnAdd.BackColor = default;

            btnUpdate.Enabled = false;
            btnUpdate.BackColor = default;

            btnDelete.Enabled = false;
            btnDelete.BackColor = default;

            btnSave.Enabled = true;
            btnSave.Cursor = Cursors.Hand;
            btnSave.BackColor = Color.FromArgb(128, 128, 255);

            btnCancel.Enabled = true;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.BackColor = Color.Gray;

            txtUserID.Enabled = false;
            txtFullName.Enabled = true;
            txtPassword.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtIdentity.Enabled = true;
            txtAddress.Enabled = true;
            rdFemale.Enabled = true;
            rdMale.Enabled = true;
            rdMale.Checked = true;
            chkStatus.Enabled = true;
            chkStatus.Checked = true;

            btnUpload.Enabled = true;
            btnUpload.BackColor = Color.Gray;
        }
        private void UnControlBlock()
        {
            btnAdd.Enabled = true;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.BackColor = Color.LimeGreen;

            btnUpdate.Enabled = true;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.BackColor = Color.DeepSkyBlue;

            btnDelete.Enabled = true;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.BackColor = Color.Crimson;

            btnSave.Enabled = false;
            btnSave.BackColor = default;

            btnCancel.Enabled = false;
            btnCancel.BackColor = default;

            txtUserID.Enabled = false;
            txtFullName.Enabled = false;
            txtPassword.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtIdentity.Enabled = false;
            txtAddress.Enabled = false;
            rdFemale.Enabled = false;
            rdMale.Enabled = false;
            chkStatus.Enabled = false;

            btnUpload.Enabled = false;
            btnUpload.BackColor = default;
            btnUpload.Cursor = Cursors.Hand;
        }
        private void Clear()
        {
            txtUserID.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtIdentity.Text = "";
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }
        private void GetAllAccounts()
        {
            accountPresenter = new AccountPresenter(this);
            da = accountPresenter.GetAll();
            dgvAccounts.DataSource = da;
            dgvAccounts.Columns[2].Visible = false;
            dgvAccounts.Columns[8].Visible = false;
        }
        private void FormAccount_Load(object sender, EventArgs e)
        {
            UnControlBlock();
            GetAllAccounts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flag = "add";
            ControlBlock();
            Clear();
            txtUserID.Enabled = true;
            txtUserID.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                MessageBox.Show("Please choose data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = "edit";
            ControlBlock();
            txtFullName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                MessageBox.Show("Please choose data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Do you want to delete ?", "Announce", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                accountPresenter = new AccountPresenter(this);
                accountPresenter.DisableAccountForAdmin();
                GetAllAccounts();
                UnControlBlock();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                {
                    accountPresenter = new AccountPresenter(this);
                    if (flag == "add")
                    {
                        accountPresenter.RegisterAccountForAdmin();
                        GetAllAccounts();
                        UnControlBlock();
                    }
                    else if (flag == "edit")
                    {
                        accountPresenter.UpdateAccountForAdmin();
                        GetAllAccounts();
                        UnControlBlock();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    MessageBox.Show(txtUserID.Text + "'s already existed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            UnControlBlock();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Select a Image";
                openFile.Filter = "jpg files (*.jpg)|*.jpg|png files(*.png)|*.png|All files (*.*)|*.*";
                openFile.FileName = "Choose image";
                string appPath = absolutePath + @"\Resources\Images\";
                if (Directory.Exists(appPath) == false)
                {
                    Directory.CreateDirectory(appPath);
                }
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string iName = openFile.SafeFileName;
                        string extension = iName.Split(".")[1];
                        string imageName = txtUserID.Text + "(" + RandomString(10, true) + ")" + "." + extension;
                        string filepath = openFile.FileName;
                        File.Copy(filepath, appPath + imageName, true);
                        ptProfile.Image = new Bitmap(appPath + imageName);
                        profile = @"\Resources\Images\" + imageName;

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Unable to open file " + exp.Message);
                    }
                }
                else
                {
                    openFile.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Please enter UserID before uploading profile", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvAccounts.CurrentCell == null ? -1 : dgvAccounts.CurrentCell.RowIndex;
            if (index > -1 && dgvAccounts.RowCount > 0)
            {
                txtUserID.Text = dgvAccounts.Rows[index].Cells[0].Value.ToString();
                txtFullName.Text = dgvAccounts.Rows[index].Cells[1].Value.ToString();
                txtPassword.Text = dgvAccounts.Rows[index].Cells[2].Value.ToString();
                txtPhone.Text = dgvAccounts.Rows[index].Cells[3].Value.ToString();
                txtEmail.Text = dgvAccounts.Rows[index].Cells[4].Value.ToString();
                txtIdentity.Text = dgvAccounts.Rows[index].Cells[5].Value.ToString();

                rdMale.Checked = true;
                if (dgvAccounts.Rows[index].Cells[6].Value.ToString() == "Female")
                {
                    rdFemale.Checked = true;
                }

                txtAddress.Text = dgvAccounts.Rows[index].Cells[7].Value.ToString();

                try
                {
                    profile = dgvAccounts.Rows[index].Cells[8].Value.ToString();
                    ptProfile.Image = new Bitmap(absolutePath + profile);
                    chkStatus.Checked = false;
                    if (bool.Parse(dgvAccounts.Rows[index].Cells[10].Value.ToString()))
                    {
                        chkStatus.Checked = true;
                    }
                }
                catch (Exception)
                {
                    ptProfile.Image = new Bitmap(absolutePath + @"\Resources\Images\default.png");
                }

                UnControlBlock();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            accountPresenter = new AccountPresenter(this);
            da = accountPresenter.FindByName();
            dgvAccounts.DataSource = da;
        }
    }
}

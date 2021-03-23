using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReservationAPI.BLL;
using ReservationDTO.DTO;
using ReservationManagement.Presenters;

namespace ReservationManagement.Views.Admin
{
    public partial class Account : Form, IAccountForm
    {
        DataTable da;
        AccountPresenter accountPresenter;

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
        public string Gender { get => GetGender();}
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public string Image { get => ptProfile.ToString(); set => throw new NotImplementedException(); }
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

        public Account()
        {
            InitializeComponent();
        }

        private void GetAll()
        {
            accountPresenter = new AccountPresenter(this);
            da = accountPresenter.GetAllAccount();
            dgvAccounts.DataSource = da;
        }
        private bool ValidationData() {
            if(string.IsNullOrEmpty(txtUserID.Text.Trim()))
            {
                MessageBox.Show("User ID is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Text = "";
                txtUserID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                MessageBox.Show("Full Name is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullName.Text = "";
                txtFullName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Phone is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Text = "";
                txtPhone.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Text = "";
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtIdentity.Text.Trim()))
            {
                MessageBox.Show("Identity Card is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdentity.Text = "";
                txtIdentity.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("Address is a required field.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Text = "";
                txtAddress.Focus();
                return false;
            }
            return true;        
        }

        private void Account_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            accountPresenter = new AccountPresenter(this);
            accountPresenter.RegisterAccountForAdmin();
            GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

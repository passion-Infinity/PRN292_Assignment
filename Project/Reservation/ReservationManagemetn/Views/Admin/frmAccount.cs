using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReservationAPI.BLL;
using ReservationDTO.DTO;

namespace ReservationManagement.Views.Admin
{
    public partial class Account : Form
    {
        DataTable da;
        UserBLL userBLL = new UserBLL();

        public Account()
        {
            InitializeComponent();
        }

        private void GetAll()
        {
            da = userBLL.GetAll();
            dgvAccounts.DataSource = da;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

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

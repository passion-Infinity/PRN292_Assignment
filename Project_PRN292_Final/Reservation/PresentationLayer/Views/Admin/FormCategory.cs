using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.Views.Admin;
using PresentationLayer.Presenter;

namespace PresentationLayer.Views.Admin
{
    public partial class FormCategory : Form, ICategoryView
    {
        DataTable da;
        int index;
        CategoryPresenter categoryPresenter;
        public FormCategory()
        {
            InitializeComponent();
        }

        public string RoomTypeID { get => txtTypeID.Text; set => txtTypeID.Text = value; }
        public string RoomTypeName { get => txtTypeName.Text; set => txtTypeName.Text = value; }
        public int People { get => (int)txtPeople.Value; set => txtPeople.Value = value; }
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value; MessageBox.Show(_message, "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty(txtTypeName.Text.Trim()))
            {
                MessageBox.Show("Type Name is a required field.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTypeName.Text = "";
                txtTypeName.Focus();
                return false;
            }
            return true;
        }
        private void UnControlBlock()
        {
            btnAdd.Cursor = Cursors.Hand;
            btnUpdate.Cursor = Cursors.Hand;
            btnRefresh.Cursor = Cursors.Hand;

            txtTypeID.Enabled = false;
        }
        private void Clear()
        {
            txtTypeID.Text = "";
            txtTypeName.Text = "";
            txtPeople.Value = 1;
            txtTypeName.Focus();
        }

        private void GetAllCategories()
        {
            categoryPresenter = new CategoryPresenter(this);
            da = categoryPresenter.GetAll();
            dgvCategories.DataSource = da;
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            UnControlBlock();
            GetAllCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                categoryPresenter = new CategoryPresenter(this);
                categoryPresenter.AddNewRoomType();
                GetAllCategories();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    MessageBox.Show(txtTypeName.Text + "'s already existed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                categoryPresenter = new CategoryPresenter(this);
                categoryPresenter.UpdateRoomType();
                GetAllCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvCategories.CurrentCell == null ? -1 : dgvCategories.CurrentCell.RowIndex;
            if (index > -1 && dgvCategories.RowCount > 0)
            {
                txtTypeID.Text = dgvCategories.Rows[index].Cells[0].Value.ToString();
                txtTypeName.Text = dgvCategories.Rows[index].Cells[1].Value.ToString();
                txtPeople.Value = int.Parse(dgvCategories.Rows[index].Cells[2].Value.ToString());
                UnControlBlock();
            }
        }
    }
}

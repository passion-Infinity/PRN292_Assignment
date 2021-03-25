using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PresentationLayer.Views.Admin;
using PresentationLayer.Presenter;
using System.IO;

namespace PresentationLayer.Views.Admin
{
    public partial class FormRoom : Form, IRoomView
    {
        float price;
        int index;
        string flag;
        int valueOfComboBox;
        DataTable da;
        RoomPresenter roomPresenter;
        string profile;
        string absolutePath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));


        public FormRoom()
        {
            InitializeComponent();
        }
        public string RoomID { get => txtRoomID.Text; set => txtRoomID.Text = value; }
        public int Category { get => valueOfComboBox; set => valueOfComboBox = value; }
        public float Price { get => float.Parse(txtPrice.Text); set => price = value; }
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
            if (string.IsNullOrEmpty(txtRoomID.Text.Trim()) || string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show("All fields are required.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRoomID.Text = "";
                txtPrice.Text = "";
                return false;
            }
            if(!Regex.IsMatch(txtPrice.Text, @"[1-9]{1,}(\.?[0-9]+)?"))
            {
                MessageBox.Show("Price is not avaliable.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return false;
            }
            return true;
        }
        private void Clear()
        {
            txtRoomID.Text = "";
            txtPrice.Text = "";
            cbRoomType.SelectedIndex = 0;
            chkStatus.Checked = true;
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

            txtRoomID.Enabled = false;
            txtPrice.Enabled = true;
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

            txtRoomID.Enabled = false;
            txtPrice.Enabled = false;
            chkStatus.Enabled = false;

            btnUpload.Enabled = false;
            btnUpload.BackColor = default;
            btnUpload.Cursor = Cursors.Hand;

        }

        private void LoadDataCombobox()
        {
            roomPresenter = new RoomPresenter(this);
            cbRoomType.DataSource = roomPresenter.GetAllCategories();
            cbRoomType.DisplayMember = "RoomTypeName";
            cbRoomType.ValueMember = "RoomTypeID";
        }

        private void GetAllRooms()
        {
            roomPresenter = new RoomPresenter(this);
            da = roomPresenter.GetAllRooms();
            dgvRooms.DataSource = da;
        }

        private void FormRoom_Load(object sender, EventArgs e)
        {
            UnControlBlock();
            LoadDataCombobox();
            GetAllRooms();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flag = "add";
            ControlBlock();
            Clear();
            txtRoomID.Enabled = true;
            txtRoomID.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomID.Text.Trim()))
            {
                MessageBox.Show("Please choose data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = "edit";
            ControlBlock();
            txtPrice.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomID.Text.Trim()))
            {
                MessageBox.Show("Please choose data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Do you want to delete ?", "Announce", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                roomPresenter = new RoomPresenter(this);
                roomPresenter.DeleteRoom();
                GetAllRooms();
                UnControlBlock();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            price = float.Parse(txtPrice.Text);
            valueOfComboBox = cbRoomType.SelectedIndex + 1;
            try
            {
                if (CheckData())
                {
                    roomPresenter = new RoomPresenter(this);
                    if (flag == "add")
                    {
                        roomPresenter.AddNewRoom();
                        GetAllRooms();
                        UnControlBlock();
                    }
                    else if (flag == "edit")
                    {
                        roomPresenter.UpdateRoom();
                        GetAllRooms();
                        UnControlBlock();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    MessageBox.Show(txtRoomID.Text + "'s already existed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            roomPresenter = new RoomPresenter(this);
            da = roomPresenter.FindByRoomID();
            dgvRooms.DataSource = da;
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvRooms.CurrentCell == null ? -1 : dgvRooms.CurrentCell.RowIndex;
            if (index > -1 && dgvRooms.RowCount > 0)
            {
                txtRoomID.Text = dgvRooms.Rows[index].Cells[0].Value.ToString();
                cbRoomType.Text =dgvRooms.Rows[index].Cells[1].Value.ToString();
                txtPrice.Text = dgvRooms.Rows[index].Cells[2].Value.ToString();
                try
                {
                    profile = dgvRooms.Rows[index].Cells[3].Value.ToString();
                    ptRoom.Image = new Bitmap(absolutePath + profile);
                }
                catch (Exception)
                {
                    ptRoom.Image = new Bitmap(absolutePath + @"\Resources\Images\default1.png");
                }
                try
                {
                    chkStatus.Checked = bool.Parse(dgvRooms.Rows[index].Cells[4].Value.ToString());
                }
                catch
                {
                    chkStatus.Checked = false;
                }
                UnControlBlock();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRoomID.Text.Trim()))
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
                        string random = DateTime.Now.ToFileTime() + "";
                        string imageName = txtRoomID.Text + "_" + random + "." + extension;
                        string filepath = openFile.FileName;
                        File.Copy(filepath, appPath + imageName, true);
                        ptRoom.Image = new Bitmap(appPath + imageName);
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
                MessageBox.Show("Please enter RoomID before uploading profile", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

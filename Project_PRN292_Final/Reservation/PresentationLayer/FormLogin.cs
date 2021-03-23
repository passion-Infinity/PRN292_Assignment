using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataObjects.DAOimpl;

namespace PresentationLayer
{
    public partial class FormLogin : Form
    {
        DataTable da;
        AccountDAO dao = new AccountDAO();
        public FormLogin()
        {
            InitializeComponent();
            GetAll();
        }

        private void GetAll()
        {
            da = dao.GetAll();
            dataGridView1.DataSource = da;
        }
    }
}

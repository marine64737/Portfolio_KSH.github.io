using Mission5Lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission5.View
{
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            dgvBook.DataSource = BookDAO.GetInstance().GetAll();
            var bookId = dgvBook.CurrentRow.Cells[0].Value;
            var bookCopy = BookCopyDAO.GetInstance().Get(Convert.ToInt32(bookId));
            dgvBookCopy.DataSource = BookCopyDAO.GetInstance().GetAll();
        }
    }
}

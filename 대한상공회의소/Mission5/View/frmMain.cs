using Mission5.View;
using Mission5Lib.Model;
using System;
using System.Windows.Forms;

namespace Mission5
{
    public partial class frmMain : Form
    {
        private Member searchedMember;
        private BookCopy searchedBookCopy;
        private Book searchedBook;
        private int limit = 3;
        private Librarian lib;

        public frmMain(Librarian emp)
        {
            InitializeComponent();
            lib = emp;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnCheckOut.Enabled = false;
            btnReturn.Enabled = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes) Application.Exit();
            else e.Cancel = true;
        }

        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            var memDAO = MemberDAO.GetInstance();
            searchedMember = memDAO.Get(txtMemberId.Text);
            if (searchedMember != null)
            {
                lblMemberName.Text = searchedMember.Name;
                lblPhoneNo.Text = searchedMember.PhoneNo;

                RefreshGrid();
            }
            else MessageBox.Show("해당하는 회원이 존재하지 않습니다.", "검색 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void RefreshGrid()
        {
            var memCheckDAO = MemberCheckOutDAO.GetInstance();
            var memCheckOut = memCheckDAO.GetCheckOutSummary(searchedMember.Id);

            lblNumOfCheckOut.Text = memCheckOut.NumOfBookCheckOut.ToString();
            lblNumOfAvailable.Text = memCheckOut.NumOfBookAvailable.ToString();
            lblNumOfOverdue.Text = memCheckOut.NumOfBookOverdue.ToString();
            lblDaysOfOverdue.Text = memCheckOut.DaysOfOverdue.ToString();
            lblOverdueFee.Text = memCheckOut.OverdueFee.ToString();

            dgvBookList.DataSource = memCheckDAO.GetCheckOutBookInfoList(searchedMember.Id);
            if (memCheckDAO.GetCheckOutBookInfoList(searchedMember.Id).Count == 0)
                btnReturn.Enabled = false;
            else btnReturn.Enabled = true;

            if (Convert.ToInt32(lblNumOfCheckOut.Text) >= limit || Convert.ToInt32(lblNumOfOverdue.Text) > 0)
                btnCheckOut.Enabled = false;
        }
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            var bookCopyDAO = BookCopyDAO.GetInstance();
            searchedBookCopy = bookCopyDAO.Get(txtBookCopyCode.Text);
            if (searchedBookCopy != null)
            {
                var bookDAO = BookDAO.GetInstance();
                searchedBook = bookDAO.Get(searchedBookCopy.BookId);
                lblTitle.Text = searchedBook.Title;
                lblPublisher.Text = searchedBook.Publisher;

                if (lblNumOfCheckOut.Text != "")
                {
                    if (searchedBookCopy.BookStatus > 0)
                    {
                        btnCheckOut.Enabled = false;
                        MessageBox.Show("대출 중인 도서입니다.", "대출 중", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (Convert.ToInt32(lblNumOfCheckOut.Text) >= limit || Convert.ToInt32(lblNumOfOverdue.Text) > 0)
                            btnCheckOut.Enabled = false;
                        else btnCheckOut.Enabled = true;
                    }
                }
            }
            else MessageBox.
                    Show("일치하는 책이 없습니다.", "검색 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var checkOut = new CheckOut
            {
                MemberId = searchedMember.Id,
                BookCopyId = searchedBookCopy.Id,
                CheckOutDate = DateTime.UtcNow.AddHours(9),
                DueDate = DateTime.UtcNow.AddDays(7),
                LibrarianId = lib.Id
            };
            CheckOutDAO.GetInstance().Add(checkOut);

            searchedBookCopy.BookStatus = 1;
            BookCopyDAO.GetInstance().Update(searchedBookCopy);

            RefreshGrid();
            if (Convert.ToInt32(lblNumOfCheckOut.Text) >= limit || searchedBookCopy.BookStatus > 0)
                btnCheckOut.Enabled = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int checkId = Convert.ToInt32(dgvBookList.CurrentRow.Cells[0].Value);
            int bookCode = Convert.ToInt32(dgvBookList.CurrentRow.Cells[1].Value);
            string title = dgvBookList.CurrentRow.Cells[2].Value.ToString();
            DateTime checkDate = Convert.ToDateTime(dgvBookList.CurrentRow.Cells[3].Value);
            DateTime dueDate = Convert.ToDateTime(dgvBookList.CurrentRow.Cells[4].Value);
            int lateDays = Convert.ToInt32(dgvBookList.CurrentRow.Cells[5].Value);
            int lateFee = Convert.ToInt32(dgvBookList.CurrentRow.Cells[6].Value);

            var checkOutDAO = CheckOutDAO.GetInstance();
            var checkOut = checkOutDAO.Get(Convert.ToInt32(checkId));
            checkOut.ReturnDate = DateTime.UtcNow.AddHours(9);
            checkOut.OverdueDays = lateDays;
            checkOut.OverdueCharge = lateFee;
            CheckOutDAO.GetInstance().Update(checkOut);

            var bookCopy = BookCopyDAO.GetInstance().Get(bookCode.ToString());
            bookCopy.BookStatus = 0;
            BookCopyDAO.GetInstance().Update(bookCopy);

            dgvBookList.DataSource = MemberCheckOutDAO.GetInstance().GetCheckOutBookInfoList(searchedMember.Id);

            RefreshGrid();
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            var form = new frmBook();
            form.Show();
        }
    }
}

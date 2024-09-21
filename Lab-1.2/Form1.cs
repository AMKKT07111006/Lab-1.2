using System.Diagnostics;

namespace Lab_1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
            //hiển thị danh sách các process ₫ang chạy khi vừa mở cửa sổ form lên
            DisplayProcess();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //tạo form duyệt chọn file khả thi cần chạy
            OpenFileDialog dlg = new OpenFileDialog();
            //hiển thị form duyệt chọn file khả thi cần chạy
            DialogResult ret = dlg.ShowDialog();
            //kiểm tra quyết ₫ịnh của người dùng, nếu người dùng chọn OK thì ghi nhận tên file
            if (ret == DialogResult.OK)
                txtPath.Text = dlg.FileName;
        }

        void DisplayProcess()
        {
            //xóa nội dung cũ của ListBox
            lbOutput.Items.Clear();
            //tìm danh sách các process ₫ang chạy
            Process[] plist = Process.GetProcesses();
            //hiển thị tên, ID của từng process
            foreach (Process process in plist)
            {
                lbOutput.Items.Add(process.ProcessName + ", " + process.Id);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //tạo mới ₫ối tượng quản lý Process.
            Process myProcess = new Process();
            try
            {
                //thiết lập ₫ường dẫn file cần chạy
                myProcess.StartInfo.FileName = txtPath.Text;
                //kích hoạt process
                myProcess.Start();
                //hiển thị danh sách các process ₫ang chạy
                DisplayProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //hiển thị danh sách các process ₫ang chạy
            DisplayProcess();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //xác ₫ịnh tên, ID của process ₫ang ₫ược chọn ₫ể xóa
            String[] param = lbOutput.SelectedItem.ToString().Split(',');
            //tìm ₫ối tượng quản lý process có ID xác ₫ịnh
            Process proc = Process.GetProcessById(Int32.Parse(param[1]));
            //xóa process
            proc.Kill();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
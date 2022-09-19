using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static DataTable GetData(string sqlCommand)
        {
            string connectionString = "Data Source = (localdb)\\ProjectModels; Initial Catalog = school;" + "Integrated Security = SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;

        }

        private void InitializeDataGridView()
        {
            try
            {
                //建立DataGridView控件
                dataGridView1.Dock = DockStyle.Fill;
                //自动生成DataGridView列
                dataGridView1.AutoGenerateColumns = true;
                //建立数据源
                bindingSource1.DataSource = GetData("select * from student");
                dataGridView1.DataSource = bindingSource1;
                //自动调整可视化行
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                //设置DataGridView控件的边界
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;
                //当用户使用DataGridView控件时，它会成为可编辑模式
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (SqlException ex)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }
    }
}

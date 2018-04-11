using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CelularCliente
{
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=prova;Data Source=LAB-08-04");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            String sql = "select * from ClienteCelular";
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataSet setar = new DataSet();
            conn.Open();
            adap.Fill(setar);
            dataGridView1.DataSource = setar;
            dataGridView1.DataMember = setar.Tables[0].TableName;
            conn.Close();

        }
    }
}

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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=prova;Data Source=LAB-08-04");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            String sql = "select * from clientes";
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataSet setar = new DataSet();
            conn.Open();
            adap.Fill(setar);
            dataCliente.DataSource = setar;
            dataCliente.DataMember = setar.Tables[0].TableName;
            conn.Close();

        }
    }
}

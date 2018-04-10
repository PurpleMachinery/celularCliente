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
    public partial class frmCelular : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=prova;Data Source=LAB-08-04");
        public frmCelular()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String sql = "insert into celulares (nome,marca,modelo,versao) values ('" + txtNome.Text + "','" + txtMarca.Text + "','" + txtModelo.Text + "','" + txtVersao.Text + "')";
            SqlCommand comando = new SqlCommand(sql, conn);
            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }
    }
}

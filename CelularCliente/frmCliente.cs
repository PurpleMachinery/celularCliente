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
    public partial class frmCliente : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=prova;Data Source=LAB-08-04");
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String nome = txtNome.Text;
            String cpf = txtCpf.Text;
            String sexoS = cmbSexo.Text;
            char sexo = ' ' ;
            if(sexoS.Length>=1)sexo = sexoS.ElementAt(0);
            String anoMatricula = txtAno.Text;
            String rg = txtRg.Text;
            String endereco = txtEndereco.Text;           
            String sql = "insert into clientes (nome, cpf, sexo, anoMatricula, rg, endereco) values ('" + nome + "','" + cpf + "','" + sexo + "','" + anoMatricula + "','" + rg + "','" + endereco + "')";
            SqlCommand comando = new SqlCommand(sql, conn);
            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();

            
        }
    }
}

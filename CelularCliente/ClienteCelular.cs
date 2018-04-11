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
    public partial class ClienteCelular : Form
    {
        SqlConnection conn = new SqlConnection("Password=info211;Persist Security Info=True;User ID=sa;Initial Catalog=prova;Data Source=LAB-08-04");
        String idCliente = "";
        public ClienteCelular()
        {
            InitializeComponent();
        }

        private void ClienteCelular_Load(object sender, EventArgs e)
        {
            String sql = "select * from clientes";
            SqlCommand comando = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader data = comando.ExecuteReader();
            while (data.Read())
            {
                cmbClientes.Items.Add(""+data.GetInt32(0)+" / "+data.GetString(1));
            }
            conn.Close();

            String sqlExistentes = "select * from celulares";
            SqlCommand comando2 = new SqlCommand(sqlExistentes, conn);
            conn.Open();
            SqlDataReader data2 = comando2.ExecuteReader();
            while(data2.Read())
            {
                lbExiste.Items.Add(data2.GetInt32(0) + " / " + data2.GetString(1) + " / " + data2.GetString(2) + " / " + data2.GetString(3) + " / " + data2.GetString(4));
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] dados = lbExiste.Text.Split('/');
            String[] cliente = cmbClientes.Text.Split('/');

            String sql = "insert into ClienteCelular values ('" + cliente[0] + "','" + dados[0] + "')";
            SqlCommand comando2 = new SqlCommand(sql, conn);
            conn.Open();
            comando2.ExecuteNonQuery();
            conn.Close();
            atualizar(dados[0], cliente[0]);
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] dados = lbExiste.Text.Split('/');
            String[] cliente = cmbClientes.Text.Split('/');
            String sql = "select cpf from clientes where pk_idCliente = '" + cliente[0] + "'";
            SqlCommand comando = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader cpf = comando.ExecuteReader();
            cpf.Read();
            txtCpf.Text = cpf.GetString(0);
            conn.Close();
            atualizar(""+1, cliente[0]);
        }

        private void atualizar(String pkCelular, String pkCliente)
        {
            lbPossui.Items.Clear();
            String sqlExistentes = "select celulares.nome, clientes.nome from ClienteCelular join celulares on ClienteCelular.fk_idCelular = " + pkCelular + " join clientes on ClienteCelular.fk_idCliente = "+pkCliente;
            SqlCommand comando2 = new SqlCommand(sqlExistentes, conn);
            conn.Open();
            SqlDataReader data2 = comando2.ExecuteReader();
            while (data2.Read())
            {
                lbPossui.Items.Add(data2.GetString(0) + " / " + data2.GetString(1));
            }
            conn.Close();
        }
    }
}

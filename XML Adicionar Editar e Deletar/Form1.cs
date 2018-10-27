using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquivoXML
{
    public partial class Form1 : Form
    {
        Pessoas pessoa = new Pessoas();

        public object ExcluirPessoa { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(txtCodigo.Value > 0)
            {
             pessoa.ExcluirPessoa(Convert.ToInt32(txtCodigo.Value));
                gridPessoas.DataSource = pessoa.ListarPessoas();

            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridPessoas.DataSource = pessoa.ListarPessoas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa()
            {
                codigo = Convert.ToInt32(txtCodigo.Value),
                nome = txtNome.Text,
                telefone = textTelefone.Text
            };
            pessoa.AdicionarPessoas(p);
            gridPessoas.DataSource = pessoa.ListarPessoas();
        }

        private void gridPessoas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = gridPessoas.Rows[e.RowIndex].Cells[0].Value.ToString();
            string nome = gridPessoas.Rows[e.RowIndex].Cells[1].Value.ToString();
            string telefone = gridPessoas.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCodigo.Value = Convert.ToInt32(codigo);
            txtNome.Text = nome;

            textTelefone.Text = telefone;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa()
            {
                codigo = Convert.ToInt32(txtCodigo.Value),
                nome = txtNome.Text,
                telefone = textTelefone.Text
            };
            pessoa.EditarPessoa(p);
            gridPessoas.DataSource = pessoa.ListarPessoas();

        }
    }
}

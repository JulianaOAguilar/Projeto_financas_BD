using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRojeto_funancas_BD
{
    public partial class Form1 : Form
    {
        // ✅ Lista de transações no nível da classe
        private List<Transacao> listaTransacoes = new List<Transacao>();

        float balance = 0.00f;

        public Form1()
        {
            InitializeComponent();
            balanceLabel.Text = balance.ToString("C2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data.Format = DateTimePickerFormat.Custom;
            data.CustomFormat = "dd/MM/yyyy";
        }

        private void alterarValor(float delta)
        {
            balance += delta;
            balanceLabel.Text = balance.ToString("C2");
        }

        // ==================== CLASSES ====================
        public class Banco
        {
            private string stringConexao = @"Data Source=localhost;Initial Catalog=financeiroDB;Integrated Security=True;";
            private SqlConnection cn;

            private void conexao()
            {
                cn = new SqlConnection(stringConexao);
            }

            public SqlConnection abrirConexao()
            {
                try
                {
                    conexao();
                    cn.Open();
                    return cn;
                }
                catch
                {
                    return null;
                }
            }

            public void fecharConexao()
            {
                try { cn.Close(); }
                catch { }
            }

            public bool InserirTransacao(Transacao transacao)
            {
                try
                {
                    SqlConnection conn = abrirConexao();
                    if (conn != null)
                    {
                        string query = "INSERT INTO transacoes (tipo, valor, dataS, descricao) " +
                                       "VALUES (@tipo, @valor, @dataS, @descricao)";

                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.AddWithValue("@tipo", transacao.Tipo);
                        command.Parameters.AddWithValue("@valor", transacao.Valor);
                        command.Parameters.AddWithValue("@dataS", transacao.Data);
                        command.Parameters.AddWithValue("@descricao", transacao.Descricao);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir transação: " + ex.Message);
                    return false;
                }
            }
        }

        public class Transacao
        {
            public string Tipo { get; set; }
            public string Nome { get; set; }
            public float Valor { get; set; }
            public DateTime Data { get; set; }
            public string Descricao { get; set; }
        }

        private void creditBtn_Click(object sender, EventArgs e)
        {
            string nome = inputName.Text;
            DateTime dataSelected = data.Value;
            string descricao = descriptionInput.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (!float.TryParse(inputValue.Text, out float valor) || valor <= 0)
            {
                MessageBox.Show("Valor inválido!");
                return;
            }

            alterarValor(valor);

            Transacao transacao = new Transacao
            {
                Tipo = "Crédito",
                Nome = nome,
                Valor = valor,
                Data = dataSelected,
                Descricao = descricao
            };

            listaTransacoes.Add(transacao);

            Banco banco = new Banco();
            bool sucesso = banco.InserirTransacao(transacao);

            if (sucesso)
                MessageBox.Show("Transação cadastrada com sucesso!");
            else
                MessageBox.Show("Falha ao cadastrar a transação.");
        }

        private void debitBtn_Click(object sender, EventArgs e)
        {
            string nome = inputName.Text;
            DateTime dataSelected = data.Value;
            string descricao = descriptionInput.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (!float.TryParse(inputValue.Text, out float valor) || valor <= 0)
            {
                MessageBox.Show("Valor inválido!");
                return;
            }

            alterarValor(-valor);

            Transacao transacao = new Transacao
            {
                Tipo = "Debito",
                Nome = nome,
                Valor = valor,
                Data = dataSelected,
                Descricao = descricao
            };

            listaTransacoes.Add(transacao);

            Banco banco = new Banco();
            bool sucesso = banco.InserirTransacao(transacao);

            if (sucesso)
                MessageBox.Show("Transação cadastrada com sucesso!");
            else
                MessageBox.Show("Falha ao cadastrar a transação.");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void balanceLabel_Click(object sender, EventArgs e)
        {

        }
    }
}


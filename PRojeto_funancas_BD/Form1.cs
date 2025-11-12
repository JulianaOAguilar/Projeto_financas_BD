using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRojeto_funancas_BD
{
    public partial class Form1 : Form
    {
        // cria uma lista, variável do saldo e tabela transacoes (para o filtro)
        private List<Transacao> listaTransacoes = new List<Transacao>();
        private float balance = 0.00f;
        private DataTable tabelaTransacoes;

        public Form1()
        {
            InitializeComponent();
            balanceLabel.Text = balance.ToString("C2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //desativar edição da tabela
            saveBtn.Enabled = false;
            deleteBtn.Enabled = false;
            data.Format = DateTimePickerFormat.Custom;
            data.CustomFormat = "dd/MM/yyyy";

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView.ReadOnly = false;
        }

        // função para definir a operação (soma ou subtração)
        private void alterarValor(float delta)
        {
            balance += delta;
            balanceLabel.Text = balance.ToString("C2");
        }

        // cria um objeto transação
        public class Transacao
        {
            public string Tipo { get; set; }
            public string Nome { get; set; }
            public float Valor { get; set; }
            public DateTime Data { get; set; }
            public string Descricao { get; set; }
        }

        //carrega transações na tabela
        private void CarregarTransacoes()
        {
            Banco banco = new Banco();
            DataTable dados = banco.BuscarTransacoes();
            if (dados != null)
            {
                tabelaTransacoes = dados; // guarda globalmente
                dataGridView.DataSource = tabelaTransacoes;

                // Bloqueia todas as células
                foreach (DataGridViewRow row in dataGridView.Rows)
                    foreach (DataGridViewCell cell in row.Cells)
                        cell.ReadOnly = true;
            }

            // Atualiza saldo
            float saldoAtual = 0f;
            if (dados != null)
            {
                foreach (DataRow row in dados.Rows)
                {
                    float valor = Convert.ToSingle(row["valor"]);
                    string tipo = row["tipo"].ToString();
                    saldoAtual += (tipo == "Crédito") ? valor : -valor;
                }
            }

            balance = saldoAtual;
            balanceLabel.Text = balance.ToString("C2");
        }

        // operações de salvar ao clicar nos botões)
        private void creditBtn_Click(object sender, EventArgs e) => InserirTransacao("Crédito");
        private void debitBtn_Click(object sender, EventArgs e) => InserirTransacao("Debito");


        // insere uma transação a partir dos campos do form
        private void InserirTransacao(string tipo)
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

            alterarValor(tipo == "Crédito" ? valor : -valor);

            Transacao transacao = new Transacao
            {
                Tipo = tipo,
                Nome = nome,
                Valor = valor,
                Data = dataSelected,
                Descricao = descricao
            };

            listaTransacoes.Add(transacao);

            Banco banco = new Banco();
            bool sucesso = banco.InserirTransacao(transacao);
            MessageBox.Show(sucesso ? "Transação cadastrada com sucesso!" : "Falha ao cadastrar a transação.");
            inputName.Clear();
            inputValue.Clear();
            descriptionInput.Clear();
        }


        private void consultBtn_Click(object sender, EventArgs e) => CarregarTransacoes();

        // permite campos editaveis
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma transação para editar!");
                return;
            }

            DataGridViewRow row = dataGridView.SelectedRows[0];

            // Desbloqueia células editáveis
            row.Cells["valor"].ReadOnly = false;
            row.Cells["descricao"].ReadOnly = false;
            row.Cells["nome"].ReadOnly = false;

            deleteBtn.Enabled = true;
            saveBtn.Enabled = true;
            groupBox1.Enabled = false;
            consultBtn.Enabled = false;

            dataGridView.CurrentCell = row.Cells["valor"];
            dataGridView.BeginEdit(true);

            MessageBox.Show("Edite os valores diretamente na linha e clique em Salvar.");
        }

        //salva edições
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para salvar!");
                return;
            }

            DataGridViewRow row = dataGridView.SelectedRows[0];

            try
            {
                int id = Convert.ToInt32(row.Cells["id"].Value);
                float novoValor = Convert.ToSingle(row.Cells["valor"].Value);
                string novaDescricao = row.Cells["descricao"].Value.ToString();
                string novoNome = row.Cells["nome"].Value.ToString();

                Banco banco = new Banco();
                bool sucesso = banco.AtualizarTransacao(id, novoNome, novoValor, novaDescricao);

                if (sucesso)
                {
                    MessageBox.Show("Transação atualizada com sucesso!");
                    CarregarTransacoes();
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar transação.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                // Bloqueia todas as células novamente
                foreach (DataGridViewRow r in dataGridView.Rows)
                    foreach (DataGridViewCell c in r.Cells)
                        c.ReadOnly = true;

                saveBtn.Enabled = false;
                deleteBtn.Enabled = false;

                groupBox1.Enabled = true;
                consultBtn.Enabled = true;
            }
        }

        // filtro
        private void FiltrarPorNome(string nome)
        {
            if (tabelaTransacoes == null) return;

            DataView dv = new DataView(tabelaTransacoes);
            dv.RowFilter = string.IsNullOrEmpty(nome) ? "" : $"nome LIKE '%{nome.Replace("'", "''")}%'";

            dataGridView.DataSource = dv;

            // Bloqueia células
            foreach (DataGridViewRow row in dataGridView.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    cell.ReadOnly = true;
        }

        private void filterInput_TextChanged(object sender, EventArgs e)
        {
            FiltrarPorNome(filterInput.Text.Trim());
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma transação para deletar!");
                return;
            }

            // Confirmação antes de excluir
            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja deletar esta transação?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.No) return;

            try
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value); // pega o ID

                Banco banco = new Banco();
                bool sucesso = banco.DeletarTransacao(id); // método que criamos no Banco.cs

                if (sucesso)
                {
                    MessageBox.Show("Transação deletada com sucesso!");
                    CarregarTransacoes(); // atualiza DataGridView e saldo
                }
                else
                {
                    MessageBox.Show("Falha ao deletar a transação.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar: " + ex.Message);
            }
        }
    }
}

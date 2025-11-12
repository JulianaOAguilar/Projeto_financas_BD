using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static PRojeto_funancas_BD.Form1;

namespace PRojeto_funancas_BD
{
    public class Banco
    {
        private string stringConexao = @"Data Source=localhost;Initial Catalog=financeiroDB;Integrated Security=True;";
        private SqlConnection cn;

        private void conexao() => cn = new SqlConnection(stringConexao);

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
            try { cn.Close(); } catch { }
        }

        public bool InserirTransacao(Transacao transacao)
        {
            try
            {
                SqlConnection conn = abrirConexao();
                if (conn != null)
                {
                    string query = "INSERT INTO transacoes (nome, tipo, valor, dataS, descricao) VALUES (@nome, @tipo, @valor, @dataS, @descricao)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@nome", transacao.Nome);
                    command.Parameters.AddWithValue("@tipo", transacao.Tipo);
                    command.Parameters.AddWithValue("@valor", transacao.Valor);
                    command.Parameters.AddWithValue("@dataS", transacao.Data);
                    command.Parameters.AddWithValue("@descricao", transacao.Descricao);
                    return command.ExecuteNonQuery() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir transação: " + ex.Message);
                return false;
            }
        }

        public DataTable BuscarTransacoes()
        {
            try
            {
                SqlConnection conn = abrirConexao();
                if (conn != null)
                {
                    string query = "SELECT id, tipo, nome, valor, dataS, descricao FROM transacoes ORDER BY dataS DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    return tabela;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar transações: " + ex.Message);
                return null;
            }
            finally { fecharConexao(); }
        }

        public bool AtualizarTransacao(int id, string novoNome, float novoValor, string novaDescricao)
        {
            try
            {
                SqlConnection conn = abrirConexao();
                if (conn != null)
                {
                    string query = "UPDATE transacoes SET nome = @nome, valor = @valor, descricao = @descricao WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@nome", novoNome);
                    command.Parameters.AddWithValue("@valor", novoValor);
                    command.Parameters.AddWithValue("@descricao", novaDescricao);
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar transação: " + ex.Message);
                return false;
            }
            finally { fecharConexao(); }
        }

        public bool DeletarTransacao(int id)
        {
            try
            {
                SqlConnection conn = abrirConexao();
                if (conn != null)
                {
                    string query = "DELETE FROM transacoes WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@id", id);
                    return command.ExecuteNonQuery() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar transação: " + ex.Message);
                return false;
            }
            finally
            {
                fecharConexao();
            }
        }
    }

}

// caso o banco seja perdido, executar isso no SQL

/*
CREATE DATABASE financeiroDB;
GO
USE financeiroDB;

CREATE TABLE transacoes (
    id INT IDENTITY(1,1) PRIMARY KEY, 
    nome NVARCHAR(100) NOT NULL,   
    tipo NVARCHAR(50) NOT NULL,       
    valor FLOAT NOT NULL,              -- valor da transação
    dataS DATE NOT NULL,               -- data selecionada
    descricao NVARCHAR(255) NOT NULL   -- de
);

INSERT INTO transacoes (nome, tipo, valor, dataS, descricao) VALUES
('Salário', 'Crédito', 5000.00, '2025-11-01', 'Pagamento mensal'),
('Supermercado', 'Debito', 250.75, '2025-11-02', 'Compras de supermercado'),
('Aluguel', 'Debito', 1200.00, '2025-11-03', 'Aluguel do apartamento'),
('Freelance', 'Crédito', 800.50, '2025-11-04', 'Projeto de freelance'),
('Academia', 'Debito', 150.00, '2025-11-05', 'Mensalidade da academia'),
('Venda Online', 'Crédito', 300.00, '2025-11-06', 'Venda de produtos online'),
('Restaurante', 'Debito', 120.25, '2025-11-07', 'Jantar com amigos'),
('Investimento', 'Crédito', 1000.00, '2025-11-08', 'Lucro de investimento'),
('Transporte', 'Debito', 80.00, '2025-11-09', 'Combustível e transporte'),
('Presente', 'Debito', 200.00, '2025-11-10', 'Presente de aniversário');
*/
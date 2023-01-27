using ApiSistemaPonto.Domain.Models;
using ApiSistemaPonto.Repositorio.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSistemaPonto.Repositorio
{
    public class FuncionarioRepositorio : Contexto
    {
        // herdando parametros do Data Contexto para injeção de dependencias
        public FuncionarioRepositorio(IConfiguration configuration) : base(configuration) { }

        // função de inserção de funcionario na tabela
        public void Inserir(FuncionarioModel model)
        {
            // crio uma variavel que recebe o parametro de insert do banco de dados
            string commandSql = @"INSERT INTO Funcionario (NomeDoFuncionario, Cpf, NascimentoFuncionario, DataDeAdmissao, CelularFuncionario, EmailFuncionario)
                                    VALUES
                                (@nomeDoFuncionario, @cpfFuncionario, @nascimentoFuncionario, @dataAdmissao, @telefoneFuncionario, @emailFuncionario);";

            // realizo um using, criando uma variavel recebendo o comando do sql e o modelo de dados a ser iserido
            using (var cmd = new SqlCommand(commandSql, _conn))
            {
                // injeto os parametros para a inserção no banco e executo sem nenhum tipo de retorno
                cmd.Parameters.AddWithValue("@nomeDoFuncionario", model.NomeFuncionario);
                cmd.Parameters.AddWithValue("@cpfFuncionario", model.CpfFuncionario);
                cmd.Parameters.AddWithValue("@nascimentoFuncionario", model.NascimentoFuncionario);
                cmd.Parameters.AddWithValue("@dataAdmissao", model.DataAdmissao);
                cmd.Parameters.AddWithValue("@telefoneFuncionario", model.TelefoneFuncionario);
                cmd.Parameters.AddWithValue("@emailFuncionario", model.EmailFuncionario);
                cmd.ExecuteNonQuery();
            }
        }

        // função de listagem de funcionarios existente na tabela, podendo ou não conter nome especifico
        public List<FuncionarioModel> ListarTodos(string? nome)
        {
            // crio uma variavel que recebe a lista de todos os cadastros existentes no banco
            string commandSql = @"SELECT FuncionarioId, NomeDoFuncionario, Cpf, NascimentoFuncionario, DataDeAdmissao, CelularFuncionario, EmailFuncionario, CargoId 
                                    FROM Funcionario";

            // caso tenha valor na variavel adiciono a pesquisa seletiva
            if (!string.IsNullOrWhiteSpace(nome))
                commandSql += " WHERE NomeDoFuncionario LIKE @nomeDoFuncionario";

            // realizo um using, criando uma variavel recebendo o comando do sql e o modelo de dados a ser localizado, caso houver
            using (var cmd = new SqlCommand(commandSql, _conn))
            {
                // verfico se o valor é nulo ou tem espaços
                if (!string.IsNullOrWhiteSpace(nome))
                    cmd.Parameters.AddWithValue("@nomeDoFuncionario", "%" + nome + "%");

                // crio uma variavel reader para percorrer pelo banco gerando uma lista de cliente, retornando a lista
                using (var rdr = cmd.ExecuteReader())
                {
                    var funcionarios = new List<FuncionarioModel>();
                    while (rdr.Read())
                    {
                        var funcionario = new FuncionarioModel();
                        funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        funcionario.NomeFuncionario = Convert.ToString(rdr["NomeDoFuncionario"]);
                        funcionario.CpfFuncionario = Convert.ToString(rdr["Cpf"]);
                        funcionario.NascimentoFuncionario = Convert.ToDateTime(rdr["NascimentoFuncionario"]);
                        funcionario.DataAdmissao = Convert.ToDateTime(rdr["DataDeAdmissao"]);
                        funcionario.TelefoneFuncionario = Convert.ToString(rdr["CelularFuncionario"]);
                        funcionario.EmailFuncionario = Convert.ToString(rdr["EmailFuncionario"]);

                        funcionarios.Add(funcionario);
                    }
                    return funcionarios;
                }
            }
        }

        public void Atualizar()
        {

        }

        public void Deletar()
        {

        }
    }
}

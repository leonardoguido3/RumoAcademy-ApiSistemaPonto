using ApiSistemaPonto.Domain.Models;
using ApiSistemaPonto.Repositorio;
using ApiSistemaPonto.Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSistemaPonto.Servico
{
    public class FuncionarioServico
    {
        // criando uma variavel readonly interna injetando Funcionario Repositorio
        private readonly FuncionarioRepositorio _repositorio;

        // criando construtor que vai receber a injecao de dependencia
        public FuncionarioServico(FuncionarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // recebo o modelo, faco a abertura da conexão com o banco e envio para a inserção, logo apos fechando a conexão
        public void Inserir(FuncionarioModel model)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        public List<FuncionarioModel> ListarTodos(string? nome)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarTodos(nome);
            }
            finally
            {
                _repositorio.FecharConexao();
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

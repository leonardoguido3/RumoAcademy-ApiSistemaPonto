using ApiSistemaPonto.Domain.Models;
using ApiSistemaPonto.Repositorio;
using ApiSistemaPonto.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ApiSistemaPonto.Ioc
{
    public class Dependencias
    {
        public static void Registro(IServiceCollection service)
        {
            // repositorios
            service.AddScoped<FuncionarioRepositorio, FuncionarioRepositorio>();

            // serviços
            service.AddScoped<FuncionarioServico, FuncionarioServico>();

            // filtros
        }
    }
}

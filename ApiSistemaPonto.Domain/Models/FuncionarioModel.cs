using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSistemaPonto.Domain.Models
{
    public class FuncionarioModel
    {
        public int FuncionarioId { get; set; }
        public string NomeFuncionario { get; set; }
        public string CpfFuncionario { get; set; }
        public DateTime NascimentoFuncionario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string TelefoneFuncionario { get; set; }
        public string EmailFuncionario { get; set; }
    }
}

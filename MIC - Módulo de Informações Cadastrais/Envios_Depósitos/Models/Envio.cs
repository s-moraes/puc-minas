using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace DepositoService.Models
{
    public class Envio
    {
        [Key]
        public int Id {get; set;}

        public int ProductId {get; set;}       

        public int ClienteId {get; set;}

        public List<Local> Locais {get; set;}
    }

    public class Local {
        public Local(string localizacao, DateTime date)
        {
            Localizacao = localizacao;
            Date = date;
        }

        [Key]
        public int Id {get; set;}

        public string Localizacao {get; set;}
        public DateTime Date {get; set;}
    }
}
using Prototype.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Prototype.Domain.Entities
{
    public class Produto: Entity
    {
        public Produto()
        {

        }

        public Produto(string nome, decimal valor, bool temPromocao, Guid? idPromocao)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Tem_Promocao = temPromocao;
            this.Id_Promocao = idPromocao;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Tem_Promocao { get; set; }
        public Guid? Id_Promocao { get; set; }
        public Promocao Promocao { get; set; }
    }
}

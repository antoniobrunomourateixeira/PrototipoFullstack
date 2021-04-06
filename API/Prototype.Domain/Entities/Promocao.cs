using Prototype.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Entities
{
    public class Promocao: Entity
    {
        public Promocao(string descricao, int leve, int pague, decimal valor)
        {
            this.Descricao = descricao;
            this.Pague = pague;
            this.Leve = leve;
            this.Valor = valor;
        }

        public string Descricao { get; set; }
        public int Leve { get; set; }
        public int Pague { get; set; }
        public decimal Valor { get; set; }

        public void UpdatePromocao(string descricao, int leve, int pague, decimal valor)
        {
            this.Descricao = descricao;
            this.Pague = pague;
            this.Leve = leve;
            this.Valor = valor;
        }
    }
}

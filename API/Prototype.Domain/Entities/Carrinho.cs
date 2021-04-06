using Prototype.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Entities
{
    public class Carrinho: Entity
    {
        public Carrinho()
        {

        }

        public Carrinho(Guid idProduto, int qtd, decimal valor)
        {
            this.Id_Produto = idProduto;
            this.Valor = valor;
            this.Quantidade = qtd;
        }

        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Guid Id_Produto { get; set; }
        public Produto Produto { get; set; }
    }
}

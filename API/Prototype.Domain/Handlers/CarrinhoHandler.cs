using Flunt.Notifications;
using Prototype.Domain.Commands.Input.Carrinho;
using Prototype.Domain.Commands.Output;
using Prototype.Domain.Entities;
using Prototype.Domain.Interfaces.IUnitOfWork;
using Prototype.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Domain.Handlers
{
    public class CarrinhoHandler : Notifiable,
        ICommandHandler<AddNewItemCommand>
    {
        private readonly IUnitOfWork _uow;

        public CarrinhoHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ICommandResult Handle(AddNewItemCommand command)
        {
            try
            {
                var produto = _uow.GetRepository<Produto>().GetFirstOrDefault(
                  predicate: x => x.Id == command.Id_Produto &&
                  x.Active == true);

                var promocaoDescricao = String.Empty;
                decimal valor = 0;

                if (produto.Tem_Promocao)
                {
                    var promocao = _uow.GetRepository<Promocao>().GetFirstOrDefault(
                      predicate: x => x.Id == produto.Id_Promocao &&
                      x.Active == true);

                    promocaoDescricao = promocao.Descricao;

                    // VERIFICAÇÃO SE TEM PROMOÇÃO MAS A QUANTIDADE NÃO ATENDEU AOS REQUISITOS
                    if(command.Quantidade < promocao.Leve)
                    {
                        valor = command.Quantidade * produto.Valor;
                    } else
                    {
                        if (promocao.Pague > 0)
                        {
                            if (command.Quantidade > promocao.Leve)
                            {
                                var resto = command.Quantidade % promocao.Leve;
                                var qtdPromo = Convert.ToInt32(command.Quantidade / promocao.Leve);
                                if (resto > 0)
                                {
                                    var valor1 = qtdPromo * produto.Valor;
                                    var valor2 = resto * produto.Valor;
                                    valor = valor1 + valor2;
                                }
                                else
                                {
                                    valor = qtdPromo * produto.Valor;
                                }
                            }
                            else
                            {
                                valor = produto.Valor;
                            }
                        }

                        if (promocao.Pague == 0 && promocao.Valor > 0)
                        {
                            if (command.Quantidade > promocao.Leve)
                            {
                                var resto = command.Quantidade % promocao.Leve;
                                var qtdPromo = Convert.ToInt32(command.Quantidade / promocao.Leve);
                                if (resto > 0)
                                {
                                    var valor1 = qtdPromo * promocao.Valor;
                                    var valor2 = resto * produto.Valor;
                                    valor = valor1 + valor2;
                                }
                                else
                                {
                                    valor = qtdPromo * produto.Valor;
                                }
                            }
                            else
                            {
                                valor = promocao.Valor;
                            }
                        }
                    }   
                    
                }
               

                var item = new Carrinho(command.Id_Produto, command.Quantidade, valor, promocaoDescricao);

                _uow.GetRepository<Carrinho>()
                    .Save(item);
                _uow.SaveChanges();

                return new CommandResult(success: true, message: "Item adicionado com sucesso", data: item.Id);
            }
            catch (Exception ex)
            {
                return new CommandResult(success: false, message: ex.Message, data: null);

            }
        }

        public ICommandResult Handle(Guid id)
        {
            try
            {
                var carrinho = _uow.GetRepository<Carrinho>().GetFirstOrDefault(predicate: x => x.Id == id);

                if(carrinho == null) return new CommandResult(success: false, message: "Item não localizado no carrinho", data: null);

                carrinho.Disable();

                _uow.GetRepository<Carrinho>().Delete(id);

                _uow.SaveChanges();

                return new CommandResult(success: true, message: "Produto removido do carrinho com sucesso", data: null);
            }
            catch (Exception ex)
            {
                return new CommandResult(success: false, message: ex.Message, data: null);
            }
        }
    }
}

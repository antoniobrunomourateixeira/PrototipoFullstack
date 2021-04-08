import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ListaCarrinhoModel } from 'app/shared/Model/Carrinho/ListaCarrinhoModel';
import { VendaService } from 'app/shared/services/venda.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-itens-carrinho',
  templateUrl: './itens-carrinho.component.html',
  styleUrls: ['./itens-carrinho.component.css']
})
export class ItensCarrinhoComponent implements OnInit {
  public listaItens: ListaCarrinhoModel[] = [];
  public qtdAlter = 0;
  public itemSelecionado: ListaCarrinhoModel;

  constructor( 
    private _service: VendaService,
    private _toastr: ToastrService,
    private modalService: NgbModal,
    private _modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  public getAll() {
    this._service.getAll().subscribe(res => {
      this.listaItens = res;
    })
  }

  public sumTotal() {
    let valor = 0;
    this.listaItens.forEach(item => {
      valor += item.Valor;
    });
    return valor;
  }

  public delete(id) {
    this._service.delete(id).subscribe(res => {
      if(res.Success) {
        this.getAll();
        this.toastSuccess();
      } else {
        this.toastInfo(res.Message);
      }
      
    })
  }

  public toastSuccess() {
    this._toastr.success(
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">Item removido com sucesso!.</span>',
      "",
      {
        timeOut: 4000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-success alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

  public toastInfo(text) {
    this._toastr.success(
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">'+text+'!.</span>',
      "",
      {
        timeOut: 4000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-warning alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

  open(content, item: ListaCarrinhoModel) {
    this.qtdAlter = item.Quantidade;
    this.itemSelecionado = item;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title', size: 'sm'});
  }

  public salvarAlteracao() {
    let dados = {
      id: this.itemSelecionado.Id,
      quantidade: this.qtdAlter
    };

    this._service.update(dados).subscribe(res => {
      if(res.Success) {
        this.toastSuccessEdi("alterado");
        this.getAll();
        this.modalService.dismissAll();
      }
    })
  }

  public toastSuccessEdi(text) {
    this._toastr.success(
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">Item '+text+' com sucesso!.</span>',
      "",
      {
        timeOut: 4000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-success alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

}

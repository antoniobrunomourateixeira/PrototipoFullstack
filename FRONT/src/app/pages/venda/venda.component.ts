import { Component, OnInit } from '@angular/core';
import { ListaProdutosModel } from 'app/shared/Model/Produto/ListaProdutosModel';
import { ProdutoService } from 'app/shared/services/produto.service';
import { VendaService } from 'app/shared/services/venda.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent implements OnInit {

  public listaProdutos: ListaProdutosModel[] = [];
  public qtd: number;
  
  constructor(
    private _service : ProdutoService, 
    private _carrinhoService: VendaService, 
    private _toastr: ToastrService,
    private _spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  public getAll() {
    this._spinner.show();
    this._service.getPromocoes().subscribe(res => {
      this._spinner.hide();
      this.listaProdutos = res;
    })
  }

  public add(item) {
    var dados = {
      quantidade: item.qtd,
      id_Produto: item.Id
    }

    var p =this.listaProdutos.indexOf(item);
    this.listaProdutos[p].qtd = null;

    this._spinner.show();
    this._carrinhoService.adicionar(dados).subscribe(res => {
      this._spinner.hide();
      if(res.Success) {
        this.toastSuccess();
      }
    })
  }

  public toastSuccess() {
    this._toastr.success(
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">Item adicionado com sucesso!.</span>',
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

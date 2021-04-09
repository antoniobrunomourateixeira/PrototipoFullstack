import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListaProdutosModel } from 'app/shared/Model/Produto/ListaProdutosModel';
import { ProdutoService } from 'app/shared/services/produto.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  public listaProdutos: ListaProdutosModel[] = [];
  
  constructor(
    private _service : ProdutoService,
    private _router: Router,
    private _toastr: ToastrService,
    private _spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.getAll();
    
  }

  public getAll() {
    this._spinner.show();
    this._service.getPromocoes().subscribe(res => {
      this._spinner.hide();
      if(res.length <= 0) {this.toastInfo('Nenhuma produto localizado')}
      this.listaProdutos = res;
    })
  }

  public delete(id) {
    this._spinner.show();
    this._service.delete(id).subscribe(res => {
      this._spinner.hide();
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
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">Produto removido com sucesso!.</span>',
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

}

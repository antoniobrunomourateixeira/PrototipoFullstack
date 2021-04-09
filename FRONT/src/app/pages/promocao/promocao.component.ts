import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListaPromocaoModel } from 'app/shared/Model/Promocao/ListaPromocaoModel';
import { PromocaoService } from 'app/shared/services/promocao.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-promocao',
  templateUrl: './promocao.component.html',
  styleUrls: ['./promocao.component.css']
})
export class PromocaoComponent implements OnInit {
  public listaPromocoes: ListaPromocaoModel[] = []

  constructor(
    private _service : PromocaoService,
    private _router: Router,
    private _toastr: ToastrService,
    private _spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.getAll();
  }

  public getAll() {
    this._spinner.show();
    this._service.getPromocoes().subscribe(res => {
      this.listaPromocoes = res;
      this._spinner.hide();
    }, err => {
      this._spinner.hide();
    })
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
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">Promoção removido com sucesso!.</span>',
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

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ListaPromocaoModel } from 'app/shared/Model/Promocao/ListaPromocaoModel';
import { ProdutoService } from 'app/shared/services/produto.service';
import { PromocaoService } from 'app/shared/services/promocao.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-edit-produto',
  templateUrl: './create-edit-produto.component.html',
  styleUrls: ['./create-edit-produto.component.css']
})
export class CreateEditProdutoComponent implements OnInit {
  public listaPromocoes: ListaPromocaoModel[] = []
  public formProduto: FormGroup;
  public text = "Cadastrar Novo Produto";

  constructor(
    private _fb: FormBuilder,
    private _servicePromo: PromocaoService,
    private _service : ProdutoService,
    private _router: Router,
    private _toastr: ToastrService,
    private _activateRoute: ActivatedRoute,
    private _spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    const idProduto = this._activateRoute.snapshot.paramMap.get('id');

    if(idProduto) {
      this.loadPromocao();
      this.getId(idProduto)
    }

    this.formProduto = this._fb.group({
      id: [''],
      nome: ['', Validators.required],
      valor: ['', Validators.required],
      tem_promocao: ['N'],
      id_promocao: ['']
    })
  }

  public loadPromocao() {
    this._spinner.show();
    this._servicePromo.getPromocoes().subscribe( res => {
      this._spinner.hide();
      this.listaPromocoes = res;
    })
  }

  public getId(id) {
    this.text = "Editar Produto";
    this._spinner.show();
    this._service.getId(id).subscribe(res => {
      this._spinner.hide();
      this.formProduto.patchValue({
        id: res.Id,
        nome: res.Nome,
        valor: res.Valor,
        tem_promocao: res.Tem_Promocao == true ? 'S' : 'N',
        id_promocao: res.Id_Promocao
      })
    })
  }

  public gravar() {
    if(this.formProduto.value.id) {
      this.Editar();
    } else {
      this.Cadastrar();
    }
  }

  private Cadastrar() {
    if(this.verificaPromocao()) return false;

    this.formProduto.patchValue({
      tem_promocao: this.formProduto.value.tem_promocao == 'S' ? true : false
    })
    this._spinner.show();
    this._service.create(this.formProduto.value).subscribe(res => {
      this._spinner.hide();
      if(res.Success) {
        this.toastSuccess("cadastrado");
        this._router.navigateByUrl("/produto");
      } else {
        this.toastInfo(res.Message)
      }
    })
  }

  private Editar() {
    if(this.verificaPromocao()) return false;

    this.formProduto.patchValue({
      tem_promocao: this.formProduto.value.tem_promocao == 'S' ? true : false
    })
    this._spinner.show();
    this._service.update(this.formProduto.value).subscribe(res => {
      this._spinner.hide();
      if(res.Success) {
        this._router.navigateByUrl("/produto");
        this.toastSuccess("alterado");
      } else {
        this.toastInfo(res.Message)
      }
    })
  }

  public verificaPromocao(): boolean {
    var dados = this.formProduto.value;
    if(dados.tem_promocao == 'S' && !dados.id_promocao) {
      this.toastInfo("Nenhuma promoção selecionada");
      return true;
    } 
    return false;
  }

  public toastSuccess(text) {
    this._toastr.success(
      '<span data-notify="icon" class="nc-icon nc-bell-55"></span><span data-notify="message">Promoção '+text+' com sucesso!.</span>',
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

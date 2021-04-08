import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PromocaoService } from 'app/shared/services/promocao.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-creat-edit-promocao',
  templateUrl: './creat-edit-promocao.component.html',
  styleUrls: ['./creat-edit-promocao.component.css']
})
export class CreatEditPromocaoComponent implements OnInit {
  public formPromocao: FormGroup;
  public text = "Cadastrar Nova Promoção";

  constructor(
    private _fb: FormBuilder,
    private _service : PromocaoService,
    private _router: Router,
    private _toastr: ToastrService,
    private _activateRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const idPromocao = this._activateRoute.snapshot.paramMap.get('id');

    if(idPromocao) {this.getId(idPromocao)}

    this.formPromocao = this._fb.group({
      id: [''],
      descricao: ['', Validators.required],
      leve: ['', Validators.required],
      pague: [''],
      valor: ['']
    })
  }

  public getId(id) {
    this.text = "Editar Promoção";
    this._service.getId(id).subscribe(res => {
      console.log(res)
      this.formPromocao.patchValue({
        id: res[0].Id,
        descricao: res[0].Descricao,
        leve: res[0].Leve,
        pague: res[0].Pague,
        valor: res[0].Valor
      })
    })
  }

  public gravar() {
    if(this.formPromocao.value.id) {
      this.Editar();
    } else {
      this.Cadastrar();
    }
  }

  private Cadastrar() {
    this._service.create(this.formPromocao.value).subscribe(res => {
      if(res.Success) {
        this.toastSuccess("cadastrada");
        this._router.navigateByUrl("/promocao");
      }
    })
  }

  private Editar() {
    this._service.update(this.formPromocao.value).subscribe(res => {
      if(res.Success) {
        this.toastSuccess("alterada");
        this._router.navigateByUrl("/promocao");
      }
    })
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

}

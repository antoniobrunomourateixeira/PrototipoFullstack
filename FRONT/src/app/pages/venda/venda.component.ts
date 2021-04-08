import { Component, OnInit } from '@angular/core';
import { ListaProdutosModel } from 'app/shared/Model/Produto/ListaProdutosModel';
import { ProdutoService } from 'app/shared/services/produto.service';
import { VendaService } from 'app/shared/services/venda.service';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent implements OnInit {

  public listaProdutos: ListaProdutosModel[] = [];
  public qtd: number;
  
  constructor(private _service : ProdutoService, private _carrinhoService: VendaService) { }

  ngOnInit(): void {
    this.getAll();
    console.log('res')
  }

  public getAll() {
    this._service.getPromocoes().subscribe(res => {
      this.listaProdutos = res;
    })
  }

  public add(item) {
    var dados = {
      quantidade: item.qtd,
      id_Produto: item.Id
    }

    this._carrinhoService.adicionar(dados).subscribe(res => {
      console.log(res);
    })
  }

}

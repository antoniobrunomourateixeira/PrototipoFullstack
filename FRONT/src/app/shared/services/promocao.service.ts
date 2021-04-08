import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListaPromocaoModel } from '../Model/Promocao/ListaPromocaoModel';
import { RetornoCadastroProdutoModel } from '../Model/Promocao/Retorno/RetornoCadastroProdutoModel';
import { RetornoPadraoModel } from '../Model/RetornoPadraoModel';
import { Utils } from '../Utils';

@Injectable({
  providedIn: 'root'
})
export class PromocaoService {

  constructor(private http: HttpClient) { }

  public getPromocoes(): Observable<ListaPromocaoModel[]> {
    return this.http.get<ListaPromocaoModel[]>(`${Utils.hostApi()}Promocao`);
  }

  public create(values): Observable<RetornoCadastroProdutoModel>{
    return this.http.post<RetornoCadastroProdutoModel>(`${Utils.hostApi()}Promocao`, values);
  }

  public update(values): Observable<RetornoCadastroProdutoModel>{
    return this.http.put<RetornoCadastroProdutoModel>(`${Utils.hostApi()}Promocao`, values);
  }

  public getId(id): Observable<ListaPromocaoModel[]> {
    return this.http.get<ListaPromocaoModel[]>(`${Utils.hostApi()}Promocao/${id}`);
  }

  public delete(id): Observable<RetornoPadraoModel> {
    return this.http.delete<RetornoPadraoModel>(`${Utils.hostApi()}Promocao/${id}`);
  }


}

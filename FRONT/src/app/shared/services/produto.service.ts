import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListaProdutosModel } from '../Model/Produto/ListaProdutosModel';
import { RetornoPadraoModel } from '../Model/RetornoPadraoModel';
import { Utils } from '../Utils';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  constructor(private http: HttpClient) { }

  public getPromocoes(): Observable<ListaProdutosModel[]> {
    return this.http.get<ListaProdutosModel[]>(`${Utils.hostApi()}Produto`);
  }

  public create(values): Observable<any>{
    return this.http.post<any>(`${Utils.hostApi()}Produto`, values);
  }

  public update(values): Observable<any>{
    return this.http.put<any>(`${Utils.hostApi()}Produto`, values);
  }

  public getId(id): Observable<ListaProdutosModel> {
    return this.http.get<ListaProdutosModel>(`${Utils.hostApi()}Produto/${id}`);
  }

  public delete(id): Observable<RetornoPadraoModel> {
    return this.http.delete<RetornoPadraoModel>(`${Utils.hostApi()}Produto/${id}`);
  }
}

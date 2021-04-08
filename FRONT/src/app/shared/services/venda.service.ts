import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListaCarrinhoModel } from '../Model/Carrinho/ListaCarrinhoModel';
import { RetornoPadraoModel } from '../Model/RetornoPadraoModel';
import { Utils } from '../Utils';

@Injectable({
  providedIn: 'root'
})
export class VendaService {

  constructor(private http: HttpClient) { }

  public adicionar(values): Observable<RetornoPadraoModel> {
    return this.http.post<RetornoPadraoModel>(`${Utils.hostApi()}Carrinho`, values);
  }

  public getAll(): Observable<ListaCarrinhoModel[]> {
    return this.http.get<ListaCarrinhoModel[]>(`${Utils.hostApi()}Carrinho`);
  }

  public update(values): Observable<any>{
    return this.http.put<any>(`${Utils.hostApi()}Carrinho`, values);
  }

  public delete(id): Observable<RetornoPadraoModel> {
    return this.http.delete<RetornoPadraoModel>(`${Utils.hostApi()}Carrinho/${id}`);
  }
}

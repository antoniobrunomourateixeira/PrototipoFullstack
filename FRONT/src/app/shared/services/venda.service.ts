import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Utils } from '../Utils';

@Injectable({
  providedIn: 'root'
})
export class VendaService {

  constructor(private http: HttpClient) { }

  public add(values){
    return this.http.post(`${Utils.hostApi()}Carrinho`, values);
  }

  public adicionar(values) {
    return this.http.post(`${Utils.hostApi()}Carrinho`, values);
  }
}

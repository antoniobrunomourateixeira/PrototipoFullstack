import { ListaPromocaoModel } from "../Promocao/ListaPromocaoModel";

export class ListaProdutosModel {
    Nome: string;
    Valor: number;
    Tem_Promocao: boolean;
    Id_Promocao: string;
    Promocao: ListaPromocaoModel
    Id: string;
    RegisterDate: Date;
    Active: boolean;
    qtd: number;
}
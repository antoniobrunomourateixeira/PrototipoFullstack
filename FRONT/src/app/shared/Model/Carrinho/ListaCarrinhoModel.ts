import { ListaProdutosModel } from "../Produto/ListaProdutosModel";

export class ListaCarrinhoModel {
    Quantidade: number;
    "Valor": number;
    "Descricao": string;
    "Id_Produto": string;
    "Produto": ListaProdutosModel;
    "Id": string;
    "RegisterDate": string;
    "Active": boolean
}
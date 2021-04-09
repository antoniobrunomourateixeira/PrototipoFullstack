import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { PromocaoComponent } from 'app/pages/promocao/promocao.component';
import { ProdutoComponent } from 'app/pages/produto/produto.component';
import { VendaComponent } from 'app/pages/venda/venda.component';
import { CreatEditPromocaoComponent } from 'app/pages/promocao/creat-edit-promocao/creat-edit-promocao.component';
import { CreateEditProdutoComponent } from 'app/pages/produto/create-edit-produto/create-edit-produto.component';
import { ItensCarrinhoComponent } from 'app/pages/venda/itens-carrinho/itens-carrinho.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',          component: DashboardComponent },
    { path: 'promocao',           component: PromocaoComponent },
    { path: 'novaPromocao',       component: CreatEditPromocaoComponent },
    { path: 'editarPromocao/:id', component: CreatEditPromocaoComponent },
    { path: 'produto',            component: ProdutoComponent },
    { path: 'novoProduto',        component: CreateEditProdutoComponent },
    { path: 'editarProduto/:id',  component: CreateEditProdutoComponent },
    { path: 'venda',              component: VendaComponent },
    { path: 'itensVenda',         component: ItensCarrinhoComponent }
];

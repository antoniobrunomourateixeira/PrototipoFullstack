import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { LOCALE_ID, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastrModule } from "ngx-toastr";

import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule} from './shared/navbar/navbar.module';
import { FixedPluginModule} from './shared/fixedplugin/fixedplugin.module';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { PromocaoComponent } from './pages/promocao/promocao.component';
import { ProdutoComponent } from './pages/produto/produto.component';
import { VendaComponent } from './pages/venda/venda.component';
import { HttpClientModule } from '@angular/common/http';
import { CreatEditPromocaoComponent } from './pages/promocao/creat-edit-promocao/creat-edit-promocao.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CurrencyMaskModule } from "ng2-currency-mask";
import { CreateEditProdutoComponent } from './pages/produto/create-edit-produto/create-edit-produto.component';

import { registerLocaleData } from '@angular/common';
import ptBr from '@angular/common/locales/pt';
import { ItensCarrinhoComponent } from './pages/venda/itens-carrinho/itens-carrinho.component';
registerLocaleData(ptBr);

@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    PromocaoComponent,
    ProdutoComponent,
    VendaComponent,
    CreatEditPromocaoComponent,
    CreateEditProdutoComponent,
    ItensCarrinhoComponent
  ],
  imports: [
    BrowserAnimationsModule,
    RouterModule.forRoot(AppRoutes,{
      useHash: true
    }),
    SidebarModule,
    NavbarModule,
    ToastrModule.forRoot(),
    FooterModule,
    ReactiveFormsModule,
    FormsModule,
    FixedPluginModule,
    HttpClientModule,
    CurrencyMaskModule
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'pt-BR' },],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { ApiModule } from './api/api.module';
import { ScannerComponent } from './scanner/scanner.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ScannerGuideComponent } from './scanner-guide/scanner-guide.component';
import { ManualScannerComponent } from './manual-scanner/manual-scanner.component';
import { ListRestComponent } from './list-rest/list-rest.component';
import { ListRestItemComponent } from './list-rest-item/list-rest-item.component';
import { PreloaderComponent } from './preloader/preloader.component';
import { ListRestStationsComponent } from './list-rest-stations/list-rest-stations.component';
import { MenuRestComponent } from './menu-rest/menu-rest.component';
import { BasketRestComponent } from './basket-rest/basket-rest.component';
import { OrderStatusComponent } from './order-status/order-status.component';
import { RestappMainComponent } from './restapp-main/restapp-main.component';


@NgModule({
  declarations: [
    AppComponent,
    ScannerComponent,
    NavbarComponent,
    ScannerGuideComponent,
    ManualScannerComponent,
    ListRestComponent,
    ListRestItemComponent,
    PreloaderComponent,
    ListRestStationsComponent,
    MenuRestComponent,
    BasketRestComponent,
    OrderStatusComponent,
    RestappMainComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', redirectTo: '/init', pathMatch: 'full'},
      {path: 'init', component: ScannerGuideComponent, data: {animation: 'ScannerGuidePage'}},
      {path: 'qr-scanner', component: ScannerComponent, data: {animation: 'ScannerPage'}},
      {path: 'manual-scanner', component: ManualScannerComponent, data: {animation: 'ManualScannerPage'}},
      {path: 'list-rest', component: ListRestComponent, data: {animation: 'ListRestPage'}},
      {path: 'list-rest-stations', component: ListRestStationsComponent, data: {animation: 'ListRestStationsPage'}},
      {path: 'menu-rest', component: MenuRestComponent, data: {animation: 'MenuRestPage'}},
      {path: 'basket-rest', component: BasketRestComponent, data: {animation: 'BasketRestPage'}},
      {path: 'order-status', component: OrderStatusComponent, data: {animation: 'OrderStatusPage'}},
      {path: 'rest/main', component: RestappMainComponent, data: {animation: 'RestappMainPage'}},
    ]),
    FormsModule,
    ApiModule.forRoot({ rootUrl: "http://localhost:5000"})
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
 
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

@NgModule({
  declarations: [
    AppComponent,
    ScannerComponent,
    NavbarComponent,
    ScannerGuideComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', redirectTo: '/init', pathMatch: 'full'},
      {path: 'init', component: ScannerGuideComponent, data: {animation: 'ScannerGuidePage'}},
      {path: 'qr-scanner', component: ScannerComponent, data: {animation: 'ScannerPage'}},
      {path: '**', redirectTo: '/'}
    ]),
    FormsModule,
    ApiModule.forRoot({ rootUrl: "https://rzhd.rtuitlab.ru"})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';
import { AppComponent } from './components/app.component';
import { HomeComponent } from './components/home/home.component';
import { TradesComponent } from './components/trades/trades.component';
import { TradeService } from './service/trade.service'


@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing, Ng2Bs3ModalModule],
    declarations: [AppComponent, TradesComponent, HomeComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, TradeService],
    bootstrap: [AppComponent]
})
export class AppModule { }

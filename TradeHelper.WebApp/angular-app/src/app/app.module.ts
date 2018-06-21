import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AppComponent } from './startup/app.component';
import { TradeService } from './service/trade.service';
import { AppRoutingModule } from './startup/app-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent, 
  ],
  imports: [
    BrowserModule,
    //HttpModule,
    // HttpClientModule,
    AppRoutingModule,   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

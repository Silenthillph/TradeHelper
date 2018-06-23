import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AppComponent } from './startup/app.component';
import { TradeService } from './service/trade.service';
import { AppRoutingModule } from './startup/app-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SettingsComponent } from './components/settings/settings.component';
import { TradesComponent } from './components/trades/trades.component'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProfileComponent } from './components/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent, 
    TradesComponent,
    SettingsComponent,
    ProfileComponent    
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HttpClientModule,
    AppRoutingModule,   
    NgbModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

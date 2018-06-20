import { TradeService } from './service/trade.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})

export class AppComponent {

  constructor(private _httpClient: HttpClient) { }

  ngOnInit(): void {
    let status = this._httpClient.get("http://localhost:49820/api/exchange/status").toPromise().then(response => {
      debugger;
    });
  }

}

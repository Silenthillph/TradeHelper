import { Component, Injectable } from '@angular/core';
import { ITradeInfo } from '../models/tradeInfo';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpHeaders } from '@angular/common/http'
import { Observable, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

export class TradeService {
    constructor(private _http: HttpClient) {
        this.apiBaseUrl = 'http://localhost:49820/'; // TODO: Set it from build configuration (dev/prod)
    }

    private apiBaseUrl: string;

    dynamicGet(url: string): Promise<any> {
        return this._http.get(`${this.apiBaseUrl}url`).toPromise();
    }

    addOrUpdateTrade(trade: ITradeInfo): Observable<any> {
        return this._http.post(`${this.apiBaseUrl}api/trade/addOrUpdateTrade`, trade);
    }
  
    add(trade: ITradeInfo) {
        let requestUlr = `${this.apiBaseUrl}api/trade/addOrUpdateTrade`;      
        return this._http.post(requestUlr, trade); 
    }
      
    getAllTrades(): Promise<any> {
        return this._http.get(`${this.apiBaseUrl}/api/trade/getalltrades`).toPromise();
    }

    deleteTrade(id: string): Promise<any> {
        return this._http.delete(`${this.apiBaseUrl}/api/trade/remove/${id}`).toPromise();
    }

    private _getDefaultPostHeaders() {
        const headers = new HttpHeaders().set("Content-Type", "application/json").set("Access-Control-Allow-Origin", "*");
        return headers;
    }

    handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
    }
}
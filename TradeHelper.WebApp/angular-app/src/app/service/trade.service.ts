import { Component, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ITradeInfo } from '../models/tradeInfo';

@Injectable({
    providedIn: 'root',
})

export class TradeService {
    constructor(private _http: HttpClient) {
        this.apiBaseUrl = 'http://localhost:49820'; // TODO: Set it from build configuration (dev/prod)
    }
    
    private apiBaseUrl: string;

    dynamicGet(url: string): Promise<any> {
        return this._http.get(`${this.apiBaseUrl}url`).toPromise();
    }

    addOrUpdateTrade(trade: ITradeInfo): Promise<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        return this._http.post(`${this.apiBaseUrl}/api/trade/addOrUpdateTrade`, trade).toPromise();
    }

    getAllTrades(): Promise<any> {
        return this._http.get(`${this.apiBaseUrl}/api/trade/getalltrades`).toPromise();
    }

    removeTrade(items: Array<number>): Promise<any> {
        return this._http.delete(`${this.apiBaseUrl}/api/trade/RemoveTradeItems?items=` + items).toPromise();
    }

    handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
    }
}
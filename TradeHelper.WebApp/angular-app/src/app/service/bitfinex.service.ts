import { Component, Injectable } from '@angular/core';
import { ITradeInfo } from '../models/tradeInfo';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse, HttpHeaders } from '@angular/common/http'
import { Observable, Subscription } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

export class BitfinexApi {
    constructor(private _http: HttpClient) {
        this.apiBaseUrl = 'https://api.bitfinex.com/v2/'; // TODO: Set it from build configuration (dev/prod)
    }

    private apiBaseUrl: string;

    getTicker(tradingPair: string): Promise<any> {
        return this._http.get(`${this.apiBaseUrl}ticker/t${tradingPair}`).toPromise();
    }

    addOrUpdateTrade(trade: ITradeInfo): Observable<any> {
        return this._http.post(`${this.apiBaseUrl}api/trade/addOrUpdateTrade`, trade);
    }
}
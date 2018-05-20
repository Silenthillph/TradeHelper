﻿import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ITradeInfo } from "../model/tradeInfo";

export class TradeService {
    constructor(private _http: Http) { }

    dynamicGet(url: string): Promise<any> {
        return this._http.get(url).toPromise();
    }

    addOrUpdateTrade(trade: ITradeInfo): Promise<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        return this._http.post('api/trade/addOrUpdateTrade', trade).toPromise();
    }

    getAllTrades(): Promise<any> {
        return this._http.get('api/trade/getalltrades').toPromise();
    }

    removeTrade(items: Array<number>): Promise<any> {
        return this._http.delete('api/trade/RemoveTradeItems?items=' + items).toPromise();
    }

    handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
    }
}
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import { ITradeInfo } from "../model/tradeInfo";


@Injectable()
export class TradeService {
    constructor(private _http: Http) { }

    dynamicGet(url: string): Promise<any> {
        return this._http.get(url).toPromise();
    }

    addOrUpdateTrade(trade: ITradeInfo): Promise<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('api/trade/addOrUpdateTrade', trade, options).toPromise();
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
        return Observable.throw(errMsg);
    }
}
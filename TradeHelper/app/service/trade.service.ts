import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class TradeService {
    constructor(private _http: Http) { }

    dynamicGet(url: string): Promise<any> {
        return this._http.get(url).toPromise();
    }

    getAllTrades(): Observable<any> {
        return this._http.get('api/trade/getalltrades')
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    removeTrade(items: Array<number>): Promise<any> {
        return this._http.delete('api/trade/RemoveTradeItems?items=' + items).toPromise();
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}
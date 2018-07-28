import { Component, OnInit, Input } from '@angular/core';
import { NgbModule, NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TradeService } from '../../service/trade.service';
import { BitfinexApi } from '../../service/bitfinex.service'
import { TradeInfo } from "../../models/tradeInfo";
import { Enums } from "../../common/enums";
import { Utils } from "../../common/utils"
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    templateUrl: './trades.component.html',
    selector: 'app-trades',
})

export class TradesComponent implements OnInit {

    constructor(private _tradeService: TradeService, private _bitfinexApi: BitfinexApi, private _modalService: NgbModal) {

    }

    submitAction: Enums.SubmitFormState;
    trades: Array<TradeInfo>;
    activeTrade: TradeInfo = new TradeInfo();
    dataTableTrades: Array<{ string, bool }>

    ngOnInit() {
        this.submitAction = Enums.SubmitFormState.None;
        this.load();
    }

    load(): void {
        let $this = this;
        this._tradeService.getAllTrades().then(trades => {
            $this.loadTableData(trades);
        },
            error => { console.log(error); });
    }

    loadTableData(tradesResponse: any) {
        this.trades = <Array<TradeInfo>>tradesResponse || [];
        this.dataTableTrades = new Array<any>();
        this.trades.forEach(trade => {
            this.dataTableTrades[trade.id] = false;
        });
    }

    startEdit(tradeItem: TradeInfo) {
        this.submitAction = Enums.SubmitFormState.Update;
        this.activeTrade = new TradeInfo(tradeItem);
        this.dataTableTrades[tradeItem.id] = true;
    }

    refreshTicker() {
        if (this.trades.length > 0) {
            this.trades.forEach(tradeItem => {
                this._bitfinexApi.getTicker(tradeItem.pairCode).then(btfnxResult => {
                    let tickerDto = btfnxResult;
                    if (tradeItem.status = Enums.PositionStatus.Closed) {
                        let profit = this.calculateProfit(tradeItem);
                        let usdProfit = this.calculateSize(tradeItem) * profit;
                        tradeItem.summary = `${(profit).toFixed(1)}% (${((usdProfit * profit) / 100).toFixed(1)}$) `
                    }
                });
            });
        }
    }

    cancelEdit() {
        this.submitAction = Enums.SubmitFormState.None;
        this.activeTrade = new TradeInfo();
    }

    deleteTrade(tradeItem: TradeInfo): void {
        this.submitAction = Enums.SubmitFormState.Delete;
        let $this = this;
        this._tradeService.deleteTrade(tradeItem.id).then(res => {
            let index = $this.trades.indexOf(tradeItem);
            $this.trades.splice(index, 1);
        });
    }

    addOrUpdate() {
        let $this = this;
        this._tradeService.addOrUpdateTrade(this.activeTrade).subscribe(result => {
            let tradeItem = <TradeInfo>$this.activeTrade;
            if ($this.submitAction == Enums.SubmitFormState.Create) {
                tradeItem.id = result;
                $this.trades.push(tradeItem);
            } else {
                $this.trades.forEach(t => {
                    if (t.id == tradeItem.id) {
                        let index = $this.trades.indexOf(t);
                        $this.trades[index] = tradeItem;
                    }
                });
            }
            $this.submitAction = Enums.SubmitFormState.None;
            $this.dataTableTrades[tradeItem.id] = false;
            this.activeTrade = new TradeInfo();
        });
    }

    editEnabled(id: string) {
        return this.dataTableTrades[id] && this.submitAction == Enums.SubmitFormState.Update;
    }

    addEnabled(): boolean {
        return this.submitAction == Enums.SubmitFormState.Create;
    }

    addTrade(): void {
        this.submitAction = Enums.SubmitFormState.Create;
    }

    cancelAdd(): void {
        this.submitAction = Enums.SubmitFormState.None;
    }

    calculateProfit(tradeItem: TradeInfo) {
        return tradeItem.status == Enums.PositionStatus.Closed
            ? (tradeItem.type == Enums.PositionType.Long
                ? ((tradeItem.amount * tradeItem.sellPrice - tradeItem.amount * tradeItem.buyPrice) / (tradeItem.amount * tradeItem.buyPrice)) * 100
                : ((tradeItem.amount * tradeItem.buyPrice - tradeItem.amount * tradeItem.sellPrice) / (tradeItem.amount * tradeItem.sellPrice)) * 100)
            : 0;
    }

    calculateSize(tradeItem: TradeInfo) {
        return tradeItem.status == Enums.PositionStatus.Closed ?
            tradeItem.type == Enums.PositionType.Long
                ? tradeItem.amount * tradeItem.buyPrice
                : tradeItem.amount * tradeItem.sellPrice
            : 0;
    }

    getPositionType(tradeItem: TradeInfo) {
        if (tradeItem) {
            return Enums.PositionType[tradeItem.type].toString();
        }
        return "";
    }
}

import { Component, OnInit, Input } from '@angular/core';
import { NgbModule, NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TradeService } from '../../service/trade.service';
import { TradeInfo } from "../../models/tradeInfo";
import { Enums } from "../../common/enums";
import { Utils } from "../../common/utils"
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    templateUrl: './trades.component.html',
    selector: 'app-trades',
})

export class TradesComponent implements OnInit {

    constructor(private _tradeService: TradeService, private _modalService: NgbModal) {

    }

    crudAction: Enums.CrudOperation;
    trades: Array<TradeInfo>;
    activeTrade: TradeInfo = new TradeInfo();
    dataTableTrades: Array<{ string, bool }>

    ngOnInit() {
        this.crudAction = Enums.CrudOperation.None;
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

    editTrade(tradeItem: TradeInfo) {
        this.crudAction = Enums.CrudOperation.Update;
        this.activeTrade = new TradeInfo(tradeItem);
        this.dataTableTrades[tradeItem.id] = true;
    }

    cancelEdit() {
        this.crudAction = Enums.CrudOperation.None;
        this.activeTrade = new TradeInfo();
    }

    deleteTrade(tradeItem: TradeInfo): void {
        this.crudAction = Enums.CrudOperation.Delete;
    }

    saveTrade(tradeItem: TradeInfo) {
        if (this.crudAction == Enums.CrudOperation.Create) {
            this.activeTrade.id = Utils.getNewGUID();
        }
        let $this = this;
        this._tradeService.addOrUpdateTrade(this.activeTrade).then(() => {        
            if ($this.crudAction == Enums.CrudOperation.Create) {
                $this.trades.push(new TradeInfo($this.activeTrade));
            }        
            $this.crudAction = Enums.CrudOperation.None;
            $this.dataTableTrades[tradeItem.id] = false;
        },
            error => { console.log(error); });
    }

    editEnabled(id: string) {
        return this.dataTableTrades[id] && this.crudAction == Enums.CrudOperation.Update;
    }

    addEnabled(): boolean {
        return this.crudAction == Enums.CrudOperation.Create;
    }

    addTrade(): void {
        this.crudAction = Enums.CrudOperation.Create;
    }

    cancelAdd(): void {
        this.crudAction = Enums.CrudOperation.None;
    }

    calculateProfit(tradeItem: TradeInfo) {
        if (tradeItem.status == Enums.PositionStatus.Closed) {
            if (tradeItem.type == Enums.PositionType.Long) {
                return ((tradeItem.amount * tradeItem.buyPrice - tradeItem.amount * tradeItem.sellPrice) / (tradeItem.amount * tradeItem.buyPrice)) * 100;
            }
            else {
                return ((tradeItem.amount * tradeItem.sellPrice - tradeItem.amount * tradeItem.buyPrice) / (tradeItem.amount * tradeItem.sellPrice)) * 100;
            }
        } else {
            return -1;
        }
    }

    getPositionType(tradeItem: TradeInfo) {
        if (tradeItem) {
            return Enums.PositionType[tradeItem.type].toString();
        }
        return "";
    }
}

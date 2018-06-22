import { Component, OnInit } from '@angular/core';
import { NgbModule, NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { TradeService } from '../../service/trade.service';
import { ITradeInfo } from "../../models/tradeInfo";
import { Enums } from "../../common/enums";
import { Utils } from "../../common/utils"

@Component({
    templateUrl: './trades.component.html',
    selector: 'app-trades',
})

export class TradesComponent implements OnInit {
  
    constructor(private _tradeService: TradeService, private _modalService: NgbModal) {

    }

    modalTitle: string;
    modalBtnTitle: string;
    crudActionType: Enums.CrudOperation;
    trades: Array<ITradeInfo>;

    ngOnInit() {
       this.load();
    }

    load(): void {   
        let $this = this;
        this._tradeService.getAllTrades()
            .then(trades => {
                $this.trades = trades.json() || {};
            },
            error => { console.log(error); });
    }

    calculateProfit(trade: ITradeInfo): number {
        let result: number = 0;
        if (trade.Status == Enums.PositionStatus.Closed) {
            result = trade.Type == Enums.PositionType.Long
                ? (trade.Amount * (trade.CellPrice - trade.BuyPrice))
                : (trade.Amount * (trade.BuyPrice - trade.CellPrice));
        }
        return result;
    }

    addTrade(modalSelector: any): void {
        const modalRef = this._modalService.open(modalSelector);
    }
}
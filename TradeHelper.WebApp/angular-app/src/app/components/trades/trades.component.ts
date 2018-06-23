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
                $this.trades = <Array<ITradeInfo>>trades || [];
            },
            error => { console.log(error); });
    }

    addTrade(modalSelector: any): void {
        const modalRef = this._modalService.open(modalSelector);
    }
}
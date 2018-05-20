import { Component, Input, OnInit } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TradeService } from '../../service/trade.service';
import { ITradeInfo } from "../../model/tradeInfo";
import { Enums } from "../../common/enums";
import { Utils } from "../../common/utils"

@Component({
    templateUrl: "app/components/trades/trades.component.html"
})

export class TradesComponent implements OnInit {
    tradeForm: FormGroup;
    modalTitle: string;
    modalBtnTitle: string;
    crudActionType: Enums.CrudOperation;
    trades: Array<ITradeInfo>;
    
    constructor(private fb: FormBuilder, private _tradeService: TradeService, private modalService: NgbModal) { }

    ngOnInit(): void {
        this.tradeForm = this.fb.group({
            Id: [''],
            PairCode: ['', Validators.required],
            Amount: ['', Validators.required],
            BuyPrice: [''],
            CellPrice: [''],
            StartDate: [''],
            CloseDate: [''],
            Status: ['', Validators.required],
            Type: ['', Validators.required]
        });
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

    addTrade(content: any): void {
        const modalRef = this.modalService.open(NgbdModalContent);
        modalRef.componentInstance.name = 'World';
    }
}

@Component({
    selector: 'ngbd-modal-content',
    template: `
    <div class="modal-header">
      <h4 class="modal-title">Hi there!</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('Cross click')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      <p>Hello, {{name}}!</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})
export class NgbdModalContent {
    @Input("name") name: any;

    constructor(public activeModal: NgbActiveModal) { }
}
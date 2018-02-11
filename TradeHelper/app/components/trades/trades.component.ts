import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { Observable } from 'rxjs/Rx';
import { TradeService } from '../../service/trade.service';
import { ITradeInfo } from "../../model/tradeInfo";
import { Enums } from "../../common/enums";

@Component({
    templateUrl: "app/components/trades/trades.component.html"
})

export class TradesComponent implements OnInit {
    //fields
    @ViewChild('modal') modal: ModalComponent;
    tradeForm: FormGroup;

    modalTitle: string;
    modalBtnTitle: string;

    trades: Array<ITradeInfo>;
    isLoading: boolean;
    
    constructor(private fb: FormBuilder, private _tradeService: TradeService) { }

    ngOnInit(): void {
        this.tradeForm = this.fb.group({
            PairCode: [''],
            Amount: ['', Validators.required]
        });
        this.load();
    }

    load(): void {   
        let $this = this;
        $this.isLoading = true;
        this._tradeService.getAllTrades()
            .subscribe(trades => {
                $this.trades = trades;
                $this.isLoading = false;
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

    addTrade(): void {
        this.setControlsState(true);
        this.modalTitle = "Add New Trade";
        this.modalBtnTitle = "Add";
        this.tradeForm.reset();
        this.modal.open();
    }

    editTrade(id: number): void {

    }

    deleteTrade(trade: ITradeInfo): void {
        if (trade && trade.Id) {
            this._tradeService.removeTrade([trade.Id]).then(
                data => {
                    var itemToDeleteIndex = this.trades.indexOf(trade);
                    if (itemToDeleteIndex !== -1) {
                        this.trades.splice(itemToDeleteIndex, 1);
                    }
                },
                error => { console.log(error); });
        } else {
            return;
        }
    }

    onSubmit(formData: any) {
        let $this = this;
        $this.isLoading = true;
        this._tradeService.addOrUpdateTrade(formData.value)
            .subscribe(result => {
                $this.trades.push(formData.value);
                $this.modal.dismiss();
                $this.isLoading = true;
            },error => { console.log(error); });
    }

    setControlsState(isEnable: boolean) {
        isEnable ? this.tradeForm.enable() : this.tradeForm.disable();
    }
}
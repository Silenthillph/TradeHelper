import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { Observable } from 'rxjs/Rx';
import { TradeService } from '../../service/trade.service';
import { ITradeInfo } from "../../model/tradeInfo";
import { Enums } from "../../common/enums";
import { Utils } from "../../common/utils"

@Component({
    templateUrl: "app/components/trades/trades.component.html"
})

export class TradesComponent implements OnInit {
    @ViewChild('modal') modal: ModalComponent;
    tradeForm: FormGroup;

    modalTitle: string;
    modalBtnTitle: string;
    crudActionType: Enums.CrudOperation;
    trades: Array<ITradeInfo>;
    
    constructor(private fb: FormBuilder, private _tradeService: TradeService) { }

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

    addTrade(): void {
        this.setControlsState(true);
        this.crudActionType = Enums.CrudOperation.Create;
        this.modalTitle = "Add New Trade";
        this.modalBtnTitle = "Add";
        this.tradeForm.reset();
        this.modal.open();
    }

    editTrade(trade: ITradeInfo): void {
        this.setControlsState(true);
        this.crudActionType = Enums.CrudOperation.Update;
        this.modalTitle = "Edit Trade";
        this.modalBtnTitle = "Update";
        this.tradeForm.setValue(trade);
        this.modal.open();
    }

    deleteTrade(trade: ITradeInfo): void {
        this.setControlsState(false);
        this.crudActionType = Enums.CrudOperation.Delete;
        this.modalTitle = "Delete Trade";
        this.modalBtnTitle = "Ok";
        this.tradeForm.setValue(trade);
        this.modal.open();
    }

    onSubmit(formData: any) {
        let $this = this;
        switch (this.crudActionType) {
            case Enums.CrudOperation.Create:
                formData.value.Id = Utils.getNewGUID();
                this._tradeService.addOrUpdateTrade(formData.value)
                    .then(() => {
                        $this.trades.push(formData.value);
                        $this.modal.dismiss();
                    }, error => { console.log(error); });
                break;
            case Enums.CrudOperation.Update:
                this._tradeService.addOrUpdateTrade(formData.value)
                    .then(() => {
                        var itemToUpdateIndex = $this.trades.findIndex(f => f.Id == formData.value.Id);
                        if (itemToUpdateIndex !== -1) {
                            $this.trades[itemToUpdateIndex] = formData.value;
                            $this.modal.dismiss();
                        } else {
                            this.load();
                        }
                    }, error => { console.log(error); });
                break;
            case Enums.CrudOperation.Delete:
                if (formData.value && formData.value.Id) {
                    this._tradeService.removeTrade([formData.value.Id]).then(
                        () => {
                            var itemToDeleteIndex = $this.trades.findIndex(f => f.Id == formData.value.Id);
                            if (itemToDeleteIndex !== -1) {
                                $this.trades.splice(itemToDeleteIndex, 1);
                            }
                            $this.modal.dismiss();
                        },
                        error => { console.log(error); });
                } else {
                    return;
                }
                break;
        }  
    }

    setControlsState(isEnable: boolean) {
        isEnable ? this.tradeForm.enable() : this.tradeForm.disable();
    }
}
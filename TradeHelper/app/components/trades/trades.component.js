"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var trade_service_1 = require("../../service/trade.service");
var enums_1 = require("../../common/enums");
var utils_1 = require("../../common/utils");
var TradesComponent = (function () {
    function TradesComponent(fb, _tradeService) {
        this.fb = fb;
        this._tradeService = _tradeService;
    }
    TradesComponent.prototype.ngOnInit = function () {
        this.tradeForm = this.fb.group({
            Id: [''],
            PairCode: ['', forms_1.Validators.required],
            Amount: ['', forms_1.Validators.required],
            BuyPrice: [''],
            CellPrice: [''],
            StartDate: [''],
            CloseDate: [''],
            Status: ['', forms_1.Validators.required],
            Type: ['', forms_1.Validators.required]
        });
        this.load();
    };
    TradesComponent.prototype.load = function () {
        var $this = this;
        this._tradeService.getAllTrades()
            .then(function (trades) {
            $this.trades = trades.json() || {};
        }, function (error) { console.log(error); });
    };
    TradesComponent.prototype.calculateProfit = function (trade) {
        var result = 0;
        if (trade.Status == enums_1.Enums.PositionStatus.Closed) {
            result = trade.Type == enums_1.Enums.PositionType.Long
                ? (trade.Amount * (trade.CellPrice - trade.BuyPrice))
                : (trade.Amount * (trade.BuyPrice - trade.CellPrice));
        }
        return result;
    };
    TradesComponent.prototype.addTrade = function () {
        this.setControlsState(true);
        this.crudActionType = enums_1.Enums.CrudOperation.Create;
        this.modalTitle = "Add New Trade";
        this.modalBtnTitle = "Add";
        this.tradeForm.reset();
        this.modal.open();
    };
    TradesComponent.prototype.editTrade = function (trade) {
        this.setControlsState(true);
        this.crudActionType = enums_1.Enums.CrudOperation.Update;
        this.modalTitle = "Edit Trade";
        this.modalBtnTitle = "Update";
        this.tradeForm.setValue(trade);
        this.modal.open();
    };
    TradesComponent.prototype.deleteTrade = function (trade) {
        this.setControlsState(false);
        this.crudActionType = enums_1.Enums.CrudOperation.Delete;
        this.modalTitle = "Delete Trade";
        this.modalBtnTitle = "Ok";
        this.tradeForm.setValue(trade);
        this.modal.open();
    };
    TradesComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        var $this = this;
        switch (this.crudActionType) {
            case enums_1.Enums.CrudOperation.Create:
                formData.value.Id = utils_1.Utils.getNewGUID();
                this._tradeService.addOrUpdateTrade(formData.value)
                    .then(function () {
                    $this.trades.push(formData.value);
                    $this.modal.dismiss();
                }, function (error) { console.log(error); });
                break;
            case enums_1.Enums.CrudOperation.Update:
                this._tradeService.addOrUpdateTrade(formData.value)
                    .then(function () {
                    var itemToUpdateIndex = $this.trades.findIndex(function (f) { return f.Id == formData.value.Id; });
                    if (itemToUpdateIndex !== -1) {
                        $this.trades[itemToUpdateIndex] = formData.value;
                        $this.modal.dismiss();
                    }
                    else {
                        _this.load();
                    }
                }, function (error) { console.log(error); });
                break;
            case enums_1.Enums.CrudOperation.Delete:
                if (formData.value && formData.value.Id) {
                    this._tradeService.removeTrade([formData.value.Id]).then(function () {
                        var itemToDeleteIndex = $this.trades.findIndex(function (f) { return f.Id == formData.value.Id; });
                        if (itemToDeleteIndex !== -1) {
                            $this.trades.splice(itemToDeleteIndex, 1);
                        }
                        $this.modal.dismiss();
                    }, function (error) { console.log(error); });
                }
                else {
                    return;
                }
                break;
        }
    };
    TradesComponent.prototype.setControlsState = function (isEnable) {
        isEnable ? this.tradeForm.enable() : this.tradeForm.disable();
    };
    return TradesComponent;
}());
__decorate([
    core_1.ViewChild('modal'),
    __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
], TradesComponent.prototype, "modal", void 0);
TradesComponent = __decorate([
    core_1.Component({
        templateUrl: "app/components/trades/trades.component.html"
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, trade_service_1.TradeService])
], TradesComponent);
exports.TradesComponent = TradesComponent;
//# sourceMappingURL=trades.component.js.map
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
var TradesComponent = (function () {
    function TradesComponent(fb, _tradeService) {
        this.fb = fb;
        this._tradeService = _tradeService;
    }
    TradesComponent.prototype.ngOnInit = function () {
        this.tradeForm = this.fb.group({
            PairCode: [''],
            Amount: ['', forms_1.Validators.required]
        });
        this.load();
    };
    TradesComponent.prototype.load = function () {
        var $this = this;
        $this.isLoading = true;
        this._tradeService.getAllTrades()
            .subscribe(function (trades) {
            $this.trades = trades;
            $this.isLoading = false;
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
        this.modalTitle = "Add New User";
        this.modalBtnTitle = "Add";
        this.tradeForm.reset();
        this.modal.open();
    };
    TradesComponent.prototype.editTrade = function (id) {
    };
    TradesComponent.prototype.deleteTrade = function (trade) {
        var _this = this;
        if (trade && trade.Id) {
            this._tradeService.removeTrade([trade.Id]).then(function (data) {
                var itemToDeleteIndex = _this.trades.indexOf(trade);
                if (itemToDeleteIndex !== -1) {
                    _this.trades.splice(itemToDeleteIndex, 1);
                }
            }, function (error) { console.log(error); });
        }
        else {
            return;
        }
    };
    TradesComponent.prototype.onSubmit = function (formData) {
        debugger;
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
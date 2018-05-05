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
var trade_service_1 = require("../../service/trade.service");
var ChartComponent = /** @class */ (function () {
    function ChartComponent(_tradeService) {
        this._tradeService = _tradeService;
    }
    ChartComponent.prototype.ngOnInit = function () {
        this.load();
    };
    ChartComponent.prototype.load = function () {
        var $this = this;
        $this.currencyOptions = [
            { value: "BITFINEX:BTCUSD", label: "BTCUSD" },
            { value: "BITFINEX:XRPUSD", label: "XRPUSD" }
        ];
    };
    ChartComponent.prototype.select = function (value) {
        debugger;
    };
    ChartComponent.prototype.ngAfterViewInit = function () {
        var $this = this;
        new TradingView.widget({
            "container_id": "chart-container",
            "width": 980,
            "height": 610,
            "symbol": $this.activeCurrency.value,
            "interval": "240",
            "timezone": "Etc/UTC",
            "theme": "Dark",
            "style": "1",
            "locale": "en",
            "toolbar_bg": "#f1f3f6",
            "enable_publishing": false,
            "allow_symbol_change": true
        });
    };
    ChartComponent = __decorate([
        core_1.Component({
            selector: "my-app",
            templateUrl: "app/components/chart/chart.component.html"
        }),
        __metadata("design:paramtypes", [trade_service_1.TradeService])
    ], ChartComponent);
    return ChartComponent;
}());
exports.ChartComponent = ChartComponent;
//# sourceMappingURL=chart.component.js.map
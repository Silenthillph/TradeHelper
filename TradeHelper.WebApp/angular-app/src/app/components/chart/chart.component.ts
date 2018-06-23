import { Component } from '@angular/core';
import { TradeService } from '../../service/trade.service';

declare const TradingView: any;

@Component({
    selector: "app-tradingview-chart",
    templateUrl: "app/components/chart/chart.component.html"
})
export class ChartComponent {
    currencyOptions: Array<any>;
    activeCurrency: any;

    constructor(private _tradeService: TradeService) { }

    ngOnInit(): void {
        this.load();
    }

    load(): void {
        let $this = this;
        $this.currencyOptions = [
            { value: "BITFINEX:BTCUSD", label: "BTCUSD" },
            { value: "BITFINEX:XRPUSD", label: "XRPUSD" }
        ];
    }

    select(value: any): void {
        debugger;
    }

    ngAfterViewInit() {
        let $this = this;
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
    }
}

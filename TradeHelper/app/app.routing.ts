import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app.component';
import { HomeComponent } from './components/home/home.component';
import { TradesComponent } from './components/trades/trades.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'trades', component: TradesComponent }
];

export const routing: ModuleWithProviders =
    RouterModule.forRoot(appRoutes);
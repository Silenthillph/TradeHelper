import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { SettingsComponent } from '../components/settings/settings.component';
import { ProfileComponent } from '../components/profile/profile.component';

const routes: Routes = [
  { path: '',  redirectTo: '/dashboard',  pathMatch: 'full'},
  { path: 'dashboard', component: DashboardComponent },
  { path: 'settings', component: SettingsComponent },
  { path: 'profile', component: ProfileComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {
    
}

import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES, Routes, Router } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomerComponent } from './+customer/customer.component';
import { APP_PROVIDERS } from './app.providers';

@Component({
    moduleId: module.id, //Needed to be able to resolve relative urls for templates and styles.
    selector: 'angular-dev-app',
    template: `<router-outlet></router-outlet>`,
    directives: [ROUTER_DIRECTIVES],
    providers: [APP_PROVIDERS]
})
@Routes([
    { path: '/', component: DashboardComponent },
    { path: '/customer/:id', component: CustomerComponent },
    { path: '*', component: DashboardComponent }
])
export class AngularDevAppComponent {
  
    title = 'angular-dev works!';
    constructor(private router: Router) {

    }

}

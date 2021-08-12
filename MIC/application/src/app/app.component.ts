import { Component } from '@angular/core';

import { AccountService } from './_services';
import { User } from './_models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
    user: User;
    isAdmin = false;

    constructor(private accountService: AccountService) {
        this.accountService.user.subscribe(x => this.user = x);

        let user = this.accountService.userValue;

        if (user != null && user.role !== undefined && user.role === "admin") {
            this.isAdmin = true;
        }
        
    }

    logout() {
        this.accountService.logout();
    }
}
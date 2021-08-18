import { Component } from '@angular/core';

import { AccountService } from '@app/_services';
import { Router, NavigationStart } from '@angular/router';

@Component({ templateUrl: 'layout.component.html' })
export class LayoutComponent { 

    constructor(private accountService: AccountService, router: Router) {
    }



}
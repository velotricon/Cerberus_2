﻿import { Component, Input, OnInit }         from '@angular/core';
import { MenuItem }                         from './menu-item';
import { MenuService }                      from './menu.service';


@Component({
    selector: 'menu',
    templateUrl: './templates/menu.html'
})

export class MenuComponent implements OnInit {
    constructor(private service: MenuService) {
    }

    MenuItems: MenuItem[];

    LoadMenuItems(): void {
        this.service.GetMenuItems().then(x => this.MenuItems = x);
    }

    ngOnInit(): void {
        this.LoadMenuItems();
    }
}
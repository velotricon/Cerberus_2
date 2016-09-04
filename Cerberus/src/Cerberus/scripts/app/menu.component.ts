import { Component, Input, OnInit }         from '@angular/core';
import { MenuItem }                         from './menu-item';
import { MenuService }                      from './menu.service';


@Component({
    selector: 'menu',
    template: `
<div *ngFor="let item of MenuItems" class="menu-item">
    <a href="{{item.href}}">{{item.label}}</a>
</div>
`
})

export class MenuComponent implements OnInit {
    MenuItems: MenuItem[];

    LoadMenuItems(): void {
        this.MenuItems = this.service.GetMenuItems();
    }

    ngOnInit(): void {
        this.LoadMenuItems();
    }

    constructor(private service: MenuService) {

    }
}
import { Component, Input }         from '@angular/core';
import { MenuItem }                 from './menu-item';

@Component({
    selector: 'menu',
    template: `
<div *ngFor="let item of MenuItems" class="menu-item">
    <a href="{{item.href}}">{{item.label}}</a>
</div>
`
})

export class MenuComponent {
    @Input()
    MenuItems: MenuItem[];
}
//Ten komponent się chyba już nie przyda. Można go będzie wywalić.

import { Component, Input }     from '@angular/core';
import { MenuItem }             from './menu-item';

@Component({
    selector: 'menu-item',
    template: `
<div class="menu-item">
    <a href="{{menuItem.href}}">{{menuItem.label}}</a>
</div>
`
})

export class MenuItemComponent {
    @Input()
    menuItem: MenuItem;
}


import { Injectable }       from '@angular/core';
import { MenuItem }         from './menu-item';
import { MENU_ITEMS }       from './menu.mock';

@Injectable()
export class MenuService {
    GetMenuItems(): MenuItem[] {
        return MENU_ITEMS;
    }
}
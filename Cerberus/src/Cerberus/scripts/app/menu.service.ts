import { Injectable }       from '@angular/core';
import { MENU_ITEMS }       from './menu.mock';

@Injectable()
export class MenuService {
    GetMenuItems(): Promise<MenuItem[]> {
        let menu_items = MENU_ITEMS;
        return Promise.resolve(menu_items);
    }
}

export class MenuItem {
    Label: string;
    Href: string;
}
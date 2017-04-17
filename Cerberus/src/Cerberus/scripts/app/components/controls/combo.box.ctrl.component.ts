import { Component, Input, Output }                     from '@angular/core';
import { trigger, state, style, animate, transition }   from '@angular/animations';
import { LoggerService }                                from '../../services/logger.service';
import { ComboBoxModelContainer }                       from '../../containers/combo.box.model.container';
import { ComboBoxItemContainer }                        from '../../containers/combo.box.item.container';


let OpenCloseComboAnimation = trigger('OpenCloseCombo', [
    state('Open', style({
        'display': 'block'
    })),
    state('Close', style({
        'display': 'none'
    })),
    transition('Open => Close', animate('100ms ease out')),
    transition('Close => Open', animate('100ms ease in'))
]);

@Component({
    selector: 'combo-box-ctrl',
    templateUrl: './templates/controls/combo.box.ctrl.html',
    animations: [OpenCloseComboAnimation]
})
export class ComboBoxCtrlComponent {
    constructor(private logger: LoggerService) { }

    @Input('Model') Model: ComboBoxModelContainer;

    private is_open: boolean = false;

    private open_close_combo() {
        this.is_open = !this.is_open;
    }

    private item_selected(ItemId: string): void {

    }
}
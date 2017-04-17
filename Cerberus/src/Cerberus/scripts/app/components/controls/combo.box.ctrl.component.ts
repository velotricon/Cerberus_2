import { Component, Input, Output }                     from '@angular/core';
import { trigger, state, style, animate, transition }   from '@angular/animations';
import { LoggerService }                                from '../../services/logger.service';
import { ComboBoxModelContainer }                       from '../../containers/combo.box.model.container';
import { ComboBoxItemContainer }                        from '../../containers/combo.box.item.container';


let OpenCloseComboAnimation = trigger('OpenCloseCombo', [
    state('Open', style({
        display: 'block'
    })),
    state('Close', style({
        display: 'none'
    })),
    transition('Open => Close', animate('500ms ease-up')),
    transition('Close => Open', animate('500ms ease-down'))
]);

@Component({
    selector: 'combo-box-ctrl',
    templateUrl: './templates/controls/combo.box.ctrl.html',
    animations: [OpenCloseComboAnimation]
})
export class ComboBoxCtrlComponent {
    constructor(private logger: LoggerService) { }

    @Input('Model') Model: ComboBoxModelContainer;

    private is_open: string = 'Close';

    private open_close_combo() {
        if (this.is_open == 'Close') {
            this.is_open = 'Open';
        } else {
            this.is_open = 'Close';
        }
    }

    private item_selected(ItemId: string): void {

    }
}
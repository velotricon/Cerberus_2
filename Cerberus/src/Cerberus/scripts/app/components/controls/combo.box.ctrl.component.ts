import { Component, Input, Output }         from '@angular/core';
import { trigger, state, style, animate, transition }   from '@angular/animations';
import { LoggerService }                    from '../../services/logger.service';
import { ComboBoxModelContainer }           from '../../containers/combo.box.model.container';
import { ComboBoxItemContainer }            from '../../containers/combo.box.item.container';

@Component({
    selector: 'combo-box-ctrl',
    templateUrl: './templates/controls/combo.box.ctrl.html'
})
export class ComboBoxCtrlComponent {
    constructor(private logger: LoggerService) { }

    @Input('Model') Model: ComboBoxModelContainer;

    private item_selected(ItemId: string): void {

    }
}

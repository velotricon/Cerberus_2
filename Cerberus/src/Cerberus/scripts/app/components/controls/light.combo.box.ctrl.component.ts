import { Component, Input, Output, EventEmitter}    from '@angular/core';
import { LightComboBoxModelContainer }              from '../../containers/light.combo.box.model.container';
import { LightComboBoxItemContainer }               from '../../containers/light.combo.box.item.container';

@Component({
    selector: 'light-combo-box-ctrl',
    templateUrl: './templates/controls/light.combo.box.ctrl.html'
})
export class LightComboBoxCtrlComponent {
    private _model: LightComboBoxModelContainer;
    @Output() modelChange: EventEmitter<LightComboBoxModelContainer> = new EventEmitter<LightComboBoxModelContainer>();
    @Input('model') model: LightComboBoxModelContainer;
    get(): LightComboBoxModelContainer {
        return this._model;
    }
    set(Model: LightComboBoxModelContainer): void {
        this._model = Model;
    }

    private on_model_changed(): void {
        this.modelChange.emit(this._model);
    }
}
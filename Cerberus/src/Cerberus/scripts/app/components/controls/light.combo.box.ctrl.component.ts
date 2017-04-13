import { Component, Input, Output, EventEmitter}    from '@angular/core';
import { LightComboBoxModelContainer }              from '../../containers/light.combo.box.model.container';
import { LightComboBoxItemContainer }               from '../../containers/light.combo.box.item.container';

@Component({
    selector: 'light-combo-box-ctrl',
    templateUrl: './templates/controls/light.combo.box.ctrl.html'
})
export class LightComboBoxCtrlComponent {
    //private _model: LightComboBoxModelContainer;
    //@Output() ModelChange: EventEmitter<LightComboBoxModelContainer> = new EventEmitter<LightComboBoxModelContainer>();
    @Input('Model') Model: LightComboBoxModelContainer;
    //get(): LightComboBoxModelContainer {
    //    return this._model;
    //}
    //set(Model: LightComboBoxModelContainer): void {
    //    this._model = Model;
    //}

    @Input('AddEmptyRow') AddEmptyRow: boolean = false;

    private on_model_changed(): void {
        //this.ModelChange.emit(this.Model);
    }
}
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { LoggerService } from '../../services/logger.service';

@Component({
    templateUrl: './templates/controls/text.box.ctrl.html',
    selector: 'text-box-ctrl'
})
export class TextBoxCtrlComponent {
    constructor(private logger: LoggerService) { }

    private _value: string;
    @Output() valueChange: EventEmitter<string> = new EventEmitter<string>();
    @Input()
    get value(): string {
        return this._value;
    }
    set value(Value: string) {
        this._value = Value;
    }

    on_value_change(): void {
        this.logger.Debug('emit', 'on_value_change', 'TextBoxCtrlComponent');
        this.valueChange.emit(this._value);
    }
}
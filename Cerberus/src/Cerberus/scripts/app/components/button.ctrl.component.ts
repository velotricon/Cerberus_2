import { Component, Output, EventEmitter, Input }    from '@angular/core';

@Component({
    selector: 'button-ctrl',
    templateUrl: './templates/button.ctrl.html'
})
export class ButtonCtrlComponent {
    @Input('text') text: string;
    @Output('click') click = new EventEmitter();

    on_click(): void {
        this.click.emit();
    }
}

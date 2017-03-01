import { Component, Output, EventEmitter }        from '@angular/core';

@Component({
    selector: 'confirm-popup',
    templateUrl: './templates/confirm.popup.html'
})
export class ConfirmPopupComponent {
    
    @Output('OnOkClick') OnOkClick = new EventEmitter();
    @Output('OnAbortClick') OnAbortClick = new EventEmitter();

    private is_visible = false;
    private text: string;
    private show_ok_abort_buttons = true;
    private show_yes_no_buttons = false;

    private ok_click(): void {
        this.is_visible = false;
        this.OnOkClick.emit();
    }
    private abort_click(): void {
        this.is_visible = false;
        this.OnAbortClick.emit();
    }
    
    public Show(Text: string, YesNoMode?: boolean): void {
        if (YesNoMode == undefined) {
            this.show_ok_abort_buttons = !YesNoMode;
            this.show_yes_no_buttons = YesNoMode;
        } else {
            this.show_ok_abort_buttons = true;
            this.show_yes_no_buttons = false;
        }
        this.text = Text;
        this.is_visible = true;
    }

}
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
    private ShowOkAbortButtons = true;
    private ShowYesNoButtons = false;

    private ok_click(): void {
        this.is_visible = false;
        this.OnOkClick.emit();
    }
    private abort_click(): void {
        this.is_visible = false;
        this.OnAbortClick.emit();
    }

    public Show(Text: string) {
        this.text = Text;
        this.is_visible = true;
    }
    public Show(Text: string, YesNoMode: boolean): void {

    }

}
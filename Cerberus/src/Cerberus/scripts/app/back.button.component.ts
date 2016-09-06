import { Component }        from '@angular/core'

@Component({
    selector: 'back-button',
    template: '<button (click)="GoBack()">Back</button>'
})
export class BackButtonComponent {
    GoBack(): void {
        window.history.back();
    }
}
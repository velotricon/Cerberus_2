import { Component, Input, OnInit }         from '@angular/core';

@Component({
    selector: 'test',
    templateUrl: './templates/test.html'
})
export class TestComponent {
    OnKeyUp(evt: any) {
        console.log(evt);
    }
}
import { Component }            from '@angular/core';
import { MenuService }          from './menu.service';

@Component({
    selector: 'cerberus-app',
    template: `
<menu [MenuItems]="MenuItemsTable"></menu>

<br />
<br />
<input [(ngModel)]="App.TmpVal">
<label>{{App.TmpVal}}</label>
<ul>
    <li *ngFor="let obj of TestObjects" (click)="OnTestObjSelected(obj)">{{obj.TmpVal}}</li>
</ul>
<label (click)="ChangeVisibility()">{{VisibilityMessage}}</label>  
<div *ngIf="TabVisibility">
    Tutaj coś jest napisane, elo!
</div>
`})

export class AppComponent {

    App: TestObj = {
        TmpVal: 'Insert your text'
    };

    OnTestObjSelected(obj: TestObj) {
        alert(obj.TmpVal);
    }

    ChangeVisibility() {
        this.TabVisibility = !this.TabVisibility;
        if (this.TabVisibility) {
            this.VisibilityMessage = "Ukryj";
        } else {
            this.VisibilityMessage = "Pokaż";
        }
    }

    TabVisibility: boolean = false;
    VisibilityMessage: string = "Pokaż";

    TestObjects: TestObj[] = [
        { TmpVal: 'test 1' },
        { TmpVal: 'test 2' },
        { TmpVal: 'test 3' }
    ];
}

export class TestObj {
    TmpVal: string;
}
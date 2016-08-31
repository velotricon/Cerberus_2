import { Component }            from '@angular/core';
import { MenuItemComponent }    from './menu-item.component';
import { MenuItem }             from './menu-item';

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
    MenuItemsTable: MenuItem[] = [
        { label: 'link 1', href: '/test1' },
        { label: 'link 2', href: '/test2' },
        { label: 'link 3', href: '/test3' }
    ]; 

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
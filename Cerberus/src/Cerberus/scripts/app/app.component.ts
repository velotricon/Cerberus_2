﻿import { Component, ViewChild }     from '@angular/core';
import { RouterModule }             from '@angular/router';
import { ProfileComponent }         from './profile.component';
import { NotificationComponent }    from './notification.component';

import { NotificationContainer }    from './containers/notification.container';

import './rxjs.operators';


@Component({
    selector: 'cerberus-app',
    templateUrl: './templates/app.html'
})
export class AppComponent {
    @ViewChild('profile') profile: ProfileComponent;
    @ViewChild('notificator') notificator: NotificationComponent;

    on_notification(NotificationObj: NotificationContainer) {
        alert('on notification');
    }

    OnClick_TestBtn(): void {
        this.notificator.ShowNotification(new NotificationContainer("Test title Test title Test title ",
            "bvsijsdklf asdadsadkkkeeek asdsdk eks sdmakorjeiraf dsde bvsijsdklf asdadsadkkkeeek asdsdk eks sdmakorjeiraf dsde bvsijsdklf asdadsadkkkeeek asdsdk eks sdmakorjeiraf dsde"
        ));
    }   
}
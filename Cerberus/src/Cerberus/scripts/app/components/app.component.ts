import { Component, ViewChild }     from '@angular/core';
import { RouterModule }             from '@angular/router';
import { ProfileComponent }         from './profile.component';
import { NotificationComponent }    from './notification.component';
import { NotificationService }      from '../services/notification.service';
import { NotificationContainer }    from '../containers/notification.container';

import './rxjs.operators';


@Component({
    selector: 'cerberus-app',
    templateUrl: './templates/app.html'
})
export class AppComponent {
    constructor(private notification_service: NotificationService) {
        this.notification_service.NotificationAnnounced.subscribe(notification => {
            this.notificator.ShowNotification(notification);
        });
    }

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
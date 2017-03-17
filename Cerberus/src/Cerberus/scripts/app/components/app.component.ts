import { Component, ViewChild }     from '@angular/core';
import { RouterModule }             from '@angular/router';

import { ProfileComponent }         from './profile.component';
import { NotificationComponent }    from './notification.component';
import { ConfirmPopupComponent }    from './confirm.popup.component';

import { NotificationService }      from '../services/notification.service';
import { RootCommunicationService } from '../services/root.communication.service';

import { NotificationContainer }    from '../containers/notification.container';


import '../rxjs.operators';


@Component({
    selector: 'cerberus-app',
    templateUrl: './templates/app.html'
})
export class AppComponent {
    constructor(private notification_service: NotificationService,
        private root_communication_service: RootCommunicationService
    ) {
        this.notification_service.NotificationAnnounced.subscribe(notification => {
            this.notificator.ShowNotification(notification);
        });

        this.root_communication_service.StringMessageAnnounced.subscribe(message => {
            this.on_string_message_anounced(message);
        });
    }

    @ViewChild('profile') profile: ProfileComponent;
    @ViewChild('notificator') notificator: NotificationComponent;
    @ViewChild('popup') popup: ConfirmPopupComponent;

    on_notification(NotificationObj: NotificationContainer) {
        alert('on notification');
    }

    OnClick_TestBtn(): void {
        //this.notificator.ShowNotification(new NotificationContainer("Test title Test title Test title ",
        //    "bvsijsdklf asdadsadkkkeeek asdsdk eks sdmakorjeiraf dsde bvsijsdklf asdadsadkkkeeek asdsdk eks sdmakorjeiraf dsde bvsijsdklf asdadsadkkkeeek asdsdk eks sdmakorjeiraf dsde"
        //));
        this.popup.Show("Are you sure?", false);
    }   

    OnPopupOk(): void {
        alert('popup OK');
    }
    OnPopupAbort(): void {
        alert('popop ABORT');
    }

    private on_string_message_anounced(Msg: string): void {
        switch (Msg) {
            case 'refresh profile':
                this.profile.RefreshProfileInfo();
                break;
        }
    }
}
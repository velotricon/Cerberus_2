import { Component }                from '@angular/core';

import { StatusContainer }          from '../containers/status.container';
import { NotificationContainer }    from '../containers/notification.container';


@Component({
    selector: 'notification',
    templateUrl: './templates/notification.html'
})
export class NotificationComponent {

    private is_visible: boolean = false;
    private current_title: string;
    private current_content: string;

    private close_click(): void {
        this.is_visible = false;
    }

    public ShowNotification(NewNotification: NotificationContainer): void {
        this.current_title = NewNotification.Title;
        this.current_content = NewNotification.Content;
        this.is_visible = true;
    }
}
import { Injectable }               from '@angular/core';
import { Subject }                  from 'rxjs/subject';
import { NotificationContainer }    from './containers/notification.container'

@Injectable()
export class NotificationService {
    //Observable sources
    private notification_announced_source = new Subject<NotificationContainer>();
    private notification_confirmed_source = new Subject<NotificationContainer>();

    //Observable streams
    public NotificationAnnounced = this.notification_announced_source.asObservable();
    public NotifiactionConfirmed = this.notification_confirmed_source.asObservable();

    //service message commands
    public AnnounceNotification(Notif: NotificationContainer) {
        this.notification_announced_source.next(Notif);
    }

    public ConfirmNotification(Notif: NotificationContainer) {
        this.notification_confirmed_source.next(Notif);
    }
}


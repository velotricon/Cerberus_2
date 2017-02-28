import { Injectable }               from '@angular/core';
import { Subject }                  from 'rxjs/subject';
import { NotificationContainer }    from './containers/notification.container'

@Injectable()
export class NotificationService {
    //Observable source
    private notification_announced_source = new Subject<NotificationContainer>();

    //Observable stream
    public NotificationAnnounced = this.notification_announced_source.asObservable();

    //service message command
    public AnnounceNotification(Notif: NotificationContainer) {
        this.notification_announced_source.next(Notif);
    }
}


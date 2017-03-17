import { Injectable }               from '@angular/core';
import { Subject }                  from 'rxjs/subject';

@Injectable()
export class RootCommunicationService {
    //Observable source
    private string_message_announced_source = new Subject<string>();

    //Observable stream
    public StringMessageAnnounced = this.string_message_announced_source.asObservable();

    //service message commang
    public AnnounceStringMessage(Msg: string) {
        this.string_message_announced_source.next(Msg);
    }
}
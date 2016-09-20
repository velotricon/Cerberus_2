import { Injectable }       from '@angular/core'

@Injectable()
export class LoggerService {
    constructor() {
        this.LogList = new Array < LogContainer >();
    }

    AllowLog: boolean = true;
    AllowInfo: boolean = true;
    AllowDebug: boolean = true;
    AllowError: boolean = true; 

    LogList: LogContainer[];


    Log(Sender: string, Message: string) {
        console.log(this.prepare_console_message(Sender, Message));
        this.add_log('LOG', Sender, Message);
    }

    Info(Sender: string, Message: string) {
        console.info(this.prepare_console_message(Sender, Message));
        this.add_log('INFO', Sender, Message);
    }

    Debug(Sender: string, Message: string) {
        console.debug(this.prepare_console_message(Sender, Message));
        this.add_log('DEBUG', Sender, Message);
    }

    Error(Sender: string, Message: string) {
        console.error(this.prepare_console_message(Sender, Message));
        this.add_log('ERROR', Sender, Message);
    }

    private add_log(LogType: string, Sender: string, Message: string) {
        //let new_log = new LogContainer(LogType, Sender, Message);
        this.LogList.push(new LogContainer(LogType, Sender, Message));
    }

    private prepare_console_message(Sender: string, Message: string): string {
        let result = Sender + ' >> ' + Message;
        return result;
    }
}

export class LogContainer {
    public LogDate: Date;
    constructor(public Type: string, public Sender: string, public Message: string) {
        this.LogDate = new Date(Date.now());
    }
}
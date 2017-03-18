import { Injectable }       from '@angular/core'
import { LogContainer }     from '../containers/log.container';

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
    
    Log(Message: string): void
    Log(Message: string, Sender: string): void
    Log(Message: string, Sender: string, ComponentName: string): void
    Log(Message: string, Sender?: string, ComponentName?: string): void {
        console.log(this.prepare_console_message(Message, Sender, ComponentName));
        this.add_log('LOG', Message, Sender, ComponentName);
    }

    Info(Message: string): void
    Info(Message: string, Sender: string): void
    Info(Message: string, Sender: string, ComponentName: string): void
    Info(Message: string, Sender?: string, ComponentName?: string): void {
        console.info(this.prepare_console_message(Message, Sender, ComponentName));
        this.add_log('INFO', Message, Sender, ComponentName);
    }

    Debug(Message: string): void
    Debug(Message: string, Sender: string): void
    Debug(Message: string, Sender: string, ComponentName: string): void
    Debug(Message: string, Sender?: string, ComponentName?: string): void {
        console.debug(this.prepare_console_message(Message, Sender, ComponentName));
        this.add_log('DEBUG', Message, Sender, ComponentName);
    }

    Error(Message: string): void
    Error(Message: string, Sender: string): void
    Error(Message: string, Sender: string, ComponentName: string): void
    Error(Message: string, Sender?: string, ComponentName?: string): void {
        console.error(this.prepare_console_message(Message, Sender, ComponentName));
        this.add_log('ERROR', Message, Sender, ComponentName);
    }

    private add_log(LogType: string, Message: string, Sender: string, ComponentName: string): void{
        //let new_log = new LogContainer(LogType, Sender, Message);
        this.LogList.push(new LogContainer(LogType, ComponentName, Sender, Message));
    }

    private prepare_console_message(Message: string, Sender: string, ComponentName: string): string {
        let result: string = "";
        if (ComponentName != null) {
            result += ComponentName + ' >> ';
        } else {

        }
        if (Sender != null) {
             result += Sender + ' >> ' + Message;
        } else {
            result += Message;
        }
        return result;
    }
}


import { Output, EventEmitter }     from '@angular/core';
import { LoggerService }            from '../logger.service';
import { NotificationContainer }    from '../containers/notification.container';

export class AbstractComponent {
    constructor(public ComponentName: string, protected logger: LoggerService) {
        this.logger.Debug(this.ComponentName, 'Component creation...');
    }

    @Output() OnNotification = new EventEmitter<NotificationContainer>();

    //#region Logs
    protected LogDebug(Message: string): void {
        this.logger.Debug(this.ComponentName, Message);
    }
    protected LogInfo(Message: string): void {
        this.logger.Info(this.ComponentName, Message);
    }
    protected LogLog(Message: string): void {
        this.logger.Log(this.ComponentName, Message);
    }
    protected LogError(Message: string): void {
        this.logger.Error(this.ComponentName, Message);
    }
    //#endregion

    protected ShowNotification(Title: string, Content: string): void {
        this.OnNotification.emit(new NotificationContainer(Title, Content));
    }

}
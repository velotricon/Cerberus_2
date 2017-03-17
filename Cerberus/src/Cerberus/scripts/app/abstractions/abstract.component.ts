//import { Output, EventEmitter }     from '@angular/core';
import { LoggerService }                    from '../services/logger.service';
import { NotificationService }              from '../services/notification.service';
import { RootCommunicationService }         from '../services/root.communication.service';
import { NotificationContainer }            from '../containers/notification.container';

export class AbstractComponent {
    constructor(public ComponentName: string,
        protected logger?: LoggerService,
        protected notification_service?: NotificationService,
        protected root_communication_service?: RootCommunicationService
    ) {
        
    }

    //#region Logs
    protected LogDebug(Message: string): void {
        if (this.logger != null) {
            this.logger.Debug(this.ComponentName, Message);
        } else {
            throw new ReferenceError("Logger service not provided!");
        }
    }
    protected LogInfo(Message: string): void {
        if (this.logger != null) {
            this.logger.Info(this.ComponentName, Message);
        } else {
            throw new ReferenceError("Logger service not provided!");
        }
    }
    protected LogLog(Message: string): void {
        if (this.logger != null) {
            this.logger.Log(this.ComponentName, Message);
        } else {
            throw new ReferenceError("Logger service not provided!");
        }
    }
    protected LogError(Message: string): void {
        if (this.logger != null) {
            this.logger.Error(this.ComponentName, Message);
        } else {
            throw new ReferenceError("Logger service not provided!");
        }
    }
    //#endregion Logs


    //#region Notifications
    protected ShowNotification(Title: string, Content: string): void {
        //this.OnNotification.emit(new NotificationContainer(Title, Content));
        if (this.notification_service != null) {
            this.notification_service.AnnounceNotification(new NotificationContainer(Title, Content));
        } else {
            throw new ReferenceError("Notification service not provided!");
        }
    } 
    //#endregion Notifications


    //#region RootCommunication
    protected MessageToRoot(Msg: string): void {
        if (this.root_communication_service != null) {
            this.root_communication_service.AnnounceStringMessage(Msg);
        } else {
            throw new ReferenceError("RootCommunication service not provided!");
        }
    }
    //#endregion RootCommunication

}
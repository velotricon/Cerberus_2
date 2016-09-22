import { LoggerService }            from '../logger.service';

export class AbstractComponent {
    constructor(public ComponentName: string, protected logger: LoggerService) {
        this.logger.Debug(this.ComponentName, 'Component creation...');
    }

    //#region Logs
    protected LogDebug(Message: string) {
        this.logger.Debug(this.ComponentName, Message);
    }
    protected LogInfo(Message: string) {
        this.logger.Info(this.ComponentName, Message);
    }
    protected LogLog(Message: string) {
        this.logger.Log(this.ComponentName, Message);
    }
    protected LogError(Message: string) {
        this.logger.Error(this.ComponentName, Message);
    }
    //#endregion


}
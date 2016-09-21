import { LoggerService }            from '../logger.service';

export class AbstractComponent {
    constructor(public ComponentName: string, protected logger: LoggerService) {
        this.logger.Debug(this.ComponentName, 'Component creation...');
    }
}
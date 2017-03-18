export class LogContainer {
    public LogDate: Date;
    constructor(public Type: string, public Component: string, public Sender: string, public Message: string) {
        this.LogDate = new Date(Date.now());
    }
}
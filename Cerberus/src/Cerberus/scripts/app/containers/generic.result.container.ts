export class GenericResultContainer {
    constructor(
        public Succeeded: boolean,
        public Message: string,
        public Result: any
    ) { };
}
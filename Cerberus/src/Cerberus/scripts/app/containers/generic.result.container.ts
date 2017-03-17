export class GenericResultContainer {
    constructor(
        public Succeded: boolean,
        public Message: string,
        public Result: any
    ) { };
}
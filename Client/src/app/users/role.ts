export class Role {
    id: string;
    name: string;
    normalizedName: string;
    concurrencyStamp: string;

    constructor(){
        this.id = "";
        this.name = "";
        this.normalizedName = "";
        this.concurrencyStamp = "";
    }
}
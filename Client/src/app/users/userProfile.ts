export class UserProfile {
    name: string;
    description: string;
    id: number;
    active: boolean;
    userId: string;
    updatedAt: Date;
    createdAt: Date;
    constructor() {
        this.name = "";
        this.description = "";
        this.id = 0;
        this.active = false;
        this.userId = "";
        this.updatedAt = new Date();
        this.createdAt = new Date();
    }
}
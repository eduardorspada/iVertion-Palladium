export class UsersProfilesDbFilter {
    name: string;
    active: boolean;
    userId: string;
    page: number;
    pageSize: number;
    orderByProperty: string;
    sort: string;
    constructor() {
        this.name = "";
        this.active = true;
        this.userId = "";
        this.page = 1;
        this.pageSize = 20;
        this.orderByProperty = "";
        this.sort = "";
    }
}

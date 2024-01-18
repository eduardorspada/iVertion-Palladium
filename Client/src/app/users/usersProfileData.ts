import { UserProfile } from "./userProfile";

export class UsersProfilesData  {
    totalRegister: number;
    data: UserProfile[];
    constructor() {
        this.totalRegister = 0;
        this.data = [];
    }
}
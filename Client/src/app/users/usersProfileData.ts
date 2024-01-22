import { UserProfile } from "./userProfile";

export class UsersProfilesData  {
    totalRegisters: number;
    data: UserProfile[];
    constructor() {
        this.totalRegisters = 0;
        this.data = [];
    }
}
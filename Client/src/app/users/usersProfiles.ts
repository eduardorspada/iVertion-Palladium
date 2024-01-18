import { UsersProfilesData } from "./usersProfileData";

export class UsersProfiles {
    data: UsersProfilesData;
    isSuccess: boolean;
    message: string;
    errors: string;
    constructor() {
        this.data = new UsersProfilesData();
        this.isSuccess = false;
        this.message = "";
        this.errors = "";
    }
}
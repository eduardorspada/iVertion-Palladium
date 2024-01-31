import { UserProfile } from "./userProfile";

export class UserProfileData  {
    totalRegisters: number;
    data: UserProfile;
    constructor() {
        this.totalRegisters = 0;
        this.data = new UserProfile;
    }
}
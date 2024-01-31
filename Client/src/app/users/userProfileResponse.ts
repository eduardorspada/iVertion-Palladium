import { UserProfile } from "./userProfile";

export class UserProfileResponse {
    data: UserProfile;
    isSuccess: boolean;
    message: string;
    errors: string;
    constructor() {
        this.data = new UserProfile();
        this.isSuccess = false;
        this.message = "";
        this.errors = "";
    }
}
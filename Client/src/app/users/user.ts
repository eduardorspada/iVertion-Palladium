export class User {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    fullName: string;
    email: string;
    password: string;
    confirmPassword: string;
    isEnabled: boolean;
    profilePicture: string;
    profileCover: string;
    profileDescription: string;
    occupation: string;
    birthday: Date;
    phoneNumber: string;
    userProfileId: number;

    constructor (){
        this.id = "";
        this.userName = "";
        this.firstName = "";
        this.lastName = "";
        this.fullName = "";
        this.email = "";
        this.password = "";
        this.confirmPassword = "";
        this.isEnabled = false;
        this.profilePicture = "";
        this.profileCover = "";
        this.profileDescription = "";
        this.occupation = "";
        this.birthday = new Date();
        this.phoneNumber = "";
        this.userProfileId = 0;
    }
}
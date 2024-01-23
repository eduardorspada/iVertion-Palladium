import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersListComponent } from './users-list/users-list.component';
import { FormsModule } from '@angular/forms';
import { UserComponent } from './user/user.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { UpdateUserPasswordComponent } from './update-user-password/update-user-password.component';
import { UpdateUserNameComponent } from './update-user-name/update-user-name.component';
import { UpdateUserFullNameComponent } from './update-user-full-name/update-user-full-name.component';
import { UpdateUserEmailComponent } from './update-user-email/update-user-email.component';
import { UpdateUserStatusComponent } from './update-user-status/update-user-status.component';
import { UpdateUserPhoneNumberComponent } from './update-user-phone-number/update-user-phone-number.component';
import { UpdateUserProfilePictureComponent } from './update-user-profile-picture/update-user-profile-picture.component';
import { UpdateUserProfileCoverComponent } from './update-user-profile-cover/update-user-profile-cover.component';
import { UpdateUserProfileDescriptionComponent } from './update-user-profile-description/update-user-profile-description.component';
import { UpdateUserOccupationComponent } from './update-user-occupation/update-user-occupation.component';
import { UpdateUserBirthdayComponent } from './update-user-birthday/update-user-birthday.component';
import { UserRolesComponent } from './user-roles/user-roles.component';
import { UsersProfilesListComponent } from './users-profiles-list/users-profiles-list.component';
import { CreateUserProfileComponent } from './create-user-profile/create-user-profile.component';
import { UserProfileComponent } from './user-profile/user-profile.component';


@NgModule({
  declarations: [
    UsersListComponent,
    UserComponent,
    CreateUserComponent,
    UpdateUserPasswordComponent,
    UpdateUserNameComponent,
    UpdateUserFullNameComponent,
    UpdateUserEmailComponent,
    UpdateUserStatusComponent,
    UpdateUserPhoneNumberComponent,
    UpdateUserProfilePictureComponent,
    UpdateUserProfileCoverComponent,
    UpdateUserProfileDescriptionComponent,
    UpdateUserOccupationComponent,
    UpdateUserBirthdayComponent,
    UserRolesComponent,
    UsersProfilesListComponent,
    CreateUserProfileComponent,
    UserProfileComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    FormsModule
  ],
  exports: [
    UsersListComponent,
  ]
})
export class UsersModule { }

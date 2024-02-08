import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../userProfile';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersService } from 'src/app/users.service';
import { Role } from '../role';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  userProfile: UserProfile = new UserProfile();
  roles: Array<string> = [];
  role: Array<string> = ["AddToRole", "GetUsers"];
  userProfileRoles: Array<string> = [];
  otherUserProfileRoles: Array<string> = [];
  allUserProfileRoles: Array<Role> = [];
  id: string = "";
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private usersService: UsersService
    )
  {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.roles = this.authService.getRoles();
  }
  ngOnInit(): void {
    for (let i in this.role) {
      if (this.roles.indexOf(this.role[i]) === -1) {
        this.router.navigate(['manager/403']);
      }
    }
    if (this.id !== undefined) {
      this.usersService.getUserProfileByIdAsync(this.id).subscribe(
        (value) => {
          this.userProfile = value.data;
        },
        (err) => {
          console.log(err)
        }
        )
        this.usersService.getRolesUserProfileById(this.id).subscribe(
          (value) => {
            this.userProfileRoles = value;
            for (let i in this.allUserProfileRoles) {
              if (this.userProfileRoles.indexOf(this.allUserProfileRoles[i].name) === -1){
                this.otherUserProfileRoles.push(this.allUserProfileRoles[i].name)
              }
            }
          },
          (err) => {
            console.log(err)
          }
        )
      this.usersService.getAllUsersRoles().subscribe(
        (value) => {
          this.allUserProfileRoles = value;
        },
        (err) => {
          console.log(err)
        },
        () => {
          // action
        }
      )
    }
  }
  onSubmit(){

  }
}

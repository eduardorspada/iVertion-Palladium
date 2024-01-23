import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UserProfile } from '../userProfile';
import { UsersService } from 'src/app/users.service';

@Component({
  selector: 'app-create-user-profile',
  templateUrl: './create-user-profile.component.html',
  styleUrls: ['./create-user-profile.component.scss']
})
export class CreateUserProfileComponent implements OnInit {
  roles: Array<string>;
  role: Array<string> = ['AddToRole'];
  userProfile: UserProfile = new UserProfile();

  constructor(
    private router: Router, 
    private authService: AuthService, 
    private userService: UsersService
    ) {
    this.roles = this.authService.getRoles();
  }
  ngOnInit(): void {
    for (let i in this.role) {
      if (this.roles.indexOf(this.role[i]) === -1) {
        this.router.navigate(['manager/403'])
      }
    }
  }

  onSubmit(){
    this.userService.createUserProfile(this.userProfile).subscribe(
      (value) =>
        {
          console.log('Observable emitted the next value: ');
          console.log(value);
        },
      (err) => 
        {
          console.log('Observable emitted the next value: ');
          console.log(err);
        },
      () =>  
        { 
          console.log('Observable emitted the complete notification');
        }
    )
  }

}
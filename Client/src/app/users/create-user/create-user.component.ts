import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { User } from '../user';
import { UsersService } from 'src/app/users.service';
import Swal from 'sweetalert2'
import { UsersProfilesDbFilter } from '../usersProfilesDbFilter';
import { UserProfile } from '../userProfile';
import { UsersProfiles } from '../usersProfiles';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})

export class CreateUserComponent implements OnInit {
  roles: Array<string>;
  role: Array<string> = ['AddUser', 'AddToRole'];
  user: User = new User();
  usersProfiles: UserProfile[] = [];
  usersProfilesDbFilter: UsersProfilesDbFilter = new UsersProfilesDbFilter();

  constructor(private router: Router,  private authService: AuthService, private userService: UsersService) {
    this.roles = this.authService.getRoles();
    this.usersProfilesDbFilter.pageSize = 1000
    this.userService.getUsersProfiles(this.usersProfilesDbFilter).subscribe(
      (value) => {
        console.log(value);
        this.usersProfiles = value.data.data;
      },
    );
  }

  ngOnInit(): void {
    for (let i in this.role) {
      if (this.roles.indexOf(this.role[i]) === -1) {
        this.router.navigate(['manager/403'])
      }
    }
  }
  onSubmit() {
    this.userService.createUser(this.user).subscribe(
      (value) =>
       {
        console.log('Observable emitted the next value: ' + value);
      },
      (err) => {
        console.error('Observable emitted an error: ' + err);
        if (err.status === 400) {
          const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
              toast.onmouseenter = Swal.stopTimer;
              toast.onmouseleave = Swal.resumeTimer;
            }
          });
          Toast.fire({
            icon: "error",
            title: err.error.error
          });
        } else {
          const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
              toast.onmouseenter = Swal.stopTimer;
              toast.onmouseleave = Swal.resumeTimer;
            }
          });
          Toast.fire({
            icon: "success",
            title: "User created successfully!"
          });
          this.router.navigate(['manager/users/list'])
        }
      },
      () =>  { 
        console.log('Observable emitted the complete notification');
      }
      
    );

  }

}

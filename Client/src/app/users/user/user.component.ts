import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UsersService } from 'src/app/users.service';
import { ActivatedRoute, Router } from '@angular/router';
import { __values } from 'tslib';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  user?: User = new User();
  roles: Array<string>;
  userRoles: Array<string> | undefined;
  role: string = 'GetUsers';
  id: string = "";

  constructor(private service: UsersService,
              private route: ActivatedRoute,
              private router: Router,
              private authService: AuthService){
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.roles = authService.getRoles();
  }

 async ngOnInit(): Promise<void>  {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }
    if (this.id !== "") {
      this.user = await (await this.service.getUsersById(this.id)).toPromise();
      if (this.user){
        this.userRoles = await this.service.getRolesByUserName(this.user.userName).toPromise();

      }
    }
  }

}


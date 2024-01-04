import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersService } from 'src/app/users.service';
import { User } from '../user';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';
  users: User[] = [];

  constructor(private router: Router, private service: UsersService, private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }

    this.service.getUsers()
      .subscribe(resposta => this.users = resposta)
  }

}

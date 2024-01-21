import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersProfilesDbFilter } from '../usersProfilesDbFilter';
import { User } from '../user';
import { UsersService } from 'src/app/users.service';
import { UserProfile } from '../userProfile';
import { UsersProfilesData } from '../usersProfileData';
import { UsersProfiles } from '../usersProfiles';

@Component({
  selector: 'app-users-profiles-list',
  templateUrl: './users-profiles-list.component.html',
  styleUrls: ['./users-profiles-list.component.scss']
})
export class UsersProfilesListComponent implements OnInit {
  roles: Array<string>;
  role: Array<string> = ['AddToRole', 'GetUsers'];
  usersProfilesDbFilter: UsersProfilesDbFilter = new UsersProfilesDbFilter();
  users: User[] = [];
  usersProfilesResponse: UsersProfiles = new UsersProfiles();
  usersProfiles: UserProfile[] = [];
  totalPages: number = 1;
  pagesArray: number[] = [];

  constructor(
    private router: Router, 
    private authService: AuthService, 
    private usersService: UsersService,
    private activatedRoute: ActivatedRoute
  ) {
    this.roles = this.authService.getRoles();
    this.usersService.getUsers()
      .subscribe(resposta => this.users = resposta);
  }

  ngOnInit(): void {
    for (let i in this.role) {
      if (this.roles.indexOf(this.role[i]) === -1) {
        this.router.navigate(['manager/403']);
      }
    }
    this.activatedRoute.queryParams.subscribe(params => {
      this.usersProfilesDbFilter = { ...this.usersProfilesDbFilter, ...params };
      this.onChange();
    });
  }

  getPagesArray(): number[] {
    return Array.from({ length: Math.max(this.totalPages, 0) }, (_, i) => i + 1);
  }

  updateTotalPages(): void {
    this.totalPages = Math.ceil(this.usersProfilesResponse.data.totalRegister / this.usersProfilesDbFilter.pageSize);
  }

  changePage(newPage: number): void {
    if (newPage >= 1 && newPage <= this.totalPages) {
      this.usersProfilesDbFilter.page = newPage;
      this.onChange();
    }
  }

  onChange(): void {
    this.router.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: { ...this.usersProfilesDbFilter },
      queryParamsHandling: 'merge'
    });
    this.usersService.getUsersProfiles(this.usersProfilesDbFilter).subscribe(
      (value) => {
        this.usersProfilesResponse = value;
        this.usersProfiles = this.usersProfilesResponse.data.data;
        this.updateTotalPages();
        this.pagesArray = this.getPagesArray();
      },
    );
  }
}

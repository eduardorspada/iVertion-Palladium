import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersProfilesDbFilter } from '../usersProfilesDbFilter';
import { User } from '../user';
import { UsersService } from 'src/app/users.service';
import { UserProfile } from '../userProfile';
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
  orderByPropertySort: string = '';
  sort: string[] = [];

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
      this.reLoadQuery();
    });
  }

  getPagesArray(): number[] {
    return Array.from({ length: Math.max(this.totalPages, 0) }, (_, i) => i + 1);
  }

  updateTotalPages(): void {
    this.totalPages = Math.ceil(this.usersProfilesResponse.data.totalRegisters / this.usersProfilesDbFilter.pageSize);
  }

  reLoadQuery(): void {
    if (this.orderByPropertySort !== "") {
      this.sort = this.orderByPropertySort.split(" ");
      this.usersProfilesDbFilter.orderByProperty = this.sort[0];
      this.usersProfilesDbFilter.sort = this.sort[1];
    } else {
      this.usersProfilesDbFilter.orderByProperty = "";
      this.usersProfilesDbFilter.sort = "";
    }
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

  changePage(direction: string): void {
    if (direction === '+' && this.usersProfilesDbFilter.page < this.totalPages) {
      this.usersProfilesDbFilter.page++;
    } else if (direction === '-' && this.usersProfilesDbFilter.page >= 1){
      this.usersProfilesDbFilter.page--
    }

    if (this.usersProfilesDbFilter.page >= 1 && this.usersProfilesDbFilter.page <= this.totalPages) {
      this.reLoadQuery();
    }
  }

  changeToPage(page: number): void {
    page++;
    if (page >= 1 && page <= this.totalPages) {
      this.usersProfilesDbFilter.page = page;
      this.reLoadQuery();
    }
  }

  onChange(): void {
    this.usersProfilesDbFilter.page = 1;
    this.reLoadQuery();
  }
}

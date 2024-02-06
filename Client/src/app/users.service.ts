import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';
import { UsersProfiles } from './users/usersProfiles';
import { UsersProfilesDbFilter } from './users/usersProfilesDbFilter';
import { UserProfile } from './users/userProfile';
import { UserProfileResponse } from './users/userProfileResponse';
import { Role } from './users/role';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/User`,
      {
        headers: {
        'Content-Type': 'application/json'
      },
    })
  }
  async getUsersById(id: string): Promise<Observable<User>>{
    return this.http.get<User>(`${this.apiUrl}/User/${id}`,
      {
        headers: {
        'Content-Type': 'application/json'
      },
    })
  }
  getRolesByUserName(userName: string): Observable<Array<string>>{

    return this.http.get<Array<string>>(`${this.apiUrl}/User/GetUserRoles/${userName}`,
    {
      headers: {
      'Content-Type': 'application/json'
    },
  })
  }

  createUser(user: User): Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/User/CreateUser`, user,
      {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  }

  createUserProfile(userProfile: UserProfile): Observable<UserProfile>{
    return this.http.post<UserProfile>(`${this.apiUrl}/User/AddUserRoleProfile`, userProfile,
    {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }

  getUsersProfiles(usersProfilesDbFilter: UsersProfilesDbFilter): Observable<UsersProfiles> {
    let url: string = `${this.apiUrl}/User/UsersProfile?`;
    if (usersProfilesDbFilter.name !== "") {
      url += `&name=${usersProfilesDbFilter.name}`;
    }
    url += `&active=${usersProfilesDbFilter.active}`;
    if (usersProfilesDbFilter.userId !== "") {
      url += `&userId=${usersProfilesDbFilter.userId}`;
    }
    if (usersProfilesDbFilter.page > 0){
      url += `&page=${usersProfilesDbFilter.page}`;
    }
    if (usersProfilesDbFilter.pageSize > 0){
      url += `&pageSize=${usersProfilesDbFilter.pageSize}`;
    }
    if (usersProfilesDbFilter.orderByProperty !== "") {
      url += `&orderByProperty=${usersProfilesDbFilter.orderByProperty}`;
    }
    if (usersProfilesDbFilter.sort!== "") {
      url += `&sort=${usersProfilesDbFilter.sort}`;
    }

    return this.http.get<UsersProfiles>(url,
      {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  }
  getUserProfileByIdAsync(id: string): Observable<UserProfileResponse> {
    let url: string = `${this.apiUrl}/User/UsersProfile/${id}`;
    return this.http.get<UserProfileResponse>(url,
      {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  }
  getRolesUserProfileById(id: string): Observable<Array<string>> {
    let url: string = `${this.apiUrl}/User/RolesUsersProfile/${id}`;

    return this.http.get<Array<string>>(url,
      {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  }
  getAllUsersRoles(): Observable<Array<Role>> {
    let url: string = `${this.apiUrl}/User/GetRoles`;

    return this.http.get<Array<Role>>(url,
      {
        headers: {
          'Content-Type': 'application/json'
        }
      });

  }
}

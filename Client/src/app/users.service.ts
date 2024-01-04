import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';

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
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, catchError, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isTokenValid: boolean = false;
  jwtHelper: JwtHelperService = new JwtHelperService();
  static isValidToken() {
    throw new Error('Method not implemented.');
  }
  apiUrl: string = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }
  getToken(){
    const tokenString = localStorage.getItem('access_token');
    if (tokenString){
      const token = JSON.parse(tokenString).token;
      return token;
    }
    return null;
  }
  tryLogin(email: string, password: string) : Observable<any> {
    const params = {
      email,
      password,
    }
    return this.http.post(`${this.apiUrl}/Token/LoginUser`, params, {
      headers: {
        'Content-Type': 'application/json',
      },
    });

  }

  signOut(){
    localStorage.removeItem('access_token');
  }
  getUserName(){
    const token = this.getToken();
    if (token){
      const userName = this.jwtHelper.decodeToken(token).Name;
      return userName;
    }
    return null;
  }

  isValidToken(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Token/ValidateTokenAsync` , {observe: 'response'})
  }

  getRoles() {
    const token = this.getToken();
    if (token){
      const roles = this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      if (roles){
        return roles;
      }
      return [];
    }
    return [];
  }
}

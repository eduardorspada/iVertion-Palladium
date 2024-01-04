import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

export const authGuard: CanActivateFn = (route, state) => {
  const access_token = localStorage.getItem('access_token');
  const router = inject(Router);
  const jwtHelper: JwtHelperService = new JwtHelperService();
  if (access_token) {
    const token: string = JSON.parse(access_token).token;
    const expirated = jwtHelper.isTokenExpired(token);
    if (!expirated){
      return true;
    } else {
      router.navigate(['/login']);
      return false;
    }
  } else {
    router.navigate(['/login']);
    return false;
  }
};

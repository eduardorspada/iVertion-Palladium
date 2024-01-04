import { Component, Inject, OnInit } from '@angular/core';
import { Login } from '../login';
import { DOCUMENT } from '@angular/common';
import { AuthService } from 'src/app/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  login: Login
  

  constructor(@Inject(DOCUMENT) 
              private document: Document, 
              private authService: AuthService, 
              private router: Router) 
  {
    this.login = new Login();
  }

  ngOnInit(){
    this.document.body.classList.add('hold-transition', 'login-page');
  }

  onSubmit() {
    this.authService.tryLogin(this.login.username, this.login.password)
                    .subscribe(response => {
                      const access_token = JSON.stringify(response);
                      localStorage.setItem('access_token', access_token)
                      this.router.navigate(['/manager'])
                    }, errorResponse => {
                      console.log(errorResponse)
                    })
    
  }
}

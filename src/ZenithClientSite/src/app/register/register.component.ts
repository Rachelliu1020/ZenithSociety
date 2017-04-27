import { Component, OnInit } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import {AuthService} from '../auth.service';
import {AuthInfo} from '../auth-info';
import {RegisterModel} from './register-model';
import { Router } from '@angular/router';
import {Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  newUser: RegisterModel = new RegisterModel();

  authFail: boolean = false;

  validFail: boolean = false;

  emptyField: boolean = false;

  emailFail: boolean = false;

  errorMsg: string = "";

  validationErr: any = [];

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register(model: RegisterModel) {
        this.authFail = false;
        this.validFail = false;
        this.emptyField = false;
        this.emailFail = false;

      // check empty fields
      if(model.UserName==null || model.FirstName == null || model.LastName == null || model.Email == null || model.Password == null || model.ConfirmPassword == null) {
        this.emptyField = true;
        return;
      } else if(model.UserName=='' || model.FirstName == '' || model.LastName == '' || model.Email == '' || model.Password == '' || model.ConfirmPassword == '') {
        this.emptyField = true;
        return;
      }
    
      // check the password
      if(model.Password != model.ConfirmPassword) {
        this.authFail = true;
        this.errorMsg = "password does not match!";
        return;
      }

      // check email 
      var EMAIL_REGEXP = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;
      
      if(!EMAIL_REGEXP.test(model.Email)) {
        this.emailFail = true;
        return;
      }

      this.authService.Regiser(model).subscribe(
        (data: any) => {
          AuthInfo.username = model.UserName;
          AuthInfo.isAuth = true;
          //AuthInfo.isMemberOrAdmin = true;

          localStorage.setItem("username", model.UserName);
          localStorage.setItem("isAuth", "true");

          this.authFail = false;
          this.validFail = false;
          this.emptyField = false;

          // login this user to get the token
          this.authService.Login(model.UserName, model.Password).subscribe(
            (data: any) => {
                localStorage.setItem("access_token", data.access_token);
                this.authService.getUserRoleInfo().then((data : any) => {
                    localStorage.setItem("isMA", `${data.isMemberOrAdmin}`);
                    this.router.navigate(['./home']);
              });
          });
        },

        (error: any) => {
          this.validFail = true;
          this.validationErr = JSON.parse(error._body);
        }
      );
    }
}

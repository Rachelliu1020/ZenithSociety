import { Component, OnInit } from '@angular/core';
import {Response} from "@angular/http";
import {AuthService} from '../auth.service';
import {AuthModel} from "./auth-model";
import {AuthInfo} from "../auth-info";
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  newUser: AuthModel = new AuthModel();

  authFail: boolean = false;

  errorMsg: string = "";

  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  login(model: AuthModel) {
      this.authService.Login(model.userName, model.passWord).subscribe(
        (data: any) => {
          localStorage.setItem("access_token", data.access_token);
          localStorage.setItem("isAuth", "true");
          localStorage.setItem("username", model.userName);
          AuthInfo.username = model.userName;
          AuthInfo.isAuth = true;
          this.authFail = false;

          this.authService.getUserRoleInfo().then((data : any) => {
            localStorage.setItem("isMA", `${data.isMemberOrAdmin}`);
            this.router.navigate(['./home']);
          });
          
        },
        (error: any) => {
            this.authFail = true;
            this.errorMsg = JSON.parse(error._body).error_description;
        }
      );
   }
}

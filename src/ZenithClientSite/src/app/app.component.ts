import { Component,OnInit } from '@angular/core';
import {Response} from "@angular/http";
import {AuthInfo} from './auth-info';
import {AuthService} from './auth.service';
import {ZenithService} from './zenith.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [AuthService, ZenithService]
})
export class AppComponent implements OnInit{
   title = 'Zenith Society';
   authInfo = AuthInfo;

   constructor(private auth: AuthService, private zenithService: ZenithService) {
  }
  
  ngOnInit() {
    if (localStorage.getItem("isAuth") && localStorage.getItem("username")) {
      this.authInfo.isAuth = true;
      this.authInfo.username = localStorage.getItem("username");
    } else {
      this.authInfo.isAuth = false;
      this.authInfo.username = "";
    }
  } 

  logoff() {
    localStorage.clear();
    this.authInfo.isAuth = false;
    this.authInfo.username = "";
  }
}

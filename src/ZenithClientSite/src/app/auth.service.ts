import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import {RegisterModel} from './register/register-model';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import {Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/catch';

@Injectable()
export class AuthService {

  private BASE_URL = "http://zenithwebsite20170401034739.azurewebsites.net"; 

  private headers = new Headers({'Content-Type': 'application/x-www-form-urlencoded'});

  constructor(private http: Http) { }

  Login(username: string, password: string) {
    const url = `${this.BASE_URL}/connect/token`;
    const type = "password";
    var body =  `username=${username}&password=${password}&grant_type=${type}`;
    // this.http.post(url, body, {headers: this.headers}).toPromise().then(res => console.log(res.json().data));
    return this.http.post(url, body, {headers: this.headers}).map((response: Response) => response.json()).catch(this.handleError);
  }

   Regiser(model: RegisterModel) {
    const url = `${this.BASE_URL}/api/AccountAPI/Register`;
    var body =  `username=${model.UserName}&password=${model.Password}&firstName=${model.FirstName}&lastName=${model.LastName}&email=${model.Email}`;
    return this.http.post(url, body, {headers: this.headers}).map((response: Response) => response.json()).catch(this.handleError);
  }

  getUserRoleInfo() {
    const url = `${this.BASE_URL}/api/AccountAPI/UserRoleInfo`;
    let headers = new Headers({'Content-Type': 'application/json'});
    let token = localStorage.getItem("access_token");
    headers.append('Authorization', `Bearer ${token}`);
    let options = new RequestOptions({ headers: headers });

    return this.http.get(url, options)
                      .toPromise()
                      .then(response => response.json())
                      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
     console.error('An error occurred', error);
     return Promise.reject(error.message || error);
  }
}

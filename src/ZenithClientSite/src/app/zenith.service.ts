import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import {EventsItem} from './home/events-item';
import { MyEvent } from './my-event';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class ZenithService {
  private BASE_URL = "http://zenithwebsite20170401034739.azurewebsites.net"; 

  constructor(private http: Http) { }

  getCurrentEvents(): Promise<EventsItem[]> {
    const url = `${this.BASE_URL}/api/MyEventsAPI`;

    if (localStorage.getItem("isAuth") && localStorage.getItem("isAuth") == "true") {
      let headers = new Headers({'Content-Type': 'application/json'});
      let token = localStorage.getItem("access_token");
      headers.append('Authorization', `Bearer ${token}`);
      let options = new RequestOptions({ headers: headers });

      return this.http.get(url, options)
                        .toPromise()
                        .then(response => response.json() as EventsItem[])
                        .catch(this.handleError);
    } else {
      return this.http.get(url)
                        .toPromise()
                        .then(response => response.json() as EventsItem[])
                        .catch(this.handleError);
    }
  }

getPreviousEvents(): Promise<EventsItem[]> {
    let headers = new Headers({'Content-Type': 'application/json'});
    let token = localStorage.getItem("access_token");
    headers.append('Authorization', `Bearer ${token}`);

    let options = new RequestOptions({ headers: headers });
    const url = `${this.BASE_URL}/api/MyEventsAPI/Previous`;
    return this.http.get(url, options)
   .toPromise()
   .then(response => response.json() as EventsItem[])
   .catch(this.handleError);
  }

  getNextEvents(): Promise<EventsItem[]> {
    let headers = new Headers({'Content-Type': 'application/json'});
    let token = localStorage.getItem("access_token");
    headers.append('Authorization', `Bearer ${token}`);

    let options = new RequestOptions({ headers: headers });
    const url = `${this.BASE_URL}/api/MyEventsAPI/Next`;
    return this.http.get(url, options)
   .toPromise()
   .then(response => response.json() as EventsItem[])
   .catch(this.handleError);
  }


  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

}

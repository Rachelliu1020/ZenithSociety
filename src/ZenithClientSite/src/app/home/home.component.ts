import { Component, OnInit } from '@angular/core';
import {ZenithService} from '../zenith.service';
import {EventsItem} from './events-item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  eventsItemList: EventsItem[];
  isMemberOrAdmin: boolean;

  constructor(private zenithService: ZenithService) { }

  ngOnInit() {
     this.getCurrentEvents();
     if (localStorage.getItem("isAuth")
          && localStorage.getItem("isAuth") == "true" 
          && localStorage.getItem("isMA") 
          && localStorage.getItem("isMA") == "true") {

        this.isMemberOrAdmin = true;
     } else {
       
       this.isMemberOrAdmin = false;
     }
  }


  getCurrentEvents() {
      this.zenithService.getCurrentEvents().then(
        (models: EventsItem[]) => {
          this.eventsItemList = models;
        });
  }

  getPreviousEvents() {
    this.zenithService.getPreviousEvents().then(
      (models: EventsItem[]) => {
        this.eventsItemList = models;
      });
  }

  getNextEvents() {
    this.zenithService.getNextEvents().then(
      (models: EventsItem[]) => {
        this.eventsItemList = models;
      });
  }
}

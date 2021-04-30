import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggedInUser: string;
  constructor(private alertiyService: AlertifyService) { }

  ngOnInit(): void {
  }

  loggedIn() {
    this.loggedInUser = localStorage.getItem('token');
    return this.loggedInUser;
  }

  onLogout() {
    localStorage.removeItem('token');
    this.alertiyService.success("You are logged out");
  }

}

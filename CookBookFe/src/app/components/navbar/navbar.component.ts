import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedInAsUser: boolean = false;
  isLoggedInAsAdmin: boolean = false;
  isNotLoggedIn: boolean = false;

  constructor(private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    const token = localStorage.getItem("jwt");
    const userId = localStorage.getItem("userId");
    const adminId = localStorage.getItem("adminId");

    if(userId && !this.jwtHelper.isTokenExpired(token!)){
      this.isLoggedInAsUser = true;
    } else if(adminId && !this.jwtHelper.isTokenExpired(token!)){
      this.isLoggedInAsAdmin = true;
    }else{
      this.isNotLoggedIn = true;
    }

    //this.isLoggedIn = !!(token && !this.jwtHelper.isTokenExpired(token));
  }

  logOut() {
    /*localStorage.removeItem("jwt");

    if(localStorage.getItem("userId"))
      localStorage.removeItem("userId");
    if(localStorage.getItem("adminId"))
      localStorage.removeItem("adminId");

    this.router.navigate(["/home"]);*/

    localStorage.removeItem("jwt");

    if(localStorage.getItem("userId"))
      localStorage.removeItem("userId");
    if(localStorage.getItem("adminId"))
      localStorage.removeItem("adminId");

    this.router.navigate(["/home"]);
  }

  isLoggedInAsUserChecker() : boolean {
    return this.isLoggedInAsUser;

  }
  isLoggedInAsAdminChecker(): boolean {
    return this.isLoggedInAsAdmin;

  }

  isLoggedOutChecker(): boolean{
    return this.isNotLoggedIn;
  }

}

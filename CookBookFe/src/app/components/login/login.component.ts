import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UserInterface} from "../../models/user-interface";
import {Router} from "@angular/router";
import {UsersService} from "../../services/users.service";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  users: UserInterface[] = [];

  constructor(private router: Router, private usersService: UsersService, private httpClient: HttpClient, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.usersService.getUsers().subscribe(res => {
      this.users = res;
      console.log(res);
    })

    this.loginForm = this.formBuilder.group({
      username: [''],
      password: ['']
    })
  }

  login() {

    this.usersService.getUsers().subscribe(res => {
      //console.log("triggered");

      const user = res.find((a: UserInterface) => {
        return a.userName === this.loginForm.value.username && a.password === this.loginForm.value.password;
      });

      if(user){
        alert("Login successful!");
        console.log(user);
        this.loginForm.reset();
        this.router.navigate(['/home']);
      }else {
        alert("User not found!");
      }
    }, err => {
      alert("Something went wrong!");
    })

  }
}

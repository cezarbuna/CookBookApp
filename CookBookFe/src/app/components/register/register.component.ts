import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {UserInterface} from "../../models/user-interface";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {UsersService} from "../../services/users.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;

  users: UserInterface[] = [];

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router, private userService: UsersService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(res => {
      this.users = res;
      console.log(res);
    })

    this.registerForm = this.formBuilder.group({
      username: [''],
      password: [''],
      email: [''],
      phoneNumber: [''],
      currentOccupation: [''],
      description: ['']
    })

  }

  register() {
    this.userService.postUser(this.registerForm.value)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/home']);
      })


  }

}

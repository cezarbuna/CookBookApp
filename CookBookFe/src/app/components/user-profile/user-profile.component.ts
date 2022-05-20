import { Component, OnInit } from '@angular/core';
import {UsersService} from "../../services/users.service";
import {Router} from "@angular/router";
import {FormBuilder, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {UserInterface} from "../../models/user-interface";

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user!: UserInterface;

  editProfileForm!: FormGroup;

  constructor(private userService: UsersService, private router: Router, private formBuilder: FormBuilder, private httpClient: HttpClient) { }

  ngOnInit(): void {

    this.userService.getUserById(localStorage.getItem("userId")!).subscribe(res => {
      this.user = res;
      console.log("Logged from user profile component:");
      console.log(res);
    })

    this.editProfileForm = this.formBuilder.group({
      userName: this.user.userName,
      password: this.user.password,
      email: this.user.email,
      phoneNumber: this.user.phoneNumber,
      currentOccupation: this.user.currentOccupation,
      description: this.user.description
    })
  }

  updateUser() {
    this.userService.updateUser(this.editProfileForm.value, this.user.id)
      .subscribe(res => {
        console.log(res);
        this.editProfileForm.reset();
        this.router.navigate(['/home']);
      })
    this.editProfileForm.reset();
  }

  getCurrentUserUsername(): string {
    return this.user.userName;
  }

}

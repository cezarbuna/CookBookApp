import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  register = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    email: new FormControl(''),
    phoneNumber : new FormControl(''),
    currentOccupation: new FormControl(''),
    description: new FormControl('')
  })

  constructor() { }

  ngOnInit(): void {
  }

  collection() {
    console.warn(this.register.value);
  }

}

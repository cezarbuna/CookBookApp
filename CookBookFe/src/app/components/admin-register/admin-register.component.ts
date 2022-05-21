import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {UserInterface} from "../../models/user-interface";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {UsersService} from "../../services/users.service";
import {AdminInterface} from "../../models/admin-interface";
import {AdminService} from "../../services/admin.service";

@Component({
  selector: 'app-admin-register',
  templateUrl: './admin-register.component.html',
  styleUrls: ['./admin-register.component.css']
})
export class AdminRegisterComponent implements OnInit {

  registerForm!: FormGroup;

  admins: AdminInterface[] = [];

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router, private adminService: AdminService) { }

  ngOnInit(): void {
    this.adminService.getAdmins().subscribe(res => {
      this.admins = res;
      console.log(res);
    })

    this.registerForm = this.formBuilder.group({
      adminId: [''],
      userName: [''],
      password: ['']
    })

  }

  register() {
    this.adminService.postAdmin(this.registerForm.value)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/admin-login']);
      })


  }

}

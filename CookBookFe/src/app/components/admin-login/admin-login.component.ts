import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {AdminInterface} from "../../models/admin-interface";
import {AdminService} from "../../services/admin.service";

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {

  loginForm!: FormGroup;

  admins: AdminInterface[] = [];

  invalidLogin!: boolean;

  constructor(private router: Router, private adminService: AdminService, private httpClient: HttpClient, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.adminService.getAdmins().subscribe(res => {
      this.admins = res;
      console.log(res);
    })

    this.loginForm = this.formBuilder.group({
      adminId: [''],
      username: [''],
      password: ['']
    })
  }

  login() {

    this.adminService.getAdmins().subscribe(res => {
      //console.log("triggered");

      const admin = res.find((a: AdminInterface) => {
        return a.userName === this.loginForm.value.username && a.password === this.loginForm.value.password && a.adminId === this.loginForm.value.adminId;
      });

      if(admin){
        alert("Login successful!");
        console.log(admin);
        this.loginForm.reset();
        this.router.navigate(['/home']);
      }else {
        alert("Admin not found!");
      }
    }, err => {
      alert("Something went wrong!");
    })

  }

  login2(form: FormGroup) {
    const credentials = {
      'adminId': form.value.adminId,

      'username': form.value.username,

      'password': form.value.password
    }

    this.httpClient.post("https://localhost:7025/api/auth/login-admin/", credentials)
      .subscribe( res => {
        const token = (<any>res).token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/home"]);
      }, err => {
        console.log("Invalid credentials!");
        this.invalidLogin = true;
      })
  }

}

import { Component, OnInit } from '@angular/core';
import {UsersService} from "../../services/users.service";
import {Router} from "@angular/router";
import {FormBuilder, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {AdminService} from "../../services/admin.service";
import {AdminInterface} from "../../models/admin-interface";

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.css']
})
export class AdminProfileComponent implements OnInit {

  editProfileForm!: FormGroup;

  admin!: AdminInterface;

  constructor(private adminService: AdminService, private router: Router, private formBuilder: FormBuilder, private httpClient: HttpClient) { }

  ngOnInit(): void {

    this.adminService.getAdminById(localStorage.getItem("adminId")!).subscribe(res => {
      this.admin = res;
      console.log("Logged from admin profile component:");
      console.log(res);
    })

    this.editProfileForm = this.formBuilder.group({
      userName: [''],
      password: ['']
    })
  }

  updateAdmin() {
    this.adminService.updateAdmin(this.editProfileForm.value, this.admin.id)
      .subscribe(res => {
        console.log(res);
        this.editProfileForm.reset();
        this.router.navigate(['/home']);
      })
    this.editProfileForm.reset();
  }


}

import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {UsersService} from "../../services/users.service";
import {PostsService} from "../../services/posts.service";

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  createForm!: FormGroup;

  userId!: string;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router, private postService: PostsService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId")!;
    console.log("Logged userId from create-post component:");
    console.log(this.userId);

    this.createForm = this.formBuilder.group({
      userId: [this.userId],
      title: [''],
      content: ['']
    })
  }

  createPost() {
    this.postService.createPost(this.createForm.value)
      .subscribe(res => {
        console.log(res);
        this.router.navigate(['/home']);
      })
  }

}



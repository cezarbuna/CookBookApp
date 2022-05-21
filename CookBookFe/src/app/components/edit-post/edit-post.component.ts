import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {PostsService} from "../../services/posts.service";

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {

  constructor(private postService: PostsService, private router: Router, private httpClient: HttpClient) { }

  ngOnInit(): void {
    
  }

}

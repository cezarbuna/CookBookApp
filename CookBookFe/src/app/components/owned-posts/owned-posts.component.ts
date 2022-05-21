import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {PostInterface} from "../../models/post-interface";
import {PostsService} from "../../services/posts.service";

@Component({
  selector: 'app-owned-posts',
  templateUrl: './owned-posts.component.html',
  styleUrls: ['./owned-posts.component.css']
})
export class OwnedPostsComponent implements OnInit {

  userId!: string;
  ownedPosts: PostInterface[] = [];

  constructor(private router: Router, private postService: PostsService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("userId")!;
    if(!this.userId) {
      alert("Error getting the posts related to the user! Please go back and retry!");
      this.router.navigate(['/home']);
    }else{
      this.postService.getPostsByUserId(this.userId).subscribe(res => {
        this.ownedPosts = res;
        console.log("Logged posts from owned-posts component:");
        console.log(res);
      })
    }

  }

  goToEdit(postId: string) {
    this.router.navigate(['/edit-post', postId]);
  }

}

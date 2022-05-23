import { Component, OnInit } from '@angular/core';
import {PostInterface} from "../../models/post-interface";
import {PostsService} from "../../services/posts.service";

@Component({
  selector: 'app-badly-rated-posts',
  templateUrl: './badly-rated-posts.component.html',
  styleUrls: ['./badly-rated-posts.component.css']
})
export class BadlyRatedPostsComponent implements OnInit {

  badlyRatedPosts: PostInterface[] = [];


  constructor(private postService: PostsService) { }

  ngOnInit(): void {
    this.postService.getBadlyRatedPosts().subscribe(res => {
      console.log("Logged bad posts from badly-rated-posts component:");
      console.log(res);
      this.badlyRatedPosts = res;
    })
  }

  deletePost(postId: string){
    return this.postService.deletePost(postId).subscribe(res => {
      console.log("Deleted post from badly-rated-posts component.");
      console.log(res);
    })
  }

}

import { Component, OnInit } from '@angular/core';
import {PostsService} from "../../services/posts.service";
import {PostInterface} from "../../models/post-interface";
import {CommentInterface} from "../../models/comment-interface";
import {CommentsService} from "../../services/comments.service";
import {Observable} from "rxjs";
import {C} from "@angular/cdk/keycodes";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  posts: PostInterface[] = [];
  comments: CommentInterface[] = [];
  commentsByPostId: CommentInterface[] = [];

  tempPostId: string = "1adc9ff2-6a17-43cd-3398-08da372aed54";

  id: string = "";


  constructor(private postsService: PostsService, private commentsService: CommentsService) { }

  ngOnInit(): void {

    this.postsService.getAllPosts().subscribe(data => {
      this.posts = data;
      console.log(data);
    })

    this.commentsService.getAllComments().subscribe(data => {
      this.comments = data;
      console.log(data);
    })

  }

  getCommentsByPostId(id: string): CommentInterface[] {
    this.commentsService.getCommentsByPostId(id).subscribe(res => {
      this.commentsByPostId = res;
    })
    return this.commentsByPostId;
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    return !!token;
  }

  logout() {
    localStorage.removeItem("jwt");
  }

  /*
  getCommentsByIdPost(postId: string): Observable<CommentInterface[]>{
    return this.commentsService.getCommentsByPostId(postId);
  }*/


}

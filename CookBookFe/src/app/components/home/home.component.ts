import { Component, OnInit } from '@angular/core';
import {PostsService} from "../../services/posts.service";
import {PostInterface} from "../../models/post-interface";
import {CommentInterface} from "../../models/comment-interface";
import {CommentsService} from "../../services/comments.service";
import {Observable} from "rxjs";
import {C} from "@angular/cdk/keycodes";
import {UserInterface} from "../../models/user-interface";
import {UsersService} from "../../services/users.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  posts: PostInterface[] = [];
  comments: CommentInterface[] = [];
  //commentsByPostId: CommentInterface[] = [];

  //tempPostId: string = "1adc9ff2-6a17-43cd-3398-08da372aed54";

  currentUser!: UserInterface;

  id: string = "";


  constructor(private postsService: PostsService, private commentsService: CommentsService, private userService: UsersService) { }

  ngOnInit(): void {

    this.postsService.getAllPosts().subscribe(data => {
      this.posts = data;
      console.log(data);
    })

    this.commentsService.getAllComments().subscribe(data => {
      this.comments = data;
      console.log(data);
    })

    this.userService.getUserById(localStorage.getItem("userId")!).subscribe(res => {
      console.log(res);
    })

  }

  likePost(postId: string) {
    this.postsService.likePost(1,postId ).subscribe(res => {
      console.log("Like post method triggered!");
      console.log(res);
    })
  }

  dislikePost(postId: string, dislikeCounter: number) {
    this.postsService.getPostById(postId).subscribe(res => {
      console.log(res);
      console.log(res.likeCounter);
    })
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

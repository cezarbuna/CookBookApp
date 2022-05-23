import { Component, OnInit } from '@angular/core';
import {PostsService} from "../../services/posts.service";
import {PostInterface} from "../../models/post-interface";
import {CommentInterface} from "../../models/comment-interface";
import {CommentsService} from "../../services/comments.service";
import {Observable} from "rxjs";
import {C} from "@angular/cdk/keycodes";
import {UserInterface} from "../../models/user-interface";
import {UsersService} from "../../services/users.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  posts: PostInterface[] = [];
  comments: CommentInterface[] = [];

  breakfastPosts: PostInterface[] = [];
  lunchPosts: PostInterface[] = [];
  dinnerPosts: PostInterface[] = [];

  selectedCategory: number = 3; //default is 3 which means no category has been selected

  currentUserId!: string;


  constructor(private postsService: PostsService, private commentsService: CommentsService, private userService: UsersService, private  router: Router) {
  }

  ngOnInit(): void {

    this.currentUserId = localStorage.getItem("userId")!;
    console.log("Current logged user is:");
    console.log(this.currentUserId);

    this.postsService.getAllPosts().subscribe(data => {
      this.posts = data;
      console.log(data);
    })

    this.postsService.getAllPostsByCategory(0).subscribe(res => {
      console.log("Breakfast posts logged from home component:");
      console.log(res);
      this.breakfastPosts = res;
    })

    this.postsService.getAllPostsByCategory(1).subscribe(res => {
      console.log("Lunch posts logged from home component:");
      console.log(res);
      this.lunchPosts = res;
    })

    this.postsService.getAllPostsByCategory(2).subscribe(res => {
      console.log("Dinner posts logged from home component:");
      console.log(res);
      this.dinnerPosts = res;
    })

    this.commentsService.getAllComments().subscribe(data => {
      this.comments = data;
      console.log(data);
    })

    this.userService.getUserById(localStorage.getItem("userId")!).subscribe(res => {
      console.log(res);
    })

  }

  deleteComment(commentId: string, userId: string){
    if(localStorage.getItem("jwt")){
      if(userId === localStorage.getItem("userId")){
        this.commentsService.deleteComment(commentId, userId).subscribe(res => {
          console.log("Logged comment deletion from home component!");
          console.log(res);
          alert("Deletion successful!");
        })
      }else{
        alert("You cannot only delete your own comments!");
      }
    }else {
      alert("You cannot delete comments as a non logged user! Please log in!");
      this.router.navigate(['/login']);
    }
  }

  getAllCommentsByPostId(postId: string): CommentInterface[] {
    let comments: CommentInterface[] = [];
    this.commentsService.getCommentsByPostId(postId).subscribe(res => {
      console.log("Logged comments belonging to the post: " + postId);
      console.log(res);
      comments = res;
    })

    return comments;
  }

  likePost(postId: string) {
    if(localStorage.getItem("jwt")){
      this.postsService.likePost(1, postId).subscribe(res => {
        console.log("Like post method triggered!");
        console.log(res);
      })
    }else{
      alert("You cannot like/dislike posts if you are not logged in!");
    }

  }

  dislikePost(postId: string) {
    if(localStorage.getItem("jwt")){
      this.postsService.dislikePost(1, postId).subscribe(res => {
        console.log("Like post method triggered!");
        console.log(res);
      })
    } else{
      alert("You cannot like/dislike posts if you are not logged in!");
    }

  }

  goToCreateComment(postId: string){
    if(localStorage.getItem("jwt")){
      this.router.navigate(['/create-comment', postId]);
    } else{
      alert("You cannot comment on other posts if you are not logged in!");
    }

  }

  selectBreakfast() {
    this.posts = this.breakfastPosts;
  }

  selectLunch() {
    this.posts = this.lunchPosts;
  }

  selectDinner() {
    this.posts = this.dinnerPosts;
  }

  goToEditComment(commentId: string){
    this.router.navigate(['/edit-comment', commentId]);
  }

}




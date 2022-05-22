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
  //commentsByPostId: CommentInterface[] = [];

  //tempPostId: string = "1adc9ff2-6a17-43cd-3398-08da372aed54";

  currentUser!: UserInterface;

  id: string = "";


  constructor(private postsService: PostsService, private commentsService: CommentsService, private userService: UsersService, private  router: Router) {
  }

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
      alert("You cannot like/dislike posts if you are not logged in!");
    }

  }

}




import { Component, OnInit } from '@angular/core';
import {PostsService} from "../../services/posts.service";
import {PostInterface} from "../../models/post-interface";
import {CommentInterface} from "../../models/comment-interface";
import {CommentsService} from "../../services/comments.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  posts: PostInterface[] = [];
  comments: CommentInterface[] = [];
  commentsByPostId: CommentInterface[] = [];

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

    this.commentsService.getCommentsByPostId(this.id).subscribe(data => {
      this.commentsByPostId = data;
      console.log(data);
    })

  }

  /*
  getCommentsByIdPost(postId: string): Observable<CommentInterface[]>{
    return this.commentsService.getCommentsByPostId(postId);
  }*/


}

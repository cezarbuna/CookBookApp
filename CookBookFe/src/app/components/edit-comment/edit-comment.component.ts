import { Component, OnInit } from '@angular/core';
import {CommentsService} from "../../services/comments.service";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-edit-comment',
  templateUrl: './edit-comment.component.html',
  styleUrls: ['./edit-comment.component.css']
})
export class EditCommentComponent implements OnInit {

  commentId!: string;
  userId!: string;

  editCommentForm!: FormGroup;

  constructor(private commentService: CommentsService, private router: Router, private route: ActivatedRoute, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.commentId = params['id'];
      console.log("Logged from edit-comment component:");
      console.log(this.commentId);
    })

    this.userId = localStorage.getItem("userId")!;

    this.editCommentForm = this.formBuilder.group({
      id: [this.commentId],
      userId: [this.userId],
      newCommentContent: ['']
    })


  }

}

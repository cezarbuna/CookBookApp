import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {CommentsService} from "../../services/comments.service";

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css']
})
export class CreateCommentComponent implements OnInit {

  createForm!: FormGroup;
  postId!: string;

  constructor(private route: ActivatedRoute, private router: Router, private commentsService: CommentsService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.postId = params['id'];
      console.log("Logged from create-comment component:");
      console.log(this.postId);
    })

    this.createForm = this.formBuilder.group({
      postId: [this.postId],
      content: ['']
    })
  }

  createComment() {
    this.commentsService.createComment(this.createForm.value).subscribe(res => {
      console.log("Created comment response from create-comment component!");
      console.log(res);
      this.router.navigate(['/home']);
    })
  }

}

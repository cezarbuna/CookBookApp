import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {PostsService} from "../../services/posts.service";
import {PostInterface} from "../../models/post-interface";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {

  post!: PostInterface;
  postId!: string;

  editPostForm!: FormGroup;

  constructor(private postService: PostsService, private router: Router, private route: ActivatedRoute, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.postId = params['id'];
      console.log("Logged from edit-post component:");
      console.log(this.postId);
    })

    if(!this.postId){
      alert("Invalid post id! Please return to your posts page and try again!");
      this.router.navigate(['/owned-posts']);
    } else {
      this.postService.getPostById(this.postId).subscribe(res => {
        this.post = res;
        console.log("Logged from edit-post component:");
        console.log(this.post);
      })

    }

    this.editPostForm = this.formBuilder.group({
      title: [''],
      content: [''],
      category: [this.post.category]
    })

  }

  updatePost() {
    this.postService.updatePost(this.editPostForm.value, this.postId).subscribe(res => {
      console.log(res);
      this.editPostForm.reset();
      this.router.navigate(['/owned-posts']);
    })
  }

  setPostCategory(category: number) {
    console.log("setPostCategory method triggered from edit-post component");
    this.editPostForm.controls.category.setValue(category);
  }

}

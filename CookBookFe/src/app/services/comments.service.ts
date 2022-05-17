import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {PostInterface} from "../models/post-interface";
import {HttpClient} from "@angular/common/http";
import {CommentInterface} from "../models/comment-interface";

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  constructor(private httpClient: HttpClient) { }

  getCommentsByPostId(id: string): Observable<CommentInterface[]> {
    return this.httpClient.get<CommentInterface[]>(`https://localhost:7025/api/Comments/get-all-comments-by-post-id/${id}`);
  }

  getAllComments(): Observable<CommentInterface[]> {
    return this.httpClient.get<CommentInterface[]>("https://localhost:7025/api/Comments");
  }


  get(): any {
    return this.httpClient.get("");
  }
}

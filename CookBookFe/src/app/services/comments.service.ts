import { Injectable } from '@angular/core';
import {map, Observable} from "rxjs";
import {PostInterface} from "../models/post-interface";
import {HttpClient} from "@angular/common/http";
import {CommentInterface} from "../models/comment-interface";

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  constructor(private httpClient: HttpClient) { }

  createComment(data: CommentInterface): Observable<CommentInterface> {
    return this.httpClient.post<CommentInterface>("https://localhost:7025/api/Comments", data)
      .pipe(map((res: CommentInterface) => {
        return res;
      }))
  }

  getCommentsByPostId(id: string): Observable<CommentInterface[]> {
    return this.httpClient.get<CommentInterface[]>(`https://localhost:7025/api/Comments/get-all-comments-by-post-id/${id}`)
      .pipe(map((res: CommentInterface[]) => {
        return res;
      }))
  }

  getAllComments(): Observable<CommentInterface[]> {
    return this.httpClient.get<CommentInterface[]>("https://localhost:7025/api/Comments");
  }

  deleteComment(id: string, userId: string) {
    return this.httpClient.delete<CommentInterface>("https://localhost:7025/api/Comments/" + id + "/" + userId)
      .pipe(map((res: any) => {
        return res;
      }))
  }


  get(): any {
    return this.httpClient.get("");
  }
}

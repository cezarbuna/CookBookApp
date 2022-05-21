import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {PostInterface} from "../models/post-interface";
import {UserInterface} from "../models/user-interface";

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private httpClient: HttpClient) { }

  createPost(data: PostInterface): Observable<PostInterface> {
    return this.httpClient.post<PostInterface>("https://localhost:7025/api/Posts/", data)
      .pipe(map((res: PostInterface) => {
        return res;
      }))
  }

  getPostsByUserId(userId: string): Observable<PostInterface[]> {
    return this.httpClient.get<PostInterface[]>("https://localhost:7025/api/Posts/get-all-posts-by-user-id/" + userId)
      .pipe(map((res: PostInterface[]) => {
        return res;
      }))
  }

  getAllPosts(): Observable<PostInterface[]> {
    return this.httpClient.get<PostInterface[]>("https://localhost:7025/api/Posts")
      .pipe(map((res: PostInterface[]) => {
        return res;
      }))
  }

  get(): any {
    return this.httpClient.get("");
  }
}

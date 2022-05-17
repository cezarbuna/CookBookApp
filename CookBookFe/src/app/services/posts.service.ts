import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PostInterface} from "../models/post-interface";

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private httpClient: HttpClient) { }

  getAllPosts(): Observable<PostInterface[]> {
    return this.httpClient.get<PostInterface[]>("https://localhost:7025/api/Posts");
  }

  get(): any {
    return this.httpClient.get("");
  }
}

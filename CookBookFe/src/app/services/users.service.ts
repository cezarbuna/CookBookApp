import { Injectable } from '@angular/core';
import {UserInterface} from "../models/user-interface";
import {HttpClient} from "@angular/common/http";
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private httpClient: HttpClient) {
  }

  postUser(data: UserInterface) {
    return this.httpClient.post<UserInterface>("https://localhost:7025/api/Users/", data)
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  deleteUser(id: string) {
    return this.httpClient.delete<any>("https://localhost:7025/api/Users/" + id)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  updateUser(data: any, id: string) {
    return this.httpClient.patch<any>("https://localhost:7025/api/Users/" + id, data)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  getUsers() {
    return this.httpClient.get<UserInterface[]>("https://localhost:7025/api/Users/")
      .pipe(map((res: UserInterface[]) => {
        return res;
      }))
  }

  getUserById(id: string) {
    return this.httpClient.get<UserInterface>("https://localhost:7025/api/Users/get-user-by-id/" + id)
      .pipe(map((res: UserInterface) => {
        return res;
      }))
  }

  getUserIdByUsername(username: string){
    return this.httpClient.get<UserInterface[]>("https://localhost:7025/api/Users/get-user-id-by-username/" + username)
      .pipe(map((res: any) => {
        return res;
      }))
  }
}

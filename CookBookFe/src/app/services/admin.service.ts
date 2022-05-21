import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserInterface} from "../models/user-interface";
import {map} from "rxjs";
import {AdminInterface} from "../models/admin-interface";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient: HttpClient) {
  }

  postAdmin(data: UserInterface) {
    return this.httpClient.post<AdminInterface>("https://localhost:7025/api/Admins/", data)
      .pipe(map((res: AdminInterface) => {
        return res;
      }))
  }

  deleteAdmin(id: string) {
    return this.httpClient.delete<any>("https://localhost:7025/api/Admins/" + id)
      .pipe(map((res: any) => {
        return res;
      }))
  }

  updateAdmin(data: AdminInterface, id: string) {
    return this.httpClient.patch<AdminInterface>("https://localhost:7025/api/Admins/" + id, data)
      .pipe(map((res: AdminInterface) => {
        return res;
      }))
  }

  getAdminIdByUserId(userId: string) {
    return this.httpClient.get<AdminInterface>("https://localhost:7025/api/Admins/get-admin-id-by-normal-id/" + userId)
      .pipe(map((res:any) => {
        return res;
      }))
  }

  getAdminById(adminId: string) {
    return this.httpClient.get<AdminInterface>("https://localhost:7025/api/Admins/get-admin-by-id/" + adminId)
      .pipe(map((res:AdminInterface) => {
        return res;
      }))
  }

  getAdmins() {
    return this.httpClient.get<AdminInterface[]>("https://localhost:7025/api/Admins/")
      .pipe(map((res: AdminInterface[]) => {
        return res;
      }))
  }
}

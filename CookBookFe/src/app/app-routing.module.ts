import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "./components/home/home.component";
import {AboutUsComponent} from "./components/about-us/about-us.component";
import {LoginComponent} from "./components/login/login.component";
import {RegisterComponent} from "./components/register/register.component";
import {AdminLoginComponent} from "./components/admin-login/admin-login.component";
import {AdminRegisterComponent} from "./components/admin-register/admin-register.component";
import {AdminProfileComponent} from "./components/admin-profile/admin-profile.component";
import {UserProfileComponent} from "./components/user-profile/user-profile.component";
import {CreatePostComponent} from "./components/create-post/create-post.component";
import {OwnedPostsComponent} from "./components/owned-posts/owned-posts.component";
import {EditPostComponent} from "./components/edit-post/edit-post.component";
import {CreateCommentComponent} from "./components/create-comment/create-comment.component";

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'about-us', component: AboutUsComponent},
  { path: 'login', component: LoginComponent},
  { path: 'admin-login', component: AdminLoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'admin-register', component: AdminRegisterComponent},
  { path: 'user-profile', component: UserProfileComponent},
  { path: 'admin-profile', component: AdminProfileComponent},
  { path: 'create-post', component: CreatePostComponent},
  { path: 'owned-posts', component: OwnedPostsComponent},
  { path: 'edit-post/:id', component: EditPostComponent},
  { path: 'create-comment/:id', component: CreateCommentComponent}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

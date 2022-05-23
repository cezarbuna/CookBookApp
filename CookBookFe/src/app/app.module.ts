import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {RouterModule} from "@angular/router";
import {MatCardModule} from "@angular/material/card";
import {MatFormFieldModule} from "@angular/material/form-field";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {FlexLayoutModule} from "@angular/flex-layout";
import {HttpClientModule} from "@angular/common/http";
import {MatListModule} from "@angular/material/list";
import {PostsService} from "./services/posts.service";
import {UsersService} from "./services/users.service";
import {CommentsService} from "./services/comments.service";
import {MatButtonToggleModule} from "@angular/material/button-toggle";
import { AdminRegisterComponent } from './components/admin-register/admin-register.component';
import { AdminLoginComponent } from './components/admin-login/admin-login.component';
import {JwtModule} from "@auth0/angular-jwt";
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { AdminProfileComponent } from './components/admin-profile/admin-profile.component';
import { CreatePostComponent } from './components/create-post/create-post.component';
import { OwnedPostsComponent } from './components/owned-posts/owned-posts.component';
import { EditPostComponent } from './components/edit-post/edit-post.component';
import { CreateCommentComponent } from './components/create-comment/create-comment.component';
import { BadlyRatedPostsComponent } from './components/badly-rated-posts/badly-rated-posts.component';
import { EditCommentComponent } from './components/edit-comment/edit-comment.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    AboutUsComponent,
    LoginComponent,
    RegisterComponent,
    AdminRegisterComponent,
    AdminLoginComponent,
    UserProfileComponent,
    AdminProfileComponent,
    CreatePostComponent,
    OwnedPostsComponent,
    EditPostComponent,
    CreateCommentComponent,
    BadlyRatedPostsComponent,
    EditCommentComponent
  ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        MatToolbarModule,
        MatButtonModule,
        MatIconModule,
        AppRoutingModule,
        RouterModule,
        MatCardModule,
        MatFormFieldModule,
        FormsModule,
        MatInputModule,
        FlexLayoutModule,
        HttpClientModule,
        MatListModule,
        ReactiveFormsModule,
        MatButtonToggleModule,
        JwtModule.forRoot({
          config: {
            tokenGetter: tokenGetter,
            allowedDomains: ["http://localhost:4200/"],
            disallowedRoutes: []
          }
        })
    ],
  providers: [PostsService, UsersService, CommentsService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Routes } from '@angular/router';
import { PostsListComponent } from './components/posts-list/posts-list.component';
import { PostDetailsComponent } from './components/post-details/post-details.component';

export const routes: Routes = [
  { path:'posts' , component:PostsListComponent },
  { path: 'postdetails', component: PostDetailsComponent }
];

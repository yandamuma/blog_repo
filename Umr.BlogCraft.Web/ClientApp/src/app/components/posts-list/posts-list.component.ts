import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-posts-list',
  standalone: true,
  imports: [],
  templateUrl: './posts-list.component.html',
  styleUrl: './posts-list.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PostsListComponent {

}

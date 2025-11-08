import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-post-details',
  standalone: true,
  imports: [],
  templateUrl: './post-details.component.html',
  styleUrl: './post-details.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PostDetailsComponent {

}

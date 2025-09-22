import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  categories: string[] = [
    'TV & Video',
    'Audio & Home Theater',
    'Mobile',
    'Computer',
    'Camera & Photo',
    'Wearable Technology',
  ];
}

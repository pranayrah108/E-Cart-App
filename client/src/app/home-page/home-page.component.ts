import { Component } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CarouselModule as owlCarouselModule } from 'ngx-owl-carousel-o';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-home-page',
  standalone: false,
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
})
export class HomePageComponent {
  myInterval: number = 1000;

  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: false,
    touchDrag: false,
    pullDrag: false,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1,
      },
      400: {
        items: 2,
      },
      740: {
        items: 3,
      },
      940: {
        items: 4,
      },
    },
    nav: true,
    autoplay: true,
    autoplaySpeed: 1000,
  };

  slidesStore: any[] = [
  {
    id: '1',
    src: 'assets/latptop.jpg',
    alt: 'Laptop product image',
    title: 'Laptop',
  },
  {
    id: '2',
    src: 'assets/mobile.jpg',
    alt: 'Smartphone product image',
    title: 'Mobile Phone',
  },
  {
    id: '3',
    src: 'assets/TV & Video.jpg',
    alt: 'TV & Video',
    title: 'TV & Video.jpg',
  },
  {
    id: '4',
    src: 'assets/Audio & Home Theater.jpg',
    alt: 'Audio & Home Theater',
    title: 'Audio & Home Theater',
  },
  {
    id: '5',
    src: 'assets/Camera & Photo.jpg',
    alt: 'Camera & Photo',
    title: 'Camera & Photo',
  },
  {
    id: '6',
    src: 'assets/Wearable Technology.jpg',
    alt: 'Wearable Technology',
    title: 'Wearable Technology',
  },
  ];

}

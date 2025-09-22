import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { AppRoutingModule } from "../app-routing.module";
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [HeaderComponent, FooterComponent],
  imports: [CommonModule, MatIconModule, MatMenuModule, AppRoutingModule,RouterModule],
  exports: [HeaderComponent, FooterComponent],
})
export class LayoutModule {}

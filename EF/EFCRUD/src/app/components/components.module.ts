import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import {ToastModule} from 'primeng/toast';

import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ConfirmationService, MessageService } from 'primeng/api';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ToastModule

  ],
  declarations: [
    NavbarComponent,
    SidebarComponent
  ],
  exports: [
    NavbarComponent,
    SidebarComponent
  ],
  providers:[MessageService,ConfirmationService]

})
export class ComponentsModule { }

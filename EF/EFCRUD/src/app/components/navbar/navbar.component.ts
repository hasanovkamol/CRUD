import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';
import { ROUTES } from '../route';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {
    private listTitles: any[]=[];
    location: Location;
      mobile_menu_visible: any = 0;

    constructor(location: Location) {
      this.location = location;
    }

    ngOnInit(){
      this.listTitles = ROUTES.filter(listTitle => listTitle);
    }
    getTitle(){
      var titlee = this.location.prepareExternalUrl(this.location.path());
      if(titlee.charAt(0) === '#'){
          titlee = titlee.slice( 1 );
      }

      for(var item = 0; item < this.listTitles.length; item++){
          if(this.listTitles[item].path === titlee){
              return this.listTitles[item].title;
          }
      }
      return 'Student';
    }
}

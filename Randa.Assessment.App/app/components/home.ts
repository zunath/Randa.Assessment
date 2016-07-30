import { Component } from '@angular/core';
import { HeaderComponent } from './header';
import { FooterComponent } from './footer';

@Component({
    selector: 'assessment-home',
    templateUrl: './app/templates/home.html',
    directives: [HeaderComponent, FooterComponent]
})
export class HomeComponent {
    
}
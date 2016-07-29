import { Component } from '@angular/core';
import { HeaderComponent } from './components/header'
import { FooterComponent } from './components/footer'

@Component({
    selector: 'app-root',
    templateUrl: './app-template.html',
    directives: [FooterComponent, HeaderComponent]
})
export class AppComponent { }
import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HomeComponent } from './components/home';
import { HeaderComponent } from './components/header';
import { FooterComponent } from './components/footer';

@Component({
    selector: 'app-root',
    templateUrl: './app-template.html',
    directives: [ROUTER_DIRECTIVES],
    precompile: [HomeComponent, HeaderComponent, FooterComponent]
})
export class AppComponent { }
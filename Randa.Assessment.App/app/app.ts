import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HomeComponent } from './components/home';

@Component({
    selector: 'app-root',
    templateUrl: './Layout.html',
    directives: [ROUTER_DIRECTIVES],
    precompile: [HomeComponent]
})
export class AppComponent { }
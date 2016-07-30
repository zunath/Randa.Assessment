import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HomeComponent } from './components/homeComponent';
import { InstitutionComponent } from './components/communication/institutionComponent';
import './rxjs-operators';

@Component({
    selector: 'app-root',
    templateUrl: './Layout.html',
    directives: [ROUTER_DIRECTIVES],
    precompile: [HomeComponent, InstitutionComponent]
})
export class AppComponent { }
import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HomeComponent } from './components/homeComponent';
import { InstitutionComponent } from './components/communication/institutionComponent';
import { ODataService } from './services/odataService';
import './rxjs-operators';

@Component({
    selector: 'app-root',
    templateUrl: './Layout.html',
    directives: [ROUTER_DIRECTIVES],
    precompile: [HomeComponent, InstitutionComponent],
    providers: [ODataService]
})
export class AppComponent { }
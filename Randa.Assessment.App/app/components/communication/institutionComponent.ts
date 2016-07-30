import { Component } from '@angular/core';
import { DistrictListComponent } from '../shared/districtListComponent';

@Component({
    selector: 'institutions',
    templateUrl: './templates/communication/institutions.html',
    directives: [DistrictListComponent]
})
export class InstitutionComponent {

}
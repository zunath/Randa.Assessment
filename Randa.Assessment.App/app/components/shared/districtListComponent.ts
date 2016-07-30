import { Component, OnInit } from '@angular/core';
import { District } from '../../models/district';
import { DistrictService } from '../../services/districtService';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'district-list',
    templateUrl: './templates/shared/districtList.html',
    directives: [],
    providers: [DistrictService]
})
export class DistrictListComponent implements OnInit {
    constructor(private service: DistrictService) { }

    public districts: District[];

    ngOnInit() {
        this.service.getDistricts().subscribe(districts => this.districts = districts);
    }

}
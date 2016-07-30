import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/map';


import { District } from '../models/district';

@Injectable()
export class DistrictService {
    constructor(private http: Http) {
    }

    private url = 'http://localhost:51513/api/Districts/';

    public getDistricts(): District[] {

        let districts = [
            new District(1, 'district 1'),
            new District(2, 'district 2'),
            new District(3, 'district 3'),
            new District(4, 'district 4'),
            new District(5, 'district 5')
        ];
        
        return districts;
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }
}
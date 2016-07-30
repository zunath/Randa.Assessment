import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/map';


import { District } from '../models/district';
import { ODataService } from './odataService'

@Injectable()
export class DistrictService {
    constructor(private http: Http, private service : ODataService) {
    }
    
    public getDistricts(): Observable<District[]> {
        return this.service.getList<District>('District');
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }
}
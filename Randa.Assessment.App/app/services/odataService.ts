import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { ODataModel } from '../models/odataModel';

@Injectable()
export class ODataService {
    private baseUrl = "http://localhost:51513/api/";

    constructor(private http: Http) {
        
    }

    public getList<T extends ODataModel>(endpoint : string) : Observable<T[]> {
        let url = this.baseUrl + endpoint;

        console.log(url);
        return this.http.get(url)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getSingle<T extends ODataModel>(endpoint: string): T {

        return null;
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.value || {};
    }
    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}

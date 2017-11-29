import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Category } from '../domain/category';

@Injectable()
export class CategoryService {
    constructor(private http: Http) { }
    private postUrl = 'http://localhost:56027/api/category/';
    //getCategory() {
    //    return this.http.get(this.postUrl)
    //        .map((res: Response) => res.json());
    //}

    getCategory(): Observable<Category[]> {
        return this.http.get(this.postUrl)
            .map(this.parseData)
            .catch(this.handleError);
    }

    private parseData(res: Response) {
        console.log(res);
        return res.json() || [];
    }

    // Displays the error message
    private handleError(error: Response | any) {
        let errorMessage: string;

        errorMessage = error.message ? error.message : error.toString();

        // In real world application, call to log error to remote server
        // logError(error);

        // This returns another Observable for the observer to subscribe to
        return Observable.throw(errorMessage);
    }
}
import { Injectable }                                   from '@angular/core';
import { Response, Http, Headers, RequestOptions }      from '@angular/http';
import { Observable }                                   from 'rxjs/Observable'

@Injectable()
export class IdentityService {
    constructor(private http: Http) { }
}

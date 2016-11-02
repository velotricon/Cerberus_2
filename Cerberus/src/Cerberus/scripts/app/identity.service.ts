import { Injectable }                                   from '@angular/core';
import { Response, Http, Headers, RequestOptions }      from '@angular/http';
import { Observable }                                   from 'rxjs/Observable'

@Injectable()
export class IdentityService {
    constructor(private http: Http) { }

    Login(Username: string, Password: string) {
        
    }

    Register(Username: string, Email: string, Password: string) {
        let new_user = {
            Username: Username,
            Email: Email,
            Password: Password
        }
    }
}


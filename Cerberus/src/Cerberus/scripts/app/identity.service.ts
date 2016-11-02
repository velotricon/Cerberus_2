import { Injectable }                                   from '@angular/core';
import { Response, Http, Headers, RequestOptions }      from '@angular/http';
import { Observable }                                   from 'rxjs/Observable'

@Injectable()
export class IdentityService {
    constructor(private http: Http) { }

    Login(Username: string, Password: string) {
        
    }

    Register(Username: string, Email: string, Password: string): Observable<boolean>{
        let body = JSON.stringify({
            Login: Username,
            Email: Email,
            Password: Password
        });
        let headers = new Headers({ 'Content-type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        //return this.http.post('api/register', body, options).map(this.map_generic_result_container).catch(this.handle_error);
        return this.http.post('api/account/register', body, options).map(this.map_generic_result_container).catch(this.handle_error);
    }

    private handle_error(error: any) {
        return Observable.throw(error.status + ': ' + error.statusText);
    }

    private map_generic_result_container(res: Response) {
        let result_container = res.json();
        return true;
    }
}


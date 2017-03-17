import { Injectable }                                   from '@angular/core';
import { Response, Http, Headers, RequestOptions }      from '@angular/http';
import { Observable }                                   from 'rxjs/Observable';
import { AbstractApiService }                           from '../abstractions/abstract.api.service';
import { GenericResultContainer }                       from '../containers/generic.result.container';

@Injectable()
export class IdentityService extends AbstractApiService{
    constructor(http: Http) {
        super(http);
    }

    Login(Username: string, Password: string): Observable<GenericResultContainer> {
        //let body = JSON.stringify({
        //    Username: Username,
        //    Password: Password,
        //    RememberMe: false
        //});
        let data = {
            Username: Username,
            Password: Password,
            RememberMe: false
        }
        //let headers = new Headers({ 'Content-type': 'application/json' });
        //let options = new RequestOptions({ headers: headers });
        //return this.http.post('api/account/authenticate/', body, options).map(this.map_generic_result_container).catch(this.handle_error);
        return this.ApiPost('api/account/authenticate/', data);
    }

    Register(Username: string, Email: string, Password: string): Observable<GenericResultContainer>{
        //let body = JSON.stringify({
        //    Login: Username,
        //    Email: Email,
        //    Password: Password
        //});
        let data = {
            Login: Username,
            Email: Email,
            Password: Password
        }
        //let headers = new Headers({ 'Content-type': 'application/json' });
        //let options = new RequestOptions({ headers: headers });
        //return this.http.post('api/register', body, options).map(this.map_generic_result_container).catch(this.handle_error);
        //return this.http.post('api/account/register', body, options).map(this.map_generic_result_container).catch(this.handle_error);
        return this.ApiPost('api/account/register', data);
    }

    GetUserInfo(): Observable<GenericResultContainer> {
        //let headers = new Headers({ 'Content-type': 'application/json' });
        //let options = new RequestOptions({ headers: headers });
        //return this.http.get('api/account/GetAccountInfo').map(this.map_generic_result_container).catch(this.handle_error);
        return this.ApiGet('api/account/GetAccountInfo');
    }

    Logout(): Observable<GenericResultContainer> {
        //let body = {};
        //let headers = new Headers({ 'Content-type': 'application/json' });
        //let options = new RequestOptions({ headers: headers });
        //return this.http.post('api/account/logout', body, options).map(this.map_generic_result_container).catch(this.handle_error);
        let body = {};
        return this.ApiPost('api/account/logout', body);
    }

    //private handle_error(error: any) {
    //    return Observable.throw(error.status + ': ' + error.statusText);
    //}

    //private map_generic_result_container(res: Response) {
    //    let result_container = res.json();
    //    return true;
    //}
}


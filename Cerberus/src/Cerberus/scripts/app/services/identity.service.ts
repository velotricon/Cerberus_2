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
        let data = {
            Username: Username,
            Password: Password,
            RememberMe: false
        }
        return this.ApiPost('api/account/authenticate/', data);
    }

    Register(Username: string, Email: string, Password: string): Observable<GenericResultContainer>{
        let data = {
            Login: Username,
            Email: Email,
            Password: Password
        }
        return this.ApiPost('api/account/register', data);
    }

    GetUserInfo(): Observable<GenericResultContainer> {
        return this.ApiGet('api/account/GetAccountInfo');
    }

    Logout(): Observable<GenericResultContainer> {
        let body = {};
        return this.ApiPost('api/account/logout', body);
    }

    RemoveUserAvatar(): Observable<GenericResultContainer> {
        let body = {};
        return this.ApiPost('api/account/avatar/remove', body);
    }
}


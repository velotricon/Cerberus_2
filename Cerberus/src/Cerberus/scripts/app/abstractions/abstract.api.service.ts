import { Response, Http, Headers, RequestOptions }      from '@angular/http';
import { Observable }                                   from 'rxjs/Observable';
import { GenericResultContainer }                       from '../containers/generic.result.container';

export class AbstractApiService {
    constructor(protected http: Http) { }

    protected handle_error(error: any) {
        return Observable.throw(error.status + ': ' + error.statusText);
    }

    protected map_generic_result_container(res: Response) {
        let request_result = res.json();
        let result_container = new GenericResultContainer(
            request_result.Succeeded,
            request_result.Message,
            request_result.Result);
        return result_container;
    }

    private get_options(): RequestOptions {
        let headers = new Headers({ 'Content-type': 'application/json' });
        let options = new RequestOptions({
            headers: headers
        });
        return options
    }

    protected ApiGet(url: string): Observable<GenericResultContainer> {
        //return this.http.get(url).map(this.map_generic_result_container).catch(this.handle_error);
        //Używanie get'a z opcjami rzuca błędem (nie wiem czemu).
        return this.http.get(url).map(this.map_generic_result_container).catch(this.handle_error);
    }

    protected ApiPost(url: string, data: any): Observable<GenericResultContainer> {
        return this.http.post(url, JSON.stringify(data), this.get_options()).map(this.map_generic_result_container).catch(this.handle_error);
    }

    protected ApiPut(url: string, data: any): Observable<GenericResultContainer> {
        return this.http.put(url, JSON.stringify(data), this.get_options()).map(this.map_generic_result_container).catch(this.handle_error);
    }

    protected ApiDelete(url: string): Observable<GenericResultContainer> {
        return this.http.delete(url, this.get_options()).map(this.map_generic_result_container).catch(this.handle_error);
    }
}
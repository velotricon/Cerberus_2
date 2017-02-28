import { Injectable }                                   from '@angular/core';
import { Response, Http, Headers, RequestOptions }      from '@angular/http';
import { PersonContainer }                              from '../containers/person.container';
import { PERSON_ARRAY }                                 from '../mockups/person.mock';
import { Observable }                                   from 'rxjs/Observable';

@Injectable()
export class PersonService {
    constructor(private http: Http) {
    }

    GetPerson(PersonId: number): Promise<PersonContainer> {
        return Promise.resolve(PERSON_ARRAY.find(x => x.Id === PersonId));
    }

    GetPersonArray(): Observable<PersonContainer[]> {
        return this.http.get('api/person').map(this.map_person_array).catch(this.handle_error);
    }

    AddPerson(PersonObj): Observable<number> {
        let body = JSON.stringify(PersonObj);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post('api/person', body, options).map(this.map_person_id).catch(this.handle_error);
    }

    private handle_error(error: any) {
        //Tutaj da się ze zmiennej error wyciągnąć jakieś ciekawsze informacje dot. wyjątku rzuconego z serwera.
        //Jak kiedyś zorientuję się jak w angularze2 pokazywać w fajny sposób błędy i jak je gdzieś logować
        //na serwerze albo jak je wysyłać mailem to się do tego wróci.
        return Observable.throw(error.status + ': ' + error.statusText);
    }

    private map_person_array(res: Response) {
        let body = res.json();
        return body;
    }

    private map_person_id(res: Response) {
        let id: number = res.json();
        return id;
    }
}
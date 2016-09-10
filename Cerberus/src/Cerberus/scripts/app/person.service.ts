import { Injectable }       from '@angular/core';
import { Response, Http }   from '@angular/http';
import { Person }           from './person';
import { PERSON_ARRAY }     from './person.mock';
import { Observable }       from 'rxjs/Observable';

@Injectable()
export class PersonService {
    constructor(private http: Http) {
    }

    GetPerson(PersonId: number): Promise<Person> {
        return Promise.resolve(PERSON_ARRAY.find(x => x.Id === PersonId));
    }

    GetPersonArray(): Observable<Person[]> {
        return this.http.get('api/person').map(this.map_person_array);
    }

    private map_person_array(res: Response) {
        let body = res.json();
        let tmp1: Person = body[0];
        let tmp2: Person = body[1];
        return body || {};
    }
}
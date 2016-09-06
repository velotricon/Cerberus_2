import { Injectable }       from '@angular/core';
import { Person }           from './person';
import { PERSON_ARRAY }     from './person.mock';

@Injectable()
export class PersonService {
    GetPerson(PersonId: number): Promise<Person> {
        return Promise.resolve(PERSON_ARRAY.find(x => x.Id === PersonId));
    }

    GetPersonArray(): Promise<Person[]> {
        return Promise.resolve(PERSON_ARRAY);
    }
}
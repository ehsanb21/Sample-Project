import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Person } from "../models/Person";

@Injectable({
  providedIn: 'root'
})

export class PersonsServices {
  private baseURL = "https://localhost:5001/Person/";

  constructor(private httpClient: HttpClient) { }

  getPersonList(): Observable<Person[]> {
    return this.httpClient.get<Person[]>(`${this.baseURL}get-person?$select=Id,FirstName,LastName,iranCityId,iranCityName,iranStateId,iranStateName`);
  }

  createPerson(person: Person): Observable<Object> {
    return this.httpClient.post(`${this.baseURL}send-person/`, person);
  }

  getPersonById(id: number | undefined): Observable<Person> {    
    return this.httpClient.get<Person>(`${this.baseURL}get-person/${id}?$select=Id,FirstName,LastName,iranCityId,iranCityName,iranStateId,iranStateName`);
  }

  updatePerson(person: Person): Observable<Object> {
    return this.httpClient.put(`${this.baseURL}edit-person`, person);
  }

  deletePerson(id: number ): Observable<Object> {
    return this.httpClient.delete(`${this.baseURL}delete-person/${id}`);
  }
}

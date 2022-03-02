import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { City } from '../models/City';
import { State } from '../models/State';

@Injectable({
  providedIn: 'root'
})

export class CountryService{
    private baseURL = "https://localhost:5001/Country/";
    constructor(private httpClient: HttpClient) { }
    getStateList(): Observable<State[]> {
        return this.httpClient.get<State[]>(`${this.baseURL}get-states`);
      }

      getCityList(id:number|undefined): Observable<City[]> {
        return this.httpClient.get<City[]>(`${this.baseURL}get-cites/${id}`);
      }
}
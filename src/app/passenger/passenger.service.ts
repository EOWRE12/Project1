import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {from, Observable, throwError } from 'rxjs';
import { catchError, of } from 'rxjs';

import { Passenger, PassengerDTO } from './passenger';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {
  private PassengerURL = 'https://localhost:7081/api/passengers';
  private currPassengerId!: number;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient) { }

  getPassengers(): Observable<Passenger[]> {
    console.log("Retrieving passengers from db");
    return this.http.get<Passenger[]>(this.PassengerURL, this.httpOptions);
  }

  getPassenger(id: number): Observable<Passenger> {
    return this.http.get<Passenger>(`${this.PassengerURL}/${id}`, this.httpOptions);
  }

  createPassenger(Passenger: Passenger): Observable<Passenger> {
    return this.http.post<Passenger>(this.PassengerURL, Passenger, this.httpOptions);
  }

  updatePassenger(Passenger: Passenger): Observable<Passenger> {
    return this.http.put<Passenger>(`${this.PassengerURL}/${this.currPassengerId}`, Passenger, this.httpOptions);
  }

  deletePassenger(id: number): Observable<Passenger> {
    return this.http.delete<Passenger>(`${this.PassengerURL}/${id}`, this.httpOptions);
  }

  updatePassengerId(id: number) {
    this.currPassengerId = id;
  }
  
  getPassengerId(): number {
    return this.currPassengerId;
  }
}

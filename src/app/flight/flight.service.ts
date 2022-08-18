import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {from, Observable, throwError } from 'rxjs';
import { catchError, of } from 'rxjs';
import { BehaviorSubject } from 'rxjs';

import { Flight, FlightDTO } from './flight';


@Injectable({
  providedIn: 'root'
})
export class FlightService {
  private FlightURL = 'https://localhost:7081/api/flights';
  private currFlightId!: number;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient) { }

  getFlights(): Observable<Flight[]> {
    console.log("retrieving flights from db");
    return this.http.get<Flight[]>(this.FlightURL, this.httpOptions);
  }

  getFlight(id: number): Observable<Flight> {
    return this.http.get<Flight>(`${this.FlightURL}/${id}`, this.httpOptions);
  }

  createFlight(flight: Flight): Observable<Flight> {
    return this.http.post<Flight>(this.FlightURL, flight, this.httpOptions);
  }

  updateFlight(flight: Flight): Observable<Flight> {
    return this.http.put<Flight>(`${this.FlightURL}/${this.currFlightId}`, flight, this.httpOptions);
  }

  deleteFlight(id: number): Observable<Flight> {
    return this.http.delete<Flight>(`${this.FlightURL}/${id}`, this.httpOptions);
  }

  updateFlightId(id: number) {
    this.currFlightId = id;
  }

  getFlightId(): number {
    return this.currFlightId;
  }
}

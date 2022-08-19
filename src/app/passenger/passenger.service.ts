import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { from, Observable, throwError } from 'rxjs';
import { catchError, of } from 'rxjs';

import { Passenger, PassengerDTO } from './passenger';
import { Ticket, TicketDTO } from './ticket';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {
  private PassengerURL = 'https://localhost:7081/api/passengers';
  private TicketURL = 'https://localhost:7081/api/tickets';
  private currPassengerId!: number;
  private currTicketId!: number;
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

  getTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.TicketURL, this.httpOptions);
  }

  getTicket(id: number): Observable<TicketDTO> {
    return this.http.get<TicketDTO>(`${this.TicketURL}/${id}`, this.httpOptions);
  }

  createTicket(ticket: Ticket): Observable<Ticket> {
    return this.http.post<Ticket>(this.TicketURL, ticket, this.httpOptions);
  }

  updateTicket(Ticket: Ticket): Observable<Ticket> {
    return this.http.put<Ticket>(`${this.TicketURL}/${this.currTicketId}`, this.httpOptions);
  }

  deleteTicket(id: number): Observable<TicketDTO> {
    return this.http.get<TicketDTO>(`${this.TicketURL}/${id}`, this.httpOptions);
  }

  updateTicketId(id: number) {
    this.currTicketId = id;
  }
  
  getTicketId(): number {
    return this.currTicketId;
  }
}

import { Component, OnInit } from '@angular/core';
import { Ticket } from '../ticket';
import { Flight } from 'src/app/flight/flight';
import { PassengerService } from '../passenger.service';
import { FlightService } from 'src/app/flight/flight.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  public newTicketForm!: FormGroup;
  flights: Flight[] = [];
  ticket: Ticket= {} as Ticket;

  constructor(
    private passengerService: PassengerService,
    private flightService: FlightService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.retrieveFlights();
  }

  retrieveFlights(): void {
    console.log("calling api with GetFlights");
    this.flightService.getFlights().subscribe(flights => this.flights = flights);
  }

  bookFlight(flightId: number): void {
    this.ticket.flightId = flightId;
    this.ticket.passengerId = this.passengerService.getPassengerId();
    this.passengerService.createTicket(this.ticket).subscribe(() => {
      this.router.navigateByUrl("/passenger/details");
    });
  }
}

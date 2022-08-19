import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Passenger } from 'src/app/passenger/passenger';
import { Flight } from '../flight';
import { FlightService } from '../flight.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  flight: Flight = {} as Flight;
  passengers: Passenger[] = [];
  
  constructor(
    private flightService: FlightService,
    private router: Router) { }

  ngOnInit(): void {
    this.retrieveFlight();
    console.log(this.flight.passengers);
  }

  retrieveFlight(): void {
    let id = this.flightService.getFlightId();
    this.flightService.getFlight(id).subscribe(flight => this.flight = flight);
  }
}

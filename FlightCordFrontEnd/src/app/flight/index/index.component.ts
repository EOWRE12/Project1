import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Flight } from '../flight';
import { FlightService } from '../flight.service';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  flights: Flight[] = [];

  constructor(
    private flightService: FlightService,
    private router: Router ) { }

  ngOnInit(): void {
    console.log("loading index, retriving flight");
    this.retrieveFlights();
  }

  retrieveFlights(): void {
    console.log("calling api with GetFlights");
    this.flightService.getFlights().subscribe(flights => this.flights = flights);
  }

  deleteFlight(id:number): void {
    console.log("deleting flight");
    this.flightService.deleteFlight(id).subscribe();
    location.reload();
  }

  editFlight(id:number): void {
    this.flightService.updateFlightId(id);
    this.router.navigateByUrl("/flight/edit");
  }

  flightDetails(id:number): void {
    this.flightService.updateFlightId(id);
    this.router.navigateByUrl("flight/details");
  }

}

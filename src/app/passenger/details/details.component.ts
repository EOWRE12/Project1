import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { Flight } from 'src/app/flight/flight';
import { Passenger } from '../passenger';
import { PassengerService } from '../passenger.service';
import { Ticket } from '../ticket';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  passenger: Passenger = {} as Passenger;

  constructor(
    private passengerService: PassengerService,
    private router: Router) { }

  ngOnInit(): void {
    this.retrievePassenger();
  } 

  retrievePassenger(): void {
    let id = this.passengerService.getPassengerId();
    this.passengerService.getPassenger(id).subscribe(passenger => this.passenger = passenger);
  }

  bookNewFlight(): void {
    this.passengerService.updatePassengerId(this.passenger.id);
    this.router.navigateByUrl("/passenger/book");
  }
}

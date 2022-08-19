import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { throwError, VirtualTimeScheduler } from 'rxjs';
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
  tickets: Ticket[] = [];

  constructor(
    private passengerService: PassengerService,
    private router: Router) { }

  ngOnInit(): void {
    this.retrievePassenger();
    this.passengerService.getTickets().subscribe(t => this.tickets = t);
  } 

  retrievePassenger(): void {
    let id = this.passengerService.getPassengerId();
    this.passengerService.getPassenger(id).subscribe(passenger => this.passenger = passenger);
  }

  bookNewFlight(): void {
    this.passengerService.updatePassengerId(this.passenger.id);
    this.router.navigateByUrl("/passenger/book");
  }

  deleteTicket(id: number) {
    console.log(id);
    this.passengerService.deleteTicket(id).subscribe(() => {
      this.router.navigateByUrl("/passenger/index");
    });
  }
}

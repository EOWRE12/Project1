import { Component, OnInit } from '@angular/core';
import { provideProtractorTestingSupport } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Passenger } from '../passenger';
import { PassengerService } from '../passenger.service';
import { Ticket } from '../ticket';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  passengers: Passenger[] =[];
  ticket: Ticket = {} as Ticket;

  constructor(
    private passengerService: PassengerService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.retrievePassengers();
  }

  retrievePassengers(): void {
    this.passengerService.getPassengers().subscribe(passengers => this.passengers = passengers);
  }

  deletePassenger(id: number): void {
    this.passengerService.deletePassenger(id).subscribe();
    location.reload();
  }

  editPassenger(id: number): void {
    this.passengerService.updatePassengerId(id);
    this.router.navigateByUrl("/passenger/edit");
  }

  passengerDetails(id:number): void {
    this.passengerService.updatePassengerId(id);
    this.router.navigateByUrl("/passenger/details");
  }
}

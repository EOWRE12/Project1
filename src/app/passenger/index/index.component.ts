import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Passenger } from '../passenger';
import { PassengerService } from '../passenger.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  passengers: Passenger[] =[];

  constructor(
    private passengerService: PassengerService,
    private router: Router
    ) { }

  ngOnInit(): void {
    console.log("loadign passengers");
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

}

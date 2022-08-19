import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Passenger } from '../passenger';
import { PassengerService } from '../passenger.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  public updatePassengerForm!: FormGroup;
  passenger: Passenger = {} as Passenger;

  constructor(private passengerService: PassengerService,
    private router: Router) {
    }

  ngOnInit(): void {
    this.retrievePassenger();
    this.updatePassengerForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      age: new FormControl('', Validators.required),
      job: new FormControl('', Validators.required)
    });
  }

  get f() { return this.updatePassengerForm.controls; }

  retrievePassenger(): void {
    let id = this.passengerService.getPassengerId();
    this.passengerService.getPassenger(id).subscribe(passenger => this.passenger = passenger);
  }

  updatePassenger(): void {
    this.passengerService.updatePassenger(this.updatePassengerForm.value).subscribe(() => {
      this.router.navigateByUrl('passenger/index');
    });
  }
}

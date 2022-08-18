import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FlightService } from '../flight.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  public newFlightForm!: FormGroup;

  constructor(
    private flightService: FlightService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.newFlightForm = new FormGroup({
      capacity: new FormControl('', Validators.required),
      departureAirport: new FormControl('', Validators.required),
      arrivalAirport: new FormControl('', Validators.required),
      flightNumber: new FormControl('', Validators.required),
      departure: new FormControl('', Validators.required),
      arrival: new FormControl('', Validators.required)
    });
  }

  get f() { return this.newFlightForm.controls; }

  submit() {
    this.flightService.createFlight(this.newFlightForm.value).subscribe(() => {
      console.log(this.newFlightForm.value);
      console.log(this.newFlightForm.valid);
      console.log("Flight Created successfully!");
      this.router.navigateByUrl('flight/index');
    });
  }
}
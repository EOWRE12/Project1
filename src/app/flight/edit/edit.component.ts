import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Flight } from '../flight';
import { FlightService } from '../flight.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  public updateFlightForm!: FormGroup;
  flight: Flight = {} as Flight;
  // flightPut: Flight = {} as Flight;

  constructor(
    private flightService: FlightService,
    private router: Router) { 
  }

  ngOnInit(): void {
    this.retrieveFlight();
    this.updateFlightForm = new FormGroup({
      capacity: new FormControl('', Validators.required),
      departureAirport: new FormControl('', Validators.required),
      arrivalAirport: new FormControl('', Validators.required),
      flightNumber: new FormControl('', Validators.required),
      departure: new FormControl('', Validators.required),
      arrival: new FormControl('', Validators.required)
    });
  }

  get f() { return this.updateFlightForm.controls; }

  retrieveFlight(): void {
    let id = this.flightService.getFlightId();
    this.flightService.getFlight(id).subscribe(flight => this.flight = flight)
  }

  updateFlight(): void {
    this.flightService.updateFlight(this.updateFlightForm.value).subscribe();
    this.router.navigateByUrl('flight/index');
  }
}

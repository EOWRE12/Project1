import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PassengerService } from '../passenger.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  public newPassengerForm!: FormGroup

  constructor(
    private passengerService: PassengerService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.newPassengerForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required)
    });
  }

  get f() { return this.newPassengerForm.controls; }

  submit() {
    this.passengerService.createPassenger(this.newPassengerForm.value).subscribe(() => {
      console.log(this.newPassengerForm.value);
      console.log(this.newPassengerForm.valid);
      console.log("Passenger Created successfully!");
      this.router.navigateByUrl('passenger/index');
    });
  }
}

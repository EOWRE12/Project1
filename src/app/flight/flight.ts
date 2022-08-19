import { Passenger } from "../passenger/passenger";

export interface Flight {
    id: number;
    capacity: number;
    departureAirport: string;
    arrivalAirport: string;
    flightNumber: string;
    departure: string;
    arrival: string;
    numPassengers: number;
    passengers: Passenger[];
}

export interface FlightDTO {
    capacity: number;
    departureAirport: string;
    arrivalAirport: string;
    flightNumber: string;
    departure: string;
    arrival: string;
}
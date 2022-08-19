import { Flight } from "../flight/flight";
import { Passenger } from "./passenger";

export interface Ticket {
    id: number;
    passengerId: number;
    flightId: number;
}

export interface TicketDTO {
    id: number;
    passengerId: number;
    flightId: number;
    passenger: Passenger;
    flight: Flight;
}
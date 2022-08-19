import { Flight } from "../flight/flight";

export interface Passenger {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    age: number;
    job: string;
    flights: Flight[];
}

export interface PassengerDTO {
    firstName: string;
    lastName: string;
    email: string;
    age: number;
    job: string;
}
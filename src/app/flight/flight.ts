export interface Flight {
    id: number;
    capacity: number;
    departureAirport: string;
    arrivalAirport: string;
    flightNumber: string;
    departure: string;
    arrival: string;
}

export interface FlightDTO {
    capacity: number;
    departureAirport: string;
    arrivalAirport: string;
    flightNumber: string;
    departure: string;
    arrival: string;
}
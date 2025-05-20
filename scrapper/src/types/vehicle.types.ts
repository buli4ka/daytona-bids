export type VehicleType = {
    make: string;
    model: string;
    lotNumber: string;
    vin: string;
    odometer: number;
    color: string;
    transmission: string;
    driveTrain: string;
    conditionType: string;
    imageUrl: string;
    engine: Engine;
    
    
}


export type Engine = {
    volume: number;
    cylinders: number;
    fuel: string;
}
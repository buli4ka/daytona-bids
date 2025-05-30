export type VehicleType = {
    make: string; //mkn
    model: string; // mmod
    lotNumber: number; // ln
    vin: string; // fv
    odometer: number; // orr
    isOdometerActual: boolean; // ord
    color: string; // clr
    transmission: string; // tmtp
    driveTrain: string; // drv
    conditionType: string;
    imageUrl: string;
    engine: Engine;
    
    
}


export type Engine = {
    volume: number;
    cylinders: number;
    fuel: string;
}

export type Condition = {
    highlights: string; // lcd - run and drives
    primaryDamage: string; // pd - 
}
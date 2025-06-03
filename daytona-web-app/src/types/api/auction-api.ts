export type AuctionApi = AuctionType & {
  lots: LotType[];
};

export type LotApi = AuctionType & {
  lot: LotType;
};

type AuctionType = {
  auctionName: string;
  auctionLocation: {
    street: string;
    city?: string;
    state?: string;
    zip?: number;
  };
};

type LotType = {
  lotNumber: number;
  lotUrl: string;
  datePlaced: Date;
  vehicle: {
    vin: string;
    odometer: number;
    imageUrl: string;
    imageUrls?: string[];
    transmission: string;
    color: string;
    make: string;
    model: string;
    year: number;
    driveTrain: string;
    bodyStyle: string;
    engine: {
      cylinderNumber: number;
      volume: number;
      fuel: string;
    };
    condition: {
      keys: boolean;
      primaryDamage?: string;
      secondaryDamage?: string;
      highlights: string;
    };
  };
  saleInfo: {
    saleStatus: string;
    retailPrice: number;
    saleDate: Date;
    facility: {
      name: string;
      address: {
        street: string;
        city?: string;
        state?: string;
        zip?: number;
      };
    };
    bid: {
      currentPrice: number;
    };
    seller: {
      name: string;
    };
  };
};

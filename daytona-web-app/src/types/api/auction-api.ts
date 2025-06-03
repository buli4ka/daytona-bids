import { LotType } from '@/types/dtos/lot';

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

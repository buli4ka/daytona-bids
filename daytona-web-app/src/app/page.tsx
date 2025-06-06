import Card from '@mui/material/Card';
import { Box, CardContent, CardMedia, Divider, Paper, Stack, Typography } from '@mui/material';
import { AuctionApi } from '@/types/api/auction-api';
import Image from 'next/image';
import Link from 'next/link';
import LotDetailsCard from '@/components/lot-details-card/lot-details-card';
import VehicleFilter from '@/components-ui/vehicle-filter/vehicle-filter';

export default async function Home({ params, searchParams }) {
  const a = await searchParams;
  console.log(a);
  const data = (await fetch('http://localhost:5281/Auction').then(async res => await res.json())) as AuctionApi;
  console.log(data);
  return (
    <Stack direction='row' spacing={2} className='p-4'>
      <Paper className='flex flex-1'>
        <VehicleFilter />
      </Paper>
      <Stack className='flex flex-3 flex-wrap gap-2 justify-center'>
        {data.lots.map(lot => (
          <LotDetailsCard key={lot.lotNumber} lotDetails={lot} />
        ))}
      </Stack>
    </Stack>
  );
}

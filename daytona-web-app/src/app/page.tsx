import Card from '@mui/material/Card';
import { Box, CardContent, CardMedia, Divider, Typography } from '@mui/material';
import { AuctionApi } from '@/types/api/auction-api';
import Image from 'next/image';
import Link from 'next/link';

export default async function Home() {
  const data = (await fetch('http://localhost:5281/Auction').then(async res => await res.json())) as AuctionApi;
  console.log(data);
  return (
    <Box className='flex flex-wrap gap-2 justify-center'>
      {data.lots.map(lot => (
        <Card className='min-w-2xs w-1/4' key={lot.lotNumber}>
          <Link href='/vahicle/[id]' as={`/lot/${lot.lotNumber}`}>
            <CardMedia
              // sx={{ height: 200, width: 300, objectFit: 'contain' }}
              className='h-52 cursor-pointer'
              component={'img'}
              image={lot.vehicle.imageUrl}
              title={lot.vehicle.vin}
            />
          </Link>
          <CardContent className='flex flex-col gap-2'>
            <Typography
              variant='h5'
              component='div'
            >{`${lot.vehicle.make} ${lot.vehicle.model} ${lot.vehicle.year}`}</Typography>
            <Divider />
            <Box className='flex gap-2'>
              <Box className='flex-1'>
                <Typography fontSize={12}>{lot.vehicle.vin}</Typography>
                <Typography fontSize={12}>{lot.vehicle.odometer}</Typography>
                <Typography fontSize={12}>{lot.vehicle.condition.highlights}</Typography>
              </Box>
              <Divider flexItem orientation='vertical' />
              <Box className='flex-1'>
                <Typography fontSize={12}>{lot.vehicle.transmission}</Typography>
                <Typography fontSize={12}>{lot.vehicle.engine.volume}</Typography>
                <Typography fontSize={12}>{lot.vehicle.driveTrain}</Typography>
              </Box>
            </Box>
            <Divider />
            <Box className='flex justify-between'>
              <Typography variant='h6'>{lot.saleInfo.saleStatus}</Typography>
              <Typography variant='h6'>${lot.saleInfo.bid.currentPrice}</Typography>
            </Box>
          </CardContent>
        </Card>
      ))}
    </Box>
  );
}

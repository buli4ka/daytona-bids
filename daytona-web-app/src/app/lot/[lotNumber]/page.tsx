import React from 'react';
import { LotApi } from '@/types/api/auction-api';
import {
  Box,
  Divider,
  Grid,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Paper,
  Stack,
  Typography,
} from '@mui/material';
import Carousel from '@/components-ui/carousel/carousel';
import NumbersIcon from '@mui/icons-material/Numbers';
type Props = {
  params: Promise<{ lotNumber: number }>;
};
const LotPage = async ({ params }: Props) => {
  const { lotNumber } = await params;
  const { lot, auctionName } = (await fetch(`http://localhost:5281/Lot/${lotNumber}`).then(
    async res => await res.json(),
  )) as LotApi;

  return (
    <Box>
      <Box>
        <Typography variant='h5'>{`${lot.vehicle.make} ${lot.vehicle.model} ${lot.vehicle.year}`}</Typography>
        {auctionName}
      </Box>
      <Grid container spacing={2}>
        <Grid size={{ md: 6, lg: 5 }}>
          <Box className='flex flex-1 justify-center'>
            {lot.vehicle.imageUrls && <Carousel images={lot.vehicle.imageUrls} />}
          </Box>
        </Grid>
        <Grid size={{ md: 6, lg: 4 }}>
          <Paper className='flex-1 flex flex-col'>
            <Box className='flex justify-center'>
              <Typography variant='h5'>Vehicle Details</Typography>
            </Box>
            {/*<Stack divider={<Divider orientation='horizontal' flexItem />} className='flex-1'>*/}
            {/*  <Typography>Lot Number: {lot.lotNumber}</Typography>*/}
            {/*  <Typography>Vin Number: {lot.vehicle.vin}</Typography>*/}
            {/*</Stack>*/}
            <Grid container padding={2}>
              <Grid size={4} className='border-b-2 border-b-gray-100 p-2 align-center'>
                <Typography className='flex align-center' component='div'>
                  <NumbersIcon fontSize={'inherit'} />
                  Lot Number:
                </Typography>
              </Grid>
              <Grid size={8} className='border-b-2 border-b-gray-100  p-2'>
                <Typography>{lot.lotNumber}</Typography>
              </Grid>

              <Grid size={4} className='border-b-2 border-b-gray-100 p-2'>
                <Typography>Vin Number: </Typography>
              </Grid>
              <Grid size={8} className='border-b-2 border-b-gray-100 p-2'>
                <Typography>{lot.vehicle.vin}</Typography>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
        <Grid size={{ md: 12, lg: 3 }}>
          <Paper className=' flex' style={{ flex: '0.5' }}>
            bidding
          </Paper>
        </Grid>
      </Grid>
      {/*<Stack direction='row' spacing={4} className='p-2'>*/}
      {/*  <Box className='flex flex-1 justify-center'>*/}
      {/*    {lot.vehicle.imageUrls && <Carousel images={lot.vehicle.imageUrls} />}*/}
      {/*  </Box>*/}
      {/*  <Paper className='flex-1 flex flex-col'>*/}
      {/*    <Box className='flex justify-center'>*/}
      {/*      <Typography variant='h5'>Vehicle Details</Typography>*/}
      {/*    </Box>*/}
      {/*    /!*<Stack divider={<Divider orientation='horizontal' flexItem />} className='flex-1'>*!/*/}
      {/*    /!*  <Typography>Lot Number: {lot.lotNumber}</Typography>*!/*/}
      {/*    /!*  <Typography>Vin Number: {lot.vehicle.vin}</Typography>*!/*/}
      {/*    /!*</Stack>*!/*/}
      {/*    <Grid container padding={2}>*/}
      {/*      <Grid size={3} className='border-b-2 border-b-gray-100 p-2'>*/}
      {/*        <Typography>Lot Number: </Typography>*/}
      {/*      </Grid>*/}
      {/*      <Grid size={8} className='border-b-2 border-b-gray-100  p-2'>*/}
      {/*        <Typography>{lot.lotNumber}</Typography>*/}
      {/*      </Grid>*/}

      {/*      <Grid size={3} className='border-b-2 border-b-gray-100 p-2'>*/}
      {/*        <Typography>Vin Number: </Typography>*/}
      {/*      </Grid>*/}
      {/*      <Grid size={8} className='border-b-2 border-b-gray-100 p-2'>*/}
      {/*        <Typography>{lot.vehicle.vin}</Typography>*/}
      {/*      </Grid>*/}
      {/*    </Grid>*/}
      {/*  </Paper>*/}
      {/*  <Paper className=' flex' style={{ flex: '0.5' }}>*/}
      {/*    bidding*/}
      {/*  </Paper>*/}
      {/*</Stack>*/}
    </Box>
  );
};

export default LotPage;

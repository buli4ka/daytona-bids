import React from 'react';
import Link from 'next/link';
import Image from 'next/image';
import { Box, CardContent, CardMedia, Divider, Stack, Typography } from '@mui/material';
import Card from '@mui/material/Card';
import { LotType } from '@/types/dtos/lot';

type Props = { lotDetails: LotType };
const LotDetailsCard = ({ lotDetails: lot }: Props) => {
  return (
    // <Card className=''>
    //   <Box className='flex gap-2'>
    //     <Link href='/vahicle/[lotNumber]' as={`/lot/${lot.lotNumber}`}>
    //       {/*<CardMedia*/}
    //       {/*  // sx={{ height: 200, width: 300, objectFit: 'contain' }}*/}
    //       {/*  className='h-52 cursor-pointer'*/}
    //       {/*  component={'img'}*/}
    //       {/*  image={lot.vehicle.imageUrl}*/}
    //       {/*  title={lot.vehicle.vin}*/}
    //       {/*/>*/}
    //       <Image
    //         src={lot.vehicle.imageUrl}
    //         alt={lot.vehicle.vin}
    //         width={300}
    //         height={200}
    //         style={{ borderRadius: 'inherit' }}
    //       />
    //     </Link>
    //     <CardContent className='flex flex-col gap-2'>
    //       <Typography
    //         variant='h5'
    //         component='div'
    //       >{`${lot.vehicle.make} ${lot.vehicle.model} ${lot.vehicle.year}`}</Typography>
    //       <Divider />
    //       <Box className='flex gap-2'>
    //         <Box className='flex-1'>
    //           <Typography fontSize={12}>{lot.vehicle.vin}</Typography>
    //           <Typography fontSize={12}>{lot.vehicle.odometer}</Typography>
    //           <Typography fontSize={12}>{lot.vehicle.condition.highlights}</Typography>
    //         </Box>
    //         <Divider flexItem orientation='vertical' />
    //         <Box className='flex-1'>
    //           <Typography fontSize={12}>{lot.vehicle.transmission}</Typography>
    //           <Typography fontSize={12}>{lot.vehicle.engine.volume}</Typography>
    //           <Typography fontSize={12}>{lot.vehicle.driveTrain}</Typography>
    //         </Box>
    //       </Box>
    //       <Divider />
    //       <Box className='flex justify-between'>
    //         <Typography variant='h6'>{lot.saleInfo.saleStatus}</Typography>
    //         <Typography variant='h6'>${lot.saleInfo.bid.currentPrice}</Typography>
    //       </Box>
    //     </CardContent>
    //   </Box>
    // </Card>
    <Card className='h-[450px] '>
      <CardContent>
        <Stack direction={{ xs: 'column', md: 'row' }} spacing={2}>
          <Box maxWidth={{ md: '400px' }} className='w-full h-full'>
            <Link href='/vahicle/[lotNumber]' as={`/lot/${lot.lotNumber}`}>
              <Image
                src={lot.vehicle.imageUrl}
                alt={lot.vehicle.vin}
                width={400}
                height={300}
                // fill
                className='w-full h-full object-contain rounded-sm'
              />
            </Link>
          </Box>
          <Box className='flex flex-col gap-2 w-full'>
            <Typography
              variant='h5'
              component='div'
            >{`${lot.vehicle.make} ${lot.vehicle.model} ${lot.vehicle.year}`}</Typography>
            <Divider orientation='horizontal' flexItem />
            <Box className=''>
              <Typography>{lot.vehicle.vin}</Typography>
              <Typography>{lot.vehicle.odometer}</Typography>
              <Typography>{lot.vehicle.condition.highlights}</Typography>
            </Box>
          </Box>
        </Stack>
        <Box className=''>Hello</Box>
      </CardContent>
    </Card>
  );
};

export default LotDetailsCard;

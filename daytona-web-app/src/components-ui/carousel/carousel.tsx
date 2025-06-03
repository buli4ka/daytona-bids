'use client';
import React from 'react';
import { Box, Stack } from '@mui/material';
import Image from 'next/image';
import styles from './carousel.module.css';
type Props = {
  images: string[];
};
const Carousel = ({ images }: Props) => {
  const [carouselIndex, setCarouselIndex] = React.useState(0);

  return (
    // <Stack spacing={2} className='flex flex-1 max-h-[600px]'>
    //   <Box className='flex-1 h-full w-full flex cursor-pointer'>
    //     <Image
    //       src={images[carouselIndex]}
    //       alt={'i'}
    //       width={1000}
    //       height={600}
    //       className='w-auto h-auto object-contain rounded-xl'
    //       priority
    //     />
    //   </Box>
    //   <Stack direction='row' spacing={2} className='flex flex-1 '>
    //     {images.map((image, index) => (
    //       <Box key={image} className='flex flex-1 max-h-30 bg-gray-200 cursor-pointer'>
    //         <Image
    //           src={image}
    //           alt={image + index}
    //           width={100}
    //           height={100}
    //           className='object-contain w-full h-full'
    //           onClick={() => setCarouselIndex(index)}
    //         />
    //       </Box>
    //     ))}
    //   </Stack>
    // </Stack>

    <Stack spacing={2} className={styles.container}>
      {/*<Box className='flex flex-1 flex-col cursor-pointer justify-center w-full h-full'>*/}
      <Box className={styles.imageContainer}>
        <Image
          src={images[carouselIndex]}
          alt={'i'}
          // width={1000}
          // height={600}
          fill
          sizes='50vw'
          // className='w-auto h-auto object-contain rounded-xl'
          className={styles.mainImage}
          priority
        />
      </Box>
      {/*</Box>*/}

      <Stack
        direction='row'
        spacing={1}
        // className='max-w-full h-full'
        className={styles.selectorContainer}
      >
        {images.map((image, index) => (
          <Box key={image} className='flex flex-1 bg-gray-200 cursor-pointer aspect-video'>
            <Image
              src={image}
              alt={image + index}
              width={100}
              height={100}
              className='object-contain w-full h-full'
              onClick={() => setCarouselIndex(index)}
            />
          </Box>
        ))}
      </Stack>
    </Stack>
  );
};

export default Carousel;

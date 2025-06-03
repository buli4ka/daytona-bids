import React from 'react';
import Image from 'next/image';
import { AppBar, Box, Container, Stack, SvgIcon, Toolbar, Typography } from '@mui/material';
import MainLayout from '@/components/main-layout/main-layout';
import Link from 'next/link';

// import { ReactComponent as LogoIcon } from 'public/icons/daytona-logo.svg';
const AppHeader = () => {
  const a = 3;

  return (
    <AppBar position='sticky' color='inherit'>
      <MainLayout>
        <Toolbar disableGutters>
          <Link href='/'>
            <Stack direction='row' alignItems='center'>
              <Image
                src='/icons/logo.svg'
                alt='logo'
                width='100'
                height='24'
                style={{ fontSize: '14px', height: '24px', scale: 1.5 }}
              />
              <Typography variant='h6'>Daytona Bids</Typography>
            </Stack>
          </Link>
        </Toolbar>
      </MainLayout>
    </AppBar>
  );
};

export default AppHeader;

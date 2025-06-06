'use client';
import { createTheme } from '@mui/material/styles';

const theme = createTheme({
  cssVariables: true,
  palette: {
    primary: {
      main: '#1F2122',
    },
    secondary: {
      main: '#000',
    },
  },
  typography: {
    fontFamily: 'var(--font-roboto)',
    subtitle1: {
      fontSize: '14px',
      fontWeight: 700,
      lineHeight: '2',
    },
    subtitle2: {
      fontSize: '14px',
      lineHeight: '2',
    },
  },
  breakpoints: {
    values: {
      xs: 0,
      sm: 600,
      md: 960,
      lg: 1280,
      xl: 1920,
    },
  },
  // components: {
  //   MuiTypography: {
  //     variants: {
  //       span: {
  //       },
  //     },
  //   },
  // },
});

export default theme;

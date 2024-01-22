import React from 'react';
import { Typography, Box, Container, Divider, Paper, TextField, Button, useTheme } from '@mui/material';

const Nieuws = () => {
  const theme = useTheme();

  const styles = {
    container: {
      marginTop: theme.spacing(8),
      marginBottom: theme.spacing(8),
    },
    mainContent: {
      padding: theme.spacing(3),
      margin: theme.spacing(2),
      [theme.breakpoints.up('md')]: {
        padding: theme.spacing(6),
      },
    },
    header: {
      color: theme.palette.primary.main,
      textAlign: 'center',
      margin: theme.spacing(0, 0),
    },
    subheader: {
      color: theme.palette.secondary.main,
      textAlign: 'center',
      margin: theme.spacing(3, 0),
    },
    divider: {
      margin: theme.spacing(3, 0),
    },
    paragraph: {
      textAlign: 'center',
      marginBottom: theme.spacing(2),
    },
    form: {
      marginTop: theme.spacing(6),
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
      '& > *': {
        margin: theme.spacing(6),
        width: '100%',
        maxWidth: '400px', // adjust as needed
      },
    },
  };

  return (
    <Container maxWidth="md" sx={styles.container}>
      <Box component={Paper} elevation={4} sx={styles.mainContent}>
        <Typography variant="h3" component="h1" sx={styles.header}>
          Nieuws
        </Typography>
        <Divider sx={styles.divider} />
        <Typography variant="body1" sx={styles.paragraph}>
          Hier vind je het laatste nieuws van Stichting Accessibility over toegankelijkheid en inclusie. 
          Je vindt informatie over onze projecten, samenwerkingsverbanden, onderzoek en innovatie, beleid 
          en wet- en regelgeving.
        </Typography>
        <Box component="div" sx={styles.subheader}>
          <Typography variant="h4" component="h2">
            Schrijf je in voor onze nieuwsbrief
          </Typography>
          <form sx={styles.form}>
            <TextField 
              label="E-mail" 
              variant="outlined" 
              id="email" 
              name="email" 
              type="email" 
              placeholder="Jouw e-mailadres" 
            />
            <Button type="submit" variant="contained" color="primary">
              Inschrijven
            </Button>
          </form>
        </Box>
      </Box>
    </Container>
  );
};

export default Nieuws;

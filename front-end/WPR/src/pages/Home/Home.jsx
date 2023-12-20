import '../../index.css'
import React, { useState, useEffect } from 'react';
import { Container, Box, Typography, Button, Grid, Paper } from '@mui/material';
import './HomePage.scss'; // Zorg ervoor dat je een SCSS-bestand hebt met deze naam

const HomePage = () => {
  // State en effecten kunnen hier worden toegevoegd zoals nodig

  return (
    <Container maxWidth="lg" className="homePage">
      <Box className="heroSection">
        <Typography variant="h3" component="h1" gutterBottom>
          Samen met onze partners en klanten werken we aan een inclusieve samenleving die toegankelijk is voor iedereen.
        </Typography>
        <Button variant="contained" size="large" className="heroButton">
          Ontdek hoe je morgen aan de slag kunt gaan
        </Button>
      </Box>
      <Grid container spacing={4} className="infoSections">
        <Grid item xs={12} md={4}>
          <Paper className="infoPaper">
            <Typography variant="h5" component="h2">Toegankelijke digitale omgeving</Typography>
            <Typography>
              De website of app voor jouw digitale product of dienst toegankelijk maken voor iedereen.
            </Typography>
          </Paper>
        </Grid>
        <Grid item xs={12} md={4}>
          <Paper className="infoPaper">
            <Typography variant="h5" component="h2">Toegankelijke fysieke omgeving</Typography>
            <Typography>
              Alle ruimtes in en om het gebouw toegankelijk maken met drempels, geleidelijnen, verlichting en/of kleuren.
            </Typography>
          </Paper>
        </Grid>
        <Grid item xs={12} md={4}>
          <Paper className="infoPaper">
            <Typography variant="h5" component="h2">Gebruiksvriendelijke omgeving</Typography>
            <Typography>
              Vergroot de toegankelijkheid, gebruiksvriendelijkheid en bruikbaarheid met ervaringsdeskundigen.
            </Typography>
          </Paper>
        </Grid>
      </Grid>
    </Container>
  );
};

export default HomePage;



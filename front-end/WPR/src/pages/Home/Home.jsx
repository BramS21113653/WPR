import React, { useState, useEffect } from 'react';
import { Container, Box, Typography, Button, Grid, Paper, useTheme, Stack } from '@mui/material';
import AccessibleForwardIcon from '@mui/icons-material/AccessibleForward';
import DesktopAccessDisabledIcon from '@mui/icons-material/DesktopAccessDisabled';
import HearingDisabledIcon from '@mui/icons-material/HearingDisabled';
import './HomePage.scss';

const HomePage = () => {
  const theme = useTheme();

  // State and effects can be added here as needed

  return (
    <div className="main-content">
      <Container maxWidth="lg" className="homePage">
        {/* Hero Section */}
        <Box className="heroSection" sx={{
          background: `linear-gradient(45deg, ${theme.palette.primary.main}, ${theme.palette.secondary.main})`,
          borderRadius: theme.shape.borderRadius,
          color: theme.palette.primary.contrastText,
          py: theme.spacing(6),
          textAlign: 'center',
          mb: -8, // Negative margin to lift the following section up
        }}>
          <Typography variant="h2" component="h1" gutterBottom>
            Een inclusieve samenleving begint hier.
          </Typography>
          <Typography variant="h6" sx={{ mb: 4 }}>
            Ontdek hoe je toegankelijkheid integreert in elk aspect van jouw digitale en fysieke omgeving.
          </Typography>
        </Box>

        {/* Information Sections */}
        <Grid container spacing={4} className="infoSections">
          {infoCards.map((card, index) => (
            <Grid item xs={12} sm={6} md={4} key={index}>
              <Paper className="infoPaper" elevation={4} sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                py: theme.spacing(4),
                height: '100%',
                '&:hover': {
                  boxShadow: theme.shadows[12],
                },
              }}>
                <card.icon color="primary" sx={{ fontSize: 40, mb: 2 }} />
                <Typography variant="h5" component="h2">{card.title}</Typography>
                <Typography>{card.description}</Typography>
              </Paper>
            </Grid>
          ))}
        </Grid>
      </Container>
    </div>
  );
};

const infoCards = [
  {
    title: "Digitale Toegankelijkheid",
    description: "Toegankelijke websites en apps creëren die iedereen kan gebruiken, ongeacht beperking.",
    icon: AccessibleForwardIcon,
  },
  {
    title: "Fysieke Toegankelijkheid",
    description: "Ruimtes ontwerpen die toegankelijk zijn voor iedereen, met duidelijke bewegwijzering en assistieve technologieën.",
    icon: DesktopAccessDisabledIcon,
  },
  {
    title: "Inclusief Ontwerp",
    description: "Design dat rekening houdt met alle gebruikers, door inbreng van ervaringsdeskundigen.",
    icon: HearingDisabledIcon,
  },
];

export default HomePage;

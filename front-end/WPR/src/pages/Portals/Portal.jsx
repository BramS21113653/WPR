import React from 'react';
import { Typography, Grid, useTheme, Paper, CardActionArea, Link } from '@mui/material';
import { Link as RouterLink } from 'react-router-dom'; // Import the Link component from react-router-dom

const Portal = () => {
  const theme = useTheme();

  const cardStyle = {
    height: '20vh',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
    borderRadius: theme.shape.borderRadius,
    boxShadow: theme.shadows[8], // Using theme-based shadow
    transition: theme.transitions.create(['box-shadow', 'transform'], {
      duration: theme.transitions.duration.standard,
    }),
    '&:hover': {
      boxShadow: theme.shadows[12], // More pronounced shadow on hover
      transform: 'translateY(-4px)', // Slight raise effect
    },
    textDecoration: 'none',
    color: 'inherit',
  };

  return (
    <div style={{ padding: theme.spacing(3) }}>
      <Typography variant="h3" component="h1" gutterBottom>
        Portalen
      </Typography>
      <Grid container spacing={theme.spacing(2)}>
        <Grid item xs={12} sm={6} md={4}>
          <CardActionArea component={RouterLink} to="/ervaringsdeskundigen-portal" sx={cardStyle}>
            <Paper elevation={4} sx={{ height: '100%', width: '100%' }}>
              <Typography gutterBottom variant="h5" component="div">
                Ervaringsdeskundigenportal
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Toegang tot ervaringsdeskundige bronnen en informatie.
              </Typography>
            </Paper>
          </CardActionArea>
        </Grid>
        <Grid item xs={12} sm={6} md={4}>
          <CardActionArea component={RouterLink} to="/bedrijfsportal" sx={cardStyle}>
            <Paper elevation={4} sx={{ height: '100%', width: '100%' }}>
              <Typography gutterBottom variant="h5" component="div">
                Bedrijfsportal
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Bedrijfsgerelateerde documenten en tools voor medewerkers.
              </Typography>
            </Paper>
          </CardActionArea>
        </Grid>
        <Grid item xs={12} sm={6} md={4}>
          <CardActionArea component={RouterLink} to="/beheerdersportal" sx={cardStyle}>
            <Paper elevation={4} sx={{ height: '100%', width: '100%' }}>
              <Typography gutterBottom variant="h5" component="div">
                Beheerdersportal
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Beheertools en administratie voor systeembeheerders.
              </Typography>
            </Paper>
          </CardActionArea>
        </Grid>
      </Grid>
    </div>
  );
};

export default Portal;

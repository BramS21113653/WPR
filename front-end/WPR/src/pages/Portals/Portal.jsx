import React from 'react';
import { Card, CardActionArea, CardContent, Typography, Grid, useTheme, Box, Paper} from '@mui/material';

const Portal = () => {
  const theme = useTheme();

  const cardStyle = {
    height: '20vh',
    width: '100%',
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
    color: 'inherit'
  };

  return (
    <div style={{ padding: theme.spacing(3) }}>
      <Typography variant="h3" component="h1" gutterBottom>
        Portalen
      </Typography>
      <Grid container spacing={theme.spacing(2)}>
        <Grid item xs={12} sm={6} md={4}>
          <Box href="/ervaringsdeskundigen-portal" sx={cardStyle} component={Paper} elevation={4}>
            <CardActionArea sx={{ height: '100%' }}>
              <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                  Ervaringsdeskundigenportal
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Toegang tot ervaringsdeskundige bronnen en informatie.
                </Typography>
              </CardContent>
            </CardActionArea>
          </Box>
        </Grid>
        <Grid item xs={12} sm={6} md={4}>
          <Box component={Paper} elevation={4} href="/bedrijfsportal" sx={cardStyle}>
            <CardActionArea sx={{ height: '100%' }}>
              <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                  Bedrijfsportal
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Bedrijfsgerelateerde documenten en tools voor medewerkers.
                </Typography>
              </CardContent>
            </CardActionArea>
          </Box>
        </Grid>
        <Grid item xs={12} sm={6} md={4}>
          <Box component={Paper} elevation={4} href="/beheerdersportal" sx={cardStyle}>
            <CardActionArea sx={{ height: '100%' }}>
              <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                  Beheerdersportal
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Beheertools en administratie voor systeembeheerders.
                </Typography>
              </CardContent>
            </CardActionArea>
          </Box>
        </Grid>
      </Grid>
    </div>
  );
};

export default Portal;

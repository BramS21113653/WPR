import React from 'react';
import { Typography, List, ListItem, Button } from '@mui/material';

const GebruikersBeheer = () => {
  // Voorbeeld data
  const gebruikers = ['Gebruiker 1', 'Gebruiker 2'];

  return (
    <div>
      <Typography variant="h6">Gebruikers Beheer</Typography>
      <List>
        {gebruikers.map((gebruiker, index) => (
          <ListItem key={index}>
            {gebruiker}
            {/* Knoppen voor gebruikersbeheer, zoals bewerken of verwijderen */}
            <Button variant="contained" color="primary">Bewerken</Button>
          </ListItem>
        ))}
      </List>
    </div>
  );
};

export default GebruikersBeheer;

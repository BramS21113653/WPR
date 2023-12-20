import React from 'react';
import { Typography, List, ListItem, Button } from '@mui/material';

const OnderzoekenBeheer = () => {
  // Voorbeeld data
  const onderzoeken = ['Onderzoek A', 'Onderzoek B'];

  return (
    <div>
      <Typography variant="h6">Onderzoeken Beheer</Typography>
      <List>
        {onderzoeken.map((onderzoek, index) => (
          <ListItem key={index}>
            {onderzoek}
            {/* Knoppen voor onderzoeksbeheer, zoals bewerken of verwijderen */}
            <Button variant="contained" color="primary">Bewerken</Button>
          </ListItem>
        ))}
      </List>
    </div>
  );
};

export default OnderzoekenBeheer;

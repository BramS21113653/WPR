import React from 'react';
import { Typography, List, ListItem } from '@mui/material';

const OnderzoekenOverzicht = () => {
  const onderzoeken = ['Onderzoek 1', 'Onderzoek 2']; // Voorbeeld data

  return (
    <div>
      <Typography variant="h6">Beschikbare Onderzoeken</Typography>
      <List>
        {onderzoeken.map((onderzoek, index) => (
          <ListItem key={index}>{onderzoek}</ListItem>
        ))}
      </List>
    </div>
  );
};

export default OnderzoekenOverzicht;

import React, { useState, useEffect } from 'react';
import { API_BASE_URL } from '../../apiConfig';
import { Card, CardContent, CardActions, Typography, Button, Grid, CircularProgress } from '@mui/material';

const Onderzoeken = () => {
  const [onderzoeken, setOnderzoeken] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchResearches = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/Research`);
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setOnderzoeken(data);
      } catch (error) {
        console.error("Error fetching data: ", error);
      } finally {
        setLoading(false);
      }
    };

    fetchResearches();
  }, []);

  if (loading) {
    return (
      <Grid container justifyContent="center" alignItems="center" style={{ height: '100vh' }}>
        <CircularProgress />
      </Grid>
    );
  }

  return (
    <Grid container spacing={4} style={{ padding: '20px' }}>
      {onderzoeken.map((onderzoek) => (
        <Grid item xs={12} sm={6} md={4} key={onderzoek.id}>
          <Card>
            <CardContent>
              <Typography variant="h5" component="h2">
                {onderzoek.title}
              </Typography>
              <Typography variant="body2" color="textSecondary" component="p">
                {onderzoek.description}
              </Typography>
              {/* Additional details can be placed here */}
            </CardContent>
            <CardActions>
              <Button size="small" color="primary">
                Meer Lezen
              </Button>
              <Button size="small" color="primary">
                Deelnemen
              </Button>
            </CardActions>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
};

export default Onderzoeken;

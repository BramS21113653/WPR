import React, { useState, useEffect } from 'react';
import { API_BASE_URL } from '../../apiConfig';
import { Card, CardContent, CardActions, Typography, Button, Grid, CircularProgress, Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions } from '@mui/material';

const Onderzoeken = () => {
  const [onderzoeken, setOnderzoeken] = useState([]);
  const [selectedOnderzoek, setSelectedOnderzoek] = useState({});
  const [openDialog, setOpenDialog] = useState(false);
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

  const handleOpenDialog = (onderzoek) => {
    setSelectedOnderzoek(onderzoek);
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
  };

  if (loading) {
    return (
      <Grid container justifyContent="center" alignItems="center" style={{ height: '100vh' }}>
        <CircularProgress />
      </Grid>
    );
  }

  return (
    <div className="main-content">
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
                <Typography variant="body2" color="textSecondary">
                  Beloning: {onderzoek.reward}
                </Typography>
              </CardContent>
              <CardActions>
                <Button size="small" color="primary" onClick={() => handleOpenDialog(onderzoek)}>
                  Meer Lezen
                </Button>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>

      <Dialog
        open={openDialog}
        onClose={handleCloseDialog}
        aria-labelledby="onderzoek-dialog-title"
        aria-describedby="onderzoek-dialog-description"
      >
        <DialogTitle id="onderzoek-dialog-title">{selectedOnderzoek.title}</DialogTitle>
        <DialogContent>
          <DialogContentText id="onderzoek-dialog-description">
            {selectedOnderzoek.description}
            <p>Beloning: {selectedOnderzoek.reward}</p>
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog} color="primary">
            Sluiten
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default Onderzoeken;

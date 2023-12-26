import React, { useState, useEffect } from 'react';
import { Typography, TextField, Button, Checkbox, FormControlLabel } from '@mui/material';

const Profile = () => {
  const [profileData, setProfileData] = useState({
    voornaam: '',
    achternaam: '',
    postcode: '',
    email: '',
    telefoonnummer: '',
    typeBeperking: '',
    hulpmiddelen: '',
    aandoening: '',
    onderzoeksvoorkeuren: '',
    benaderingsvoorkeur: '',
    toestemmingCommercieel: false,
    beschikbaarheid: '',
    ouderInfo: '',
  });

  useEffect(() => {
    // Your fetch logic here to load the user's profile data
    // Make sure you handle the authorization header correctly
    const token = localStorage.getItem('jwtToken');
    const fetchProfileData = async () => {
      try {
        const response = await fetch(`https://localhost:5001/PanelMember`, {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        });
        if (!response.ok) {
          throw new Error(`Error ${response.status}: ${await response.text()}`);
        }
        const data = await response.json();
        setProfileData(data);
      } catch (error) {
        console.error('Error fetching profile data:', error);
      }
    };

    fetchProfileData();
  }, []);

  const handleChange = (event) => {
    const { name, value, checked, type } = event.target;
    setProfileData((prevData) => ({
      ...prevData,
      [name]: type === 'checkbox' ? checked : value,
    }));
  };

  const handleUpdate = async (event) => {
    event.preventDefault(); // Prevent default form submission behavior
    // Your update logic here
    // Make sure you handle the authorization header correctly
    const token = localStorage.getItem('jwtToken');
    try {
      const response = await fetch(`https://localhost:5001/PanelMember/${profileData.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
        },
        body: JSON.stringify(profileData),
      });

      if (!response.ok) {
        throw new Error('Update failed');
      }
      alert('Profile updated successfully');
    } catch (error) {
      console.error('Error updating profile:', error);
    }
  };

  const handleDelete = async () => {
    // Your delete logic here
    // Make sure you handle the authorization header correctly
    const token = localStorage.getItem('jwtToken');
    try {
      const response = await fetch(`https://localhost:5001/PanelMember/${profileData.id}`, {
        method: 'DELETE',
        headers: {
          'Authorization': `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        throw new Error('Delete failed');
      }
      alert('Profile deleted successfully');
      // Handle additional logic after deletion, like redirecting
    } catch (error) {
      console.error('Error deleting profile:', error);
    }
  };

  return (
    <div>
      <Typography variant="h6">Mijn Profiel</Typography>
      <form onSubmit={handleUpdate}>
        <TextField
          label="Voornaam"
          variant="outlined"
          name="voornaam"
          value={profileData.voornaam}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Achternaam"
          variant="outlined"
          name="achternaam"
          value={profileData.achternaam}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Postcode"
          variant="outlined"
          name="postcode"
          value={profileData.postcode}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Email"
          variant="outlined"
          name="email"
          value={profileData.email}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Telefoonnummer"
          variant="outlined"
          name="telefoonnummer"
          value={profileData.telefoonnummer}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Type beperking"
          variant="outlined"
          name="typeBeperking"
          value={profileData.typeBeperking}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Hulpmiddelen"
          variant="outlined"
          name="hulpmiddelen"
          value={profileData.hulpmiddelen}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Aandoening"
          variant="outlined"
          name="aandoening"
          value={profileData.aandoening}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Onderzoeksvoorkeuren"
          variant="outlined"
          name="onderzoeksvoorkeuren"
          value={profileData.onderzoeksvoorkeuren}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Benaderingsvoorkeur"
          variant="outlined"
          name="benaderingsvoorkeur"
          value={profileData.benaderingsvoorkeur}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <FormControlLabel
          control={
            <Checkbox
              checked={profileData.toestemmingCommercieel}
              onChange={handleChange}
              name="toestemmingCommercieel"
            />
          }
          label="Toestemming voor commercieel benaderen"
        />
        <TextField
          label="Beschikbaarheid"
          variant="outlined"
          name="beschikbaarheid"
          value={profileData.beschikbaarheid}
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Informatie van ouder/voogd"
          variant="outlined"
          name="ouderInfo"
          value={profileData.ouderInfo}
          onChange={handleChange}
          margin="normal"
          fullWidth
          multiline
          rows={4}
        />
        <Button variant="contained" color="primary" type="submit">
          Bijwerken
        </Button>
        <Button variant="contained" color="secondary" onClick={handleDelete}>
          Verwijderen
        </Button>
      </form>
    </div>
  );  
};

export default Profile;

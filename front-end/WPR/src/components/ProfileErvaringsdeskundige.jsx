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
    // Fetch logic here to load the user's profile data
    const token = localStorage.getItem('jwtToken');
    const fetchProfileData = async () => {
      try {
        const response = await fetch(`https://localhost:5001/PanelMember/profile`, {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        });
        if (!response.ok) {
          throw new Error(`Error ${response.status}: ${await response.text()}`);
        }
        const data = await response.json();
    
        // Map the properties from the response to your state object
        setProfileData({
          voornaam: data.firstName, // Map 'FirstName' from the response to 'voornaam' in the state
          achternaam: data.lastName, // Map 'LastName' from the response to 'achternaam' in the state
          postcode: data.postCode, // Map 'PostCode' from the response to 'postcode' in the state
          email: data.email, // Email should match directly
          telefoonnummer: data.phoneNumber, // Map 'PhoneNumber' from the response to 'telefoonnummer' in the state
          typeBeperking: data.disabilityType, // Map 'DisabilityType' from the response to 'typeBeperking' in the state
          hulpmiddelen: data.usedAssistiveTools, // Map 'UsedAssistiveTools' from the response to 'hulpmiddelen' in the state
          aandoening: data.conditionDisease, // Map 'ConditionDisease' from the response to 'aandoening' in the state
          onderzoeksvoorkeuren: data.preferredResearchTypes, // Map 'PreferredResearchTypes' from the response to 'onderzoeksvoorkeuren' in the state
          benaderingsvoorkeur: data.preferredApproach, // Map 'PreferredApproach' from the response to 'benaderingsvoorkeur' in the state
          toestemmingCommercieel: data.consentForCommercialApproach, // Map 'ConsentForCommercialApproach' from the response to 'toestemmingCommercieel' in the state
          beschikbaarheid: data.availabilityTimes, // Map 'AvailabilityTimes' from the response to 'beschikbaarheid' in the state
          ouderInfo: data.relationToPanelMember, // Map 'RelationToPanelMember' from the response to 'ouderInfo' in the state
        });
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

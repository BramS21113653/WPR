import React, { useState, useEffect, useContext } from 'react';
import { Typography, TextField, Button, Checkbox, FormControlLabel, 
         Card, CardContent, CardActions, Grid, 
         Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions } from '@mui/material';
import { API_BASE_URL } from './../../apiConfig';
import ChatComponent from './ChatComponent';
import { UserContext } from './../UserContext';

const ProfileErvaringsdeskundige = () => {
  console.log('ProfielComponent is rendering'); // Debug log

  const [profileData, setProfileData] = useState({
    id: '', 
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

  const [researches, setResearches] = useState([]);
  const [likedResearches, setLikedResearches] = useState(new Set());
  const [showChat, setShowChat] = useState(false); // State om te bepalen of de chat zichtbaar moet zijn
  const [selectedResearchId, setSelectedResearchId] = useState(null); // State voor het geselecteerde research ID voor de chat
  const [selectedBusinessUserId, setSelectedBusinessUserId] = useState(null); // State voor het geselecteerde research ID voor de chat
  const { handleLogout } = useContext(UserContext); // Now useContext is defined and can be used here
  const [isProfileExpanded, setIsProfileExpanded] = useState(false);
  const [selectedResearch, setSelectedResearch] = useState({});
  const [openDialog, setOpenDialog] = useState(false);

  const handleOpenChat = (researchId, businessUserId) => {
    console.log('Opening chat for:', researchId, businessUserId); // Debug log
    setSelectedResearchId(researchId);
    setSelectedBusinessUserId(businessUserId);
    setShowChat(true);
  };  

  const handleCloseChat = () => {
    setShowChat(false);
    setSelectedResearchId(null);
    setSelectedBusinessUserId(null);
  };

  const toggleProfile = () => {
    setIsProfileExpanded(!isProfileExpanded);
  };  

  const handleOpenDialog = (research) => {
    setSelectedResearch(research);
    setOpenDialog(true);
  };
  
  const handleCloseDialog = () => {
    setOpenDialog(false);
  };

  useEffect(() => {
    // Fetch logic here to load the user's profile data
    const token = localStorage.getItem('jwtToken');
    const fetchProfileData = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/PanelMember/profile`, {
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
          id: data.id,
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

    const fetchResearches = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/Research`, {
          headers: { 'Authorization': `Bearer ${token}` },
        });
        if (!response.ok) {
          throw new Error(`Error: ${response.status}`);
        }
        const data = await response.json();
        setResearches(data);
      } catch (error) {
        console.error('Error fetching researches:', error);
      }
    };
  
      fetchResearches();
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
      const response = await fetch(`${API_BASE_URL}/PanelMember/${profileData.id}`, {
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
      const response = await fetch(`${API_BASE_URL}/PanelMember/${profileData.id}`, {
        method: 'DELETE',
        headers: {
          'Authorization': `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        throw new Error('Delete failed');
      }
      alert('Profile deleted successfully');
      handleLogout();
    } catch (error) {
      console.error('Error deleting profile:', error);
    }
  };

  const handleLikeResearch = async (researchId) => {
    const token = localStorage.getItem('jwtToken');
    try {
      const response = await fetch(`${API_BASE_URL}/Research/like/${researchId}`, {
        method: 'POST',
        headers: { 'Authorization': `Bearer ${token}` },
      });
      if (!response.ok) {
        throw new Error('Failed to like research');
      }
      setLikedResearches(new Set([...likedResearches, researchId]));
    } catch (error) {
      console.error('Error liking research:', error);
    }
  };

  const handleUnlikeResearch = async (researchId) => {
    const token = localStorage.getItem('jwtToken');
    try {
      const response = await fetch(`${API_BASE_URL}/Research/unlike/${researchId}`, {
        method: 'POST',
        headers: { 'Authorization': `Bearer ${token}` },
      });
      if (!response.ok) {
        throw new Error('Failed to unlike research');
      }
      setLikedResearches(new Set([...likedResearches].filter(id => id !== researchId)));
    } catch (error) {
      console.error('Error unliking research:', error);
    }
  };

  return (
    <div style={{ textAlign: 'left' }}>
    <Typography variant="h6" onClick={toggleProfile} style={{ cursor: 'pointer'}}>
        Mijn Profiel {isProfileExpanded ? '▲' : '▼'}
      </Typography>
  
      {isProfileExpanded && (
        <form onSubmit={handleUpdate}>
  <TextField
            label="Voornaam"
            variant="outlined"
            name="voornaam"
            value={profileData.voornaam || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Achternaam"
            variant="outlined"
            name="achternaam"
            value={profileData.achternaam || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Postcode"
            variant="outlined"
            name="postcode"
            value={profileData.postcode || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Email"
            variant="outlined"
            name="email"
            value={profileData.email || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Telefoonnummer"
            variant="outlined"
            name="telefoonnummer"
            value={profileData.telefoonnummer || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Type beperking"
            variant="outlined"
            name="typeBeperking"
            value={profileData.typeBeperking || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Hulpmiddelen"
            variant="outlined"
            name="hulpmiddelen"
            value={profileData.hulpmiddelen || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Aandoening"
            variant="outlined"
            name="aandoening"
            value={profileData.aandoening || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Onderzoeksvoorkeuren"
            variant="outlined"
            name="onderzoeksvoorkeuren"
            value={profileData.onderzoeksvoorkeuren || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Benaderingsvoorkeur"
            variant="outlined"
            name="benaderingsvoorkeur"
            value={profileData.benaderingsvoorkeur || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <FormControlLabel
            control={
              <Checkbox
                checked={profileData.toestemmingCommercieel || false} 
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
            value={profileData.beschikbaarheid || ''} 
            onChange={handleChange}
            margin="normal"
            fullWidth
          />
          <TextField
            label="Informatie van ouder/voogd"
            variant="outlined"
            name="ouderInfo"
            value={profileData.ouderInfo || ''} 
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
      )}
  
  <Typography variant="h6" style={{ marginTop: '20px' }}>
        Beschikbare Onderzoeken
      </Typography>
      <Grid container spacing={4} style={{ padding: '20px' }}>
        {researches.map(research => (
          <Grid item xs={12} sm={6} md={4} key={research.id}>
            <Card>
              <CardContent>
                <Typography variant="h5">{research.title}</Typography>
                <Typography variant="body2">{research.description}</Typography>
                <Typography variant="body2">Beloning: {research.reward}</Typography>
              </CardContent>
              <CardActions>
                <Button size="small" color="primary" onClick={() => handleOpenDialog(research)}>
                  Meer Lezen
                </Button>
                {/* Chat initiation button */}
                <Button size="small" color="secondary" onClick={() => handleOpenChat(research.id, research.conductorId)}>
                  Chat
                </Button>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>

      {/* Dialog for displaying selected research details */}
    {/* Dialog for displaying selected research details */}
    <Dialog open={openDialog} onClose={handleCloseDialog} aria-labelledby="dialog-title" aria-describedby="dialog-description">
      <DialogTitle id="dialog-title">{selectedResearch.title}</DialogTitle>
      <DialogContent>
        <DialogContentText id="dialog-description">
          {selectedResearch.description}
          <p>Beloning: {selectedResearch.reward}</p>
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleCloseDialog} color="primary">
          Sluiten
        </Button>
      </DialogActions>
    </Dialog>
      {/* Existing chat component */}
      {showChat && (
        <ChatComponent
          researchId={selectedResearchId}
          businessUserId={selectedBusinessUserId}
          handleClose={handleCloseChat}
        />
      )}
    </div>
  );  
};

export default ProfileErvaringsdeskundige;


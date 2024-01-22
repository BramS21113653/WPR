import React, { useState, useEffect, useContext } from 'react';
import { Typography, TextField, Button, Select, MenuItem, FormControl, InputLabel, Grid, Card, CardContent } from '@mui/material';
import { API_BASE_URL } from './../../apiConfig';
import { UserContext } from './../UserContext';
import Collapse from '@mui/material/Collapse';

const BusinessUserProfile = () => {
  const [businessUserData, setBusinessUserData] = useState({
    id: '',
    firstName: '',
    lastName: '',
    companyName: '',
    location: '',
    websiteURL: '',
    contactInfo: '',
  });
  const [researches, setResearches] = useState([]);
  const [researchMessages, setResearchMessages] = useState({});
  const [isProfileExpanded, setIsProfileExpanded] = useState(false);
  const [panelMemberInfo, setPanelMemberInfo] = useState({}); 

  const { handleLogout } = useContext(UserContext);

    const fetchBusinessUserData = async () => {
      const token = localStorage.getItem('jwtToken');
      try {
        const response = await fetch(`${API_BASE_URL}/BusinessUser/profile`, {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        });
        if (!response.ok) {
          throw new Error(`Error ${response.status}: ${await response.text()}`);
        }
        const data = await response.json();
        setBusinessUserData(data);
    
        // Call fetchResearches after setting the business user data
        fetchResearches(data.id);
      } catch (error) {
        console.error('Error fetching business user data:', error);
      }
    };

    const fetchResearchMessages = async (researchId) => {
      try {
        const response = await fetch(`${API_BASE_URL}/Chat/getMessagesByResearch?researchId=${researchId}`, {
          headers: { 'Authorization': `Bearer ${localStorage.getItem('jwtToken')}` },
        });
        if (!response.ok) {
          throw new Error('Kan berichten voor dit onderzoek niet ophalen');
        }
        const messages = await response.json();
        setResearchMessages(prevMessages => ({ ...prevMessages, [researchId]: messages }));
      } catch (error) {
        console.error('Error fetching messages:', error);
      }
    }; 

  const fetchPanelMemberInfo = async () => {
    try {
      const response = await fetch(`${API_BASE_URL}/PanelMember/all`, {
        headers: { 'Authorization': `Bearer ${localStorage.getItem('jwtToken')}` },
      });
      if (!response.ok) {
        throw new Error('Kan informatie van panelleden niet ophalen');
      }
      const panelMembers = await response.json();
      const panelMemberMap = {};
      panelMembers.forEach(member => {
        panelMemberMap[member.id] = member.firstName + " " + member.lastName;
      });
      setPanelMemberInfo(panelMemberMap);
    } catch (error) {
      console.error('Error fetching panel member info:', error);
    }
  };

    const handleUpdate = async () => {
      const token = localStorage.getItem('jwtToken');
      const patchOperations = [
          { op: "replace", path: "/firstName", value: businessUserData.firstName },
          { op: "replace", path: "/lastName", value: businessUserData.lastName },
          { op: "replace", path: "/companyName", value: businessUserData.companyName },
          { op: "replace", path: "/location", value: businessUserData.location },
          { op: "replace", path: "/websiteURL", value: businessUserData.websiteURL },
          { op: "replace", path: "/contactInfo", value: businessUserData.contactInfo },
          // Add other fields as necessary
      ];
  
      try {
          const response = await fetch(`${API_BASE_URL}/BusinessUser/${businessUserData.id}`, {
              method: 'PATCH',
              headers: {
                  'Content-Type': 'application/json-patch+json',
                  'Authorization': `Bearer ${token}`,
              },
              body: JSON.stringify(patchOperations),
          });
  
          if (!response.ok) {
              throw new Error('Update failed: ' + await response.text());
          }
          alert('Profile updated successfully');
      } catch (error) {
          console.error('Error updating profile:', error);
      }
  };
  
  const handleDelete = async () => {
    const token = localStorage.getItem('jwtToken');
    try {
        const response = await fetch(`${API_BASE_URL}/BusinessUser/${businessUserData.id}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error('Delete failed: ' + await response.text());
        }
        alert('Profile deleted successfully');
        handleLogout();
        // navigate('/'); // Redirect to the homepage after successful login
        // localStorage.removeItem('jwtToken');
      } catch (error) {
        console.error('Error deleting profile:', error);
    }
};

const fetchResearches = async (conductorId) => {
  const token = localStorage.getItem('jwtToken');
  try {
    const response = await fetch(`${API_BASE_URL}/Research/ByConductor?conductorId=${conductorId}`, {
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error(`Error ${response.status}: ${await response.text()}`);
    }

    const data = await response.json();
    setResearches(data);
  } catch (error) {
    console.error('Error fetching researches:', error);
  }
};

  const toggleProfile = () => {
    setIsProfileExpanded(!isProfileExpanded); // Toggle profile expansion
  };

  useEffect(() => {
    fetchBusinessUserData();
    fetchPanelMemberInfo();
  }, []);

  useEffect(() => {
    if (businessUserData && businessUserData.id) {
      fetchResearches(businessUserData.id);
    }
  }, [businessUserData]);

  useEffect(() => {
    researches.forEach(research => {
      fetchResearchMessages(research.id);
    });
  }, [researches]);

  const handleChange = (event) => {
    const { name, value, checked, type } = event.target;
    setBusinessUserData((prevData) => ({
      ...prevData,
      [name]: type === 'checkbox' ? checked : value,
    }));
  };

  return (
    <div>
      <Typography variant="h6">Berichten/feedback van ervaringsdeskundigen per onderzoek</Typography>
      <div>
      <Grid container spacing={2}>
        {researches.map((research) => (
          <Grid item xs={12} sm={6} md={4} key={research.id}>
            <Card>
              <CardContent>
                <Typography variant="h6">{research.title}</Typography>
                {researchMessages[research.id] ? (
                  <div>
                    {researchMessages[research.id].map((msg, index) => (
                      <p key={index}>
                        {panelMemberInfo[msg.senderId] && <strong>{panelMemberInfo[msg.senderId]}:</strong>} {msg.content}
                      </p>
                    ))}
                  </div>
                ) : (
                  <Typography>Berichten worden geladen...</Typography>
                )}
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>
          <br></br>
          <br></br>
   <Button variant="contained" color="primary" onClick={toggleProfile}>
     {isProfileExpanded ? 'Verberg Profiel' : 'Toon en bewerk eventueel je profiel'}
   </Button>
   <Collapse in={isProfileExpanded}>
      <Typography variant="h6">Bedrijfsprofiel</Typography>
      <form>
        <TextField
          label="Voornaam"
          variant="outlined"
          name="firstName"
          value={businessUserData.firstName || ''} 
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Achternaam"
          variant="outlined"
          name="lastName"
          value={businessUserData.lastName || ''} 
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Bedrijfsnaam"
          variant="outlined"
          name="companyName"
          value={businessUserData.companyName || ''} 
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Locatie"
          variant="outlined"
          name="location"
          value={businessUserData.location || ''} 
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Website URL"
          variant="outlined"
          name="websiteURL"
          value={businessUserData.websiteURL || ''} 
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <TextField
          label="Contactinformatie"
          variant="outlined"
          name="contactInfo"
          value={businessUserData.contactInfo || ''} 
          onChange={handleChange}
          margin="normal"
          fullWidth
        />
        <Button variant="contained" color="primary" onClick={handleUpdate}>
          Bijwerken
        </Button>
        <Button variant="contained" color="secondary" onClick={handleDelete}>
          Verwijderen
        </Button>
        </form>
      </Collapse>
      </div>
    </div>
  );
};

export default BusinessUserProfile;

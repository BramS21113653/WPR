import React, { useState, useEffect, useContext } from 'react';
import { Typography, TextField, Button, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
import { API_BASE_URL } from './../../apiConfig';
import { UserContext } from './../UserContext';

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

    // const navigate = useNavigate();
    const { handleLogout } = useContext(UserContext); // Correct usage of useContext

    const [showChat, setShowChat] = useState(false);
    const [activeChat, setActiveChat] = useState(null);
    const [messages, setMessages] = useState([]);

    const [researches, setResearches] = useState([]);
    const [selectedResearch, setSelectedResearch] = useState('');
    const [panelMembers, setPanelMembers] = useState([]);
    const [selectedPanelMember, setSelectedPanelMember] = useState('');

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
      } catch (error) {
        console.error('Error fetching business user data:', error);
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

const handleOpenChat = async (panelMemberId) => {
  setShowChat(true);
  setActiveChat({ panelMemberId });
};

const handleSendMessage = async (messageContent) => {
  const message = {
      content: messageContent,
      timestamp: new Date(),
  };
  setMessages([...messages, message]);
};

const handleCloseChat = () => {
  setShowChat(false);
  setActiveChat(null);
  setMessages([]);
};

    // Method to fetch researches
    const fetchResearches = async () => {
      const token = localStorage.getItem('jwtToken'); // Adjust based on how you store tokens
      try {
          const response = await fetch(`${API_BASE_URL}/api/researches`, {
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
          setResearches(data); // Assuming 'data' is the array of researches
      } catch (error) {
          console.error('Error fetching researches:', error);
      }
  };
  
  const fetchPanelMembers = async (researchId) => {
    const token = localStorage.getItem('jwtToken'); // Adjust based on your token storage
    try {
        const response = await fetch(`${API_BASE_URL}/api/researches/${researchId}/panelmembers`, {
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
        setPanelMembers(data); // Assuming 'data' is the array of panel members
    } catch (error) {
        console.error('Error fetching panel members:', error);
    }
};

  // Handle change for research select
  const handleResearchChange = (event) => {
      const researchId = event.target.value;
      setSelectedResearch(researchId);
      fetchPanelMembers(researchId);
  };

  // Handle change for panel member select
  const handlePanelMemberChange = (event) => {
      setSelectedPanelMember(event.target.value);
  };

  const handleOpenChatButtonClick = () => {
    if (selectedPanelMember) {
        setShowChat(true);
        setActiveChat({ panelMemberId: selectedPanelMember });
        // Fetch existing chat messages if necessary
    }
};

  useEffect(() => {
    fetchResearches();
  }, []);

  const handleChange = (event) => {
    const { name, value, checked, type } = event.target;
    setBusinessUserData((prevData) => ({
      ...prevData,
      [name]: type === 'checkbox' ? checked : value,
    }));
  };

  // UI-rendering met TextFields voor elk veld in businessUserData
  // en knoppen voor bijwerken en verwijderen

  return (
    <div>
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
        <br></br>
        <br></br>
        <Typography variant="h6">Chat with panelmembers</Typography>
        <Typography variant="h6">not working yet...</Typography>
          <div>
            {/* UI for Chat */}
            <FormControl fullWidth>
              <InputLabel>Research</InputLabel>
              <Select
                  value={selectedResearch}
                  onChange={handleResearchChange}
              >
                  {researches.map((research) => (
                      <MenuItem key={research.id} value={research.id}>{research.title}</MenuItem>
                  ))}
              </Select>
          </FormControl>

          <FormControl fullWidth>
              <InputLabel>Panel Member</InputLabel>
              <Select
                  value={selectedPanelMember}
                  onChange={handlePanelMemberChange}
              >
                  {panelMembers.map((member) => (
                      <MenuItem key={member.id} value={member.id}>{member.name}</MenuItem>
                  ))}
              </Select>
          </FormControl>

          <Button variant="outlined" onClick={handleOpenChatButtonClick}>Open Chat</Button>
        </div>
      </form>
    </div>
  );
};

export default BusinessUserProfile;

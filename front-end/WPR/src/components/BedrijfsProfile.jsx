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

    // const navigate = useNavigate();
    const { handleLogout } = useContext(UserContext); // Correct usage of useContext

    const [showChat, setShowChat] = useState(false);
    const [activeChat, setActiveChat] = useState(null);
    const [messages, setMessages] = useState([]);

    const [researches, setResearches] = useState([]);
    const [selectedResearch, setSelectedResearch] = useState('');
    const [panelMembers, setPanelMembers] = useState([]);
    const [selectedPanelMember, setSelectedPanelMember] = useState('');
    const [isProfileExpanded, setIsProfileExpanded] = useState(false); // State for profile expansion
    const [chats, setChats] = useState([]);
    const [activePanelMembers, setActivePanelMembers] = useState([]); // Bevat panelmembers met actieve chats
    const [panelMembersInfo, setPanelMembersInfo] = useState([]);
    const [selectedPanelMemberForResearch, setSelectedPanelMemberForResearch] = useState({});
    const [panelMembersInfoByResearch, setPanelMembersInfoByResearch] = useState({});

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

    const fetchPanelMembersForAllResearches = async () => {
      const token = localStorage.getItem('jwtToken');
      try {
        await Promise.all(researches.map(async (research) => {
          const response = await fetch(`${API_BASE_URL}/Chat/getChatsByResearch?researchId=${research.id}`, {
            headers: { 'Authorization': `Bearer ${token}` },
          });
  
          if (!response.ok) throw new Error(`Error: ${await response.text()}`);
          const chatData = await response.json();
          
          const panelMemberIds = new Set(
            chatData.flatMap(chat => 
              chat.messages.map(message => message.senderId)
            ).filter(id => id && typeof id === 'string')
          );
  
          const panelMembersInfoData = await Promise.all([...panelMemberIds].map(id => 
            fetch(`${API_BASE_URL}/PanelMember/${id}`, {
              headers: { 'Authorization': `Bearer ${token}` },
            }).then(res => res.ok ? res.json() : null)
          ));
  
          setPanelMembersInfoByResearch(prevState => ({
            ...prevState,
            [research.id]: panelMembersInfoData.filter(info => info)
          }));
        }));
      } catch (error) {
        console.error('Error fetching panel members for all researches:', error);
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

const openChatWithPanelMember = async (researchId, panelMemberId) => {
  setActiveChat({ researchId, panelMemberId });
  setShowChat(true);
  // U kunt hier ook berichten voor deze chat ophalen indien nodig
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
    fetchChatsForResearch(researchId);
  };

  const handlePanelMemberChange = (event) => {
    const panelMemberId = event.target.value;
    setSelectedPanelMember(panelMemberId);

    // Ensure that both panelMemberId and selectedResearch are valid before fetching chats
    if (panelMemberId && selectedResearch) {
        fetchChatsForResearch(selectedResearch);
    }
};

// nieuw
const handlePanelMemberChangeForResearch = (researchId, panelMemberId) => {
  setSelectedPanelMemberForResearch(prevState => ({
    ...prevState,
    [researchId]: panelMemberId,
  }));
};

// nieuw
const openChatForResearch = (researchId) => {
  const panelMemberId = selectedPanelMemberForResearch[researchId];
  if (panelMemberId) {
    setShowChat(true);
    setActiveChat({ panelMemberId });
    // Fetch existing chat messages if necessary
  }
};

  const handleOpenChatButtonClick = () => {
    if (selectedPanelMember) {
        setShowChat(true);
        setActiveChat({ panelMemberId: selectedPanelMember });
        // Fetch existing chat messages if necessary
    }
};


  const toggleProfile = () => {
    setIsProfileExpanded(!isProfileExpanded); // Toggle profile expansion
  };

  useEffect(() => {
    fetchBusinessUserData();
  }, []);
  
  useEffect(() => {
    if (businessUserData && businessUserData.id) {
      fetchResearches(businessUserData.id);
    }
  }, [businessUserData]);  

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
        <Typography variant="h6">Berichten/feedback van ervaringsdeskundigen per onderzoek</Typography>
          <div>
      {/* Grid Layout for Researches */}
      <Grid container spacing={2}>
        {researches.map((research) => (
          <Grid item xs={12} sm={6} md={4} key={research.id}>
            <Card>
              <CardContent>
                <Typography variant="h6">{research.title}</Typography>
                {panelMembersInfoByResearch[research.id] ? (
                  <FormControl fullWidth>
                    <InputLabel>Berichten</InputLabel>
                    <Select
                      value={selectedPanelMemberForResearch[research.id] || ''}
                      onChange={(event) => handlePanelMemberChangeForResearch(research.id, event.target.value)}
                    >
                      {panelMembersInfoByResearch[research.id].map((member) => (
                        <MenuItem key={member.id} value={member.id}>
                          {member.firstName} {member.lastName}
                        </MenuItem>
                      ))}
                    </Select>
                    <Button
                      variant="contained"
                      color="primary"
                      onClick={() => openChatForResearch(research.id)}
                      style={{ marginTop: '10px' }}
                    >
                      Open Chat
                    </Button>
                  </FormControl>
                ) : (
                  <Typography>Loading panel members...</Typography>
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

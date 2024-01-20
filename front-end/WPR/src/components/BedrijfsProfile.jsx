import React, { useState, useEffect, useContext } from 'react';
import { Typography, TextField, Button, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
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

    const fetchChatsForResearch = async (researchId) => {
      const token = localStorage.getItem('jwtToken');
      try {
        const response = await fetch(`${API_BASE_URL}/Chat/getChatsByResearch?researchId=${researchId}`, {
          headers: { 'Authorization': `Bearer ${token}` },
        });
     
        if (!response.ok) throw new Error(`Error ${response.status}: ${await response.text()}`);
     
        const chatData = await response.json();
        console.log('Chat Data:', chatData); // Log the chat data
     
        const validSenderIds = new Set(
          chatData.flatMap(chat => 
            chat.messages.map(message => message.senderId)
          ).filter(id => id && typeof id === 'string')
        );
     
        console.log('Valid Sender IDs:', validSenderIds); // Log the filtered IDs
     
        const panelMembersInfoData = await Promise.all([...validSenderIds].map(id => 
          fetch(`${API_BASE_URL}/PanelMember/${id}`, {
            headers: { 'Authorization': `Bearer ${token}` },
          }).then(res => res.ok ? res.json() : null)
        ));
     
        console.log('Panel Members Info:', panelMembersInfoData); // Log the panel member info
        setPanelMembersInfo(panelMembersInfoData.filter(info => info));
      } catch (error) {
        console.error('Error fetching chats:', error);
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
        <Typography variant="h6">Chat with panelmembers</Typography>
          <div>
            {/* UI for Chat */}
            <FormControl fullWidth>
      <InputLabel>Onderzoek</InputLabel>
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
        {panelMembersInfo.map((member) => (
            <MenuItem key={member.id} value={member.id}>{member.firstName} {member.lastName}</MenuItem>
        ))}
    </Select>
</FormControl>
              <div>
            {showChat && chats
              .filter(chat => chat.panelMemberId === selectedPanelMember)
              .flatMap(chat => chat.messages)
              .sort((a, b) => new Date(a.timestamp) - new Date(b.timestamp))
              .map((message, index) => (
                <div key={index}>
                  <p>{message.content} - {new Date(message.timestamp).toLocaleString()}</p>
                </div>
              ))}
          </div>
        </div>
        <div>
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

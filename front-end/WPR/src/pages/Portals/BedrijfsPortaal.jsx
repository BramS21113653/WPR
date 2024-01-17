import React, { useState, useEffect } from 'react';
import Profile from '../../components/Profile';
import OpdrachtenBeheer from '../../components/OpdrachtenBeheer';
<<<<<<< HEAD
<<<<<<< Updated upstream
import ChatInterface from '../../components/ChatInterface';
=======
import ChatComponent from "../../components/ChatComponent"; // Aangepaste import
import { API_BASE_URL } from '../../../apiConfig';
>>>>>>> Stashed changes
=======
import ChatInterface from '../../components/ChatComponent';
>>>>>>> main

const BedrijfsPortaal = () => {
  const [researches, setResearches] = useState([]);
  const [selectedResearch, setSelectedResearch] = useState(null);
  const [showChat, setShowChat] = useState(false);

  useEffect(() => {
    // Aanname: Je hebt een endpoint om onderzoeksopdrachten op te halen
    const fetchResearches = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/research`);
        if (!response.ok) {
          throw new Error('Failed to fetch researches');
        }
        const data = await response.json();
        setResearches(data);
      } catch (error) {
        console.error('Error fetching researches:', error);
      }
    };

    fetchResearches();
  }, []);

  const handleSelectResearch = (researchId) => {
    const selected = researches.find(r => r.id === researchId);
    setSelectedResearch(selected);
    setShowChat(true);
  };

  const handleCloseChat = () => {
    setShowChat(false);
    setSelectedResearch(null);
  };

  return (
    <div className="main-content">
      <h1>Bedrijfsportaal</h1>
      <Profile title="Bedrijfsprofiel" />
<<<<<<< Updated upstream
      <OpdrachtenBeheer title="Beheer Onderzoeksopdrachten" />
<<<<<<< HEAD
      <ChatInterface title="Chat met Deelnemers en Accessibility" />
=======
      <OpdrachtenBeheer 
        title="Beheer Onderzoeksopdrachten" 
        researches={researches}
        onSelectResearch={handleSelectResearch}
      />
      {showChat && selectedResearch && (
        <ChatComponent
          researchId={selectedResearch.id}
          handleClose={handleCloseChat}
        />
      )}
>>>>>>> Stashed changes
=======
>>>>>>> main
    </div>
  );
};

export default BedrijfsPortaal;

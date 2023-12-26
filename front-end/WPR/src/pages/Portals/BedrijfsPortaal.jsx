import React from 'react';
import Profile from '../../components/Profile';
import OpdrachtenBeheer from '../../components/OpdrachtenBeheer';
import ChatInterface from '../../components/ChatInterface';

const BedrijfsPortaal = () => {
  return (
    <div className="main-content">
      <h1>Bedrijfsportaal</h1>
      <Profile title="Bedrijfsprofiel" />
      <OpdrachtenBeheer title="Beheer Onderzoeksopdrachten" />
      <ChatInterface title="Chat met Deelnemers en Accessibility" />
    </div>
  );
};

export default BedrijfsPortaal;

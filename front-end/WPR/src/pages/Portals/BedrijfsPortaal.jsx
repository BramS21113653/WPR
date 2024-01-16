import React from 'react';
import Profile from '../../components/Profile';
import OpdrachtenBeheer from '../../components/OpdrachtenBeheer';
import ChatInterface from '../../components/ChatComponent';

const BedrijfsPortaal = () => {
  return (
    <div className="main-content">
      <h1>Bedrijfsportaal</h1>
      <Profile title="Bedrijfsprofiel" />
      <OpdrachtenBeheer title="Beheer Onderzoeksopdrachten" />
    </div>
  );
};

export default BedrijfsPortaal;

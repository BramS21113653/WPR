import React from 'react';
import BedrijfsProfile from '../../components/BedrijfsProfile';
import OpdrachtenBeheer from '../../components/OpdrachtenBeheer';
import ChatInterface from '../../components/ChatComponent';

const BedrijfsPortaal = () => {
  return (
    <div className="main-content">
      <h1>Bedrijfsportaal</h1>
      <BedrijfsProfile title="Bedrijfsprofiel" />
      {/* <OpdrachtenBeheer title="Beheer Onderzoeksopdrachten" /> */}

      {/* todo 
      post research
      chatfunctie businessuser */}
    </div>
  );
};

export default BedrijfsPortaal;

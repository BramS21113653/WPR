import React from 'react';
import GebruikersBeheer from '../../components/GebruikersBeheer';
import OnderzoekenBeheer from '../../components/OnderzoekenBeheer';
import ChatInterface from '../../components/ChatComponent';

const BeheerdersPortal = () => {
  return (
    <div className="main-content">
      <h1>Beheerdersportaal</h1>
      <GebruikersBeheer />
      <OnderzoekenBeheer />
    </div>
  );
};

export default BeheerdersPortal;

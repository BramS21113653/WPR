import React from 'react';
import GebruikersBeheer from '../../components/GebruikersBeheer';
import OnderzoekenBeheer from '../../components/OnderzoekenBeheer';
import ChatInterface from '../../components/ChatInterface';
import '../../index.scss'

const BeheerdersPortal = () => {
  return (
    <div>
      <GebruikersBeheer />
      <OnderzoekenBeheer />
      <ChatInterface />
    </div>
  );
};

export default BeheerdersPortal;

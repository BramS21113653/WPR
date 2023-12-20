import React from 'react';
import Profile from '../../components/Profile';
import OpdrachtenBeheer from '../../components/OpdrachtenBeheer';
import ChatInterface from '../../components/ChatInterface';

const BedrijfsPortaal = () => {
  return (
    <div className="main-content">
      <Profile />
      <OpdrachtenBeheer />
      <ChatInterface />
    </div>
  );
};

export default BedrijfsPortaal;

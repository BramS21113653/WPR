import React from 'react';
import Profile from '../../components/Profile';
import OpdrachtenBeheer from '../../components/OpdrachtenBeheer';
import ChatInterface from '../../components/ChatInterface';
import '../../index.scss'

const BedrijfsPortaal = () => {
  return (
    <div>
      <Profile />
      <OpdrachtenBeheer />
      <ChatInterface />
    </div>
  );
};

export default BedrijfsPortaal;

import React from 'react';
import ProfielComponent from '../../components/Profile';
import OnderzoekenOverzicht from '../../components/OnderzoekenOverzicht';
import ChatInterface from '../../components/ChatInterface';

const ErvaringsdeskundigenPortaal = () => {
  return (
    <div>
      <ProfielComponent />
      <OnderzoekenOverzicht />
      <ChatInterface />
    </div>
  );
};

export default ErvaringsdeskundigenPortaal;

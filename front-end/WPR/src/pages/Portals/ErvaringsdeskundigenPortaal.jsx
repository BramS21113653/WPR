import React from 'react';
import ProfielComponent from '../../components/ProfileErvaringsdeskundige';
import OnderzoekenOverzicht from '../../components/OnderzoekenOverzicht';
import ChatInterface from '../../components/ChatComponent';

const ErvaringsdeskundigenPortaal = () => {
  return (
    <div className="main-content">
      <h1>Evaringsdeskundigenportaal</h1>
      <ProfielComponent />
      {/* <OnderzoekenOverzicht /> */}
    </div>
  );
};

export default ErvaringsdeskundigenPortaal;

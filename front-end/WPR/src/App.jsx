import React, { useState, useEffect } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Navbar from './assets/navbar/Navbar';
import Footer from './assets/footer/Footer';
import Home from './pages/Home/Home';
import OverOns from './pages/OverOns';
import Nieuws from './pages/Nieuws';
import Contact from './pages/Contact';
import Portal from './pages/Portals/Portal';
import Onderzoeken from './pages/Onderzoeken';
import Registreren from './pages/registreren/Registreren';
import Inloggen from './pages/Login/Inloggen';
// Import the new components
import Hulpmiddelen from './pages/General_Pages/Hulpmiddelen';
import FAQ from './components/FAQ';
import Toegankelijkheidsfuncties from './pages/General_Pages/Toegankelijkheidsfuncties';
import Partners from './pages/General_Pages/Partners';
import ErvaringsdeskundigenPortaal from './pages/Portals/ErvaringsdeskundigenPortaal';
import BedrijfsPortaal from './pages/Portals/BedrijfsPortaal';
import BeheerdersPortaal from './pages/Portals/BeheerdersPortaal';
import './index.scss'
import ChatModal from './assets/chatmodal/ChatModal'; // Zorg ervoor dat dit het juiste pad is
import ChatButton from './assets/chat/ChatButton'
import { UserProvider } from './UserContext';


const App = () => {
  const [showChatModal, setShowChatModal] = useState(false);

  const handleChatClick = () => {
    setShowChatModal(!showChatModal); // Schakelt de zichtbaarheid van de chatmodal
  };

  return (
    <UserProvider>
    <BrowserRouter>
      <Navbar />
      <div>
        <Routes>
          {/* Routes nav links */}
          <Route path="/" element={<Home />} />
          <Route path="over-ons" element={<OverOns />} />
          <Route path="nieuws" element={<Nieuws />} />
          <Route path="contact" element={<Contact />} />
          <Route path="portal" element={<Portal />} />
          <Route path="onderzoeken" element={<Onderzoeken />} />
          <Route path="registreren" element={<Registreren />} />
          <Route path="inloggen" element={<Inloggen />} />
          {/* Add new routes for Footer links */}
          <Route path="hulpmiddelen" element={<Hulpmiddelen />} />
          <Route path="faq" element={<FAQ />} />
          <Route path="toegankelijkheidsfuncties" element={<Toegankelijkheidsfuncties />} />
          <Route path="partners" element={<Partners />} />
          {/* Routes portalen */}
          <Route path="/ervaringsdeskundigen-portal" element={<ErvaringsdeskundigenPortaal />} />
          <Route path="/bedrijfsportal" element={<BedrijfsPortaal />} />
          <Route path="/beheerdersportal" element={<BeheerdersPortaal />} />
        </Routes>
      </div>
      <Footer onChatClick={handleChatClick} />
      {showChatModal && <ChatModal onClose={() => setShowChatModal(false)} />}
      </BrowserRouter>
      </UserProvider>
  );
};

export default App;

import React, { useState, useContext } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
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
import Hulpmiddelen from './pages/General_Pages/Hulpmiddelen';
import FAQ from './components/FAQ';
import Toegankelijkheidsfuncties from './pages/General_Pages/Toegankelijkheidsfuncties';
import Partners from './pages/General_Pages/Partners';
import ErvaringsdeskundigenPortaal from './pages/Portals/ErvaringsdeskundigenPortaal';
import BedrijfsPortaal from './pages/Portals/BedrijfsPortaal';
import BeheerdersPortaal from './pages/Portals/BeheerdersPortaal';
import ChatModal from './assets/chatmodal/ChatModal';
import ChatButton from './assets/chat/ChatButton';
import { UserProvider, UserContext } from './UserContext';
import './index.scss';
import PrivateRoute from './privateroute';

const App = () => {
  const [showChatModal, setShowChatModal] = useState(false);

  const handleChatClick = () => {
    setShowChatModal(!showChatModal);
  };

  return (
    <UserProvider>
      <BrowserRouter>
        <Navbar />
        <div>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="over-ons" element={<OverOns />} />
            <Route path="nieuws" element={<Nieuws />} />
            <Route path="contact" element={<Contact />} />
            <Route path="portal" element={<Portal />} />
            <Route path="onderzoeken" element={<Onderzoeken />} />
            <Route path="registreren" element={<Registreren />} />
            <Route path="inloggen" element={<Inloggen />} />
            <Route path="hulpmiddelen" element={<Hulpmiddelen />} />
            <Route path="faq" element={<FAQ />} />
            <Route path="toegankelijkheidsfuncties" element={<Toegankelijkheidsfuncties />} />
            <Route path="partners" element={<Partners />} />
            {/* Beveiligde routes */}
            <Route path="/ervaringsdeskundigen-portal" element={
              // <PrivateRoute><ErvaringsdeskundigenPortaal /></PrivateRoute>
              <ErvaringsdeskundigenPortaal />
            } />
            <Route path="/bedrijfsportal" element={
              <PrivateRoute><BedrijfsPortaal /></PrivateRoute>
            } />
            <Route path="/beheerdersportal" element={
              <PrivateRoute><BeheerdersPortaal /></PrivateRoute>
            } />
          </Routes>
        </div>
        <Footer onChatClick={handleChatClick} />
        {showChatModal && <ChatModal onClose={() => setShowChatModal(false)} />}
      </BrowserRouter>
    </UserProvider>
  );
};

export default App;

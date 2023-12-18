import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Navbar from './assets/navbar/Navbar';
import Footer from './assets/footer/Footer';
import Home from './Home';
import OverOns from './OverOns';
import Nieuws from './Nieuws';
import Contact from './Contact';
import Portal from './Portal';
import Onderzoeken from './Onderzoeken';
import Registreren from './Registreren';
import Inloggen from './Inloggen';
// Import the new components
import Hulpmiddelen from './Hulpmiddelen';
import FAQ from './FAQ';
import Toegankelijkheidsfuncties from './Toegankelijkheidsfuncties';
import Partners from './Partners';

const App = () => {
  return (
    <BrowserRouter>
      <Navbar />
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
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default App;

import React from "react";
import './Footer.css';
import { Link } from 'react-router-dom';
import ChatButton from '../chat/ChatButton'; // Zorg ervoor dat dit pad correct is

const Footer = ({ onChatClick }) => {
    return (
        <footer>
            <ul>
                <li><Link to="/hulpmiddelen">Hulpmiddelen / Bronnen</Link></li>
                <li><Link to="/faq">FAQ / Hulp</Link></li>
                <li><Link to="/toegankelijkheidsfuncties">Toegankelijkheidsfuncties</Link></li>
                <li><Link to="/partners">Partners en Sponsoren</Link></li>
            </ul>
            <ChatButton onClick={onChatClick} />
            <p>&copy; {new Date().getFullYear()} Stichting Accessibility</p>
        </footer>
    );
};

export default Footer;

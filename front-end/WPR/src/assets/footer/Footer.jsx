import React from "react";
import './Footer.css';

const Footer = () => {
    return (
        <footer>
            <ul>
                <li><a href="/hulpmiddelen">Hulpmiddelen / Bronnen</a></li>
                <li><a href="/faq">FAQ / Hulp</a></li>
                <li><a href="/toegankelijkheidsfuncties">Toegankelijkheidsfuncties</a></li>
                <li><a href="/partners">Partners en Sponsoren</a></li>
            </ul>
            <p>&copy; {new Date().getFullYear()} Stichting Accessibility</p>
        </footer>
    );
};

export default Footer;

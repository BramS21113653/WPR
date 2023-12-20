// Navbar.jsx
import React, { useState } from "react";
import { Link } from 'react-router-dom';
import logo from '../LOGO.png'; // Adjust the path as needed
import './Navbar.scss';

const Navbar = () => {
    const [isOpen, setIsOpen] = useState(false);

    const toggleMenu = () => {
        setIsOpen(!isOpen);
    };

    return (
        <nav>
            <div className="logo">
                <Link to="/">
                    <img src={logo} alt="Logo" />
                </Link>
            </div>

            <button className="hamburger" onClick={toggleMenu}>
                {/* Icon from Font Awesome or similar library */}
                <span className="hamburger-lines"></span>
            </button>

            <ul className={isOpen ? "nav-links open" : "nav-links"}>
                <li><Link to="/" onClick={toggleMenu}>Home</Link></li>
                <li><Link to="/over-ons" onClick={toggleMenu}>Over Ons</Link></li>
                <li><Link to="/nieuws" onClick={toggleMenu}>Nieuws</Link></li>
                <li><Link to="/contact" onClick={toggleMenu}>Contact</Link></li>
                <li><Link to="/portal" onClick={toggleMenu}>portal</Link></li>
                <li><Link to="/onderzoeke" onClick={toggleMenu}>onderzoeke</Link></li>
                <li><Link to="/inloggen" onClick={toggleMenu}>inloggen</Link></li>
                <li><Link to="/registreren" onClick={toggleMenu}>registreren</Link></li>
            </ul>
        </nav>
    );
};

export default Navbar;


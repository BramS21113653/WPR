import React from "react";
import logo from '../LOGO.png'; // Adjusted path going one directory up then to assets
import './Navbar.css';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav>
            <div className="logo">
                <a href="/">
                    <img src={logo} alt="Logo" />
                </a>
            </div>

            <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/over-ons">Over Ons</Link></li>
            <li><Link to="/nieuws">Nieuws</Link></li>
            <li><Link to="/contact">Contact</Link></li>
            <li><Link to="/portal">Portal</Link></li>
            <li><Link to="/onderzoeken">Onderzoeken</Link></li>
            <li><Link to="/inloggen">Inloggen</Link></li>
            <li><Link to="/registreren">Registreren</Link></li>
            </ul>
        </nav>
    );
};

export default Navbar;

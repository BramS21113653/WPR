import React from "react";
import logo from '../LOGO.png'; // Adjusted path going one directory up then to assets
import './Navbar.css';

const Navbar = () => {
    return (
        <nav>
            <div className="logo">
                <a href="/">
                    <img src={logo} alt="Logo" />
                </a>
            </div>

            <ul>
                <li><a href="/">Home</a></li>
                <li><a href="/over-ons">Over Ons</a></li>
                <li><a href="/nieuws">Nieuws</a></li>
                <li><a href="/contact">Contact</a></li>
                <li><a href="/portal">Portal</a></li>
                <li><a href="/onderzoeken">Onderzoeken</a></li>
                <li><a href="/signin">Inloggen</a></li>
                <li><a href="/signup">Registreren</a></li>
            </ul>
        </nav>
    );
};

export default Navbar;

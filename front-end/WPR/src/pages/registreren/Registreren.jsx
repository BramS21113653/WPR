import React, { useState } from 'react';
import './Registreren.css';
import { API_BASE_URL } from '../../../apiConfig';
import { useNavigate } from 'react-router-dom';

const Registreren = () => {
  const [formData, setFormData] = useState({
    voornaam: '',
    achternaam: '',
    email: '',
    wachtwoord: '',
    herhaalWachtwoord: '',
    userType: '',
  });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.id]: e.target.value });
  };

  const navigate = useNavigate();

  const handleLinkedInFill = () => {
    // Load the LinkedIn script and initialize the API
    const script = document.createElement("script");
    script.src = "https://platform.linkedin.com/in.js";
    script.innerHTML = `api_key: 78ljemtnficc1r
                         authorize: true
                         onLoad: onLinkedInLoad`;
    document.body.appendChild(script);

    window.onLinkedInLoad = () => {
      window.IN.User.authorize(() => {
        window.IN.API.Profile("me").fields(["firstName", "lastName", "emailAddress"]).result(profiles => {
          const profile = profiles.values[0];
          setFormData(prevData => ({
            ...prevData,
            voornaam: profile.firstName || '',
            achternaam: profile.lastName || '',
            email: profile.emailAddress || '',
          }));
        });
      });
    };
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (formData.wachtwoord !== formData.herhaalWachtwoord) {
      alert('Wachtwoorden komen niet overeen!');
      return;
    }

    try {
      const response = await fetch(`${API_BASE_URL}/ApplicationUser/register`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          Username: formData.voornaam + formData.achternaam,
          Email: formData.email,
          Password: formData.wachtwoord,
          FirstName: formData.voornaam,
          LastName: formData.achternaam,
          UserType: formData.userType,
        }),
      });

      if (!response.ok) {
        throw new Error('Er is iets misgegaan bij de registratie.');
      }
      
      alert('Registratie succesvol!');
      navigate('/inloggen'); // Redirect to login page
    } catch (error) {
      alert(error.message);
    }
  };

  return (
    <div className="registreren main-content">
      <h1>Registreren</h1>
      <form onSubmit={handleSubmit}>
        <div className="linkedin-autofill">
          <button type="button" onClick={handleLinkedInFill}>Vul in met LinkedIn</button>
          <p>coming soon...</p>
        </div>

        <div className="form-body">
          <div className="voornaam">
            <label className="form__label" htmlFor="voornaam">Voornaam </label>
            <input className="form__input" type="text" id="voornaam" placeholder="Voornaam" onChange={handleChange} value={formData.voornaam} />
          </div>
          <div className="achternaam">
            <label className="form__label" htmlFor="achternaam">Achternaam </label>
            <input type="text" id="achternaam" className="form__input" placeholder="Achternaam" onChange={handleChange} value={formData.achternaam} />
          </div>
          <div className="email">
            <label className="form__label" htmlFor="email">Email </label>
            <input type="email" id="email" className="form__input" placeholder="Email" onChange={handleChange} value={formData.email} />
          </div>
          <div className="wachtwoord">
            <label className="form__label" htmlFor="wachtwoord">Wachtwoord </label>
            <input className="form__input" type="password" id="wachtwoord" placeholder="Wachtwoord" onChange={handleChange} value={formData.wachtwoord} />
          </div>
          <div className="herhaal-wachtwoord">
            <label className="form__label" htmlFor="herhaalWachtwoord">Herhaal wachtwoord </label>
            <input className="form__input" type="password" id="herhaalWachtwoord" placeholder="Herhaal Wachtwoord" onChange={handleChange} value={formData.herhaalWachtwoord} />
          <div className="user-type">
            <label htmlFor="userType">Gebruikerstype:</label>
            <select id="userType" value={formData.userType} onChange={handleChange} className="form__input">
              <option value="">Kies een type</option>
              <option value="PanelMember">PanelMember</option>
              <option value="BusinessUser">BusinessUser</option>
              <option value="Administrator">Administrator</option>
            </select>
          </div>
        </div>
      </div>
        <div className="footer">
          <button type="submit" className="btn">Registreer</button>
        </div>
      </form>
    </div>
  );
};

export default Registreren;

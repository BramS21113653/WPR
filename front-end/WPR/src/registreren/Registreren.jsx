import React, { useState } from 'react';
import './Registreren.css';

const Registreren = () => {
  // State to hold form data
  const [formData, setFormData] = useState({
    voornaam: '',
    achternaam: '',
    email: '',
    wachtwoord: '',
    herhaalWachtwoord: '',
  });

  // Update form data on input change
  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.id]: e.target.value });
  };

  // LinkedIn AutoFill functionality
  const handleLinkedInFill = () => {
    // Load the LinkedIn script and initialize the API
    const script = document.createElement("script");
    script.src = "https://platform.linkedin.com/in.js";
    script.innerHTML = `api_key: 78ljemtnficc1r
                         authorize: true
                         onLoad: onLinkedInLoad`;
    document.body.appendChild(script);

    // Define the callback function for when LinkedIn is loaded
    window.onLinkedInLoad = () => {
      window.IN.User.authorize(() => {
        window.IN.API.Profile("me").fields(["firstName", "lastName", "emailAddress"]).result(profiles => {
          const profile = profiles.values[0];
          setFormData({
            ...formData,
            voornaam: profile.firstName || '',
            achternaam: profile.lastName || '',
            email: profile.emailAddress || '',
          });
        });
      });
    };
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();

    if (formData.wachtwoord !== formData.herhaalWachtwoord) {
      alert('Wachtwoorden komen niet overeen!');
      return;
    }

    try {
      const response = await fetch('https://localhost:5001/ApplicationUser/register', {
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
        }),
      });

      if (!response.ok) {
        throw new Error('Er is iets misgegaan bij de registratie.');
      }

      alert('Registratie succesvol!');
      // Further actions on successful registration like redirecting to a login page
    } catch (error) {
      alert(error.message);
    }
  };

  return (
    <div className="registreren">
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
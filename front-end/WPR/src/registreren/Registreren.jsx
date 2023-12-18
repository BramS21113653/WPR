import React from 'react';
import './Registreren.css';

const Registreren = () => {
  return (
    <div className="registreren">
      <h1>Registreren</h1>
      <form>
      <div className="form-body">
        <div className="voornaam">
          <label className="form__label" for="firstName">Voornaam </label>
          <input className="form__input" type="text" id="voornaam" placeholder="Voornaam"/>
        </div>
        <div className="achternaam">
          <label className="form__label" for="lastName">Achternaam </label>
          <input type="text" id="achternaam" className="form__input" placeholder="Achternaam"/>
        </div>
        <div className="email">
          <label className="form__label" for="email">Email </label>
          <input type="email" id="email" className="form__input" placeholder="Email"/>
        </div>
        <div className="wachtwoord">
          <label className="form__label" for="password">Wachtwoord </label>
          <input className="form__input" type="password" id="wachtwoord" placeholder="Wachtwoord"/>
        </div>
        <div className="herhaal-wachtwoord">
          <label className="form__label" for="herhaalWachtwoord">Herhaal wachtwoord </label>
          <input className="form__input" type="wachtwoord" id="herhaalWachtwoord" placeholder="Herhaal Wachtwoord"/>
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


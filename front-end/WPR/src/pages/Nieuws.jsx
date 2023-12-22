import React from 'react';

const Nieuws = () => {
  return (
    <div className="main-content">
      <h1>Nieuws</h1>
      <p>
        Hier vind je het laatste nieuws van Stichting Accessibility over toegankelijkheid en inclusie. 
        Je vindt informatie over onze projecten, samenwerkingsverbanden, onderzoek en innovatie, beleid 
        en wet- en regelgeving.
      </p>

      <div className="nieuwsbrief-inschrijven">
        <h2>Schrijf je in voor onze nieuwsbrief</h2>
        <form>
          <label htmlFor="email">E-mail:</label>
          <input type="email" id="email" name="email" placeholder="Jouw e-mailadres" />
          <button type="submit">Inschrijven</button>
        </form>
      </div>
    </div>
  );
};

export default Nieuws;


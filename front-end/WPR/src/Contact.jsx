import React from 'react';

const Contact = () => {
  return (
    <div className="main-content">
      <h1>Contactgegevens</h1>
      <p>Stichting Accessibility is gevestigd in het bedrijfsverzamelgebouw de Krammstate op een paar minuten lopen van Station Utrecht Overvecht.</p>

      <h2>Bezoek- en postadres:</h2>
      <address>
        Christiaan Krammlaan 2<br />
        3571 AX Utrecht
      </address>

      <p>Mocht je met de trein en bus komen dan kun je <a href="route-link">hier</a> de uitgebreide routebeschrijving raadplegen.</p>

      <p>Algemene informatie over de toegankelijkheid, rolstoelvriendelijkheid en het meebrengen van geleidehonden staat op onze <a href="accessibility-info-link">pagina over de toegankelijkheid van ons kantoor</a>.</p>

      <h2>Contactgegevens:</h2>
      <p>Tel. <a href="tel:+31302398270">+31 30 239 82 70</a><br />
      E-mail: <a href="mailto:info@accessibility.nl">info@accessibility.nl</a></p>
    </div>
  );
};

export default Contact;


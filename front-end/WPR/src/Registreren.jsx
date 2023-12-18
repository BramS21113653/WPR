import React from 'react';

const Registreren = () => {
  return (
    <div className="main-content">
      <h1>Registreren</h1>
      <form>
      <div className="form-body">
        <div className="username">
          <label className="form__label" for="firstName">First Name </label>
          <input className="form__input" type="text" id="firstName" placeholder="First Name"/>
        </div>
        <div className="lastname">
          <label className="form__label" for="lastName">Last Name </label>
          <input type="text" id="lastName" className="form__input" placeholder="Last Name"/>
        </div>
        <div className="email">
          <label className="form__label" for="email">Email </label>
          <input type="email" id="email" className="form__input" placeholder="Email"/>
        </div>
        <div className="password">
          <label className="form__label" for="password">Password </label>
          <input className="form__input" type="password" id="password" placeholder="Password"/>
        </div>
        <div className="confirm-password">
          <label className="form__label" for="confirmPassword">Confirm Password </label>
          <input className="form__input" type="password" id="confirmPassword" placeholder="Confirm Password"/>
        </div>
      </div>
      <div className="footer">
        <button type="submit" className="btn">Register</button>
      </div>
    </form>    
    </div>
  );
};

export default Registreren;


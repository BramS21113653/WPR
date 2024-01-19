import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import Inloggen from './Inloggen';
import { UserContext } from '../../UserContext';

describe('<Inloggen />', () => {
  let setUser;

  beforeEach(() => {
    setUser = cy.stub();
    cy.intercept('POST', '**/ApplicationUser/authenticate', (req) => {
      if (req.body.Username === 'RemcoLangemaire' && req.body.Password === 'Hallo123!') {
        req.reply({ token: 'fakeToken', user: { id: '123' } });
      } else {
        req.reply(401, { message: 'Inloggen mislukt.' });
      }
    });

    cy.mount(
      <Router>
        <UserContext.Provider value={{ setUser }}>
          <Inloggen />
        </UserContext.Provider>
      </Router>
    );
  });

  it('renders the login form', () => {
    cy.get('h1').should('contain', 'Inloggen');
    cy.get('input[type="text"]').should('exist');
    cy.get('input[type="password"]').should('exist');
    cy.get('button').should('contain', 'Inloggen');
  });

  it('successfully logs in with correct credentials', () => {
    cy.get('input[type="text"]').type('RemcoLangemaire');
    cy.get('input[type="password"]').type('Hallo123!');
    cy.get('form').submit();

    // Check if setUser was called with the correct arguments
    cy.wrap(setUser).should('have.been.calledWith', { isLoggedIn: true, userInfo: { id: '123' } });

    // Check for navigation to home page (assuming '/')
    cy.url().should('eq', Cypress.config().baseUrl + '/');
  });

  it('shows error message on failed login attempt', () => {
    cy.get('input[type="text"]').type('wrongUsername');
    cy.get('input[type="password"]').type('wrongPassword');
    cy.get('form').submit();

    // Check for the error alert
    cy.on('window:alert', (text) => {
      expect(text).to.contains('Inloggen mislukt.');
    });
  });

  // Additional tests for form validation can be added here
});

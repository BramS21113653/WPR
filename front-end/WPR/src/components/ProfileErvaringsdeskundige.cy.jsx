import React from 'react';
import ProfileErvaringsdeskundige from './ProfileErvaringsdeskundige';
import { API_BASE_URL } from './../../apiConfig';

describe('<ProfileErvaringsdeskundige />', () => {
  beforeEach(() => {
    // Mocking the API response for fetching profile data
    cy.intercept('GET', `${API_BASE_URL}/PanelMember/profile`, {
      statusCode: 200,
      body: {
        id: '1',
        voornaam: 'Jan',
        achternaam: 'Jansen',
        // ... other fields with mock data
      },
    }).as('getProfileData');

    // Mocking the API response for fetching research data
    cy.intercept('GET', `${API_BASE_URL}/Research`, {
      statusCode: 200,
      body: [
        { id: 'r1', title: 'Research 1' },
        { id: 'r2', title: 'Research 2' },
      ],
    }).as('getResearches');

    // Mount the component before each test
    cy.mount(<ProfileErvaringsdeskundige />);
  });

  it('renders the component with mocked data', () => {
    cy.wait('@getProfileData');
    cy.wait('@getResearches');

    // Check if initial data is rendered
    cy.get('input[name="voornaam"]').should('have.value', 'Jan');
    cy.get('input[name="achternaam"]').should('have.value', 'Jansen');
    // ... other assertions for initial data
  });

  it('updates profile data', () => {
    // Example of interacting with the form
    cy.get('input[name="voornaam"]').clear().type('Piet');
    cy.get('input[name="achternaam"]').clear().type('Pietersen');
    // ... other interactions

    // Mock the update API response if needed
    // cy.intercept('PUT', `${API_BASE_URL}/PanelMember/1`, { statusCode: 200 }).as('updateProfile');

    // Submit the form
    cy.get('form').submit();

    // Check for successful update
    // cy.wait('@updateProfile');
    // ... additional assertions
  });

  it('handles profile delete action', () => {
    // Mock delete API response
    // cy.intercept('DELETE', `${API_BASE_URL}/PanelMember/1`, { statusCode: 200 }).as('deleteProfile');

    // Trigger the delete action
    cy.get('button').contains('Verwijderen').click();

    // Assert profile delete behavior
    // cy.wait('@deleteProfile');
    // ... additional assertions
  });

  it('interacts with researches and opens chat', () => {
    // Ensure researches are loaded
    cy.get('div').contains('Beschikbare Onderzoeken').should('exist');

    // Interact with like and unlike buttons
    cy.get('button').contains('Like').first().click();
    cy.get('button').contains('Unlike').first().click();

    // Open chat and check if it's visible
    cy.get('button').contains('Chat').first().click();
    cy.get('div').contains('Sluit Chat').should('exist');
  });

  // ... Add more tests as needed
});

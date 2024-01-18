// profileErvaringsdeskundige_spec.js

describe('Profile Ervaringsdeskundige Component', () => {
    beforeEach(() => {
      // Setup code here. You can set up mock API responses if needed.
      cy.visit('../WPR/src/components/ProfileErvaringsdeskundige.jsx'); // Adjust the URL to your component's URL
    });
  
    it('loads the initial profile data correctly', () => {
      // Test if the initial data is loaded correctly
      // You might need to mock the API response
      cy.get('input[name="voornaam"]').should('have.value', '');
      // Add similar checks for other fields
    });
  
    it('updates profile data', () => {
      // Fill the form
      cy.get('input[name="voornaam"]').type('Jan');
      cy.get('input[name="achternaam"]').type('Jansen');
      // Fill other fields similarly
  
      // Submit the form
      cy.get('form').submit();
  
      // Add your assertions here
      // For example, checking if a success message is displayed
    });
  
    it('handles profile delete action', () => {
      // Trigger the delete action
      cy.get('button').contains('Verwijderen').click();
  
      // Assert that the profile is deleted
      // This might depend on how your app responds to a delete action
    });
  
    it('interacts with researches', () => {
      // Check if researches are loaded
      cy.get('div').contains('Beschikbare Onderzoeken').should('exist');
  
      // Interact with like and unlike buttons
      cy.get('button').contains('Like').first().click();
      cy.get('button').contains('Unlike').first().click();
  
      // Open chat
      cy.get('button').contains('Chat').first().click();
      cy.get('div').contains('Sluit Chat').should('exist');
    });
  
    it('sends a message in the chat', () => {
      // Open chat
      cy.get('button').contains('Chat').first().click();
  
      // Type a message
      cy.get('input[type="text"]').type('Hello');
  
      // Send the message
      cy.get('button').contains('Verzend').click();
  
      // Assert the message is sent
      // This might depend on how your chat component displays messages
    });
  
    // Add more tests as needed
  });
  
  
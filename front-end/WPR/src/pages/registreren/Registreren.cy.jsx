import React from 'react'
import Registreren from './Registreren'

describe('<Registreren />', () => {
  it('renders', () => {
    // see: https://on.cypress.io/mounting-react
    cy.mount(<Registreren />)
  })
})
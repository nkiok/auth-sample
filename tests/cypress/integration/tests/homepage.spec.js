/// <reference types="Cypress" />

describe('home page', () => {
  before(() => {
    cy.visit('/');
  });

  it('should have a href to home', () => {
    cy.get('.navbar-brand')
      .contains('AuthSample')
      .should('have.attr', 'href', '/');
  });

  it('should have button to login', () => {
    cy.get('a.btn.btn-primary')
      .contains('Login')
      .should('have.attr', 'href', '/Identity/Account/Login?returnUrl=%2FIdentity%2FAccount%2FManage%2FAnalytics');
  });

  it('should have a big welcome text', () => {
    cy.get('.display-4').should('have.text', 'Welcome')
  });
});

/// <reference types="Cypress" />

describe("login page", () => {
  before(function() {
    cy.visit("/");
  });

  it("should login", function() {
    cy.get('a.btn.btn-primary')
      .contains('Login')
      .click()
    cy.get("input[id=Input_Email]")
      .first()
      .type(Cypress.env("login_email"));
    cy.get("input[id=Input_Password]")
      .first()
      .type(Cypress.env("login_password"));
    cy.get("button.btn.btn-primary")
      .contains('Login')
      .click();
    cy.get("button.btn.btn-primary")
      .first()
      .should('have.text', 'Logout');
  });

  it("should land on analytics page", function() {
    cy.url().should("contain", "Analytics");
  });

  it("should have a logout button", function() {
    cy.get("button.btn.btn-primary")
      .first()
      .should('have.text', 'Logout');
  });
});

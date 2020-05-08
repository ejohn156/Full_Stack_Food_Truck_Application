import React, { Component } from 'react';
import { Form, Input, FormGroup } from 'reactstrap';

export default class Signup extends Component {
  Signup() {
    console.log("User has created a new account user is then re-directed to login")
    this.props.changeFormType("login")
  }
  render() {
    return (
      <Form inline>
        <FormGroup>
          <Input type="email" name="email" id="emailInput" placeholder="Enter Email" value={this.props.Email} onChange={this.props.handleEmailChange}></Input>
          <Input type="password" name="password" id="passwordInput" placeholder="Enter Password" value={this.props.Password} onChange={this.props.handlePasswordChange}></Input>
          <Input type="firstName" name="firstName" id="firstNameInput" placeholder="Enter First Name" value={this.props.First_Name} onChange={this.props.handleFirstNameChange}></Input>
          <Input type="lastName" name="lastName" id="lastNameInput" placeholder="Enter Last Name" value={this.props.Last_Name} onChange={this.props.handleLastNameChange}></Input>
        </FormGroup>
      </Form>
    );
  }
}
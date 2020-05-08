import React, { Component } from 'react';
import { Form, Input, FormGroup } from 'reactstrap';

export default class Login extends Component {

  Login() {
    console.log("Credentials will be checked and if valid user will be authorized")
    this.props.closeRegistrationForm()
  }
  render() {
    return (
      <Form inline>
        <FormGroup>
          <Input type="email" name="email" id="emailInput" placeholder="Enter Email" value={this.props.Email} onChange={this.props.handleEmailChange}></Input>
          <Input type="password" name="password" id="passwordInput" placeholder="Enter Password" value={this.props.Password} onChange={this.props.handlePasswordChange}></Input>
        </FormGroup>
      </Form>
    );
  }
}
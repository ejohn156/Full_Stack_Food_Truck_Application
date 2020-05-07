import React, { Component } from 'react';
import LogIn from '../forms/LogIn';
import SignUp from '../forms/Signup'
import {Modal, Button}from 'react-bootstrap';

export default class RegistrationForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formType: "Login",
      FirstName: null,
      LastName:  null,
      Email: null,
      Password: null
    }
    this.changeFormType = this.changeFormType.bind(this)
  }
  changeFormType() {
    this.state.formType === "Login" ?
      this.setState({ formType: "Signup" }) : this.setState({ formType: "Login" })
  }

  
  

  render() {
    if (this.props.show) {
      return (
        <Modal show={this.props.show}>
          <Modal.Header>
            <h2>{this.state.formType}</h2>
            <Button onClick={() => this.changeFormType()}>
            {this.state.formType === "Login" ?
            "Sign-up"
            :
            "Login"
          }
            </Button>
          </Modal.Header>
          <Modal.Body>{this.state.formType === "Login" ?
            <LogIn />
            :
            <SignUp />
          }</Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={this.props.closeRegistrationForm}>
              Close
          </Button>
            <Button variant="success" onClick={this.props.submitRegistrationForm}>
              Submit
          </Button>
          </Modal.Footer>
        </Modal>
      )}
    else return null
  }
}

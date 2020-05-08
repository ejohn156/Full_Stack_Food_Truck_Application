import React, { Component } from 'react';
import LogIn from '../forms/LogIn';
import SignUp from '../forms/Signup'
import {Modal, Button}from 'react-bootstrap';


export default class RegistrationForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formType: "Login",
      First_Name: null,
      Last_Name:  null,
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
          {this.state.formType === "Login" ?
            <LogIn closeRegistrationForm={this.props.closeRegistrationForm}/>
            :
            <SignUp closeRegistrationForm={this.props.closeRegistrationForm} changeFormType={this.changeFormType}/>
            }
        </Modal>
      )}
    else return null
  }
}

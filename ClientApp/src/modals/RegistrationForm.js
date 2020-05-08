import React, { Component } from 'react';
import LogIn from '../forms/LogIn';
import SignUp from '../forms/Signup'
import {Modal, Button}from 'react-bootstrap';
import UserDb from '../util/DB/User'

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

  submitLogin(){
    UserDb.AuthenticateUser({Email: "test@test.com", Password: "testpw"})
    
    //this.setState({userRegistered : true,
      //showRegistrationForm : !this.state.showRegistrationForm})
}
submitSignUp(){
  UserDb.newUserSignUp({
    Email : "test@test.com",
    Password : "testpw",
    First_Name : "test",
    Last_Name : "test"
  })
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
            <Button variant="success" onClick={this.state.formType === 'Login' ? this.submitLogin : this.submitSignUp}>
              Submit
          </Button>
          </Modal.Footer>
        </Modal>
      )}
    else return null
  }
}

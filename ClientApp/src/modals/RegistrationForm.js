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
    this.handleFirstNameChange = this.handleFirstNameChange(this)
    this.handleLastNameChange = this.handleLastNameChange(this)
    this.handlePasswordChange = this.handlePasswordChange(this)
    this.handleEmailChange = this.handleEmailChange(this)
  }
  
  handleFirstNameChange(event){
    this.setState({First_Name : event.target.value})
  }
  handleLastNameChange(event){
    this.setState({Last_Name : event.target.value})
  }
  handlePasswordChange(event){
    this.setState({Password : event.target.value})
  }
  handleEmailChange(event){
    this.setState({Email : event.target.value})
  }
  changeFormType() {
    this.state.formType === "Login" ?
      this.setState({ formType: "Signup" }) : this.setState({ formType: "Login" })
  }

  submitLogin(){
    UserDb.AuthenticateUser({Email: this.state.Email, Password: this.state.Password})
    
    //this.setState({userRegistered : true,
      //showRegistrationForm : !this.state.showRegistrationForm})
}
submitSignUp(){
  UserDb.newUserSignUp({
    Email : this.state.Email,
    Password : this.state.Password,
    First_Name : this.state.First_Name,
    Last_Name : this.state.Last_Name
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
            <LogIn Email={this.state.Email} 
            Password={this.state.Password} 
            handleEmailChange={this.handleEmailChange} 
            handlePasswordChange={this.handlePasswordChange}/>
            :
            <SignUp Email={this.state.Email} 
            Password={this.state.Password} 
            First_Name={this.state.First_Name} 
            Last_Name={this.state.Last_Name}
            handleEmailChange={this.handleEmailChange} 
            handlePasswordChange={this.handlePasswordChange}
            handleFirstNameChange={this.handleFirstNameChange}
            handleLastNameChange={this.handleLastNameChange}/>
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

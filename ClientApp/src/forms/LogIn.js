import React, { Component } from 'react';


export default class Login extends Component{

  Login(){
    console.log("Credentials will be checked and if valid user will be authorized")
    this.props.closeRegistrationForm()
  }
  render(){
    return (
      <h4>Login Form</h4>
    );
  }
}
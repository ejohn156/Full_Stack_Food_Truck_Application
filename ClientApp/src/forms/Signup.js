import React, { Component} from 'react';


export default class Signup extends Component {
  Signup(){
    console.log("User has created a new account user is then re-directed to login")
    this.props.changeFormType("login")
  }
  render() {
    return (
      <h4>Signup Form</h4>

    );
  }
}
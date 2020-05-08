import React, { Component } from 'react';
import { Form, FormGroup, Button, Modal} from 'react-bootstrap';
import {Input} from 'reactstrap'
import UserDb from '../util/DB/User'

export default class Signup extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Email: "",
      Password: "",
      First_Name: "",
      Last_Name: ""
    }
    this.handleFirstNameChange = this.handleFirstNameChange.bind(this)
    this.handleLastNameChange = this.handleLastNameChange.bind(this)
    this.handlePasswordChange = this.handlePasswordChange.bind(this)
    this.handleEmailChange = this.handleEmailChange.bind(this)
    this.submitSignUp = this.submitSignUp.bind(this)
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
  async submitSignUp(){
    await UserDb.newUserSignUp({
      Email : this.state.Email,
      Password : this.state.Password,
      First_Name : this.state.First_Name,
      Last_Name : this.state.Last_Name
    })
    this.props.changeFormType()
  }

  render() {
    return (
      <>
      <Modal.Body>
      <Form>
        <FormGroup>
          <Input type="email" name="email" id="emailInput" placeholder="Enter Email" value={this.state.Email} onChange={this.handleEmailChange}></Input>
          <Input type="password" name="password" id="passwordInput" placeholder="Enter Password" value={this.state.Password} onChange={this.handlePasswordChange}></Input>
          <Input type="firstName" name="firstName" id="firstNameInput" placeholder="Enter First Name" value={this.state.First_Name} onChange={this.handleFirstNameChange}></Input>
          <Input type="lastName" name="lastName" id="lastNameInput" placeholder="Enter Last Name" value={this.state.Last_Name} onChange={this.handleLastNameChange}></Input>
        </FormGroup>
      </Form>
    </Modal.Body>
    <Modal.Footer>
      <Button variant="secondary" onClick={this.props.closeRegistrationForm}>
        Close
      </Button>
      <Button variant="success" onClick={this.submitSignUp}>
        Submit
      </Button>
    </Modal.Footer>
    </>
    );
  }
}
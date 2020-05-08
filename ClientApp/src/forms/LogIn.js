import React, { Component } from 'react';
import { Form, FormGroup, Modal, Button } from 'react-bootstrap';
import {Input} from 'reactstrap'
import UserDb from '../util/DB/User'

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Email: "",
      Password: ""
    }
    this.handlePasswordChange = this.handlePasswordChange.bind(this)
    this.handleEmailChange = this.handleEmailChange.bind(this)
    this.submitLogin = this.submitLogin.bind(this)
  }

  render() {
    return (
      <>
        <Modal.Body>
          <Form>
            <FormGroup>
              <Input type="email" name="email" id="emailInput" placeholder="Enter Email" onChange={this.handleEmailChange} value={this.state.Email} ></Input>
              <Input type="password" name="password" id="passwordInput" placeholder="Enter Password" onChange={this.handlePasswordChange} value={this.state.Password}></Input>
            </FormGroup>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={this.props.closeRegistrationForm}>
            Close
          </Button>
          <Button variant="success" onClick={this.submitLogin}>
            Submit
          </Button>
        </Modal.Footer>
      </>
    );
  }
  handlePasswordChange(event){
    this.setState({Password : event.target.value})
  }
  handleEmailChange(event){
    this.setState({Email : event.target.value})
  }
  async submitLogin(){
    await UserDb.AuthenticateUser({Email: this.state.Email, Password: this.state.Password})
    this.props.closeRegistrationForm()
  }
}
import React, { Component } from 'react';
import { Form, FormGroup, Button} from 'react-bootstrap';
import {Input, Label} from 'reactstrap'
import UserDb from '../util/DB/User'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { UPDATE_PROFILE } from '../Store/profile.action'
import User from '../util/DB/User';

const updateProfile = (profile) => ({ type: UPDATE_PROFILE, state: profile })


function mapDispatchToProps(dispatch) {
    return bindActionCreators({ updateProfile }, dispatch)
}

class ProfileUpdate extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Email: this.props.profile.Email,
            firstName: this.props.profile.First_Name,
            lastName: this.props.profile.Last_Name,
            password: "",
        }
        this.handleFirstNameChange = this.handleFirstNameChange.bind(this)
        this.handleLastNameChange = this.handleLastNameChange.bind(this)
        this.handleEmailChange = this.handleEmailChange.bind(this)
        this.submitprofileUpdate = this.submitprofileUpdate.bind(this)
        this.handlePasswordChange = this.handlePasswordChange.bind(this)
    }

    render() {
        return (
            <Form>
                <FormGroup>
                    <Label for="emailInput">Email:</Label><Input type="email" name="email" id="emailInput" placeholder="Enter Email" onChange={this.handleEmailChange} value={this.state.Email} ></Input>
                    <Label for="firstNameInput">First Name:</Label><Input type="firstName" name="firstName" id="firstNameInput" placeholder="Enter First Name" onChange={this.handleFirstNameChange} value={this.state.firstName}></Input>
                    <Label for="lastNameInput">Last Name:</Label><Input type="lastName" name="lastName" id="lastNameInput" placeholder="Enter Last Name" onChange={this.handleLastNameChange} value={this.state.lastName}></Input>
                    <Label for="password">Password:</Label><Input type="password" name="password" id="passwordInput" placeholder="Enter Password" onChange={this.handlePasswordChange} value={this.state.password}></Input>
                    <Button variant="success" onClick={this.submitprofileUpdate}>
                        Submit
                    </Button>
                </FormGroup>
            </Form>
         ) }
    handleFirstNameChange(event) {
        this.setState({ firstName: event.target.value })
    }
    handleLastNameChange(event) {
        this.setState({ lastName: event.target.value })
    }
    handleEmailChange(event) {
        this.setState({ Email: event.target.value })
    }
    handlePasswordChange(event) {
        this.setState({ password: event.target.value })
    }
    async submitprofileUpdate(event) {
        event.preventDefault()
        if(this.state.password.length > 0){
        await UserDb.updateUser(
            {Id : this.props.profile.Id,
            Email: this.state.Email,
            First_Name : this.state.firstName,
            Last_Name : this.state.lastName,
            Password : this.state.password}, this.props.profile.Token)
            
            console.log("user updated")
            
            this.props.toggleUpdateForm()
        }
        else {
            alert("Enter your password to make profile updates")
        }
    }
}


export default connect(null, mapDispatchToProps)(ProfileUpdate)
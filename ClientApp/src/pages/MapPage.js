import React, { Component } from 'react';
import Map from '../components/Map'
import RegistrationForm from '../modals/RegistrationForm'
export default class MapPage extends Component {
    constructor(){
        super();
        this.state = {
            showRegistrationForm: true
        }
        this.closeRegistrationForm = this.closeRegistrationForm.bind(this)
    }
    closeRegistrationForm(){
        this.setState({showRegistrationForm : !this.state.showRegistrationForm})
    }
    render() {
        return (
            <div>
                <Map></Map>
                <RegistrationForm show={this.state.showRegistrationForm} closeRegistrationForm={this.closeRegistrationForm}/>
            </div>
        )
    }
}

import React, { Component } from 'react';
import { Modal, Button } from 'react-bootstrap';
import ProfileUpdate from '../forms/ProfileUpdate'

export default class Favorites extends Component {
    constructor(props) {
        super(props);
        this.state = {
            profile: this.props.profile,
            displayUpdateForm: false
        }
        this.toggleUpdateForm = this.toggleUpdateForm.bind(this)
    }

    componentDidUpdate() {
        if (this.state.profile !== this.props.profile) {
            this.setState({
                profile: this.props.profile
            })
        }
    }

    toggleUpdateForm(){
        this.setState({
            displayUpdateForm: !this.state.displayUpdateForm
        })
    }

    render() {
        if (this.props.show) {
            return (
                <Modal show={this.props.show}>
                    <Modal.Header>
                        <h2>{this.state.formType}</h2>
                        <Button onClick={this.toggleUpdateForm}>
                        {!this.state.displayUpdateForm ? <h4>Update</h4> : <h4>Back</h4>}
                        </Button>
                    </Modal.Header>
                    <Modal.Body>
                        {!this.state.displayUpdateForm ?  <div><h3>{this.state.profile.First_Name} {this.state.profile.Last_Name}</h3>
                        <h3>{this.state.profile.Email}</h3></div> : <ProfileUpdate profile={this.state.profile} toggleUpdateForm={this.toggleUpdateForm}/>}
                       
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={this.props.toggleProfile}>
                            Close
                        </Button>
                    </Modal.Footer>
                </Modal>
            )
        }
        else return null
    }
}

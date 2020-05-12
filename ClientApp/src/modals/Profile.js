import React, { Component } from 'react';
import { Modal, Button } from 'react-bootstrap';


export default class Favorites extends Component {
    constructor(props) {
        super(props);
        this.state = {
            profile: this.props.profile
        }
    }

    componentDidUpdate(){
        if(this.state.profile !== this.props.profile){
            this.setState({
                profile: this.props.profile
            })
        }
    }

    render() {
        if (this.props.show) {
            return (
                <Modal show={this.props.show}>
                    <Modal.Header>
                        <h2>{this.state.formType}</h2>
                        <Button>
                            Update
            </Button>
                    </Modal.Header>
                    <Modal.Body>
                        <h3>{this.state.profile.First_Name} {this.state.profile.Last_Name}</h3>
                        <h3>{this.state.profile.Email}</h3>
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

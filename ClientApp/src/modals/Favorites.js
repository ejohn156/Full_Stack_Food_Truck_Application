import React, { Component } from 'react';
import {Modal, Button}from 'react-bootstrap';


export default class Favorites extends Component {
  constructor(props) {
    super(props);
    this.state = {
      favorites: this.props.Favorites
    }
  }

  componentDidUpdate(){
      console.log(this.props.favorites)
    if(this.state.favorites !== this.props.favorites){
        this.setState({
            favorites: this.props.favorites
        })
    }
}
  

  render() {
    if (this.props.show) {
      return (
        <Modal show={this.props.show}>
          <Modal.Header>
            <h2>Favorites</h2>
          </Modal.Header>
          <Modal.Body>
              <ul>
                  {this.state.favorites.map(favorite => {
                      return(<li key={favorite.id}>
                          {favorite.truck_Name}
                      </li>)
                  })}
              </ul>
          </Modal.Body>
          <Modal.Footer>
          <Button variant="secondary" onClick={this.props.toggleFavorites}>
            Close
          </Button>
        </Modal.Footer>
        </Modal>
      )}
    else return null
  }
}

import React, { Component } from 'react';
import { Container } from 'reactstrap';
{/*import { NavMenu } from '../components/NavMenu/NavMenu';*/}

export class Layout extends Component {

  render () {
    return (
      <div>
        {/*<NavMenu />*/}
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}

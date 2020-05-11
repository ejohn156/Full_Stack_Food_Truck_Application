import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler} from 'reactstrap';
import {Button} from 'react-bootstrap'
import { Link } from 'react-router-dom';
import './NavMenu.css';
import RegistrationForm from '../../modals/RegistrationForm'
import NavigationLink from '../NavigationLink/NavigationLink'
import SearchBar from '../SearchBar/SearchBar'
import { connect } from 'react-redux'

function mapStateToProps(state) {
  return ({
    profile: state.Profile
  })
}

class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      showRegistrationForm: false,
      profile: this.props.profile
    };

    this.closeRegistrationForm = this.closeRegistrationForm.bind(this)

  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  Register(){
      this.setState({
          showRegistrationForm : !this.state.showRegistrationForm,
      })
  }

    closeRegistrationForm(){
        this.setState({showRegistrationForm : !this.state.showRegistrationForm})
    }
    //temporary until store holding users info is created
    
    componentDidUpdate(){
      console.log(this.props.profile)
      if(this.state.profile !== this.props.profile){
        this.setState({
          profile: this.props.profile
        })
      }
    }

  render() {
    return (
        <div>
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Food Truck Forum</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                  {!this.state.profile.Id ? <Button variant="info" onClick={() => this.Register()}>Register</Button>
                  : 
                  <>
                  <NavigationLink linkName="Map"></NavigationLink>
                  <NavigationLink linkName="Profile"></NavigationLink>
                  </>
                  }
              </ul>
            </Collapse>
            <SearchBar/>
          </Container>
        </Navbar>
      </header>
      <RegistrationForm show={this.state.showRegistrationForm} closeRegistrationForm={this.closeRegistrationForm} submitRegistrationForm={this.submitRegistrationForm}/>
      </div>
    );
  }
}
export default connect(mapStateToProps)(NavMenu)
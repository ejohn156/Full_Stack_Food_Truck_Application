import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarToggler } from 'reactstrap';
import { Button , DropdownButton, DropdownItem} from 'react-bootstrap'
import { Link } from 'react-router-dom';
import './NavMenu.css';
import RegistrationForm from '../../modals/RegistrationForm'

import SearchBar from '../SearchBar/SearchBar'
import { connect } from 'react-redux'
import Favorites from '../../modals/Favorites/Favorites'
import Profile from '../../modals/Profile'

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
      showProfile: false,
      showFavorites: false,
      profile: this.props.profile,
    };
    this.closeRegistrationForm = this.closeRegistrationForm.bind(this)
    this.toggleFavorites = this.toggleFavorites.bind(this)
    this.toggleProfile = this.toggleProfile.bind(this)
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  Register() {
    this.setState({
      showRegistrationForm: !this.state.showRegistrationForm,
    })
  }

  closeRegistrationForm() {
    this.setState({ showRegistrationForm: !this.state.showRegistrationForm })
  }
  toggleProfile() {
    this.setState({
      showProfile: !this.state.showProfile,
    })
  }
  toggleFavorites() {
    this.setState({ showFavorites: !this.state.showFavorites })
  }

  Register() {
    this.setState({
      showRegistrationForm: !this.state.showRegistrationForm,
    })
  }

  closeRegistrationForm() {
    this.setState({ showRegistrationForm: !this.state.showRegistrationForm })
  }
  //temporary until store holding users info is created

  componentDidUpdate() {
    if (this.state.profile !== this.props.profile) {
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
              <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
              <Collapse className="d-sm-inline-flex flex-sm-row" isOpen={!this.state.collapsed} navbar>
                <ul className="navbar-nav flex-grow">
                  {!this.state.profile.Id ? <Button variant="info" onClick={() => this.Register()}>Register</Button>
                    :
                    <>
                      <DropdownButton variant="info" id="dropdown-basic-button" title="Profile">
                          <DropdownItem onClick={() => this.toggleProfile()}>Profile Info</DropdownItem>
                          <DropdownItem>Change Password</DropdownItem>
                          <DropdownItem>Delete Account</DropdownItem>
                      </DropdownButton>
                      <Button variant="info" onClick={() => this.toggleFavorites()}>Favorites</Button>
                    </>
                  }
                  <SearchBar />
                </ul>
              </Collapse>
            </Container>
          </Navbar>
        </header>
        <RegistrationForm show={this.state.showRegistrationForm} closeRegistrationForm={this.closeRegistrationForm} submitRegistrationForm={this.submitRegistrationForm} />
        <Favorites show={this.state.showFavorites} favorites={this.state.profile.Favorites} toggleFavorites={this.toggleFavorites} />
        <Profile show={this.state.showProfile} profile={this.state.profile} toggleProfile={this.toggleProfile} />
      </div>
    );
  }
}
export default connect(mapStateToProps)(NavMenu)
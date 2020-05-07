import React, { Component } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavigationLink.css'
import '../NavMenu/NavMenu.css'

var link
var linkName
export default class NavigationLink extends Component {

    componentWillUpdate(){
        link = "/" + this.props.linkName
        linkName = this.props.linkName
    }
    componentWillMount(){
        link = "/" + this.props.linkName
        linkName = this.props.linkName
    }
    render() {
        return (
            <NavItem>
                <NavLink tag={Link} className="text-dark" to={link}>{linkName}</NavLink>
            </NavItem>
        )
    }
}
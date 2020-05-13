import React, { Component } from 'react';
import { Form, Input, FormGroup, Button } from 'reactstrap';
import './SearchBar.css'
import '../NavMenu/NavMenu.css'
import yelpAPI from '../../util/API/Yelp'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { REFRESH_TRUCKS } from '../../Store/trucks/trucks.action'

const RefreshTrucks = (trucks) => ({ type: REFRESH_TRUCKS, state: trucks })


function mapDispatchToProps(dispatch) {
    return bindActionCreators({ RefreshTrucks }, dispatch)
}

class SearchBar extends Component {
    constructor(props) {
        super(props)
        this.state = {
            SearchText: "",
        }

        this.handleSearchTextChange = this.handleSearchTextChange.bind(this)
        this.handleSearchSubmit = this.handleSearchSubmit.bind(this)
    }



    async componentDidMount() {
        var trucks = await yelpAPI.searchTrucks("")
        this.props.RefreshTrucks(trucks)
    }
    render() {
        return (
            <Form inline>
                <FormGroup>
                    <Input type="Input" name="truck" id="truckSearch" placeholder="Enter Truck or Cuisine" value={this.state.SearchText} onChange={this.handleSearchTextChange}></Input>
                    <Button onClick={this.handleSearchSubmit}>Search</Button>
                </FormGroup>
            </Form>
        )
    }

    handleSearchTextChange(event) {
        this.setState({ SearchText: event.target.value })
    }

    async handleSearchSubmit(event) {
        event.preventDefault()
        var trucks = await yelpAPI.searchTrucks(this.state.SearchText)
        this.props.RefreshTrucks(trucks)
    }
}

export default connect(null,mapDispatchToProps)(SearchBar)
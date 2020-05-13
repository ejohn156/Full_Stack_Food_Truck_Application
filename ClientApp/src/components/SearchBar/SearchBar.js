import React, { Component } from 'react';
import { Form, Input, FormGroup, Button} from 'reactstrap';
import './SearchBar.css'
import '../NavMenu/NavMenu.css'
import yelpAPI from '../../util/API/Yelp'

export default class SearchBar extends Component {
    constructor(props) {
        super(props)
        this.state = {
            SearchText : "", 
    }

    this.handleSearchTextChange = this.handleSearchTextChange.bind(this)
    this.handleSearchSubmit = this.handleSearchSubmit.bind(this)
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
        this.setState({SearchText : event.target.value})
    }

    handleSearchSubmit(event){
        event.preventDefault()
        yelpAPI.searchTrucks(this.state.SearchText)
    }
}


import React, { Component } from 'react';
import Map from '../../components/Map/Map'
import { connect } from 'react-redux'
import './MapPage.css'

function mapStateToProps(state) {
    return ({
      profile: state.Profile.Profile,
      trucks: state.Trucks.Trucks
    })
  }

class MapPage extends Component {
        
    constructor(props) {
        super(props)
        this.state = {
                profile: this.props.profile
        }
    }
    componentDidUpdate() {
        if (this.props.profile !== this.state.profile) {
            this.setState({
                profile: this.props.profile,
            })
        }
        else if(this.props.trucks !== this.state.trucks){
            this.setState({
                trucks: this.props.trucks,
            })
        }
    }
    render() {
        return (
            <div>
                <Map favorites={this.state.profile.Favorites} trucks={this.state.trucks}/>
            </div>
        )
    }
}
export default connect(mapStateToProps)(MapPage)
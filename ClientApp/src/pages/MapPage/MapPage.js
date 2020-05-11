import React, { Component } from 'react';
import Map from '../../components/Map/Map'
import { connect } from 'react-redux'
import './MapPage.css'

function mapStateToProps(state) {
    return ({
      profile: state.Profile
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
                profile: this.props.profile
            })
        }
    }
    render() {
        return (
            <div>
                <Map className="Map" profile={this.state.profile}/>
            </div>
        )
    }
}
export default connect(mapStateToProps)(MapPage)
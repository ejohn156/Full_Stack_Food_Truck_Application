import React, { Component } from 'react';
import Map from '../../components/Map/Map'
import { connect } from 'react-redux'
import './MapPage.css'
import Markers from '../../util/Markers/Marker'

function mapStateToProps(state) {
    return ({
        profile: state.Profile.Profile,
        trucks: state.Trucks.Trucks,
        markers: {}
    })
}

class MapPage extends Component {

    constructor(props) {
        super(props)
        this.state = {
            profile: this.props.profile
        }
    }
    async componentDidUpdate() {
        if (this.props.profile !== this.state.profile) {
            await this.setState({
                profile: this.props.profile,
            })
            await this.setState({ markers: Markers.CreateMarkers(this.state.trucks, this.state.profile.favorites) })
        }
        else if (this.props.trucks !== this.state.trucks) {
            await this.setState({
                trucks: this.props.trucks,
            })
            await this.setState({ markers: Markers.CreateMarkers(this.state.trucks, this.state.profile.favorites) })
        }
    }
    render() {
        return (
            <div>
                <Map markers={this.state.markers}/>
            </div>
        )
    }
}
export default connect(mapStateToProps)(MapPage)